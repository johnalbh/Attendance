USE [Attendance]
GO
/****** Object:  Table [dbo].[Dominio]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dominio](
	[Dominio] [varchar](50) NOT NULL,
	[Valor] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Ordern] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Dominio] PRIMARY KEY CLUSTERED 
(
	[Dominio] ASC,
	[Valor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumGrupo] [int] NOT NULL,
	[IdMateria] [int] NOT NULL,
	[TipoIdentificacionEmpleado] [varchar](30) NOT NULL,
	[NumeroIdentificacionEmpleado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoHorario]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoHorario](
	[IdGrupo] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[Asistencia] [bit] NOT NULL,
 CONSTRAINT [PK_GrupoHorario] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [int] NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFin] [time](7) NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametro]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametro](
	[Codigo] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Valor] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[TipoIdentificacion] [varchar](30) NOT NULL,
	[NumeroIdentificacion] [varchar](50) NOT NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[UrlFoto] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[TipoIdentificacion] ASC,
	[NumeroIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 10/12/2019 3:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[TipoIdentificacion] [varchar](30) NOT NULL,
	[NumeroIdentificacion] [varchar](50) NOT NULL,
	[FechaIngreso] [date] NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[TipoIdentificacion] ASC,
	[NumeroIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Materia] FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Materia]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Profesor] FOREIGN KEY([TipoIdentificacionEmpleado], [NumeroIdentificacionEmpleado])
REFERENCES [dbo].[Profesor] ([TipoIdentificacion], [NumeroIdentificacion])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Profesor]
GO
ALTER TABLE [dbo].[GrupoHorario]  WITH CHECK ADD  CONSTRAINT [FK_GrupoHorario_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([Id])
GO
ALTER TABLE [dbo].[GrupoHorario] CHECK CONSTRAINT [FK_GrupoHorario_Grupo]
GO
ALTER TABLE [dbo].[GrupoHorario]  WITH CHECK ADD  CONSTRAINT [FK_GrupoHorario_Horario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
GO
ALTER TABLE [dbo].[GrupoHorario] CHECK CONSTRAINT [FK_GrupoHorario_Horario]
GO
ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Persona] FOREIGN KEY([TipoIdentificacion], [NumeroIdentificacion])
REFERENCES [dbo].[Persona] ([TipoIdentificacion], [NumeroIdentificacion])
GO
ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Persona]
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearPersona]    Script Date: 10/12/2019 3:02:29 PM ******/
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
           
PARAMETROS DE SALIDA:        
	No aplica.
RESULTADO:        
	Muestra la última persona registrada. 

------------------------------------------------------------------------- */
CREATE PROCEDURE  [dbo].[SP_CrearPersona]
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






 
GO
