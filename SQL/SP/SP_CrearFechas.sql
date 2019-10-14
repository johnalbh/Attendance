IF OBJECT_ID('crud_CalendarioInsert') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.crud_CalendarioInsert
END
GO
CREATE PROCEDURE dbo.SP_CrearFechas
	(
		@FechaInicio [date],
		@FechaFin [date]
	)
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION

	select 
		   @fec_inicio ,
		   @fec_fin
	;WITH FECHAS(fecha) AS (
	SELECT @fec_inicio fecha
	UNION ALL
	SELECT DATEADD(day, 1, fecha) fecha
	FROM FECHAS
	WHERE fecha < @fec_fin
	)
	INSERT INTO [dbo].[Calendario]
			   ([Fecha]
			   ,[NumeroDia])
	select fecha AS fecha, datepart(dw, fecha) AS NumeroDia from FECHAS 

	OPTION (MaxRecursion 0)
	GO

	COMMIT
GO





