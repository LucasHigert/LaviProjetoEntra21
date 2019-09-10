
INSERT INTO estados (nome, registro_ativo) VALUES
('Acre', 1),
('Alagoas', 1),
('Amazonas', 1),
('Amapá', 1),
('Bahia', 1),
('Ceará', 1),
('Distrito Federal', 1),
('Espírito Santo', 1),
('Goiás', 1),
( 'Maranhão', 1),
( 'Minas Gerais', 1),
( 'Mato Grosso do Sul', 1),
( 'Mato Grosso', 1),
( 'Pará', 1),
( 'Paraía', 1),
( 'Pernambuco', 1),
( 'Piauí', 1),
( 'Paraná', 1),
( 'Rio de Janeiro', 1),
( 'Rio Grande do Norte', 1),
( 'Rondônia', 1),
( 'Roraima', 1),
( 'Rio Grande do Sul', 1),
( 'Santa Catarina', 1),
( 'Sergipe', 1),
( 'São Paulo', 1),
( 'Tocantins', 1);
INSERT INTO cidades (nome, id_estado, registro_ativo) VALUES
('Blumenau',24, 1),
('Gaspar', 24, 1);
INSERT INTO postos (id_cidade,nome,cep,registro_ativo) VALUES
(2,'Posto Salto do Norte','89027-031',1),
(2,'Posto Velha Centro','89046-230',1),
(2,'ESF Walter Reiter','89095-535',1),
(2,'Posto Garcia','89037-690',0),
(3,'Posto de Saúde Gasparinho Quadro','89110-975',1),
(3,'Unidade Avançada de Saúde Pocinho','89110-974',1),
(3,'Estratégia Saúde da Família Santa Terezinha','89110-974',1),
(3,'Posto de Saude Teste','89110-976',0);
INSERT INTO pacientes (id_posto,nome,endereco,cep,idade,sexo,altura,peso,registro_ativo,cpf,rne,passaporte,telefone) VALUES
(2,'Leticia Rodriguez Garcia','Rua Anna Fischer 80','89068-022'	,35,1, 1.74,63.2,1,'963.842.780-90','V565371-S','','4798856-0458'),
(2,'Maiara Ilinoi Cardoso','Rua Noel Rosa 10','89057-420',18,1,1.50,50.2,1,'267.450.960-05','K568371-F','','4799241-5064'),
(3,'Pedro Alexandre Madeiro','Rua Curitiba 55','89012-412',42,0,1.82,82,1,'769.127.850-00','R5653971-J','',''),
(2,'Maiara Ilinoi Cardoso','Rua Noel Rosa 10','89057-420',18,1,1.50,50.2,  0   ,'267.450.960-05','K568371-F','','4799241-5064'),
(3,'Felipe Marcos Peixoto','Rua das Torres 77','89031-673',22,0,1.75,60.1,1,'126.282.070-79','','','4798822-4565');
INSERT INTO cargos (nome,registro_ativo, nivel_permissao) VALUES
('Atendente',1,4);
('Médico',1),
('Trigem',1),
('Médico',0);
INSERT INTO funcionarios (id_posto,id_cargo,nome,login,senha,registro_ativo) VALUES 
(2,1,'Tiffany Carlene','Tiffany Carlene','carlezinha123',1),
(2,2,'Roberto Francisco Sagaz','Roberto Sagaz','medicotop',1),
(2,3,'Vanessa Revineia','Revineia','triagemboa',1),
(2,2,'Roberto Francisco Sagaz','Roberto Sagaz','medicotop',0),
(3,1,'Josefina Carla','Josefa','amomeufilho',1),
(3,2,'Gabriel Tirone','Tirone','deusefiel',1),
(3,3,'Marilene Peixes','Marilene Peixe','olamarilene',1),
(3,3,'Vanessa Revineia','Revineia','triagemboa',0);




