USE SPMedGroup;
GO

INSERT INTO tiposUsuarios(NomeTipoUsuario)
VALUES					 ('Administrador')
						,('Medico')
						,('Paciente');
GO

INSERT INTO usuarios(idTipoUsuario, email, senha)
VALUES					 (2, 'ricardo.lemos@spmedicalgroup.com.br','12345' )
						,(2, 'roberto.possarle@spmedicalgroup.com.br','12345' )
						,(2, 'helena.souza@spmedicalgroup.com.br','12345' )
						,(3, 'ligia@gmail.com','12345' )
						,(3, 'alexandre@gmail.com','12345' )
						,(3, 'fernando@gmail.com','12345' )
						,(3, 'henrique@gmail.com','12345' )
						,(3, 'joao@hotmail.com','12345' )
						,(3, 'bruno@gmail.com','12345' )
						,(3, 'mariana@outlook.com','12345' )
GO

INSERT INTO paciente(idUsuario, DataNascimento, NomePaciente, CPF, RG, Telefone, Rua, Numero, CEP)
VALUES					 (4, '13/10/1983', 'Ligia', 94839859000, 435225435, 1134567654, 'Estado de Israel', 240, 04022000)
						,(5, '23/07/2001', 'Alexandre', 73556944057, 326543457, 11987656543, 'Av. Paulista', 1578, 01310200)
						,(6, '10/10/1978', 'Fernando', 16839338002, 546365253, 11972084453, 'Av. Ibirapuera', 2927,  04029200)
						,(7, '13/10/1985', 'Henrique', 14332654765, 543663625, 1134566543, 'Vitória', 120,  06402030 )
						,(8, '27/08/1975', 'João', 91305348010, 532544441, 1176566377, 'Ver. Geraldo de Camargo', 66, 09405380)
						,(9, '21/03/1972', 'Bruno', 79799299004, 545662667, 11954368769, 'Alameda dos Arapanés', 945, 04524001)
						,(10,'05/03/2018', 'Mariana', 13771913039, 545662668, NULL , 'Sao Antonio', 232, 06407140)
GO

INSERT INTO especialidade(NomeEspecialidade)
VALUES					 ('Acupuntura')
						,('Anestesiologia')
						,('Angiologia')
						,('Cardiologia')
						,('Cirurgia Cardiovascular')
						,('Cirurgia da Mão')
						,('Cirurgia do Aparelho Digestivo')
						,('Cirurgia Geral')
						,('Cirurgia Pediátrica')
						,('Cirurgia Plástica')
						,('Cirurgia Torácica')
						,('Cirurgia Vascular')
						,('Dermatologia')
						,('Radioterapia')
						,('Urologia')
						,('Pediatria')
						,('Psiquiatria')
GO


INSERT INTO clinica(cnpj, nomeFantasia, Rua, Numero, RazaoSocial)
VALUES					 ('86400902000130', 'Clinica Possarle' , 'Barão Limeira', 532, 'SP Medical Group')
GO

INSERT INTO medico(idUsuario, idClinica, idEspecialidade, NomeMedico, CRM)
VALUES					 (1, 3, 2, 'Ricardo Lemos', '54356-SP')
						,(2, 3, 17, 'Roberto Possarle', '53452-SP')
						,(3, 3, 16, 'Helena Strada', '65463-SP')
GO

INSERT INTO situacao(TipoSituacao)
VALUES					 ('Realizada')
						,('Cancelada')
						,('Agendada')
GO

INSERT INTO consulta(idSituacao, idMedico, idPaciente, DataRealizacao)
VALUES					 (1, 3, 7, '20/01/2020 15:00:00')
						,(2, 2, 2, '06/01/2020 10:00:00')
						,(1, 2, 3, '07/02/2020 11:00:00')
						,(1, 2, 2, '06/02/2018 10:00:00')
						,(2, 1, 4, '07/02/2019 11:00:00')
						,(2, 1, 4, '07/02/2019 11:00:00')













					
						 
