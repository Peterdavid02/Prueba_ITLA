
IF ( NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Tipo_de_identificaci�n'))
	BEGIN
	CREATE TABLE Tipo_de_identificaci�n (
		id INT PRIMARY KEY IDENTITY(1,1),
		type VARCHAR(50) NOT NULL
	); 
	END
	ELSE PRINT('LA TABLA Tipo_de_identificaci�n YA EXISTE ')

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'persona'))
			BEGIN
				CREATE TABLE persona (
					id INT PRIMARY KEY IDENTITY(1,1),
					Nombres VARCHAR(50) NOT NULL,
					Apellidos VARCHAR(50) NOT NULL,
					Identificaci�n VARCHAR(50) NOT NULL,
					Fecha_de_Nacimiento DATE NOT NULL,
					tipo_id  int NOT NULL,
					FOREIGN KEY (tipo_id) REFERENCES Tipo_de_identificaci�n(id)
					);
					END
				ELSE PRINT('LA TABLA persona YA EXISTE ')