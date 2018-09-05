create table Usuario(
					IdUsuario						int							identity(1,1),
					Nome							nvarchar(50)				not null,
					Login							nvarchar(50)				not null,
					Senha							nvarchar(50)				not null,
					DataCadasdtro					datetime					not null,
					primary key(IdUsuario),
					foreign key(IdTarefa) references Tarefa(IdTarefa),
					foreign key(IdContato) references Contato(IdContato))
					