

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

SELECT nomeFantasia AS Clinica, NomeMedico AS Nome,email AS Email, NomeEspecialidade AS Especialidade 
FROM medico
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica 
INNER JOIN usuarios
ON usuarios.idUsuario = medico.idUsuario
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idClinica
WHERE idMedico = @ID

SELECT DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao
FROM consulta 
INNER JOIN medico 
ON consulta.idMedico = medico.idMedico 
INNER JOIN especialidade 
ON especialidade.idEspecialidade = medico.idEspecialidade 
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente 
INNER JOIN situacao 
ON consulta.idSituacao = situacao.idSituacao 
WHERE idConsulta = 6