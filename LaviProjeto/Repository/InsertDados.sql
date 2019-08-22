
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
(1,'ESF Walter Reiter','89095-535',1)
(1,'Posto Garcia','89037-690',0),
(2,'Posto de Saúde Gasparinho Quadro','89110-975',1),
(2,'Unidade Avançada de Saúde Pocinho','89110-974',1),
(2,'Estratégia Saúde da Família Santa Terezinha','89110-974',1),
(2,'Posto de Saude Teste','89110-976',0);



