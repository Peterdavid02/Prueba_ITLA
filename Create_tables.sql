
IF ( NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Tipo_de_identificación'))
	BEGIN
	CREATE TABLE Tipo_de_identificación (
		id INT PRIMARY KEY IDENTITY(1,1),
		type VARCHAR(50) NOT NULL
	); 
	
	INSERT INTO Tipo_de_identificación (type)
 	  VALUES ('Cedula');
 	INSERT INTO Tipo_de_identificación (type)
	  VALUES ('Passaporte');
	END
	ELSE PRINT('LA TABLA Tipo_de_identificación YA EXISTE ')

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'persona'))
			BEGIN
				CREATE TABLE persona (
					id INT PRIMARY KEY IDENTITY(1,1),
					Nombres VARCHAR(50) NOT NULL,
					Apellidos VARCHAR(50) NOT NULL,
					Identificacion VARCHAR(50) NOT NULL,
					Fecha_de_Nacimiento DATE NOT NULL,
					tipo_id  int,
					FOREIGN KEY (tipo_id) REFERENCES Tipo_de_identificación(id)
					);
					END
				ELSE PRINT('LA TABLA persona YA EXISTE ')
