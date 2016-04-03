namespace pfa_mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auth",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 128),
                        pass = c.String(),
                        type = c.String(),
                        rememberme = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.login);
            
            CreateTable(
                "dbo.Chef_dep",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        identificateur = c.String(),
                        passe = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.classes",
                c => new
                    {
                        nom_classe = c.String(nullable: false, maxLength: 128),
                        groupe = c.String(),
                    })
                .PrimaryKey(t => t.nom_classe);
            
            CreateTable(
                "dbo.planning",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom_planning = c.String(),
                        nom_classe = c.String(maxLength: 128),
                        nomSemestre = c.String(maxLength: 128),
                        etat = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.classes", t => t.nom_classe)
                .ForeignKey("dbo.Semestre", t => t.nomSemestre)
                .Index(t => t.nom_classe)
                .Index(t => t.nomSemestre);
            
            CreateTable(
                "dbo.Sceance",
                c => new
                    {
                        id_sceance = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        start = c.String(),
                        end = c.String(),
                        background_color = c.String(),
                        border_color = c.String(),
                        url = c.String(),
                        nom_prof = c.String(maxLength: 128),
                        id = c.Int(nullable: false),
                        Semestre_nomSemestre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_sceance)
                .ForeignKey("dbo.planning", t => t.id, cascadeDelete: true)
                .ForeignKey("dbo.Professeur", t => t.nom_prof)
                .ForeignKey("dbo.Semestre", t => t.Semestre_nomSemestre)
                .Index(t => t.nom_prof)
                .Index(t => t.id)
                .Index(t => t.Semestre_nomSemestre);
            
            CreateTable(
                "dbo.Professeur",
                c => new
                    {
                        nom_prof = c.String(nullable: false, maxLength: 128),
                        prenom = c.String(),
                        numTel = c.Int(nullable: false),
                        grade = c.String(),
                        login = c.String(),
                        password = c.String(),
                        mail = c.String(),
                    })
                .PrimaryKey(t => t.nom_prof);
            
            CreateTable(
                "dbo.competence",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom_competence = c.String(),
                        prof_nom_prof = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Professeur", t => t.prof_nom_prof)
                .Index(t => t.prof_nom_prof);
            
            CreateTable(
                "dbo.Disponibilité",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        day = c.Int(nullable: false),
                        nom_prof = c.String(maxLength: 128),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Professeur", t => t.nom_prof)
                .Index(t => t.nom_prof);
            
            CreateTable(
                "dbo.type_prof",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        prof_nom_prof = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Professeur", t => t.prof_nom_prof)
                .Index(t => t.prof_nom_prof);
            
            CreateTable(
                "dbo.Semestre",
                c => new
                    {
                        nomSemestre = c.String(nullable: false, maxLength: 128),
                        matiere_nom = c.String(),
                        matiere_nom1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.nomSemestre)
                .ForeignKey("dbo.matiere", t => t.matiere_nom1)
                .Index(t => t.matiere_nom1);
            
            CreateTable(
                "dbo.matiere",
                c => new
                    {
                        nom = c.String(nullable: false, maxLength: 128),
                        chargehoraire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.nom);
            
            CreateTable(
                "dbo.Etudiant",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        matricule = c.Int(nullable: false),
                        pass = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Recrutement",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        cv_path = c.String(),
                        etat = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.planning", "nomSemestre", "dbo.Semestre");
            DropForeignKey("dbo.Sceance", "Semestre_nomSemestre", "dbo.Semestre");
            DropForeignKey("dbo.Semestre", "matiere_nom1", "dbo.matiere");
            DropForeignKey("dbo.type_prof", "prof_nom_prof", "dbo.Professeur");
            DropForeignKey("dbo.Sceance", "nom_prof", "dbo.Professeur");
            DropForeignKey("dbo.Disponibilité", "nom_prof", "dbo.Professeur");
            DropForeignKey("dbo.competence", "prof_nom_prof", "dbo.Professeur");
            DropForeignKey("dbo.Sceance", "id", "dbo.planning");
            DropForeignKey("dbo.planning", "nom_classe", "dbo.classes");
            DropIndex("dbo.Semestre", new[] { "matiere_nom1" });
            DropIndex("dbo.type_prof", new[] { "prof_nom_prof" });
            DropIndex("dbo.Disponibilité", new[] { "nom_prof" });
            DropIndex("dbo.competence", new[] { "prof_nom_prof" });
            DropIndex("dbo.Sceance", new[] { "Semestre_nomSemestre" });
            DropIndex("dbo.Sceance", new[] { "id" });
            DropIndex("dbo.Sceance", new[] { "nom_prof" });
            DropIndex("dbo.planning", new[] { "nomSemestre" });
            DropIndex("dbo.planning", new[] { "nom_classe" });
            DropTable("dbo.Recrutement");
            DropTable("dbo.Etudiant");
            DropTable("dbo.matiere");
            DropTable("dbo.Semestre");
            DropTable("dbo.type_prof");
            DropTable("dbo.Disponibilité");
            DropTable("dbo.competence");
            DropTable("dbo.Professeur");
            DropTable("dbo.Sceance");
            DropTable("dbo.planning");
            DropTable("dbo.classes");
            DropTable("dbo.Chef_dep");
            DropTable("dbo.Auth");
        }
    }
}
