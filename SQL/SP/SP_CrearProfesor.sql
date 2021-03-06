USE [Attendance]
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearPersona]    Script Date: 10/12/2019 7:20:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************************      
NOMBRE DEL PROGRAMA: [SP_CrearPersona] 
FECHA CREACIÓN: 11 de Octubre de 2019
DESCRIPCION: SP que permite crear una persona.
PARAMETROS DE ENTRADA:

	   @TipoIdentificacion    
	   @NumeroIdentificacion
	   @PrimerNombre	  
	   @SegundoNombre  
	   @PrimerApellido   
	   @SegundoApellido 
	   @UrlFoto           
	   @FechaNacimiento
	   @FechaIngreso
           
PARAMETROS DE SALIDA:        
	No aplica.
RESULTADO:        
	Muestra la última persona registrada. 

------------------------------------------------------------------------- */
ALTER PROCEDURE  [dbo].[SP_CrearProfesor]
	 (
	   @TipoIdentificacion		 varchar(30),
	   @NumeroIdentificacion     varchar(50),
	   @PrimerNombre			 varchar(30),
	   @SegundoNombre			 varchar(50),
	   @PrimerApellido			 varchar(50),
	   @SegundoApellido			 varchar(50),
	   @UrlFoto					 varchar(100),
	   @FechaNacimiento          date,
	   @FechaIngreso			 date

	 )
AS
BEGIN TRY
	BEGIN TRANSACTION
	
INSERT INTO [dbo].[Persona]
           ([TipoIdentificacion]
           ,[NumeroIdentificacion]
           ,[PrimerNombre]
           ,[SegundoNombre]
           ,[PrimerApellido]
           ,[SegundoApellido]
           ,[UrlFoto]
           ,[FechaNacimiento])
    VALUES (
	   @TipoIdentificacion,    
	   @NumeroIdentificacion,
	   @PrimerNombre,	  
	   @SegundoNombre,
	   @PrimerApellido,   
	   @SegundoApellido,
	   @UrlFoto,          
	   @FechaNacimiento
	  )
INSERT INTO [dbo].[Profesor]
           ([TipoIdentificacion]
           ,[NumeroIdentificacion]
           ,[FechaIngreso])
     VALUES
           (
	   @TipoIdentificacion,    
	   @NumeroIdentificacion,
       @FechaIngreso
	)
	
	SELECT 
		PR.TipoIdentificacion,
		PR.NumeroIdentificacion,
		PR.PrimerNombre,
		PR.SegundoNombre,
		PR.PrimerApellido,
		PR.SegundoApellido,
		PR.UrlFoto,
		PR.FechaNacimiento,
		PRO.FechaIngreso  
	FROM Persona AS PR
	INNER JOIN dbo.Profesor AS PRO ON
	PR.TipoIdentificacion = PRO.TipoIdentificacion
	AND PR.NumeroIdentificacion = PRO.NumeroIdentificacion

	WHERE PR.TipoIdentificacion = @TipoIdentificacion AND PR.NumeroIdentificacion =  @NumeroIdentificacion

	COMMIT
	END TRY
	BEGIN CATCH 
		ROLLBACK
		SELECT
		ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
