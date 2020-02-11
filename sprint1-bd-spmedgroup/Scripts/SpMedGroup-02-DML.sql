-- DML SpMedGroup_Manha

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'),
	   ('Médico'),
	   ('Paciente')

INSERT INTO TipoMedico (Especialidade)
VALUES ('Acupuntura'),
	   ('Anestesiologia'),
	   ('Angiologia'),
	   ('Cardiologia'),
	   ('Cirurgia Cardiovascular'),
	   ('Cirurgia da Mão'),
	   ('Cirurgia do Aparelho Digestivo'),
	   ('Cirurgia Geral'),
	   ('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),
	   ('Cirurgia Torácica'),
	   ('Cirurgia Vascular'),
	   ('Dermatologia'),
	   ('Radioterapia'),
	   ('Urologia'),
	   ('Pediatria'),
	   ('Psiquiatria')

INSERT INTO Clinica (RazaoSocial, NomeFantasia, Endereco, Telefone)
VALUES ('SpMedicalGroup','Clinica Possarle','Av. Barão Limeira, 532, São Paulo, SP','11 95436-8769')

INSERT INTO Situacao (Tipo_Situacao)
VALUES ('Agendada'),
	   ('Realizada'),
	   ('Cancelada')

INSERT INTO Usuario (Nome, Email, Senha, Data_Nascimento,Telefone, RG, CPF, Endereco, IdTipoUsuario)
VALUES ('Carlos Eduardo','cadu12@gmail.com','cadu1243','29/03/2003','(11)99999999','1234567891','12345678910','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200',2),
	   ('Nicolas Freitas','nico12@gmail.com','nico1243','13/08/2003','(11)88888888','9876543219','10987654321','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200',3),
	   ('Ana Laura','ana12@gmail.com','ana1243','09/08/2001','(11)77777777','2135468792','20123456789','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200',3),
	   ('Administrador','admin@gmail.com','admin1243','01/01/1990','(11)55555555','3124567893','30123456789','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200',1)

INSERT INTO Paciente (Queixa, IdUsuario)
VALUES ('Dores no peito',2),
	   ('Dor na garganta',3)

INSERT INTO Medico (CRM, IdTipoMedico, IdClinica, IdUsuario)
VALUES ('2903/SP',4,1,1)

INSERT INTO Consulta (Data_Consulta, IdMedico, IdPaciente, IdSituacao)
VALUES ('13/02/2020 13:20:00',1,2,1),
	   ('14/02/2020 15:00:00',1,1,1)

SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM TipoMedico
SELECT * FROM Medico
SELECT * FROM Paciente
SELECT * FROM Situacao
SELECT * FROM Clinica
SELECT * FROM Consulta