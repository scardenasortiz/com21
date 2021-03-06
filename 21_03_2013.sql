USE [com21db]
GO
/****** Object:  Table [dbo].[tbl_c_categoria]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_categoria](
	[Id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](max) NULL,
	[Activar] [bit] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_categoria] PRIMARY KEY CLUSTERED 
(
	[Id_Categoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_categoria] ON
INSERT [dbo].[tbl_c_categoria] ([Id_Categoria], [Categoria], [Activar], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (1, N'Servicio Eléctricos', 1, CAST(0x0000A17701862C28 AS DateTime), CAST(0x0000A17701862C28 AS DateTime), 1)
INSERT [dbo].[tbl_c_categoria] ([Id_Categoria], [Categoria], [Activar], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (2, N'Computadoras & Partes', 1, CAST(0x0000A1770186C98B AS DateTime), CAST(0x0000A1770186C98B AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_c_categoria] OFF
/****** Object:  Table [dbo].[tbl_c_administrador]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_administrador](
	[Id_Administrador] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](100) NULL,
	[Clave] [nvarchar](32) NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[Correo] [nvarchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Ruta] [nvarchar](max) NULL,
	[Telefono] [nvarchar](11) NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbbl_c_administrador] PRIMARY KEY CLUSTERED 
(
	[Id_Administrador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_administrador] ON
INSERT [dbo].[tbl_c_administrador] ([Id_Administrador], [Usuario], [Clave], [Nombres], [Apellidos], [Correo], [FechaIngreso], [FechaModificacion], [Estado], [Ruta], [Telefono], [Activar]) VALUES (1, N'scardenas', N'scardenas123', N'Steven Omar', N'Cardenas Ortiz', N'so_cardenas@hotmail.com', CAST(0x0000A125018439FE AS DateTime), CAST(0x0000A17B01171F32 AS DateTime), 1, N'~/images/users.png', N'0992332570', 1)
INSERT [dbo].[tbl_c_administrador] ([Id_Administrador], [Usuario], [Clave], [Nombres], [Apellidos], [Correo], [FechaIngreso], [FechaModificacion], [Estado], [Ruta], [Telefono], [Activar]) VALUES (2, N'ecardenas', N'202020', N'erick omar', N'cardenas ortiz', N'ag_sobo@hotmail.com', CAST(0x0000A17B010F9870 AS DateTime), CAST(0x0000A17B010F9870 AS DateTime), 1, N'~/images/users.png', N'0992332575', 0)
INSERT [dbo].[tbl_c_administrador] ([Id_Administrador], [Usuario], [Clave], [Nombres], [Apellidos], [Correo], [FechaIngreso], [FechaModificacion], [Estado], [Ruta], [Telefono], [Activar]) VALUES (3, N'asanchez', N'202020', N'andrea gissel', N'sanchez barahona', N'steven.cardenas@bonsai.com.ec', CAST(0x0000A17B01104A24 AS DateTime), CAST(0x0000A17B01104A24 AS DateTime), 1, N'~/images/users.png', N'0992332575', 0)
SET IDENTITY_INSERT [dbo].[tbl_c_administrador] OFF
/****** Object:  Table [dbo].[tbl_c_clientes]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_clientes](
	[Id_Clientes] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Usuario] [nvarchar](max) NULL,
	[Clave] [nvarchar](32) NULL,
	[Id_Sexo] [int] NULL,
	[Sexo] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Id_Ciudad] [int] NULL,
	[Id_Provincia] [int] NULL,
	[Id_Pais] [int] NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Correo_Secundario] [nvarchar](max) NULL,
	[Cedula] [nvarchar](50) NULL,
	[FechaNacimiento] [nvarchar](50) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_clientes] PRIMARY KEY CLUSTERED 
(
	[Id_Clientes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_videos]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_videos](
	[Id_Video] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[RutaVideo] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_videos] PRIMARY KEY CLUSTERED 
(
	[Id_Video] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_subcategoria]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_subcategoria](
	[Id_SubCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Activar] [bit] NULL,
	[Id_Categoria] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_c_subcategoria] PRIMARY KEY CLUSTERED 
(
	[Id_SubCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_subcategoria] ON
INSERT [dbo].[tbl_c_subcategoria] ([Id_SubCategoria], [Titulo], [Activar], [Id_Categoria], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (1, N'instalación de cableado', 1, 1, CAST(0x0000A1780009C93F AS DateTime), CAST(0x0000A1780009C93F AS DateTime), 1)
INSERT [dbo].[tbl_c_subcategoria] ([Id_SubCategoria], [Titulo], [Activar], [Id_Categoria], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (3, N'Disco Duros', 1, 2, CAST(0x0000A178000BAE23 AS DateTime), CAST(0x0000A178000BAE23 AS DateTime), 2)
INSERT [dbo].[tbl_c_subcategoria] ([Id_SubCategoria], [Titulo], [Activar], [Id_Categoria], [FechaIngreso], [FechaModificacion], [Estado]) VALUES (4, N'Discos Duros', 1, 2, CAST(0x0000A178000EB922 AS DateTime), CAST(0x0000A17A0178AD8F AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_c_subcategoria] OFF
/****** Object:  Table [dbo].[tbl_c_slide]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_slide](
	[Id_Slide] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Ruta] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_slide] PRIMARY KEY CLUSTERED 
(
	[Id_Slide] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_slide] ON
INSERT [dbo].[tbl_c_slide] ([Id_Slide], [Titulo], [Descripcion], [Ruta], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (1, N'test', N'teste', N'~/upload/slide/k4c7ai.jpg', CAST(0x0000A14A0014C427 AS DateTime), CAST(0x0000A14A0014C427 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_slide] ([Id_Slide], [Titulo], [Descripcion], [Ruta], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (2, N'test', N'teste', N'~/upload/slide/7njsue.jpg', CAST(0x0000A14A00152B58 AS DateTime), CAST(0x0000A14A00152B58 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_slide] ([Id_Slide], [Titulo], [Descripcion], [Ruta], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (3, N'testggj', N'hjhj', N'~/upload/slide/miwn3x.jpg', CAST(0x0000A14A0015D036 AS DateTime), CAST(0x0000A14A0015D036 AS DateTime), 2, 0)
SET IDENTITY_INSERT [dbo].[tbl_c_slide] OFF
/****** Object:  Table [dbo].[tbl_c_producto]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_producto](
	[Id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Cantidad] [nvarchar](max) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Id_Categoria] [int] NULL,
	[Id_SubCategoria] [int] NULL,
	[Ruta] [nvarchar](max) NULL,
	[Activar] [bit] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Id_Marca] [int] NULL,
	[DescripcioCorta] [nvarchar](max) NULL,
	[ActIva] [int] NULL,
	[Descuento] [nvarchar](50) NULL,
	[Codigo] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_c_producto] PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_perfil]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_perfil](
	[Id_Perfil] [int] IDENTITY(1,1) NOT NULL,
	[Id_Administrador] [int] NULL,
	[Id_Menu] [int] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_perfil] PRIMARY KEY CLUSTERED 
(
	[Id_Perfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_perfil] ON
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (9, 1, 1, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (10, 1, 2, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (11, 1, 3, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (12, 1, 4, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (13, 1, 5, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (14, 1, 6, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (15, 1, 7, 1, 1)
INSERT [dbo].[tbl_c_perfil] ([Id_Perfil], [Id_Administrador], [Id_Menu], [Estado], [Activar]) VALUES (16, 1, 8, 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_c_perfil] OFF
/****** Object:  Table [dbo].[tbl_c_pais]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_pais](
	[Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Aplicar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_pais] PRIMARY KEY CLUSTERED 
(
	[Id_Pais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_pais] ON
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (1, N'Ecuador', CAST(0x0000A12401214915 AS DateTime), CAST(0x0000A12401214915 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (2, N'Brazil', CAST(0x0000A13A01856E16 AS DateTime), CAST(0x0000A13A01856E16 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (3, N'Perú', CAST(0x0000A13A0185AA79 AS DateTime), CAST(0x0000A13A0185AA79 AS DateTime), 2, 0)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (4, N'Perú', CAST(0x0000A17C00D93192 AS DateTime), CAST(0x0000A17F0006A587 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (5, N'Chile', CAST(0x0000A17F0001E7D5 AS DateTime), CAST(0x0000A17F0001E7D5 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (6, N'Chile', CAST(0x0000A17F0001E84E AS DateTime), CAST(0x0000A17F0001E84E AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (7, N'Chile', CAST(0x0000A17F0001E8BE AS DateTime), CAST(0x0000A17F0001E8BE AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (8, N'Mexico', CAST(0x0000A17F0001FEA0 AS DateTime), CAST(0x0000A17F0001FEA0 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (9, N'Colombia', CAST(0x0000A17F000248EF AS DateTime), CAST(0x0000A18200C84713 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (10, N'Perú', CAST(0x0000A17F000422B4 AS DateTime), CAST(0x0000A17F000422B4 AS DateTime), 2, 0)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (11, N'Perú', CAST(0x0000A17F0004AA84 AS DateTime), CAST(0x0000A17F0004AA84 AS DateTime), 2, 0)
INSERT [dbo].[tbl_c_pais] ([Id_Pais], [Pais], [FechaIngreso], [FechaModificacion], [Estado], [Aplicar]) VALUES (12, N'Perú', CAST(0x0000A17F0006031E AS DateTime), CAST(0x0000A17F0006031E AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[tbl_c_pais] OFF
/****** Object:  Table [dbo].[tbl_c_menu_administrador]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_menu_administrador](
	[Id_Menu_Admin] [int] IDENTITY(1,1) NOT NULL,
	[Id_Menu] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModifacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Id_Administrador] [int] NULL,
 CONSTRAINT [PK_tbl_c_menu_administrador] PRIMARY KEY CLUSTERED 
(
	[Id_Menu_Admin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_menu]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_menu](
	[Id_Menu] [int] IDENTITY(1,1) NOT NULL,
	[Menu] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Activar] [bit] NULL,
	[Estado] [int] NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_c_menu] PRIMARY KEY CLUSTERED 
(
	[Id_Menu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_menu] ON
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (1, N'Costo de Envio', CAST(0x0000A17B01140A13 AS DateTime), CAST(0x0000A17B01140A13 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (2, N'Empresa', CAST(0x0000A17B01141318 AS DateTime), CAST(0x0000A17B01141318 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (3, N'Productos', CAST(0x0000A17B01141A6E AS DateTime), CAST(0x0000A17B01141A6E AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (4, N'Usuarios Administradores', CAST(0x0000A17B011422E1 AS DateTime), CAST(0x0000A17B011422E1 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (5, N'Usuarios Clientes', CAST(0x0000A17B01142E07 AS DateTime), CAST(0x0000A17B01142E07 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (6, N'Galería Fotográfica', CAST(0x0000A17B011441C4 AS DateTime), CAST(0x0000A17B011441C4 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (7, N'Reportes', CAST(0x0000A17B01145126 AS DateTime), CAST(0x0000A17B01145126 AS DateTime), 1, 1, NULL)
INSERT [dbo].[tbl_c_menu] ([Id_Menu], [Menu], [FechaIngreso], [FechaModificacion], [Activar], [Estado], [Descripcion]) VALUES (8, N'Transacciones', CAST(0x0000A17B01145D53 AS DateTime), CAST(0x0000A17B01145D53 AS DateTime), 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[tbl_c_menu] OFF
/****** Object:  Table [dbo].[tbl_c_marca]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_marca](
	[Id_Marca] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](max) NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_tbl_c_marca] PRIMARY KEY CLUSTERED 
(
	[Id_Marca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_marca] ON
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (1, N'Dell', 1, 1, CAST(0x0000A17A01839C96 AS DateTime), CAST(0x0000A17A01839C96 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (2, N'LG', 1, 1, CAST(0x0000A17A0183B2A9 AS DateTime), CAST(0x0000A17A0183B2A9 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (3, N'Panasonic', 1, 1, CAST(0x0000A17A0183DF8A AS DateTime), CAST(0x0000A17A0183DF8A AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (4, N'HP', 1, 1, CAST(0x0000A17A0183EC56 AS DateTime), CAST(0x0000A17A0183EC56 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (5, N'Samsung', 1, 1, CAST(0x0000A17A01840664 AS DateTime), CAST(0x0000A17A01840664 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (6, N'General Electric', 1, 1, CAST(0x0000A17A01843F57 AS DateTime), CAST(0x0000A17A01843F57 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (7, N'EPSON', 1, 1, CAST(0x0000A17A01849A23 AS DateTime), CAST(0x0000A17A01849A23 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (8, N'Genius', 1, 1, CAST(0x0000A17A0184B712 AS DateTime), CAST(0x0000A17A0184B712 AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (9, N'Sony', 1, 1, CAST(0x0000A17A0184C02C AS DateTime), CAST(0x0000A17A0184C02C AS DateTime))
INSERT [dbo].[tbl_c_marca] ([Id_Marca], [Marca], [Estado], [Activar], [FechaIngreso], [FechaModificacion]) VALUES (10, N'Toshiba', 1, 1, CAST(0x0000A17A0184C6CE AS DateTime), CAST(0x0000A17A0184C6CE AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_c_marca] OFF
/****** Object:  Table [dbo].[tbl_c_info_empresa]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_info_empresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Informacion] [nvarchar](max) NULL,
	[Id_pagina] [int] NULL,
	[Pagina] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Titulo] [nvarchar](max) NULL,
	[Activar] [bit] NULL,
	[DescripcionCorta] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_c_info_empresa] PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_info_empresa] ON
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (1, N'test de pruebas', 2, N'NO', CAST(0x0000A1490172A460 AS DateTime), CAST(0x0000A1490172A460 AS DateTime), 2, N'nosotros', 1, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (2, N'test de pruebas1', 2, N'NO', CAST(0x0000A14901731217 AS DateTime), CAST(0x0000A14901731217 AS DateTime), 2, N'nosotros1', 0, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (3, N'test de pruebas1', 2, N'NO', CAST(0x0000A14901731E22 AS DateTime), CAST(0x0000A14901731E22 AS DateTime), 2, N'nosotros1', 1, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (4, N'test de pruebas1', 2, N'NO', CAST(0x0000A149017343F8 AS DateTime), CAST(0x0000A149017343F8 AS DateTime), 2, N'nosotros1', 0, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (5, N'tes nmnmnmn', 2, N'NO', CAST(0x0000A149017451DE AS DateTime), CAST(0x0000A149017451DE AS DateTime), 2, N'test', 0, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (6, N'<span style="color: #000000; font-family: courier new, courier, monospace; font-size: 8pt; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable.<br />
All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures</span>', 1, N'MV', CAST(0x0000A14901794B51 AS DateTime), CAST(0x0000A16F000F9C38 AS DateTime), 1, N'Misión', 1, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (7, N'pruebasesendff', 2, N'NO', CAST(0x0000A14A0002205D AS DateTime), CAST(0x0000A16E00E0855B AS DateTime), 2, N'nosotors1', 1, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (8, N'<strong style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">Lorem Ipsum</strong><span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span>', 2, N'NO', CAST(0x0000A16E01710AF8 AS DateTime), CAST(0x0000A16E01738258 AS DateTime), 1, N'Nosotros 2', 1, N'is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (9, N'<span style="color: #000000; font-family: courier new, courier, monospace; line-height: 14px; text-align: justify;">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content here'', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).</span>', 2, N'NO', CAST(0x0000A16E0178CB4E AS DateTime), CAST(0x0000A16E017A32DD AS DateTime), 2, N'Nosotros 3', 1, N'<span style="color: #000000; font-family: courier new, courier, monospace; line-height: 14px; text-align: justify;">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content here'', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).</span>')
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (10, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F00108BE7 AS DateTime), CAST(0x0000A16F00108BE7 AS DateTime), 2, N'Visión', 1, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (11, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F0010952C AS DateTime), CAST(0x0000A16F0010952C AS DateTime), 2, N'Visión', 0, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (12, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F0010AA5B AS DateTime), CAST(0x0000A16F0010AA5B AS DateTime), 2, N'Visión', 0, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (13, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F001103CC AS DateTime), CAST(0x0000A16F001103CC AS DateTime), 1, N'Visión', 1, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (14, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F001109B3 AS DateTime), CAST(0x0000A16F001109B3 AS DateTime), 2, N'Visión', 0, NULL)
INSERT [dbo].[tbl_c_info_empresa] ([Id_Empresa], [Informacion], [Id_pagina], [Pagina], [FechaIngreso], [FechaModificacion], [Estado], [Titulo], [Activar], [DescripcionCorta]) VALUES (15, N'<span style="color: #000000; font-family: arial, helvetica, sans; font-size: 11px; line-height: 14px; text-align: justify;">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</span>', 1, N'MV', CAST(0x0000A16F0011B571 AS DateTime), CAST(0x0000A16F0011B571 AS DateTime), 2, N'Visión', 0, NULL)
SET IDENTITY_INSERT [dbo].[tbl_c_info_empresa] OFF
/****** Object:  Table [dbo].[tbl_c_imagenes_productos]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_imagenes_productos](
	[Id_Imagenes] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [nvarchar](max) NULL,
	[Ruta1] [nvarchar](max) NULL,
	[Ruta2] [nvarchar](max) NULL,
	[Rutas3] [nvarchar](max) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
	[Id_Producto] [int] NULL,
 CONSTRAINT [PK_tbl_c_imagenes_productos] PRIMARY KEY CLUSTERED 
(
	[Id_Imagenes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_c_empresa]    Script Date: 03/21/2013 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_empresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [nvarchar](max) NULL,
	[Estado] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Activar] [bit] NULL,
	[Principal] [bit] NULL,
 CONSTRAINT [PK_tbl_c_empresa] PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_empresa] ON
INSERT [dbo].[tbl_c_empresa] ([Id_Empresa], [Empresa], [Estado], [FechaIngreso], [FechaModificacion], [Activar], [Principal]) VALUES (1, N'Com21 Guayaquil', 2, CAST(0x0000A1800059C646 AS DateTime), CAST(0x0000A180005D883F AS DateTime), 1, 0)
INSERT [dbo].[tbl_c_empresa] ([Id_Empresa], [Empresa], [Estado], [FechaIngreso], [FechaModificacion], [Activar], [Principal]) VALUES (2, N'Com21 Quito', 2, CAST(0x0000A180005A0985 AS DateTime), CAST(0x0000A180005D8C43 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_empresa] ([Id_Empresa], [Empresa], [Estado], [FechaIngreso], [FechaModificacion], [Activar], [Principal]) VALUES (3, N'Matriz', 1, CAST(0x0000A182000FEA04 AS DateTime), CAST(0x0000A182000FEA04 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_empresa] ([Id_Empresa], [Empresa], [Estado], [FechaIngreso], [FechaModificacion], [Activar], [Principal]) VALUES (4, N'Guayaquil', 1, CAST(0x0000A182000FFE8E AS DateTime), CAST(0x0000A182000FFE8E AS DateTime), 1, 0)
INSERT [dbo].[tbl_c_empresa] ([Id_Empresa], [Empresa], [Estado], [FechaIngreso], [FechaModificacion], [Activar], [Principal]) VALUES (5, N'Milagro', 1, CAST(0x0000A18200100839 AS DateTime), CAST(0x0000A18200100839 AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_c_empresa] OFF
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Categoria]    Script Date: 03/21/2013 23:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Categoria](@Id_Categoria int)
AS
BEGIN TRAN
update tbl_c_categoria
set Estado = 2
where Id_Categoria = @Id_Categoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Administrador]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Administrador](@Id_Administrador int)
AS
BEGIN TRAN
update tbl_c_administrador
set Estado = 2
where Id_Administrador = @Id_Administrador
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_VideoId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_VideoId](@Id_Video int)
AS
BEGIN TRAN
SELECT [Id_Video],[Titulo],[Descripcion],[RutaVideo],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_videos where Id_Video = @Id_Video and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Video]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Video]
AS
BEGIN TRAN
SELECT [Id_Video],[Titulo],[Descripcion],[RutaVideo],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_videos where Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_SubCategoriaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_SubCategoriaId](@Id_SubCategoria int)
AS
BEGIN TRAN
SELECT Id_SubCategoria,Titulo,Activar,[FechaIngreso],[FechaModificacion],[Estado],Id_Categoria from tbl_c_subcategoria where Id_SubCategoria = @Id_SubCategoria and Estado = 1

SELECT Id_SubCategoria,Titulo,Activar,[FechaIngreso],[FechaModificacion],[Estado],Id_Categoria from tbl_c_subcategoria where Id_Categoria = @Id_SubCategoria and Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_SubCategoria_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_SubCategoria_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
SELECT Id_SubCategoria,Titulo,Activar,[FechaIngreso],[FechaModificacion],[Estado],Id_Categoria from tbl_c_subcategoria where Titulo like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_SubCategoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_SubCategoria]
AS
BEGIN TRAN
SELECT Id_SubCategoria,Titulo,Activar,[FechaIngreso],[FechaModificacion],[Estado],Id_Categoria from tbl_c_subcategoria where Estado = 1

SELECT Id_SubCategoria,Titulo,Activar,[FechaIngreso],[FechaModificacion],[Estado],Id_Categoria from tbl_c_subcategoria where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_SlideId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_SlideId](@Id_Slide int)
AS
BEGIN TRAN
SELECT [Id_Slide],[Titulo],[Descripcion],[Ruta],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_slide where Id_Slide = @Id_Slide and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Slide_mostrar]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Slide_mostrar]
AS
BEGIN TRAN
SELECT [Id_Slide],[Titulo],[Descripcion],[Ruta],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_slide where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Slide]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Slide]
AS
BEGIN TRAN
SELECT [Id_Slide],[Titulo],[Descripcion],[Ruta],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_slide where Estado = 1

SELECT [Id_Slide],[Titulo],[Descripcion],[Ruta],[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_slide where Estado = 2
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Pais]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Pais](@Id_Pais int)
AS
BEGIN TRAN
--elimana logicamente de la tabla pais 
update tbl_c_pais
set Estado = 2
where Id_Pais = @Id_Pais

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Marca]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Marca](@Id_Marca int)
AS
BEGIN TRAN
update tbl_c_marca
set Estado = 2
where Id_Marca = @Id_Marca
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Info]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Info](@Id_Empresa int)
AS
BEGIN TRAN
update tbl_c_info_empresa
set Estado = 2
where Id_Empresa = @Id_Empresa
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Imagenes]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Imagenes](@Id_Imagenes int)
AS
BEGIN TRAN
update tbl_c_imagenes_productos
set Estado = 2
where Id_Imagenes = @Id_Imagenes
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Empresa]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Empresa](@Id_Empresa int)
AS
BEGIN TRAN
--elimana logicamente de la tabla empresa
update tbl_c_empresa
set Estado = 2
where Id_Empresa = @Id_Empresa

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Categoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Categoria](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_categoria(Categoria,Activar)
SELECT 
        x.value('@Categoria','nvarchar(max)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Categoria') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Categoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Administrador]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Administrador](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_administrador(Usuario,Clave,Nombres,Apellidos,Correo,Ruta,Telefono,Activar)
SELECT 
		x.value('@Usuario','nvarchar(100)'),
		x.value('@Clave','nvarchar(32)'),
		x.value('@Nombres','nvarchar(100)'),
		x.value('@Apellidos','nvarchar(100)'),
		x.value('@Correo','nvarchar(100)'),
		x.value('@Ruta','nvarchar(max)'),
		x.value('@Telefono','nvarchar(11)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Administrador') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Administrador
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Inactivar_Productos_SubCategoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Inactivar_Productos_SubCategoria](@Id_SubCategoria int)
AS
BEGIN TRAN
update tbl_c_producto
set Estado = 2,
    Id_SubCategoria = 0
where Id_SubCategoria = @Id_SubCategoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Inactivar_Productos_Marca]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Inactivar_Productos_Marca](@Id_Marca int)
AS
BEGIN TRAN
update tbl_c_producto
set Estado = 2,
    Id_Marca = 0
where Id_Marca = @Id_Marca
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Video]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Video](@Id_Video int)
AS
BEGIN TRAN
update tbl_c_videos
set Estado = 2
where Id_Video = @Id_Video
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_SubCategoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_SubCategoria](@Id_SubCategoria int)
AS
BEGIN TRAN
update tbl_c_subcategoria
set Estado = 2
where Id_SubCategoria = @Id_SubCategoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Slide]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Slide](@Id_Slide int)
AS
BEGIN TRAN
update tbl_c_slide
set Estado = 2
where Id_Slide = @Id_Slide
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_ProductosId_Mostrar]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_ProductosId_Mostrar](@Id_Producto int)
AS
BEGIN TRAN
SELECT p.Id_Producto,p.Titulo,p.Descripcion,p.Cantidad,p.Precio,p.Id_Categoria,p.Id_SubCategoria,p.Ruta,p.FechaIngreso,p.Activar,c.Categoria,sc.Titulo as SubCategoria
from tbl_c_producto as p,tbl_c_categoria as c,tbl_c_subcategoria as sc 
where p.Estado = 1 and p.Activar = 1 and p.Id_Producto = @Id_Producto and p.Id_Categoria = c.Id_Categoria and p.Id_SubCategoria = sc.Id_SubCategoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_ProductosId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_ProductosId](@Id_Producto int)
AS
BEGIN TRAN
SELECT Id_Producto,Titulo,Descripcion,Cantidad,Precio,Id_Categoria,Id_SubCategoria,Ruta,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,[Activar] from tbl_c_producto where Id_Producto = @Id_Producto and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Productos_Mostrar]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Productos_Mostrar]
AS
BEGIN TRAN
SELECT p.Id_Producto,p.Titulo,p.Descripcion,p.Cantidad,p.Precio,p.Id_Categoria,p.Id_SubCategoria,p.Ruta,p.FechaIngreso,p.Activar,c.Categoria,sc.Titulo as SubCategoria
from tbl_c_producto as p,tbl_c_categoria as c,tbl_c_subcategoria as sc 
where p.Estado = 1 and p.Activar = 1 and p.Id_Categoria = c.Id_Categoria and p.Id_SubCategoria = sc.Id_SubCategoria
--SELECT Id_Producto,Titulo,Descripcion,Cantidad,Precio,Id_Categoria,Id_SubCategoria,Ruta,FechaIngreso,[Activar] from tbl_c_producto where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Productos]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Productos]
AS
BEGIN TRAN
SELECT Id_Producto,Titulo,Descripcion,Cantidad,Precio,Id_Categoria,Id_SubCategoria,Ruta,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,[Activar] from tbl_c_producto where Estado = 1

SELECT Id_Producto,Titulo,Descripcion,Cantidad,Precio,Id_Categoria,Id_SubCategoria,Ruta,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,[Activar] from tbl_c_producto where Estado = 2
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_PaisId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_PaisId](@Id_Pais int)
AS
BEGIN TRAN
select Id_Pais,Pais,Aplicar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso from tbl_c_pais where Estado = 1 and Id_Pais = @Id_Pais
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Pais_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Pais_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select Id_Pais,Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Aplicar from tbl_c_pais where Pais like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Pais]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Pais]
AS
BEGIN TRAN
select Id_Pais,Pais,Aplicar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso from tbl_c_pais where Estado = 1

select Id_Pais,Pais,Aplicar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso from tbl_c_pais where Estado = 1 and Aplicar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Menu]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Menu]
AS
BEGIN TRAN
SELECT [Id_Menu]
      ,[Menu]
      ,[FechaIngreso]
      ,[FechaModificacion]
      ,[Activar]
      ,[Estado]
      ,[Descripcion]
      from tbl_c_menu where Estado = 1 and Activar = 1
      
SELECT     tbl_c_perfil.Id_Perfil, tbl_c_perfil.Id_Administrador, tbl_c_perfil.Id_Menu, tbl_c_menu.Menu, tbl_c_administrador.Usuario, tbl_c_perfil.Estado, tbl_c_perfil.Activar
FROM         tbl_c_perfil INNER JOIN
                      tbl_c_menu ON tbl_c_perfil.Id_Menu = tbl_c_menu.Id_Menu INNER JOIN
                      tbl_c_administrador ON tbl_c_perfil.Id_Administrador = tbl_c_administrador.Id_Administrador
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_MarcaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_MarcaId](@Id_Marca int)
AS
BEGIN TRAN
SELECT Id_Marca,Marca,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_marca where Id_Marca = @Id_Marca and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Marca_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Marca_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select Id_Marca,Marca,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_marca where Marca like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Marca]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Marca]
AS
BEGIN TRAN
SELECT Id_Marca,Marca,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_marca where Estado = 1

SELECT Id_Marca,Marca,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_marca where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_InfoId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_InfoId](@Id_Empresa int)
AS
BEGIN TRAN
SELECT [Id_Empresa],[Informacion],[Id_pagina],[Pagina],[FechaIngreso],[FechaModificacion],[Estado],[Titulo],[Activar] from tbl_c_info_empresa where Id_Empresa = @Id_Empresa and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Info]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Info]
AS
BEGIN TRAN
--nosotros
SELECT [Id_Empresa],Informacion,Id_pagina,[Pagina],CONVERT(char(15),FechaIngreso,107) as FechaIngreso,[FechaModificacion],[Estado],[Titulo],[Activar],SUBSTRING(DescripcionCorta,0,50)+'...' as DescripcionCorta from tbl_c_info_empresa where Estado = 1 and Id_pagina = 2

SELECT [Id_Empresa],Informacion,[Id_pagina],[Pagina],CONVERT(char(15),FechaIngreso,107) as FechaIngreso,[FechaModificacion],[Estado],[Titulo],[Activar],SUBSTRING(DescripcionCorta,0,50)+'...' as DescripcionCorta from tbl_c_info_empresa where Estado = 2 and Id_pagina = 2

--mision vision
SELECT [Id_Empresa],Informacion,[Id_pagina],[Pagina],CONVERT(char(15),FechaIngreso,107) as FechaIngreso,[FechaModificacion],[Estado],[Titulo],[Activar],SUBSTRING(DescripcionCorta,0,50)+'...' as DescripcionCorta from tbl_c_info_empresa where Estado = 1 and Id_pagina = 1

SELECT [Id_Empresa],Informacion,[Id_pagina],[Pagina],CONVERT(char(15),FechaIngreso,107) as FechaIngreso,[FechaModificacion],[Estado],[Titulo],[Activar],SUBSTRING(DescripcionCorta,0,50)+'...' as DescripcionCorta from tbl_c_info_empresa where Estado = 2 and Id_pagina = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_ImagenesId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_ImagenesId](@Id_Imagenes int)
AS
BEGIN TRAN
SELECT i.Id_Imagenes,i.Ruta,i.Ruta1,i.Ruta2,i.Rutas3,i.FechaIngreso,i.Activar,i.Id_Producto,p.Titulo 
from tbl_c_imagenes_productos as i,tbl_c_producto as p 
where i.Id_Imagenes = @Id_Imagenes and i.Estado = 1 and i.Id_Producto = p.Id_Producto
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Imagenes_Mostrar]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Imagenes_Mostrar]
AS
BEGIN TRAN
SELECT Id_Imagenes,Ruta,Ruta1,Ruta2,Rutas3,[FechaIngreso],[FechaModificacion],[Estado],[Activar] from tbl_c_imagenes_productos where Estado = 1 and Activar = 1

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Imagenes]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Imagenes]
AS
BEGIN TRAN
SELECT i.Id_Imagenes,i.Ruta,i.Ruta1,i.Ruta2,i.Rutas3,i.FechaIngreso,i.FechaModificacion,i.Estado,i.Activar,p.Titulo
from tbl_c_imagenes_productos as i,tbl_c_producto as p
where i.Estado = 1 and i.Id_Producto = p.Id_Producto

SELECT i.Id_Imagenes,i.Ruta,i.Ruta1,i.Ruta2,i.Rutas3,i.FechaIngreso,i.FechaModificacion,i.Estado,i.Activar,p.Titulo
from tbl_c_imagenes_productos as i, tbl_c_producto as p
where i.Estado = 2 and i.Id_Producto = p.Id_Producto

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_EmpresaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_EmpresaId](@Id_Empresa int)
AS
BEGIN TRAN
select Id_Empresa,Empresa,Activar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso,Principal from tbl_c_empresa where Estado = 1 and Id_Empresa = @Id_Empresa
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Empresa_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Empresa_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select Id_Empresa,Empresa,Activar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso,Principal from tbl_c_empresa where Empresa like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Empresa]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Empresa]
AS
BEGIN TRAN
select Id_Empresa,Empresa,Activar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso,Principal from tbl_c_empresa where Estado = 1

select Id_Empresa,Empresa,Activar,CONVERT(char(15),FechaIngreso,107) as FechaIngreso,Principal from tbl_c_empresa where Estado = 1 and Activar = 1

select Id_Empresa from tbl_c_empresa where Estado = 1 and Principal = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Productos]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Productos](@xmlDatos xml,@Id_Producto int)
AS
Begin Tran
		Update tbl_c_producto
		set
			Titulo=x.value('@Titulo','nvarchar(max)'),
			Descripcion=x.value('@Descripcion','nvarchar(max)'),
			Cantidad=x.value('@Cantidad','nvarchar(max)'),
			Precio=x.value('@Precio','decimal(18,2)'),
			Id_Categoria=x.value('@Id_Categoria','int'),
			Id_SubCategoria=x.value('@Id_SubCategoria','int'),
			Ruta=x.value('@Ruta','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Productos') R(x)
		where Id_Producto = @Id_Producto
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Pais]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Pais](@xmlDatos xml,@Id_Pais int)
AS
Begin Tran
		Update tbl_c_pais
		set
			Pais=x.value('@Pais','nvarchar(max)'),
			Aplicar=x.value('@Aplicar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Pais') R(x)
		where Id_Pais = @Id_Pais
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Marca]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Marca](@xmlDatos xml,@Id_Marca int)
AS
Begin Tran
		Update tbl_c_marca
		set
			Marca=x.value('@Marca','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Marca') R(x)
		where Id_Marca = @Id_Marca
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Info]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Info](@xmlDatos xml,@Id_Empresa int)
AS
Begin Tran
		Update tbl_c_info_empresa
		set
			Informacion=x.value('@Informacion','nvarchar(max)'),
			Id_pagina=x.value('@Id_pagina','int'),
			Pagina=x.value('@Pagina','nvarchar(max)'),
			Titulo=x.value('@Titulo','nvarchar(max)'),
			DescripcionCorta=x.value('@DescripcionCorta','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Info') R(x)
		where Id_Empresa = @Id_Empresa
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Imagenes]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Imagenes](@xmlDatos xml,@Id_Imagenes int)
AS
Begin Tran
		Update tbl_c_imagenes_productos
		set
			Ruta=x.value('@Ruta','nvarchar(max)'),
			Ruta1=x.value('@Ruta1','nvarchar(max)'),
			Ruta2=x.value('@Ruta2','nvarchar(max)'),
			Rutas3=x.value('@Rutas3','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Imagenes') R(x)
		where Id_Imagenes = @Id_Imagenes
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Empresa]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Empresa](@xmlDatos xml,@Id_Empresa int)
AS
Begin Tran
		Update tbl_c_empresa
		set
			Empresa=x.value('@Empresa','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			Principal=x.value('@Principal','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Empresa') R(x)
		where Id_Empresa = @Id_Empresa
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Categoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Categoria](@xmlDatos xml,@Id_Categoria int)
AS
Begin Tran
		Update tbl_c_categoria
		set
			Categoria=x.value('@Categoria','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Categoria') R(x)
		where Id_Categoria = @Id_Categoria
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Administrador]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Administrador](@xmlDatos xml,@Id_Administrador int)
AS
Begin Tran
		Update tbl_c_administrador
		set
			Usuario=x.value('@Usuario','nvarchar(100)'),
			Clave=x.value('@Clave','nvarchar(32)'),
			Nombres=x.value('@Nombres','nvarchar(100)'),
			Apellidos=x.value('@Apellidos','nvarchar(100)'),
			Correo=x.value('@Correo','nvarchar(100)'),
			Ruta=x.value('@Ruta','nvarchar(max)'),
			Telefono=x.value('@Telefono','nvarchar(11)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Administrador') R(x)
		where Id_Administrador = @Id_Administrador
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Activar_Slide]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Activar_Slide](@Id_Slide int)
AS
BEGIN TRAN
update tbl_c_slide
set Estado = 1
where Id_Slide = @Id_Slide
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_CategoriaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_CategoriaId](@Id_Categoria int)
AS
BEGIN TRAN
SELECT Id_Categoria,Categoria,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_categoria where Id_Categoria = @Id_Categoria and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Categoria_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Categoria_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select Id_Categoria,Categoria,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_categoria where Categoria like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Categoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Categoria]
AS
BEGIN TRAN
SELECT Id_Categoria,Categoria,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_categoria where Estado = 1

SELECT Id_Categoria,Categoria,Activar,[FechaIngreso],[FechaModificacion],[Estado] from tbl_c_categoria where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_AdministradorId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_AdministradorId](@Id_Administrador int)
AS
BEGIN TRAN
SELECT [Id_Administrador]
      ,[Usuario]
      ,[Clave]
      ,[Nombres]
      ,[Apellidos]
      ,[Correo]
      ,[FechaIngreso]
      ,[FechaModificacion]
      ,[Estado]
      ,[Ruta]
      ,[Telefono]
      ,[Activar]
  FROM [com21db].[dbo].[tbl_c_administrador] where Estado = 1 and Id_Administrador = @Id_Administrador
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Administrador_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Administrador_Letra](@Letra nvarchar(10))
AS
BEGIN TRAN
select Id_Administrador
      ,[Usuario]
      ,[Clave]
      ,[Nombres]
      ,[Apellidos]
      ,[Correo]
      ,[FechaIngreso]
      ,[FechaModificacion]
      ,[Estado]
      ,[Ruta]
      ,[Telefono]
      ,[Activar] from tbl_c_administrador where Usuario like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Administrador]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Administrador]
AS
BEGIN TRAN
SELECT [Id_Administrador]
      ,[Usuario]
      ,[Clave]
      ,[Nombres]
      ,[Apellidos]
      ,[Correo]
      ,[FechaIngreso]
      ,[FechaModificacion]
      ,[Estado]
      ,[Ruta]
      ,[Telefono]
      ,Activar
  FROM tbl_c_administrador where Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Video]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_Video](@xmlDatos xml,@Id_Video int)
AS
Begin Tran
		Update tbl_c_videos
		set
			Titulo=x.value('@Titulo','nvarchar(max)'),
			Descripcion=x.value('@Descripcion','nvarchar(max)'),
			RutaVideo=x.value('@RutaVideo','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Video') R(x)
		where Id_Video = @Id_Video
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_SubCategoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Actualiza_SubCategoria](@xmlDatos xml,@Id_SubCategoria int)
AS
Begin Tran
		Update tbl_c_subcategoria
		set
			Titulo=x.value('@Titulo','nvarchar(max)'),
			Id_Categoria=x.value('@Id_Categoria','int'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_SubCategoria') R(x)
		where Id_SubCategoria = @Id_SubCategoria
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Slide]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Slide](@xmlDatos xml,@Id_Slide int)
AS
Begin Tran
		Update tbl_c_slide
		set
			Titulo=x.value('@Titulo','nvarchar(max)'),
			Descripcion=x.value('@Descripcion','nvarchar(max)'),
			Ruta=x.value('@Ruta','nvarchar(max)'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Slide') R(x)
		where Id_Slide = @Id_Slide
Commit Tran
GO
/****** Object:  Table [dbo].[tbl_c_provincia]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_provincia](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [nvarchar](max) NULL,
	[Id_Pais] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_provincia] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_provincia] ON
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (1, N'Guayas', 1, CAST(0x0000A14A000DE7FE AS DateTime), CAST(0x0000A17B013D39FE AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (2, N'Pichincha', 1, CAST(0x0000A14A000E6A0A AS DateTime), CAST(0x0000A14A000E6A0A AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (3, N'Azuay', 1, CAST(0x0000A156017D8E8C AS DateTime), CAST(0x0000A15601803786 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (4, N'Cañar', 1, CAST(0x0000A1570000DCBB AS DateTime), CAST(0x0000A1570000F932 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (5, N'Pichincha', 1, CAST(0x0000A16901785497 AS DateTime), CAST(0x0000A16901785497 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (6, N'Los Ríos', 1, CAST(0x0000A17F000868CD AS DateTime), CAST(0x0000A17F0008E63E AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (7, N'Esmeralda', 1, CAST(0x0000A17F0009227E AS DateTime), CAST(0x0000A17F0009227E AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_provincia] ([Id_Provincia], [Provincia], [Id_Pais], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (8, N'Lima', 4, CAST(0x0000A18201015F7E AS DateTime), CAST(0x0000A18201015F7E AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[tbl_c_provincia] OFF
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Productos]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Productos](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_producto(Titulo,Descripcion,Cantidad,Precio,Id_Categoria,Id_SubCategoria,Ruta,Activar)
SELECT 
		x.value('@Titulo','nvarchar(max)'),
		x.value('@Descripcion','nvarchar(max)'),
		x.value('@Cantidad','nvarchar(max)'),
		x.value('@Precio','decimal(18,2)'),
		x.value('@Id_Categoria','int'),
		x.value('@Id_SubCategoria','int'),
		x.value('@Ruta','nvarchar(max)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Productos') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Producto
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Pais]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Pais](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_pais(Pais,Aplicar)
SELECT 
		x.value('@Pais','nvarchar(max)'),
        x.value('@Aplicar','bit')
FROM @xmlDatos.nodes('/Ad_Pais') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Pais
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Marca]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Marca](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_marca(Marca,Activar)
SELECT 
        x.value('@Marca','nvarchar(max)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Marca') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Marca
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Info]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Info](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_info_empresa(Informacion,Id_pagina,Pagina,Titulo,DescripcionCorta,Activar)
SELECT 
        x.value('@Informacion','nvarchar(max)'),
		x.value('@Id_pagina','int'),
		x.value('@Pagina','nvarchar(max)'),
		x.value('@Titulo','nvarchar(max)'),
		x.value('@DescripcionCorta','nvarchar(max)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Info') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Empresa
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Imagenes]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Imagenes](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_imagenes_productos(Ruta,Ruta1,Ruta2,Rutas3,Id_Producto,Activar)
SELECT 
		x.value('@Ruta','nvarchar(max)'),
		x.value('@Ruta1','nvarchar(max)'),
		x.value('@Ruta2','nvarchar(max)'),
		x.value('@Rutas3','nvarchar(max)'),
		x.value('@Id_Producto','int'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Imagenes') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Imagenes
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Empresa]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Empresa](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_empresa(Empresa,Activar,Principal)
SELECT 
        x.value('@Empresa','nvarchar(max)'),
        x.value('@Activar','bit'),
        x.value('@Principal','bit')
FROM @xmlDatos.nodes('/Ad_Empresa') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Empresa
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Productos]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Productos](@Id_Producto int)
AS
BEGIN TRAN
update tbl_c_producto
set Estado = 2
where Id_Producto = @Id_Producto
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_C_valida_administrador]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_C_valida_administrador](@Usuario varchar(100), @Clave varchar(32))
AS
select * from tbl_c_administrador where Usuario = @Usuario and Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Video]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_Video](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_videos(Titulo,Descripcion,RutaVideo,Activar)
SELECT 
		x.value('@Titulo','nvarchar(max)'),
		x.value('@Descripcion','nvarchar(max)'),
		x.value('@RutaVideo','nvarchar(max)'),
        x.value('@Aplicar','bit')
FROM @xmlDatos.nodes('/Ad_Video') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Video
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_SubCategoria]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Ingresa_SubCategoria](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_subcategoria(Titulo,Id_Categoria,Activar)
SELECT 
        x.value('@Titulo','nvarchar(max)'),
        x.value('@Id_Categoria','int'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_SubCategoria') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_SubCategoria
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Slide]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Slide](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_slide(Titulo,Descripcion,Ruta,Activar)
SELECT 
		x.value('@Titulo','nvarchar(max)'),
		x.value('@Descripcion','nvarchar(max)'),
		x.value('@Ruta','nvarchar(max)'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Slide') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Slide
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Provincias]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Provincias](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_provincia(Provincia,Id_Pais,Activar)
SELECT 
		x.value('@Provincia','nvarchar(max)'),
        x.value('@Id_Pais','int'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Provincias') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Provincia
COMMIT TRAN
GO
/****** Object:  Table [dbo].[tbl_c_ciudad]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_ciudad](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad] [nvarchar](max) NULL,
	[Id_Provincia] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Activar] [bit] NULL,
 CONSTRAINT [PK_tbl_c_ciudad] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_ciudad] ON
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (1, N'Guayaquil', 1, CAST(0x0000A17F002D6F20 AS DateTime), CAST(0x0000A17F002D6F20 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (2, N'Milagro', 1, CAST(0x0000A17F002D7CFE AS DateTime), CAST(0x0000A17F002D7CFE AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (3, N'Daule', 1, CAST(0x0000A17F002D82CA AS DateTime), CAST(0x0000A17F002DEEFC AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (4, N'Durán', 1, CAST(0x0000A17F002DF715 AS DateTime), CAST(0x0000A17F002DFB76 AS DateTime), 1, 1)
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (5, N'Quito', 5, CAST(0x0000A182002C54D3 AS DateTime), CAST(0x0000A182002C54D3 AS DateTime), 2, 1)
INSERT [dbo].[tbl_c_ciudad] ([Id_Ciudad], [Ciudad], [Id_Provincia], [FechaIngreso], [FechaModificacion], [Estado], [Activar]) VALUES (6, N'Lima', 8, CAST(0x0000A18201017239 AS DateTime), CAST(0x0000A18201017239 AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[tbl_c_ciudad] OFF
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Pais_Provincia]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Pais_Provincia](@Id_Pais int)
AS
BEGIN TRAN
update tbl_c_provincia
set Estado = 2
where Id_Pais = @Id_Pais
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Provincias]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Provincias](@xmlDatos xml,@Id_Provincia int)
AS
Begin Tran
		Update tbl_c_provincia
		set
			Provincia=x.value('@Provincia','nvarchar(max)'),
			Id_Pais=x.value('@Id_Pais','int'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Provincias') R(x)
		where Id_Provincia = @Id_Provincia
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Activar_Provincia]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Activar_Provincia](@Id_Provincia int)
AS
BEGIN TRAN
update tbl_c_provincia
set Estado = 1
where Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_ProvinciaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_ProvinciaId](@Id_Provincia int)
AS
BEGIN TRAN
update tbl_c_provincia
set Estado = 2
where Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_ProvinciaId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_ProvinciaId](@Id_Provincia int)
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Id_Provincia = @Id_Provincia and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Provincia_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Provincia_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Provincia like @Letra+'%' and Estado = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Provincia_IdPais]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Provincia_IdPais](@Id_Pais int)
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Id_Pais = @Id_Pais and Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Provincia]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Provincia]
AS
BEGIN TRAN
select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Estado = 1

select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Estado = 2

select Id_Provincia,Provincia,Id_Pais,CONVERT(char(10),FechaIngreso,107) as FechaIngreso,Activar from tbl_c_provincia where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  Table [dbo].[tbl_c_costo_envio]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_c_costo_envio](
	[Id_Costo] [int] IDENTITY(1,1) NOT NULL,
	[Costo] [nvarchar](50) NULL,
	[Id_Ciudad] [int] NULL,
	[Activar] [bit] NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[Estado] [int] NULL,
	[Id_Empresa] [int] NULL,
 CONSTRAINT [PK_tbl_c_costo_envio] PRIMARY KEY CLUSTERED 
(
	[Id_Costo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_c_costo_envio] ON
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (20, N'20', 1, 1, CAST(0x0000A182002365B5 AS DateTime), CAST(0x0000A182002365B5 AS DateTime), 1, 3)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (21, N'20', 2, 1, CAST(0x0000A182002394BD AS DateTime), CAST(0x0000A182002394BD AS DateTime), 1, 3)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (22, N'20', 2, 1, CAST(0x0000A18200239CFD AS DateTime), CAST(0x0000A18200239CFD AS DateTime), 1, 4)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (23, N'12', 2, 1, CAST(0x0000A1820023A8D1 AS DateTime), CAST(0x0000A1820023A8D1 AS DateTime), 1, 5)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (24, N'20', 4, 1, CAST(0x0000A1820023B110 AS DateTime), CAST(0x0000A1820023B110 AS DateTime), 1, 5)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (25, N'23', 3, 1, CAST(0x0000A1820023C2AF AS DateTime), CAST(0x0000A1820023C2AF AS DateTime), 2, 3)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (26, N'20', 5, 1, CAST(0x0000A182002C679C AS DateTime), CAST(0x0000A182002C679C AS DateTime), 2, 3)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (27, N'10', 5, 1, CAST(0x0000A182002C6E60 AS DateTime), CAST(0x0000A182002C6E60 AS DateTime), 2, 4)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (28, N'30', 5, 1, CAST(0x0000A182002C78E8 AS DateTime), CAST(0x0000A182002C78E8 AS DateTime), 2, 5)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (29, N'20', 6, 1, CAST(0x0000A18201018B47 AS DateTime), CAST(0x0000A18201018B47 AS DateTime), 2, 3)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (30, N'30', 6, 1, CAST(0x0000A18201019144 AS DateTime), CAST(0x0000A18201019144 AS DateTime), 2, 4)
INSERT [dbo].[tbl_c_costo_envio] ([Id_Costo], [Costo], [Id_Ciudad], [Activar], [FechaIngreso], [FechaModificacion], [Estado], [Id_Empresa]) VALUES (31, N'40', 6, 1, CAST(0x0000A1820101990D AS DateTime), CAST(0x0000A1820101990D AS DateTime), 2, 5)
SET IDENTITY_INSERT [dbo].[tbl_c_costo_envio] OFF
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_CiudadId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_CiudadId](@Id_Ciudad int)
AS
BEGIN TRAN
select Id_Ciudad,Ciudad,Id_Provincia,CONVERT(char(15),FechaIngreso,106) as FechaIngreso,Activar from tbl_c_ciudad where Estado = 1 and Id_Ciudad = @Id_Ciudad

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Ciudad_Mostrar]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Ciudad_Mostrar]
AS
BEGIN TRAN
select Id_Ciudad,Ciudad,Id_Provincia,CONVERT(char(15),FechaIngreso,106) as FechaIngreso,Activar from tbl_c_ciudad where Estado = 1 and Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Ciudad_Letra]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Ciudad_Letra](@Letra nvarchar(50))
AS
BEGIN TRAN
select c.Id_Ciudad,c.Ciudad,c.Id_Provincia,CONVERT(char(15),c.FechaIngreso,106) as FechaIngreso,c.Activar,p.Provincia from tbl_c_ciudad as c, tbl_c_provincia as p where c.Estado = 1 and c.Id_Provincia = p.Id_Provincia and c.Ciudad like @Letra+'%'
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Ciudad_IdProvincia]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Ciudad_IdProvincia](@Id_Provincia int)
AS
BEGIN TRAN
select Id_Ciudad,Ciudad from tbl_c_ciudad where Estado = 1 and Activar = 1 and Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Ciudad]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Ciudad]
AS
BEGIN TRAN
select c.Id_Ciudad,c.Ciudad,c.Id_Provincia,CONVERT(char(15),c.FechaIngreso,106) as FechaIngreso,c.Activar,p.Provincia from tbl_c_ciudad as c, tbl_c_provincia as p where c.Estado = 1 and c.Id_Provincia = p.Id_Provincia

select c.Id_Ciudad,c.Ciudad,c.Id_Provincia,CONVERT(char(15),c.FechaIngreso,106) as FechaIngreso,c.Activar,p.Provincia from tbl_c_ciudad as c, tbl_c_provincia as p where c.Estado = 1 and c.Id_Provincia = p.Id_Provincia and c.Activar = 1
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Provincia_Cuidades]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Elimina_Provincia_Cuidades](@Id_Provincia int)
AS
BEGIN TRAN
update tbl_c_ciudad
set Estado = 2
where Id_Provincia = @Id_Provincia
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Ciudad]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Ciudad](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_ciudad(Ciudad,Id_Provincia,Activar)
SELECT 
        x.value('@Ciudad','nvarchar(max)'),
        x.value('@Id_Provincia','int'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Ciudades') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Ciudades]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Ciudades](@Id_Ciudad int)
AS
BEGIN TRAN
update tbl_c_ciudad
set Estado = 2
where Id_Ciudad = @Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Ciudad]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Ciudad](@xmlDatos xml,@Id_Ciudad int)
AS
Begin Tran
		Update tbl_c_ciudad
		set
			Ciudad=x.value('@Ciudad','nvarchar(max)'),
			Id_Provincia=x.value('@Id_Provincia','int'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Ciudades') R(x)
		where Id_Ciudad = @Id_Ciudad
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Activar_Ciudad]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Activar_Ciudad](@Id_Ciudad int)
AS
BEGIN TRAN
update tbl_c_ciudad
set Estado = 1
where Id_Ciudad = @Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Ingresa_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Ingresa_Costo](@xmlDatos xml)
AS
BEGIN TRAN
INSERT tbl_c_costo_envio(Costo,Id_Ciudad,Id_Empresa,Activar)
SELECT 
        x.value('@Costo','nvarchar(max)'),
        x.value('@Id_Ciudad','int'),
        x.value('@Id_Empresa','int'),
        x.value('@Activar','bit')
FROM @xmlDatos.nodes('/Ad_Costo') R(x)
--retorna el ID de Persona Generado
	select @@IDENTITY as Id_Costo
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Cuidades_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Elimina_Cuidades_Costo](@Id_Ciudad int)
AS
BEGIN TRAN
update tbl_c_costo_envio
set Estado = 2
where Id_Ciudad = @Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_CostoIdEmpresa]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_CostoIdEmpresa](@Id_Empresa int)
AS
BEGIN TRAN
--elimana logicamente de la tabla empresa
update tbl_c_costo_envio
set Estado = 2
where Id_Empresa = @Id_Empresa

COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Elimina_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Elimina_Costo](@Id_Costo int)
AS
BEGIN TRAN
update tbl_c_costo_envio
set Estado = 2
where Id_Costo = @Id_Costo
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Valide_CostoId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Consulta_Valide_CostoId](@Id_Costo int)
AS
BEGIN TRAN
SELECT Id_Costo FROM tbl_c_costo_envio where Estado = 1 and Id_Costo = @Id_Costo
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_CostoId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_CostoId](@Id_Costo int)
AS
BEGIN TRAN
SELECT [Id_Costo]
      ,[Costo]
      ,[Id_Ciudad]
      ,[Activar]
      ,CONVERT(char(15),FechaIngreso,106) as FechaIngreso
      ,[FechaModificacion]
      ,[Estado],Id_Empresa
  FROM tbl_c_costo_envio where Estado = 1 and Id_Costo = @Id_Costo
  
  --join
SELECT     tbl_c_costo_envio.Id_Costo, tbl_c_costo_envio.Costo, tbl_c_costo_envio.Id_Ciudad, tbl_c_costo_envio.Id_Empresa, tbl_c_provincia.Id_Provincia, tbl_c_pais.Id_Pais, 
                      tbl_c_costo_envio.Activar
FROM         tbl_c_costo_envio INNER JOIN
                      tbl_c_ciudad ON tbl_c_costo_envio.Id_Ciudad = tbl_c_ciudad.Id_Ciudad INNER JOIN
                      tbl_c_provincia ON tbl_c_ciudad.Id_Provincia = tbl_c_provincia.Id_Provincia INNER JOIN
                      tbl_c_pais ON tbl_c_provincia.Id_Pais = tbl_c_pais.Id_Pais
WHERE     (tbl_c_costo_envio.Id_Costo = @Id_Costo and tbl_c_costo_envio.Estado = 1)
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Costo_CiudadId]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Costo_CiudadId](@Id_Ciudad int, @Id_Empresa int)
AS
BEGIN TRAN
SELECT [Id_Costo] FROM tbl_c_costo_envio where Estado = 1 and Id_Ciudad = @Id_Ciudad and Id_Empresa = @Id_Empresa
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Consulta_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Consulta_Costo]
AS
BEGIN TRAN
SELECT c.Id_Costo
      ,c.Costo
      ,c.Id_Ciudad
      ,c.Activar
      ,CONVERT(char(15),c.FechaIngreso,106) as FechaIngreso
      ,c.FechaModificacion
      ,c.Estado,ciu.Ciudad
  FROM tbl_c_costo_envio as c, tbl_c_ciudad as ciu where c.Estado = 1 and c.Id_Ciudad = ciu.Id_Ciudad
  
SELECT c.Id_Costo
      ,c.Costo
      ,c.Id_Ciudad
      ,c.Activar
      ,CONVERT(char(15),c.FechaIngreso,106) as FechaIngreso
      ,c.FechaModificacion
      ,c.Estado,ciu.Ciudad
  FROM tbl_c_costo_envio as c, tbl_c_ciudad as ciu where c.Estado = 2 and c.Id_Ciudad = ciu.Id_Ciudad
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Actualiza_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_c_Actualiza_Costo](@xmlDatos xml,@Id_Costo int)
AS
Begin Tran
		Update tbl_c_costo_envio
		set
			Costo=x.value('@Costo','nvarchar(max)'),
			Id_Ciudad=x.value('@Id_Ciudad','int'),
			Id_Empresa=x.value('@Id_Empresa','int'),
			Activar=x.value('@Activar','bit'),
			FechaModificacion = GETDATE()
			FROM @xmlDatos.nodes('/Ad_Costo') R(x)
		where Id_Costo = @Id_Costo
Commit Tran
GO
/****** Object:  StoredProcedure [dbo].[sp_c_Activar_Costo]    Script Date: 03/21/2013 23:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_c_Activar_Costo](@Id_Costo int)
AS
BEGIN TRAN
update tbl_c_costo_envio
set Estado = 1
where Id_Costo = @Id_Costo
COMMIT TRAN
GO
/****** Object:  Default [DF_tbl_c_categoria_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_categoria] ADD  CONSTRAINT [DF_tbl_c_categoria_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_categoria_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_categoria] ADD  CONSTRAINT [DF_tbl_c_categoria_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_categoria_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_categoria] ADD  CONSTRAINT [DF_tbl_c_categoria_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbbl_c_administrador_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbbl_c_administrador_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbbl_c_administrador_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_administrador] ADD  CONSTRAINT [DF_tbbl_c_administrador_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Ciudad]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Ciudad]  DEFAULT ((0)) FOR [Id_Ciudad]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Provincia]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Provincia]  DEFAULT ((0)) FOR [Id_Provincia]
GO
/****** Object:  Default [DF_tbl_c_clientes_Id_Pais]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Id_Pais]  DEFAULT ((0)) FOR [Id_Pais]
GO
/****** Object:  Default [DF_tbl_c_clientes_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_clientes_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_clientes_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_clientes] ADD  CONSTRAINT [DF_tbl_c_clientes_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_videos_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_videos] ADD  CONSTRAINT [DF_tbl_c_videos_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_videos_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_videos] ADD  CONSTRAINT [DF_tbl_c_videos_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_videos_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_videos] ADD  CONSTRAINT [DF_tbl_c_videos_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_subcategoria_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_subcategoria] ADD  CONSTRAINT [DF_tbl_c_subcategoria_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_subcategoria_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_subcategoria] ADD  CONSTRAINT [DF_tbl_c_subcategoria_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_subcategoria_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_subcategoria] ADD  CONSTRAINT [DF_tbl_c_subcategoria_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_slide_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_slide_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_slide_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_slide] ADD  CONSTRAINT [DF_tbl_c_slide_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_producto_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_producto] ADD  CONSTRAINT [DF_tbl_c_producto_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_producto_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_producto] ADD  CONSTRAINT [DF_tbl_c_producto_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_producto_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_producto] ADD  CONSTRAINT [DF_tbl_c_producto_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_perfil_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_perfil] ADD  CONSTRAINT [DF_tbl_c_perfil_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_pais_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_pais_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_pais_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_pais] ADD  CONSTRAINT [DF_tbl_c_pais_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_menu_administrador_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu_administrador] ADD  CONSTRAINT [DF_tbl_c_menu_administrador_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_menu_administrador_FechaModifacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu_administrador] ADD  CONSTRAINT [DF_tbl_c_menu_administrador_FechaModifacion]  DEFAULT (getdate()) FOR [FechaModifacion]
GO
/****** Object:  Default [DF_tbl_c_menu_administrador_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu_administrador] ADD  CONSTRAINT [DF_tbl_c_menu_administrador_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_menu_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu] ADD  CONSTRAINT [DF_tbl_c_menu_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_menu_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu] ADD  CONSTRAINT [DF_tbl_c_menu_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_menu_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_menu] ADD  CONSTRAINT [DF_tbl_c_menu_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_marca_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_marca] ADD  CONSTRAINT [DF_tbl_c_marca_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_marca_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_marca] ADD  CONSTRAINT [DF_tbl_c_marca_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_marca_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_marca] ADD  CONSTRAINT [DF_tbl_c_marca_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_info_empresa_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_info_empresa] ADD  CONSTRAINT [DF_tbl_c_info_empresa_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_imagenes_productos_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_imagenes_productos] ADD  CONSTRAINT [DF_tbl_c_imagenes_productos_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_imagenes_productos_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_imagenes_productos] ADD  CONSTRAINT [DF_tbl_c_imagenes_productos_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_imagenes_productos_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_imagenes_productos] ADD  CONSTRAINT [DF_tbl_c_imagenes_productos_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_empresa_Estado]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_empresa] ADD  CONSTRAINT [DF_tbl_c_empresa_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_empresa_FechaIngreso]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_empresa] ADD  CONSTRAINT [DF_tbl_c_empresa_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_empresa_FechaModificacion]    Script Date: 03/21/2013 23:10:54 ******/
ALTER TABLE [dbo].[tbl_c_empresa] ADD  CONSTRAINT [DF_tbl_c_empresa_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_provincia_FechaIngreso]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_provincia_FechaModificacion]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_provincia_Estado]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_provincia] ADD  CONSTRAINT [DF_tbl_c_provincia_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_ciudad_FechaIngreso]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_ciudad_FechaModificacion]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_ciudad_Estado]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_ciudad] ADD  CONSTRAINT [DF_tbl_c_ciudad_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_tbl_c_costo_envio_FechaIngreso]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_costo_envio] ADD  CONSTRAINT [DF_tbl_c_costo_envio_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
/****** Object:  Default [DF_tbl_c_costo_envio_FechaModificacion]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_costo_envio] ADD  CONSTRAINT [DF_tbl_c_costo_envio_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
/****** Object:  Default [DF_tbl_c_costo_envio_Estado]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_costo_envio] ADD  CONSTRAINT [DF_tbl_c_costo_envio_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  ForeignKey [FK_tbl_c_provincia_tbl_c_pais]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_provincia]  WITH CHECK ADD  CONSTRAINT [FK_tbl_c_provincia_tbl_c_pais] FOREIGN KEY([Id_Pais])
REFERENCES [dbo].[tbl_c_pais] ([Id_Pais])
GO
ALTER TABLE [dbo].[tbl_c_provincia] CHECK CONSTRAINT [FK_tbl_c_provincia_tbl_c_pais]
GO
/****** Object:  ForeignKey [FK_tbl_c_ciudad_tbl_c_provincia]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_ciudad]  WITH CHECK ADD  CONSTRAINT [FK_tbl_c_ciudad_tbl_c_provincia] FOREIGN KEY([Id_Provincia])
REFERENCES [dbo].[tbl_c_provincia] ([Id_Provincia])
GO
ALTER TABLE [dbo].[tbl_c_ciudad] CHECK CONSTRAINT [FK_tbl_c_ciudad_tbl_c_provincia]
GO
/****** Object:  ForeignKey [FK_tbl_c_costo_envio_tbl_c_ciudad]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_costo_envio]  WITH CHECK ADD  CONSTRAINT [FK_tbl_c_costo_envio_tbl_c_ciudad] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[tbl_c_ciudad] ([Id_Ciudad])
GO
ALTER TABLE [dbo].[tbl_c_costo_envio] CHECK CONSTRAINT [FK_tbl_c_costo_envio_tbl_c_ciudad]
GO
/****** Object:  ForeignKey [FK_tbl_c_costo_envio_tbl_c_empresa]    Script Date: 03/21/2013 23:10:57 ******/
ALTER TABLE [dbo].[tbl_c_costo_envio]  WITH CHECK ADD  CONSTRAINT [FK_tbl_c_costo_envio_tbl_c_empresa] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[tbl_c_empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[tbl_c_costo_envio] CHECK CONSTRAINT [FK_tbl_c_costo_envio_tbl_c_empresa]
GO
