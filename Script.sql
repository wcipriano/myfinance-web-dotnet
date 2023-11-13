 
CREATE DATABASE myfinance;

use myfinance;

drop table dbo.transacao;
drop table dbo.planoconta;

CREATE TABLE dbo.planoconta (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	descricao varchar(100) NOT NULL,
	tipo char(1) NOT NULL
);


CREATE TABLE dbo.transacao (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	planocontaid int NOT NULL FOREIGN KEY REFERENCES planoconta(id),
	descricao varchar(200) NOT NULL,
	valor float NOT NULL,
	data DATETIME NULL DEFAULT GETDATE()
);


INSERT INTO planoconta (descricao, tipo) values ('Alimentação', 'D');
INSERT INTO planoconta (descricao, tipo) values ('Aluguel', 'D');
INSERT INTO planoconta (descricao, tipo) values ('Combustível', 'D');
INSERT INTO planoconta (descricao, tipo) values ('Plano de saúde', 'D');

INSERT INTO planoconta (descricao, tipo) values ('Salário', 'R');
INSERT INTO planoconta (descricao, tipo) values ('Juros capital próprio', 'R');
INSERT INTO planoconta (descricao, tipo) values ('Dividendos', 'R');


select * from dbo.planoconta;
INSERT INTO transacao (descricao, valor, planocontaid) values ('Almoço de domingo', 49.80, 1);
select * from dbo.transacao;

