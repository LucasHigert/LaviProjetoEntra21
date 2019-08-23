
INSERT INTO estados (nome) VALUES
('Acre'),
('Alagoas'),
('Amazonas'),
('Amapá'),
('Bahia'),
('Ceará'),
('Distrito Federal'),
('Espírito Santo'),
('Goiás'),
( 'Maranhão'),
( 'Minas Gerais'),
( 'Mato Grosso do Sul'),
( 'Mato Grosso'),
( 'Pará'),
( 'Paraía'), 
( 'Pernambuco'),
( 'Piauí'),
( 'Paraná'),
( 'Rio de Janeiro'),
( 'Rio Grande do Norte'),
( 'Rondônia'),
( 'Roraima'),
( 'Rio Grande do Sul'),
( 'Santa Catarina'),
( 'Sergipe'),
( 'São Paulo'),
( 'Tocantins');
SELECT * FROM estados;

INSERT INTO cidades (nome, id_estado) VALUES
('Blumenau',24),
('Gaspar', 24);

INSERT INTO postos (id_cidade,nome,cep,registro_ativo) VALUES
(1,'Posto Salto do Norte','89027-031',1),
(1,'Posto Velha Centro','89046-230',1),
(1,'ESF Walter Reiter','89095-535',1),
(1,'Posto Garcia','89037-690',0),
(2,'Posto de Saúde Gasparinho Quadro','89110-975',1),
(2,'Unidade Avançada de Saúde Pocinho','89110-974',1),
(2,'Estratégia Saúde da Família Santa Terezinha','89110-974',1),
(2,'Posto de Saude Teste','89110-976',0);

INSERT INTO pacientes (id_cidade,nome,endereco,cep,idade,sexo,altura,peso,registro_ativo,cpf,rne,passaporte,telefone) VALUES
(1,'Leticia Rodriguez Garcia','Rua Anna Fischer 80','89068-022'	,35,1, 1.74,63.2,1,'963.842.780-90','V565371-S','','4798856-0458'),
(1,'Maiara Ilinoi Cardoso','Rua Noel Rosa 10','89057-420',18,1,1.50,50.2,1,'267.450.960-05','K568371-F','','4799241-5064'),
(2,'Pedro Alexandre Madeiro','Rua Curitiba 55','89012-412',42,0,1.82,82,1,'769.127.850-00','R5653971-J','',''),
(1,'Maiara Ilinoi Cardoso','Rua Noel Rosa 10','89057-420',18,1,1.50,50.2,  0   ,'267.450.960-05','K568371-F','','4799241-5064'),
(2,'Felipe Marcos Peixoto','Rua das Torres 77','89031-673',22,0,1.75,60.1,1,'126.282.070-79','','','4798822-4565');

INSERT INTO cargos (nome,registro_ativo) VALUES
('Atendente',1),
('Médico',1),
('Trigem',1),
('Médico',0);

INSERT INTO funcionarios (id_posto,id_cargo,nome,login,senha,registro_ativo) VALUES 
(1,1,'Tiffany Carlene','Tiffany Carlene','carlezinha123',1),
(1,2,'Roberto Francisco Sagaz','Roberto Sagaz','medicotop',1),
(1,3,'Vanessa Revineia','Revineia','triagemboa',1),
(1,2,'Roberto Francisco Sagaz','Roberto Sagaz','medicotop',0),

(2,1,'Josefina Carla','Josefa','amomeufilho',1),
(2,2,'Gabriel Tirone','Tirone','deusefiel',1),
(2,3,'Marilene Peixes','Marilene Peixe','olamarilene',1),
(2,3,'Vanessa Revineia','Revineia','triagemboa',0);




