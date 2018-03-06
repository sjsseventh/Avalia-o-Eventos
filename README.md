# Avalia-o-Eventos
O Controle da quantidade de ingressos vendidas foi feito pelas seguintes triggers.

alter TRIGGER TG_PARTICIPANTE ON Participantes
	INSTEAD OF INSERT
	AS
	BEGIN
	SET NOCOUNT ON;

	DECLARE @IdEventoI int;
	DECLARE @NIngressosVendidosI int;
	DECLARE @NMaximoIngressosI int = 0;
	DECLARE @ContagemNIngressosVendidos int = 0;

	DECLARE @EmailI varchar(150);
	DECLARE @NomeI varchar(100);

	select	@IdEventoI = IdEvento,
			@NomeI = Nome,
			@EmailI = Email
	from INSERTED;

	select	@NMaximoIngressosI = e.NMaximoIngressos
	from Eventos as e where e.IdEvento = @IdEventoI;

	select @ContagemNIngressosVendidos = Count(*) from Participantes as p where p.IdEvento = @IdEventoI;

	 if(@ContagemNIngressosVendidos >= @NMaximoIngressosI)
	 BEGIN
		ROLLBACK
		RAISERROR ('Todos os ingressos para esse evento já foram vendidos!',16, 10)
	 END

	 else
	 BEGIN 
		INSERT INTO Participantes
     VALUES
		(@EmailI, @IdEventoI, @NomeI);

		UPDATE Eventos set	Eventos.NIngressosVendidos = @ContagemNIngressosVendidos + 1
		where eventos.IdEvento = @IdEventoI;
	 END
END


CREATE TRIGGER TG_PARTICIPANTE2 ON Participantes
	INSTEAD OF DELETE
	AS
	BEGIN
	SET NOCOUNT ON;

	DECLARE @IdEventoI int;
	DECLARE @IdParticipanteI int;
	DECLARE @NIngressosVendidosI int;
	DECLARE @NMaximoIngressosI int = 0;
	DECLARE @ContagemNIngressosVendidos int = 0;

	DECLARE @EmailI varchar(150);
	DECLARE @NomeI varchar(100);

	select	@IdEventoI = IdEvento,
			@NomeI = Nome,
			@EmailI = Email,
			@IdParticipanteI = IdParticipante
	from DELETED;

	select @ContagemNIngressosVendidos = Count(*) from Participantes as p where p.IdEvento = @IdEventoI;
	
	DELETE FROM Participantes WHERE Participantes.IdParticipante = @IdParticipanteI;

	UPDATE Eventos set	Eventos.NIngressosVendidos = @ContagemNIngressosVendidos - 1
	where eventos.IdEvento = @IdEventoI;
END
