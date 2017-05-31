namespace _2014118187_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        ATMId = c.Int(nullable: false, identity: true),
                        DescripcionATM = c.String(),
                        RanuraDepositoId = c.Int(nullable: false),
                        TecladoId = c.Int(nullable: false),
                        DispensadorEfectivoId = c.Int(nullable: false),
                        PantallaId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                        BasedeDatosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ATMId);
            
            CreateTable(
                "dbo.Base de Datos",
                c => new
                    {
                        BasedeDatosId = c.Int(nullable: false),
                        AutentificarCuenta = c.Boolean(nullable: false),
                        ObtenerSaldoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ObtenerSaldoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debitar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acreditar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasedeDatosId)
                .ForeignKey("dbo.ATM", t => t.BasedeDatosId)
                .Index(t => t.BasedeDatosId);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        Pin = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.Int(nullable: false),
                        BaseDatosId = c.Int(nullable: false),
                        BasedeDatos_BasedeDatosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pin)
                .ForeignKey("dbo.Base de Datos", t => t.BasedeDatos_BasedeDatosId, cascadeDelete: true)
                .Index(t => t.BasedeDatos_BasedeDatosId);
            
            CreateTable(
                "dbo.Retiro",
                c => new
                    {
                        RetiroId = c.Int(nullable: false),
                        PantallaId = c.Int(nullable: false),
                        TecladoId = c.Int(nullable: false),
                        DispensadorEfectivoId = c.Int(nullable: false),
                        BasedeDatosId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RetiroId)
                .ForeignKey("dbo.Base de Datos", t => t.RetiroId)
                .ForeignKey("dbo.DispensadorEfectivo", t => t.RetiroId)
                .ForeignKey("dbo.Pantalla", t => t.RetiroId)
                .ForeignKey("dbo.Teclado", t => t.RetiroId)
                .ForeignKey("dbo.ATM", t => t.RetiroId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.DispensadorEfectivo",
                c => new
                    {
                        DispensadorEfectivoId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DispensadorEfectivoId)
                .ForeignKey("dbo.ATM", t => t.DispensadorEfectivoId)
                .Index(t => t.DispensadorEfectivoId);
            
            CreateTable(
                "dbo.Pantalla",
                c => new
                    {
                        PantallaId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PantallaId)
                .ForeignKey("dbo.ATM", t => t.PantallaId)
                .Index(t => t.PantallaId);
            
            CreateTable(
                "dbo.Teclado",
                c => new
                    {
                        TecladoId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TecladoId)
                .ForeignKey("dbo.ATM", t => t.TecladoId)
                .Index(t => t.TecladoId);
            
            CreateTable(
                "dbo.Ranura",
                c => new
                    {
                        RanuraDepositoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RanuraDepositoId)
                .ForeignKey("dbo.ATM", t => t.RanuraDepositoId)
                .Index(t => t.RanuraDepositoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teclado", "TecladoId", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.ATM");
            DropForeignKey("dbo.Ranura", "RanuraDepositoId", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "PantallaId", "dbo.ATM");
            DropForeignKey("dbo.DispensadorEfectivo", "DispensadorEfectivoId", "dbo.ATM");
            DropForeignKey("dbo.Base de Datos", "BasedeDatosId", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Teclado");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Pantalla");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.DispensadorEfectivo");
            DropForeignKey("dbo.Retiro", "RetiroId", "dbo.Base de Datos");
            DropForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos");
            DropIndex("dbo.Ranura", new[] { "RanuraDepositoId" });
            DropIndex("dbo.Teclado", new[] { "TecladoId" });
            DropIndex("dbo.Pantalla", new[] { "PantallaId" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "DispensadorEfectivoId" });
            DropIndex("dbo.Retiro", new[] { "RetiroId" });
            DropIndex("dbo.Cuenta", new[] { "BasedeDatos_BasedeDatosId" });
            DropIndex("dbo.Base de Datos", new[] { "BasedeDatosId" });
            DropTable("dbo.Ranura");
            DropTable("dbo.Teclado");
            DropTable("dbo.Pantalla");
            DropTable("dbo.DispensadorEfectivo");
            DropTable("dbo.Retiro");
            DropTable("dbo.Cuenta");
            DropTable("dbo.Base de Datos");
            DropTable("dbo.ATM");
        }
    }
}
