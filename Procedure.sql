
-----------------VALIDAMOS SI EXISTE EL PROCEDIMIENTO--------------------------------

IF (EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND name = 'persona_registrar'))
DROP PROCEDURE persona_registrar
GO
IF (EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND name = 'persona_editar'))
DROP PROCEDURE persona_editar
GO

IF (EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND name = 'persona_obtener'))
DROP PROCEDURE persona_obtener
GO

IF (EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND name = 'persona_listar'))

DROP PROCEDURE persona_listar
GO

IF (EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND name = 'persona_eliminar'))

DROP PROCEDURE persona_eliminar
GO

---------------PROCEDIMIENTO REGISTRAR --------------
CREATE PROCEDURE persona_registrar(

@Nombres VARCHAR(60),
@Apellidos VARCHAR(60),
@Identificación VARCHAR(60),
@Fecha_de_Nacimiento VARCHAR(60),
@tipo_id VARCHAR(60)
)
AS
BEGIN

INSERT INTO persona(Nombres,Apellidos,Identificación,Fecha_de_Nacimiento,tipo_id)
VALUES
(
@Nombres,
@Apellidos,
@Identificación,
@Fecha_de_Nacimiento,
@tipo_id
)
END

GO

CREATE PROCEDURE persona_editar(
@id INT,
@Nombres VARCHAR(60),
@Apellidos VARCHAR(60),
@Identificación VARCHAR(60),
@Fecha_de_Nacimiento VARCHAR(60),
@tipo_id VARCHAR(60)
)
AS
BEGIN
UPDATE P SET 
P.Nombres  = @Nombres ,
P.Apellidos = @Apellidos,
P.Identificación = @Identificación,
P.Fecha_de_Nacimiento = @Fecha_de_Nacimiento,
p.tipo_id = @tipo_id
FROM persona P 
INNER JOIN Tipo_de_identificación T
ON P.id = T.id
WHERE P.id = @id


END
GO

CREATE PROCEDURE  persona_obtener(
@id int
)
AS
BEGIN 
SELECT * FROM persona WHERE id = @id

END

GO

CREATE PROCEDURE persona_listar
AS 
BEGIN SELECT * FROM persona
END
GO

CREATE PROCEDURE persona_eliminar(@id int)
AS
BEGIN
DELETE FROM persona WHERE id = @id

END
GO
