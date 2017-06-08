namespace _2014118187_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.ATM");
            DropForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Base de Datos");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.DispensadorEfectivo");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Pantalla");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Teclado");
            DropIndex("dbo.Cuenta", new[] { "BasedeDatos_BasedeDatosId" });
            DropIndex("dbo.Retiro", new[] { "RetiroId" });
            DropPrimaryKey("dbo.Retiro");
            CreateTable(
                "dbo.CuentaRetiros",
                c => new
                    {
                        CuentaId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CuentaId, t.RetiroId })
                .ForeignKey("dbo.Retiro", t => t.CuentaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuenta", t => t.RetiroId, cascadeDelete: true)
                .Index(t => t.CuentaId)
                .Index(t => t.RetiroId);
            
            AlterColumn("dbo.Cuenta", "BasedeDatos_BasedeDatosId", c => c.Int());
            AlterColumn("dbo.Retiro", "RetiroId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Retiro", "RetiroId");
            CreateIndex("dbo.ATM", "RetiroId");
            CreateIndex("dbo.Base de Datos", "RetiroId");
            CreateIndex("dbo.Cuenta", "BasedeDatos_BasedeDatosId");
            CreateIndex("dbo.DispensadorEfectivo", "RetiroId");
            CreateIndex("dbo.Pantalla", "RetiroId");
            CreateIndex("dbo.Teclado", "RetiroId");
            AddForeignKey("dbo.ATM", "RetiroId", "dbo.Retiro", "RetiroId", cascadeDelete: true);
            AddForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos", "BasedeDatosId");
            AddForeignKey("dbo.Base de Datos", "RetiroId", "dbo.Retiro", "RetiroId", cascadeDelete: true);
            AddForeignKey("dbo.DispensadorEfectivo", "RetiroId", "dbo.Retiro", "RetiroId", cascadeDelete: true);
            AddForeignKey("dbo.Pantalla", "RetiroId", "dbo.Retiro", "RetiroId", cascadeDelete: true);
            AddForeignKey("dbo.Teclado", "RetiroId", "dbo.Retiro", "RetiroId", cascadeDelete: true);
            DropColumn("dbo.Cuenta", "BaseDatosId");
            DropColumn("dbo.Retiro", "PantallaId");
            DropColumn("dbo.Retiro", "TecladoId");
            DropColumn("dbo.Retiro", "DispensadorEfectivoId");
            DropColumn("dbo.Retiro", "BasedeDatosId");
            DropColumn("dbo.Retiro", "ATMId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Retiro", "ATMId", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "BasedeDatosId", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "DispensadorEfectivoId", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "TecladoId", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "PantallaId", c => c.Int(nullable: false));
            AddColumn("dbo.Cuenta", "BaseDatosId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Teclado", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Pantalla", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.DispensadorEfectivo", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Base de Datos", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos");
            DropForeignKey("dbo.ATM", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.CuentaRetiros", "RetiroId", "dbo.Cuenta");
            DropForeignKey("dbo.CuentaRetiros", "CuentaId", "dbo.Retiro");
            DropIndex("dbo.CuentaRetiros", new[] { "RetiroId" });
            DropIndex("dbo.CuentaRetiros", new[] { "CuentaId" });
            DropIndex("dbo.Teclado", new[] { "RetiroId" });
            DropIndex("dbo.Pantalla", new[] { "RetiroId" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "RetiroId" });
            DropIndex("dbo.Cuenta", new[] { "BasedeDatos_BasedeDatosId" });
            DropIndex("dbo.Base de Datos", new[] { "RetiroId" });
            DropIndex("dbo.ATM", new[] { "RetiroId" });
            DropPrimaryKey("dbo.Retiro");
            AlterColumn("dbo.Retiro", "RetiroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cuenta", "BasedeDatos_BasedeDatosId", c => c.Int(nullable: false));
            DropTable("dbo.CuentaRetiros");
            AddPrimaryKey("dbo.Retiro", "RetiroId");
            CreateIndex("dbo.Retiro", "RetiroId");
            CreateIndex("dbo.Cuenta", "BasedeDatos_BasedeDatosId");
            AddForeignKey("dbo.Retiro", "RetiroId", "dbo.Teclado", "TecladoId");
            AddForeignKey("dbo.Retiro", "RetiroId", "dbo.Pantalla", "PantallaId");
            AddForeignKey("dbo.Retiro", "RetiroId", "dbo.DispensadorEfectivo", "DispensadorEfectivoId");
            AddForeignKey("dbo.Retiro", "RetiroId", "dbo.Base de Datos", "BasedeDatosId");
            AddForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos", "BasedeDatosId", cascadeDelete: true);
            AddForeignKey("dbo.Retiro", "RetiroId", "dbo.ATM", "ATMId");
        }
    }
}
