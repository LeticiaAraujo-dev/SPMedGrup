

SELECT * FROM tiposUsuarios;
SELECT * FROM usuarios;
SELECT * FROM paciente;
SELECT * FROM especialidade;
SELECT * FROM clinica;
SELECT * FROM medico;
SELECT * FROM situacao;
SELECT * FROM consulta;

SELECT idUsuario, NomeTipoUsuario, email FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario;


SELECT DataRealizacao, NomeMedico, NomePaciente
FROM consulta C
INNER JOIN medico M
ON C.idMedico = M.idMedico 
INNER JOIN paciente P
ON C.idPaciente = P.idPaciente 
INNER JOIN situacao S
ON C.idSituacao = S.idSituacao 
WHERE idPaciente = 2