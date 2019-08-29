DROP TABLE IF EXISTS partes_corpo_sintomas,atendimentos_partes_corpo_sintomas,sintomas,partes_corpo,atendimentos,funcionarios,cargos,encaminhamentos,postos,pacientes,cidades,estados;

CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	id_estado INT, 
	FOREIGN KEY (id_estado) REFERENCES estados(id) ON DELETE CASCADE ON UPDATE CASCADE,
	registro_ativo BIT
);

CREATE TABLE pacientes(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cidade INT, 
	FOREIGN KEY (id_cidade) REFERENCES cidades(id) ON DELETE CASCADE ON UPDATE CASCADE,
	nome VARCHAR(100),
	endereco VARCHAR(100),
	cep VARCHAR(9),
	idade INT,
	sexo BIT,
	altura DECIMAL(4,2),
	peso DECIMAL(5,1),
	cpf VARCHAR(14),
	rne VARCHAR(10),
	passaporte VARCHAR(16),
	telefone VARCHAR(14),
	logradouro VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE postos(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cidade INT, 
	FOREIGN KEY (id_cidade) REFERENCES cidades(id)  ON DELETE CASCADE ON UPDATE CASCADE,
	nome VARCHAR(100),
	cep VARCHAR(9),
	registro_ativo BIT
);

CREATE TABLE cargos(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(20),
	registro_ativo BIT
);

CREATE TABLE encaminhamentos(
	id INT PRIMARY KEY IDENTITY(1,1),
	descricao VARCHAR(100),
	traducao_criolo VARCHAR(100),
	traducao_frances VARCHAR(100),
	local_encaminhamento VARCHAR(100),
	status_encaminhamento INT,
	registro_ativo BIT
);

CREATE TABLE funcionarios(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_posto INT, 
	FOREIGN KEY (id_posto) REFERENCES postos(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	id_cargo INT, 
	FOREIGN KEY (id_cargo) REFERENCES cargos(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	nome VARCHAR(100),
	login VARCHAR(100),
	senha VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE atendimentos(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_encaminhamento INT, 

	FOREIGN KEY (id_encaminhamento) REFERENCES encaminhamentos(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	id_funcionario_atendente INT, 
	FOREIGN KEY (id_funcionario_atendente)  REFERENCES funcionarios(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	id_paciente INT, 
	FOREIGN KEY (id_paciente) REFERENCES pacientes(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	id_funcionario_medico INT, 
	--FOREIGN KEY (id_funcionario_medico) REFERENCES funcionarios(id)  ON DELETE CASCADE ON UPDATE CASCADE,

	data_atendimento DATE,
	tratamento VARCHAR(100),
	prioridade INT,
	status_atendimento INT,
	observacao VARCHAR(100),
	pressao VARCHAR(7),
	registro_ativo BIT
);

CREATE TABLE partes_corpo(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	traducao_criolo VARCHAR(100),
	traducao_frances VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE sintomas(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_parte_corpo INT, 
	FOREIGN KEY (id_parte_corpo) REFERENCES partes_corpo(id) ON DELETE CASCADE ON UPDATE CASCADE,
	nome VARCHAR(100),
	traducao_criolo VARCHAR(100),
	traducao_frances VARCHAR(100),
	registro_ativo BIT
);

CREATE TABLE atendimentos_partes_corpo_sintomas(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_atendimento INT,
	FOREIGN KEY (id_atendimento) REFERENCES atendimentos(id) ON DELETE CASCADE ON UPDATE CASCADE,
	id_parte_corpo INT, 
	FOREIGN KEY (id_parte_corpo) REFERENCES partes_corpo(id) ON DELETE CASCADE ON UPDATE CASCADE,
	nivel_dor INT,
	registro_ativo BIT
);

CREATE TABLE partes_corpo_sintomas(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_sintoma INT, 
	FOREIGN KEY (id_sintoma) REFERENCES sintomas(id) ON DELETE CASCADE ON UPDATE CASCADE,
	id_atendimento_parte_corpo_sintoma INT, 
	--FOREIGN KEY (id_atendimento_parte_corpo_sintoma) 
	--REFERENCES atendimentos_partes_corpo_sintomas(id) ON DELETE CASCADE ON UPDATE CASCADE,
	registro_ativo BIT
);