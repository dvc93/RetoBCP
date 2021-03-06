USE [AppCambioDinero]
GO
/****** Object:  Schema [CambioMoneda]    Script Date: 10/05/2021 15:56:41 ******/
CREATE SCHEMA [CambioMoneda]
GO
/****** Object:  Schema [GENERALES]    Script Date: 10/05/2021 15:56:41 ******/
CREATE SCHEMA [GENERALES]
GO
/****** Object:  Table [GENERALES].[Moneda]    Script Date: 10/05/2021 15:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GENERALES].[Moneda](
	[CodigoMoneda] [varchar](10) NOT NULL,
	[NombreMoneda] [varchar](50) NULL,
	[FlagActivo] [bit] NULL,
	[AuditoriaFechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_MONEDA] PRIMARY KEY CLUSTERED 
(
	[CodigoMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GENERALES].[TipoCambioMoneda]    Script Date: 10/05/2021 15:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GENERALES].[TipoCambioMoneda](
	[MonedaOrigen] [varchar](10) NOT NULL,
	[MonedaDestino] [varchar](10) NOT NULL,
	[TipoCambio] [decimal](18, 3) NOT NULL,
	[FlagActivo] [bit] NOT NULL,
	[AuditoriaFechaCreacion] [datetime] NULL,
	[AuditoriaFechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_TIPOCAMBIO] PRIMARY KEY CLUSTERED 
(
	[MonedaOrigen] ASC,
	[MonedaDestino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GENERALES].[Usuario]    Script Date: 10/05/2021 15:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GENERALES].[Usuario](
	[UserName] [varchar](10) NOT NULL,
	[Correo] [varchar](30) NOT NULL,
	[Nombres] [varchar](200) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Token] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [GENERALES].[Moneda] ([CodigoMoneda], [NombreMoneda], [FlagActivo], [AuditoriaFechaCreacion]) VALUES (N'DLR', N'DOLAR', 1, CAST(N'2021-05-08T17:54:41.563' AS DateTime))
INSERT [GENERALES].[Moneda] ([CodigoMoneda], [NombreMoneda], [FlagActivo], [AuditoriaFechaCreacion]) VALUES (N'EUR', N'EURO', 1, CAST(N'2021-05-09T00:33:36.360' AS DateTime))
INSERT [GENERALES].[Moneda] ([CodigoMoneda], [NombreMoneda], [FlagActivo], [AuditoriaFechaCreacion]) VALUES (N'SOL', N'SOL', 1, CAST(N'2021-05-08T17:54:54.207' AS DateTime))
GO
INSERT [GENERALES].[TipoCambioMoneda] ([MonedaOrigen], [MonedaDestino], [TipoCambio], [FlagActivo], [AuditoriaFechaCreacion], [AuditoriaFechaModificacion]) VALUES (N'DLR', N'SOL', CAST(3.500 AS Decimal(18, 3)), 1, CAST(N'2021-05-09T01:06:44.750' AS DateTime), NULL)
INSERT [GENERALES].[TipoCambioMoneda] ([MonedaOrigen], [MonedaDestino], [TipoCambio], [FlagActivo], [AuditoriaFechaCreacion], [AuditoriaFechaModificacion]) VALUES (N'EUR', N'SOL', CAST(4.600 AS Decimal(18, 3)), 1, CAST(N'2021-05-09T01:11:56.707' AS DateTime), CAST(N'2021-05-10T11:44:35.090' AS DateTime))
INSERT [GENERALES].[TipoCambioMoneda] ([MonedaOrigen], [MonedaDestino], [TipoCambio], [FlagActivo], [AuditoriaFechaCreacion], [AuditoriaFechaModificacion]) VALUES (N'SOL', N'DLR', CAST(0.285 AS Decimal(18, 3)), 1, CAST(N'2021-05-10T12:18:53.357' AS DateTime), NULL)
GO
ALTER TABLE [GENERALES].[Moneda] ADD  DEFAULT ((1)) FOR [FlagActivo]
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda] ADD  CONSTRAINT [DF__TipoCambi__FlagA__4E88ABD4]  DEFAULT ((1)) FOR [FlagActivo]
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda] ADD  CONSTRAINT [DF__TipoCambi__Audit__4F7CD00D]  DEFAULT (getdate()) FOR [AuditoriaFechaCreacion]
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda]  WITH CHECK ADD  CONSTRAINT [FK_TIPOCAMBIOMONEDA_MONEDA_MonedaDestino] FOREIGN KEY([MonedaDestino])
REFERENCES [GENERALES].[Moneda] ([CodigoMoneda])
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda] CHECK CONSTRAINT [FK_TIPOCAMBIOMONEDA_MONEDA_MonedaDestino]
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda]  WITH CHECK ADD  CONSTRAINT [FK_TIPOCAMBIOMONEDA_MONEDA_MonedaOrigen] FOREIGN KEY([MonedaOrigen])
REFERENCES [GENERALES].[Moneda] ([CodigoMoneda])
GO
ALTER TABLE [GENERALES].[TipoCambioMoneda] CHECK CONSTRAINT [FK_TIPOCAMBIOMONEDA_MONEDA_MonedaOrigen]
GO
