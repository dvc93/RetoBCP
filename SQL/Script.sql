
CREATE  TABLE [GENERALES].[Moneda](
	[CodigoMoneda] [VARCHAR](10) NOT NULL  ,
	[NombreMoneda] [VARCHAR](50) NULL,
	[FlagActivo] [BIT] DEFAULT 1 ,
	[AuditoriaFechaCreacion] [DATETIME] NULL
	CONSTRAINT PK_MONEDA PRIMARY KEY (CodigoMoneda )
	)

CREATE   TABLE GENERALES.TipoCambioMoneda
(  IdTipoCambio INT NOT NULL IDENTITY (1,1) ,
   MonedaOrigen  VARCHAR(10) NOT NULL ,
   MonedaDestino  VARCHAR(10) NOT NULL ,
   TipoCambio DECIMAL (18,2),
   FlagActivo   BIT NOT NULL  DEFAULT 1 ,
   AuditoriaFechaCreacion DATETIME DEFAULT GETDATE(),
   AuditoriaFechaModificacion DATETIME NULL ,
   CONSTRAINT PK_TIPOCAMBIO PRIMARY KEY (MonedaOrigen , MonedaDestino ) ,
   CONSTRAINT  FK_TIPOCAMBIOMONEDA_MONEDA_MonedaOrigen FOREIGN KEY (MonedaOrigen) REFERENCES GENERALES.Moneda(CodigoMoneda),
    CONSTRAINT FK_TIPOCAMBIOMONEDA_MONEDA_MonedaDestino FOREIGN KEY (MonedaDestino) REFERENCES GENERALES.Moneda (CodigoMoneda )
   
   )



