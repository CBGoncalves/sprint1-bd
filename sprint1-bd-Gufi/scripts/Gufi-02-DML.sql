-- DML Gufi_Manha

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'),
	   ('Comum');
GO

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES ('C#'),
	   ('React'),
	   ('SQL');
GO

INSERT INTO Instituicao (CNPJ,NomeFantasia,Endereco)
VALUES ('11111111111111','Escola SENAI de Informática','Alameda Barão de Limeira, 538')
GO

INSERT INTO Usuario (Nome,Email,Senha,DataCadastro,Genero,IdTipousuario)
VALUES ('Adminitrador','adm@adm.com','adm123','06/02/2020','Nao Informado',1),
	   ('Carol','carol@email.com','carol123','06/02/2020','Feminino',2),
	   ('Saulol','saulo@email.com','saulo123','06/02/2020','Masculino',2);
GO

INSERT INTO Evento (NomeEvento,DataEvento,Descricao,AcessoLivre,IdInstituicao,IdTipoEvento)
VALUES ('Orientação a objetos','07/02/2020','Conceitos sobre os pilares da programação orientada a objetos',1,1,1),
	   ('Ciclo de vida','08/02/2020','Como utilizar os ciclos de vida com a biblioteca ReactJs',0,1,2),
	   ('Introdução a SQL','09/02/2020','Comandos básicos utilizando SQL Server',1,1,3);
GO

INSERT INTO Presenca (IdUsuario,IdEvento,Situacao)
VALUES (2,2,'Confirmada'),
	   (2,3,'Não Confirmada'),
	   (3,1,'Confirmada');
GO

UPDATE Usuario
SET Nome = 'Saulo'
WHERE IdUsuario = 3;



SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;


