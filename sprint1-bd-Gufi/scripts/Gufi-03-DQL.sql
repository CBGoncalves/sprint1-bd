--DQL Gufi_Manha


--LISTAR TODOS OS USUARIOS CADASTRADOS
SELECT * FROM Usuario

--LISTAR TODAS AS INSTITUIÇÕES CADASTRADAS
SELECT * FROM Instituicao

--LISTAR TODOS OS TIPOS DE EVENTOS 
SELECT * FROM TipoEvento

--LISTAR TODOS OS EVENTOS
SELECT * FROM Evento

--LISTAR APENAS OS EVENTOS QUE SÃO PUBLICOS
SELECT * FROM Evento
WHERE AcessoLivre = 1

--LISTAR TODOS OS EVENTOS QUE UM DETERMINADO USUARIO PARTICIPA
SELECT Usuario.Nome, Evento.NomeEvento, IdTipoEvento, DataEvento, AcessoLivre, Descricao, NomeFantasia FROM Presenca
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
INNER JOIN Evento ON Evento.IdEvento = Presenca.IdEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
WHERE (Usuario.Nome = 'Carol') and  (Situacao = 'Confirmada')

--EXTRAS

SELECT NomeEvento, DataEvento, NomeFantasia, (CASE WHEN AcessoLivre=1 THEN 'Publico' ELSE 'Privado' END) AS TipoAcesso FROM Evento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao;


SELECT Usuario.Nome, Evento.NomeEvento, Situacao FROM Presenca
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
INNER JOIN Evento ON Evento.IdEvento = Presenca.IdEvento
WHERE (Usuario.Nome = 'Saulo') and (Situacao = 'Confirmada')