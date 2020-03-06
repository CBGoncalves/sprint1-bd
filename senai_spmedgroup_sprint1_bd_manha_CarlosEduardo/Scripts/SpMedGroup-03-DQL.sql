--DQL SpMedGroup

--LISTAR APENAS OS CONSULTAS AGENDADAS
SELECT * FROM Consulta
WHERE IdSituacao = 1

--LISTAR TODOS AS CONSUTAS QUE UM DETERMINADO USUARIO MARCOU

SELECT * FROM Paciente
INNER JOIN Consulta ON Paciente.IdPaciente = Consulta.IdPaciente
WHERE IdUsuario = 2

--CONVERTER DATA E NASCIMENTO DO USUARIO PARA O FORMATO (MM-DD-YYYY)

SELECT COUNT(Nome) FROM Usuario; 

--RETORNA A QUANTIDADE DE MEDICOS DE UMA DETERMINADA ESPECIALIDADE

SELECT COUNT(*) FROM Medico
WHERE IdTipoMedico = 4;


--RETORNA A IDADE OU USUARIO A PARTIR DE UMA DETERMINADA STORED PROCEDURE

SELECT * FROM Usuario

CREATE PROCEDURE IdadePacientes
AS 
SELECT 
Nome,
CPF,
FORMAT (Data_Nascimento, 'mm/dd/yyyy') AS Data_Nascimento,
CONVERT(varchar,GETDATE(),1) AS [DataHoje],
DATEDIFF (YY,Data_Nascimento,GETDATE()) -
CASE 
	WHEN DATEADD(YY,DATEDIFF(YY,Data_Nascimento,GETDATE()), Data_Nascimento)
		> GETDATE() THEN 1
	ELSE 0
END AS [Idade]
FROM Usuario;
GO

EXEC IdadePacientes

