﻿create table Tarefa(
					IdTarefa				int					identity(1,1),
					Nome					nvarchar(50)		not null,
					DataEntrega				datetime			not null,
					Descricao				nvarchar(1000)		not null,
					Primary Key(IdTarefa))
