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
           
PARAMETROS DE SALIDA:        
	No aplica.
RESULTADO:        
	Muestra la última persona registrada. 

------------------------------------------------------------------------- */
ALTER PROCEDURE  [dbo].[SP_CrearPersona]
	 (
	   @TipoIdentificacion		 varchar(30),
	   @NumeroIdentificacion     varchar(50),
	   @PrimerNombre			 varchar(30),
	   @SegundoNombre			 varchar(50),
	   @PrimerApellido			 varchar(50),
	   @SegundoApellido			 varchar(50),
	   @UrlFoto					 varchar(100),
	   @FechaNacimiento          date

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


	SELECT 
		TipoIdentificacion =	@TipoIdentificacion,
		NumeroIdentificacion =  @NumeroIdentificacion,
		PrimerNombre =			@PrimerNombre,
		SegundoNombre =			@SegundoNombre,
		PrimerApellido =		@PrimerApellido,
		UrlFoto =				@SegundoApellido,
		FechaNacimiento =		@FechaNacimiento
	FROM Persona

	WHERE TipoIdentificacion = @TipoIdentificacion AND NumeroIdentificacion =  @NumeroIdentificacion

	COMMIT
	END TRY
	BEGIN CATCH 
		ROLLBACK
		SELECT
		ERROR_MESSAGE() AS ErrorMessage;
	END CATCH

	EXEC SP_CrearPersona 'CC','1022347506','ALBERTO','JOHN','HERNANDEZ','LOPEZ','1022347504.JPG','1988-04-23'


	SELECT * FROM Persona


 