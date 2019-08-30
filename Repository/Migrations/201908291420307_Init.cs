namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.atendimentos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_encaminhamento = c.Int(nullable: false),
                        id_funcionario = c.Int(nullable: false),
                        id_paciente = c.Int(nullable: false),
                        id_funcionario_medico = c.Int(nullable: false),
                        data_atendimento = c.DateTime(nullable: false),
                        tratamento = c.String(),
                        prioridade = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        observacao = c.String(),
                        pressao = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.encaminhamentos", t => t.id_encaminhamento)
                .ForeignKey("dbo.funcionarios", t => t.id_funcionario)
                .ForeignKey("dbo.funcionarios", t => t.id_funcionario_medico)
                .ForeignKey("dbo.pacientes", t => t.id_paciente)
                .Index(t => t.id_encaminhamento)
                .Index(t => t.id_funcionario)
                .Index(t => t.id_paciente)
                .Index(t => t.id_funcionario_medico);
            
            CreateTable(
                "dbo.encaminhamentos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_posto = c.Int(nullable: false),
                        descricao = c.String(),
                        traducao_criolo = c.String(),
                        traducao_frances = c.String(),
                        local = c.String(),
                        status = c.Int(nullable: false),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.postos", t => t.id_posto)
                .Index(t => t.id_posto);
            
            CreateTable(
                "dbo.postos",
                c => new
                    {
                        id_posto = c.Int(nullable: false, identity: true),
                        id_cidade = c.Int(nullable: false),
                        nome = c.String(),
                        cep = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_posto)
                .ForeignKey("dbo.cidades", t => t.id_cidade)
                .Index(t => t.id_cidade);
            
            CreateTable(
                "dbo.cidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        id_estado = c.Int(nullable: false),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.estados", t => t.id_estado)
                .Index(t => t.id_estado);
            
            CreateTable(
                "dbo.estados",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.funcionarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_posto = c.Int(nullable: false),
                        id_cargo = c.Int(nullable: false),
                        nome = c.String(),
                        login = c.String(),
                        senha = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cargos", t => t.id_cargo)
                .ForeignKey("dbo.postos", t => t.id_posto)
                .Index(t => t.id_posto)
                .Index(t => t.id_cargo);
            
            CreateTable(
                "dbo.cargos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_cidade = c.Int(nullable: false),
                        nome = c.String(),
                        cep = c.String(),
                        sexo = c.Boolean(nullable: false),
                        altura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cpf = c.String(),
                        rne = c.String(),
                        passaporte = c.String(),
                        endereco = c.String(),
                        telefone = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cidades", t => t.id_cidade)
                .Index(t => t.id_cidade);
            
            CreateTable(
                "dbo.atendimentos_partes_corpo_sintomas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_atendimento = c.Int(nullable: false),
                        id_parte_corpo = c.Int(nullable: false),
                        nivel_dor = c.Int(nullable: false),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.atendimentos", t => t.id_atendimento)
                .ForeignKey("dbo.partes_corpo", t => t.id_parte_corpo)
                .Index(t => t.id_atendimento)
                .Index(t => t.id_parte_corpo);
            
            CreateTable(
                "dbo.partes_corpo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        traducao_criolo = c.String(),
                        traducao_frances = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.partes_corpo_sintomas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_sintomas = c.Int(nullable: false),
                        id_atentimento_parte_corpo_sintoma = c.Int(nullable: false),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.atendimentos_partes_corpo_sintomas", t => t.id_atentimento_parte_corpo_sintoma)
                .ForeignKey("dbo.sintomas", t => t.id_sintomas)
                .Index(t => t.id_sintomas)
                .Index(t => t.id_atentimento_parte_corpo_sintoma);
            
            CreateTable(
                "dbo.sintomas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_parte_corpo = c.Int(nullable: false),
                        nome = c.String(),
                        traducao_criolo = c.String(),
                        traducao_frances = c.String(),
                        registro_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.partes_corpo", t => t.id_parte_corpo)
                .Index(t => t.id_parte_corpo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.partes_corpo_sintomas", "id_sintomas", "dbo.sintomas");
            DropForeignKey("dbo.sintomas", "id_parte_corpo", "dbo.partes_corpo");
            DropForeignKey("dbo.partes_corpo_sintomas", "id_atentimento_parte_corpo_sintoma", "dbo.atendimentos_partes_corpo_sintomas");
            DropForeignKey("dbo.atendimentos_partes_corpo_sintomas", "id_parte_corpo", "dbo.partes_corpo");
            DropForeignKey("dbo.atendimentos_partes_corpo_sintomas", "id_atendimento", "dbo.atendimentos");
            DropForeignKey("dbo.atendimentos", "id_paciente", "dbo.pacientes");
            DropForeignKey("dbo.pacientes", "id_cidade", "dbo.cidades");
            DropForeignKey("dbo.atendimentos", "id_funcionario_medico", "dbo.funcionarios");
            DropForeignKey("dbo.atendimentos", "id_funcionario", "dbo.funcionarios");
            DropForeignKey("dbo.funcionarios", "id_posto", "dbo.postos");
            DropForeignKey("dbo.funcionarios", "id_cargo", "dbo.cargos");
            DropForeignKey("dbo.atendimentos", "id_encaminhamento", "dbo.encaminhamentos");
            DropForeignKey("dbo.encaminhamentos", "id_posto", "dbo.postos");
            DropForeignKey("dbo.postos", "id_cidade", "dbo.cidades");
            DropForeignKey("dbo.cidades", "id_estado", "dbo.estados");
            DropIndex("dbo.sintomas", new[] { "id_parte_corpo" });
            DropIndex("dbo.partes_corpo_sintomas", new[] { "id_atentimento_parte_corpo_sintoma" });
            DropIndex("dbo.partes_corpo_sintomas", new[] { "id_sintomas" });
            DropIndex("dbo.atendimentos_partes_corpo_sintomas", new[] { "id_parte_corpo" });
            DropIndex("dbo.atendimentos_partes_corpo_sintomas", new[] { "id_atendimento" });
            DropIndex("dbo.pacientes", new[] { "id_cidade" });
            DropIndex("dbo.funcionarios", new[] { "id_cargo" });
            DropIndex("dbo.funcionarios", new[] { "id_posto" });
            DropIndex("dbo.cidades", new[] { "id_estado" });
            DropIndex("dbo.postos", new[] { "id_cidade" });
            DropIndex("dbo.encaminhamentos", new[] { "id_posto" });
            DropIndex("dbo.atendimentos", new[] { "id_funcionario_medico" });
            DropIndex("dbo.atendimentos", new[] { "id_paciente" });
            DropIndex("dbo.atendimentos", new[] { "id_funcionario" });
            DropIndex("dbo.atendimentos", new[] { "id_encaminhamento" });
            DropTable("dbo.sintomas");
            DropTable("dbo.partes_corpo_sintomas");
            DropTable("dbo.partes_corpo");
            DropTable("dbo.atendimentos_partes_corpo_sintomas");
            DropTable("dbo.pacientes");
            DropTable("dbo.cargos");
            DropTable("dbo.funcionarios");
            DropTable("dbo.estados");
            DropTable("dbo.cidades");
            DropTable("dbo.postos");
            DropTable("dbo.encaminhamentos");
            DropTable("dbo.atendimentos");
        }
    }
}
