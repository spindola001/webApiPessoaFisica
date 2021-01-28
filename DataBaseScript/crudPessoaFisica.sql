USE crudDB

IF OBJECT_ID('dbo.PessoaFisica', 'U') IS NOT NULL
DROP TABLE dbo.PessoaFisica
GO

CREATE TABLE dbo.PessoaFisica
(
	id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	nome varchar(255) NOT NULL,
	dataNascimento date NOT NULL,
	renda float NOT NULL,
	CPF varchar(11) NOT NULL
)
GO

/*INSERT INTO dbo.PessoaFisica(nome, dataNascimento, renda, CPF) 
VALUES('TESTE', '1111-11-11', 1000.00, '11122233300'),
('TESTE2', '1111-11-11', 1000.00, '11122233300'),
('TESTE3', '1111-11-11', 1000.00, '11122233300')
GO

SELECT * FROM dbo.PessoaFisica
GO*/