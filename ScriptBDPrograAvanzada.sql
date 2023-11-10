USE [ImportadoraMoyaUlate]
GO

/*Procedimiento almacenado para registrar proveedores*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarProveedorSP]
    @Nombre_Proveedor varchar(60),
    @Apellido_Proveedor varchar(70),
    @Cedula_Proveedor varchar(25),
    @Direccion_Exacta varchar(255),
    @Estado_Proveedor int,
    @Empresa bigint
AS
BEGIN
    INSERT INTO [dbo].[Proveedores] (
        [Nombre_Proveedor],
        [Apellido_Proveedor],
        [Cedula_Proveedor],
        [Direccion_Exacta],
        [Estado_Proveedor],
        [Empresa]
    )
    VALUES (
		@Nombre_Proveedor,
        @Apellido_Proveedor,
        @Cedula_Proveedor,
        @Direccion_Exacta,
        1,
        @Empresa
    );
END;
GO


/*Procedimiento almacenado para actualizar el estado de proveedor de activo a inactivo o viceversa*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarEstadoProveedorSP]
    @ID_Proveedor BIGINT
AS
BEGIN
    UPDATE Proveedores
    SET Estado_Proveedor = (CASE WHEN Estado_Proveedor = 1 THEN 0 ELSE 1 END)
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO


/*Procedimiento almacenado para actualizar la informcion del proveedor que se haya modificado/actualizado*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarProveedorSP]
    @ID_Proveedor BIGINT,
    @Nombre_Proveedor VARCHAR(255),
    @Apellido_Proveedor VARCHAR(255),
    @Cedula_Proveedor VARCHAR(15),
    @Direccion_Exacta VARCHAR(255),
    @Empresa BIGINT
AS
BEGIN
    UPDATE dbo.Proveedores
    SET
        Nombre_Proveedor = @Nombre_Proveedor,
        Apellido_Proveedor = @Apellido_Proveedor,
        Cedula_Proveedor = @Cedula_Proveedor,
        Direccion_Exacta = @Direccion_Exacta,
        Empresa = @Empresa
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO


/*Procedimiento almacenado para eliminar permanentemente un proveedor del sistema*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarProveedorSP]
    @ID_Proveedor bigint
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Proveedores WHERE ID_Proveedor = @ID_Proveedor;
END
GO







