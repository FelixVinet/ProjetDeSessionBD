USE master
GO

CREATE DATABASE H22_4D5_Projet_session
GO
USE [H22_4D5_Projet_session]
GO
/****** Object:  Schema [Disponibilites]    ******/
CREATE SCHEMA [Disponibilites]
GO
/****** Object:  Schema [Photos]    ******/
CREATE SCHEMA [Photos]
GO
/****** Object:  Schema [Proprietes]    ******/
CREATE SCHEMA [Proprietes]
GO
/****** Object:  Schema [Utilisateurs]    ******/
CREATE SCHEMA [Utilisateurs]
GO



/****** Object:  Table [Disponibilites].[Disponibilite]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Disponibilites].[Disponibilite](
	[disponibiliteID] [int] IDENTITY(1,1) NOT NULL,
	[dateDisponibilite] [datetime2](7) NOT NULL,
	[photographeID] [int] NOT NULL,
	[heureDebut] [time](7) NOT NULL,
	[rendezVousID] [int] NULL,
	[statut] [nvarchar](30) NULL,
 CONSTRAINT [PK_disponibiliteID] PRIMARY KEY CLUSTERED 
(
	[disponibiliteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Disponibilites].[RendezVous]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Disponibilites].[RendezVous](
	[rendezVousID] [int] IDENTITY(1,1) NOT NULL,
	[dateRendezVous] [datetime2](7) NOT NULL,
	[commentaire] [nvarchar](250) NULL,
	[proprieteID] [int] NOT NULL,
	[heureDebut] [time](7) NOT NULL,
	[justification] [nvarchar](250) NULL,
	[statutPhoto] [nvarchar](30) NULL DEFAULT ('Aucune'),
	[commentairePhotos] [nvarchar](250) NULL,
 CONSTRAINT [PK_rendezVousID] PRIMARY KEY CLUSTERED 
(
	[rendezVousID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [Photos].[Photo]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Photos].[Photo](
	[photoID] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](100) NOT NULL,
	[rendezVousID] [int] NOT NULL,
 CONSTRAINT [PK_photoID] PRIMARY KEY CLUSTERED 
(
	[photoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Proprietes].[Propriete]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Proprietes].[Propriete](
	[proprieteID] [int] IDENTITY(1,1) NOT NULL,
	[adresse] [nvarchar](50) NOT NULL,
	[ville] [nvarchar](25) NOT NULL,
	[nomProprio] [nvarchar](50) NOT NULL,
	[telProprio] [nvarchar](11) NOT NULL,
	
 CONSTRAINT [PK_proprieteID] PRIMARY KEY CLUSTERED 
(
	[proprieteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [Utilisateurs].[Photographes]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Utilisateurs].[Photographes](
	[photographeID] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_photographeID] PRIMARY KEY CLUSTERED 
(
	[photographeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** INSERTS ******/

SET IDENTITY_INSERT [Disponibilites].[Disponibilite] ON 

INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (128, CAST(N'2021-05-25 00:00:00.0000000' AS DateTime2), 1, CAST(N'10:30:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (129, CAST(N'2021-05-26 00:00:00.0000000' AS DateTime2), 2, CAST(N'14:15:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (130, CAST(N'2021-04-26 00:00:00.0000000' AS DateTime2), 6, CAST(N'15:30:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (131, CAST(N'2021-05-26 00:00:00.0000000' AS DateTime2), 1, CAST(N'16:45:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (132, CAST(N'2021-05-27 00:00:00.0000000' AS DateTime2), 1, CAST(N'16:45:00' AS Time), 194, N'Occupé')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (133, CAST(N'2021-05-27 00:00:00.0000000' AS DateTime2), 1, CAST(N'18:00:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (134, CAST(N'2021-04-27 00:00:00.0000000' AS DateTime2), 6, CAST(N'19:15:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (135, CAST(N'2021-05-29 00:00:00.0000000' AS DateTime2), 1, CAST(N'08:00:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (136, CAST(N'2021-05-29 00:00:00.0000000' AS DateTime2), 1, CAST(N'09:15:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (137, CAST(N'2021-05-29 00:00:00.0000000' AS DateTime2), 1, CAST(N'10:30:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (138, CAST(N'2021-05-31 00:00:00.0000000' AS DateTime2), 1, CAST(N'13:00:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (139, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), 1, CAST(N'14:15:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (140, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), 1, CAST(N'16:45:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (141, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), 1, CAST(N'18:00:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (142, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), 1, CAST(N'19:15:00' AS Time), NULL, N'Libre')
INSERT [Disponibilites].[Disponibilite] ([disponibiliteID], [dateDisponibilite], [photographeID], [heureDebut], [rendezVousID], [statut]) VALUES (143, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), 1, CAST(N'20:30:00' AS Time), NULL, N'Libre')
SET IDENTITY_INSERT [Disponibilites].[Disponibilite] OFF
SET IDENTITY_INSERT [Disponibilites].[RendezVous] ON 


INSERT [Disponibilites].[RendezVous] ([rendezVousID], [dateRendezVous], [commentaire], [proprieteID], [heureDebut], [justification], [statutPhoto], [commentairePhotos]) VALUES (194, CAST(N'2021-05-27 00:00:00.0000000' AS DateTime2), N'Toutes les pièces', 45, CAST(N'16:45:00' AS Time), NULL, N'En attente', NULL)
SET IDENTITY_INSERT [Disponibilites].[RendezVous] OFF


SET IDENTITY_INSERT [Photos].[Photo] ON 
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (352, N'194_Arrière.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (357, N'194_ChambreDeBain.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (358, N'194_ChambreDeBain2.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (359, N'194_ChambreDesMaitres.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (360, N'194_ChambreEnfant1.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (361, N'194_ChambreEnfant2.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (362, N'194_Cinéma.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (363, N'194_Cuisine.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (364, N'194_Cuisine2.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (365, N'194_Devant.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (366, N'194_Hall d''entrée.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (367, N'194_Hall d''entrée2.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (368, N'194_PiscineIntérieur.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (369, N'194_SalleDeJeu.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (370, N'194_Salon.jpg', 194)
INSERT [Photos].[Photo] ([photoID], [nom], [rendezVousID]) VALUES (371, N'194_Salon2.jpg', 194)
SET IDENTITY_INSERT [Photos].[Photo] OFF
SET IDENTITY_INSERT [Proprietes].[Propriete] ON 

INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio] ) VALUES (24, N'943 Rue des Fuchsias', N'Sainte-Dorothée', N'Jean Dubu', N'5008150066')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (25, N'364 Rue Des Bremailles', N'Beauport', N'Marie Jean', N'5008880069')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (26, N'12828 Rue Berry', N'Pierrefonds', N'Florence Lebel', N'4006388006')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (27, N'3211 Rue Jean', N'Terrebonne', N'Hugo Saul', N'5008195046')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (28, N'721 Ch. de Covey Hill', N'Havelock', N'William Jean', N'4009560085')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (29, N'7600 Route 148', N'Pontiac', N'Maxime Lavy', N'5002003325')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (30, N'18 Ch. des Frênes', N'L''Ange-Gardien', N'Véronique Dube', N'4009658002')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (31, N'1248 Av. de l''Hôtel-de-Ville', N'Ville-Marie', N'Ariane Lara', N'4009980054')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (32, N'400 Place Orchard', N'Saint-Bruno', N'Anne Smith', N'4006940028')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (33, N'12410 Av. de St-Castin', N'Ahuntsic-Cartierville', N'Jasmine Baude', N'5008480023')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (34, N'1000 Rue de la Commune', N'Ville-Marie', N'Émilie Bédi', N'4009761223')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (35, N'350 Boul. De Maisonneuve', N'Ville-Marie', N'Jean Mironne', N'5008210031')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (36, N'28 Rue du Périgord', N'La Prairie', N'Olivier Bras', N'5005782004')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (37, N'24 Rue du Chardonneret', N'Brossard', N'Yolande Moris', N'4501233002')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (38, N'13 monchamp', N'St-Constant', N'Rich Man', N'4500080063')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (39, N'32 Rue d''Edimbourg', N'Candiac', N'Églantine Glandinette Desbi', N'4506004009')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (40, N'13 rang Petit Saint-Regis Nord', N'Saint-Constant', N'Christopher Pierre', N'4383009001')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (41, N'1251 rue Nielsen', N'Saint-Hubert', N'Yanick Bel', N'4500045007')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (42, N'36 rue de l''estoril', N'Candiac', N'Philip Lali', N'5147700777')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (43, N'12 rue du Domaine', N'Candiac', N'Jacques Desjardins', N'4508754121')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (44, N'225 rue Pierre-Gasnier', N'La Prairie', N'Jean-Claude Apollo', N'4501004567')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (45, N'5 rue de Dublin', N'Candiac', N'Vergil Lamothe', N'4506003005')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (46, N'708 avenue Grosvenor', N'Montréal', N'Hector Lavoie', N'5009457009')
INSERT [Proprietes].[Propriete] ([proprieteID], [adresse], [ville], [nomProprio], [telProprio]) VALUES (47, N'212 rue baudelaire', N'Catherine', N'Paul', N'4504400058')
SET IDENTITY_INSERT [Proprietes].[Propriete] OFF



SET IDENTITY_INSERT [Utilisateurs].[Photographes] ON 
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (1, N'Vincent Guy')
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (2, N'Benjamin Desjardin')
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (5, N'Lara Lawetz')
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (6, N'Dom Lawetz')
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (7, N'Yves Dube')
INSERT [Utilisateurs].[Photographes] ([photographeID], [nom]) VALUES (8, N'Albert Inkel')
SET IDENTITY_INSERT [Utilisateurs].[Photographes] OFF


/****** Object:  Index [UC_photographe_date_heure]    ******/
ALTER TABLE [Disponibilites].[Disponibilite] ADD  CONSTRAINT [UC_photographe_date_heure] UNIQUE NONCLUSTERED 
(
	[photographeID] ASC,
	[dateDisponibilite] ASC,
	[heureDebut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** TODO Object:  Index [IX_dispo_photographeID]   ******/

Create Nonclustered index IX_dispo_photographeID
on [Disponibilites].[Disponibilite]
(
rendezVousID asc
)

/****** Object:  Index [IX_dispo_rdvID]    ******/
CREATE NONCLUSTERED INDEX [IX_dispo_rdvID] ON [Disponibilites].[Disponibilite]
(
	[rendezVousID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** TODO Object:  Index [IX_rv_proprieteID]    ******/
Create Nonclustered index IX_rv_proprieteID
on [Disponibilites].[RendezVous]
(
proprieteID asc
)


	
/****** Object:  Index [IX_Photo_RendezVousID]    ******/
CREATE NONCLUSTERED INDEX [IX_Photo_RendezVousID] ON [Photos].[Photo]
(
	[rendezVousID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


/****** ALTER TABLE  ******/
	
ALTER TABLE [Disponibilites].[Disponibilite]  WITH CHECK ADD  CONSTRAINT [FK_photographeID] FOREIGN KEY([photographeID])
REFERENCES [Utilisateurs].[Photographes] ([photographeID])
GO


/****** TODO ALTER TABLE: les entités Disponibilite et Photographe  ******/



ALTER TABLE [Disponibilites].[Disponibilite]  WITH CHECK ADD  CONSTRAINT [FK_rendezVousID] FOREIGN KEY([rendezVousID])
REFERENCES [Disponibilites].[RendezVous] ([rendezVousID])
GO
ALTER TABLE [Disponibilites].[Disponibilite] CHECK CONSTRAINT [FK_rendezVousID]
GO
ALTER TABLE [Disponibilites].[RendezVous]  WITH CHECK ADD  CONSTRAINT [FK_proprieteID] FOREIGN KEY([proprieteID])
REFERENCES [Proprietes].[Propriete] ([proprieteID])
GO
ALTER TABLE [Disponibilites].[RendezVous] CHECK CONSTRAINT [FK_proprieteID]
GO

/****** TODO ALTER TABLE: les entités Photo et RendezVous  ******/

ALTER TABLE Photos.Photo 
ADD
CONSTRAINT FK_Photo_RendezVousID 
FOREIGN KEY (rendezVousID ) REFERENCES Disponibilites.RendezVous




ALTER TABLE [Photos].[Photo] CHECK CONSTRAINT [FK_Photo_rendezVousID]
GO


ALTER TABLE [Disponibilites].[Disponibilite]  WITH CHECK ADD  CONSTRAINT [CHK_Disponibilite_HeureDebut] CHECK  (([heureDebut]='20:30' OR [heureDebut]='19:15' OR [heureDebut]='18:00' OR [heureDebut]='16:45' OR [heureDebut]='15:30' OR [heureDebut]='14:15' OR [heureDebut]='13:00' OR [heureDebut]='11:45' OR [heureDebut]='10:30' OR [heureDebut]='9:15' OR [heureDebut]='8:00'))
GO
ALTER TABLE [Disponibilites].[Disponibilite] CHECK CONSTRAINT [CHK_Disponibilite_HeureDebut]
GO
ALTER TABLE [Disponibilites].[RendezVous]  WITH CHECK ADD  CONSTRAINT [CHK_RendezVous_HeureDebut] CHECK  (([heureDebut]='20:30' OR [heureDebut]='19:15' OR [heureDebut]='18:00' OR [heureDebut]='16:45' OR [heureDebut]='15:30' OR [heureDebut]='14:15' OR [heureDebut]='13:00' OR [heureDebut]='11:45' OR [heureDebut]='10:30' OR [heureDebut]='9:15' OR [heureDebut]='8:00'))
GO
ALTER TABLE [Disponibilites].[RendezVous] CHECK CONSTRAINT [CHK_RendezVous_HeureDebut]
GO
ALTER TABLE [Photos].[Photo]  WITH CHECK ADD  CONSTRAINT [CHK_Photos_NomFichier] CHECK  (([nom] like '[0-9]_%.jpg' OR [nom] like '[0-9]_%.png' OR [nom] like '[0-9]_%.jpeg'))
GO
ALTER TABLE [Photos].[Photo] CHECK CONSTRAINT [CHK_Photos_NomFichier]
GO

/****** TODO Object:  UserDefinedFunction setHeureFin ******/

Create function Disponibilites.ufnCalcHeureFin(@HeureDebut time(7)) returns time(7)
as 
begin
	Declare @heure time(7)
	select @heure = DATEADD(minute,45,@HeureDebut)
		return @heure
end
go


/****** TODO Requête: fonction   ******/


alter table Disponibilites.Disponibilite
add HeureFin as Disponibilites.ufnCalcHeureFin(heureDebut);
go
alter table Disponibilites.RendezVous
add HeureFin as Disponibilites.ufnCalcHeureFin(heureDebut);
go


/****** TODO Object:  Procédure stockée    ******/

Create Procedure Disponibilites.uspStatutDispo
@id int,
@dateDebut datetime2(7),
@dateFin datetime2(7)
as
set nocount on;
select d.photographeID, d.dateDisponibilite 
from Disponibilites.Disponibilite d
where d.photographeID = @id and d.dateDisponibilite  < @dateFin and d.dateDisponibilite >@dateDebut
go

/****** TODO Interrogation: procédure stockée   ******/
exec Disponibilites.uspStatutDispo @id = 2, @dateDebut = '2021-04-26 00:00:00.0000000' ,@dateFin = '2021-06-26 00:00:00.0000000'
go

/****** TODO Object:  Procédure stockée    ******/

Create Procedure Disponibilites.uspListRDV
@id int,
@dateDebut datetime2(7),
@dateFin datetime2(7)
as
set nocount on;
select rdv.rendezVousID,rdv.dateRendezVous,rdv.commentaire,rdv.proprieteID,rdv.heureDebut,rdv.justification,rdv.statutPhoto,rdv.commentairePhotos,rdv.HeureFin
from Disponibilites.RendezVous rdv
inner join Disponibilites.Disponibilite d
on d.rendezVousID = rdv.rendezVousID
where d.photographeID = @id and rdv.dateRendezVous  < @dateFin and rdv.dateRendezVous >@dateDebut
go

/****** TODO Interrogation: procédure stockée   ******/
exec Disponibilites.uspListRDV @id = 1, @dateDebut = '2021-04-26 00:00:00.0000000' ,@dateFin = '2022-06-26 00:00:00.0000000'
go




/****** TODO Object:  Trigger trg_addRendezVous   ******/

create trigger Disponibilites.trg_addRendezVous
on Disponibilites.RendezVous
after Insert
as 
begin
	declare @heure time(7), @date datetime2(7), @id int
	Select @heure = heureDebut, @date = dateRendezVous, @id=rendezVousID from inserted;
	begin
		update Disponibilites.Disponibilite
		set rendezVousID = @id, statut = 'À confirmer'
		where @heure = heureDebut and @date=dateDisponibilite
		update Disponibilites.RendezVous
		set statutPhoto = 'en attente'
		where rendezVousID = @id
	end
end
go
SET IDENTITY_INSERT [Disponibilites].[RendezVous] ON 
INSERT [Disponibilites].[RendezVous] ([rendezVousID], [dateRendezVous], [commentaire], [proprieteID], [heureDebut], [justification], [statutPhoto], [commentairePhotos]) VALUES (196, CAST(N'2021-06-02 00:00:00.0000000' AS DateTime2), N'Toutes les pièces', 45, CAST(N'16:45:00' AS Time), NULL, N'En attente', NULL)
INSERT [Disponibilites].[RendezVous] ([rendezVousID], [dateRendezVous], [commentaire], [proprieteID], [heureDebut], [justification], [statutPhoto], [commentairePhotos]) VALUES (420, CAST(N'2021-08-30 00:00:00.0000000' AS DateTime2), N'Toutes les pièces', 45, CAST(N'10:30:00' AS Time), NULL, N'En attente', NULL)
SET IDENTITY_INSERT [Disponibilites].[RendezVous] OFF
go

/****** TODO Object:  Trigger trg_deleteRDV    ******/

create trigger Disponibilites.trg_deleteRDV
on Disponibilites.RendezVous
Instead of Delete
as 
begin
	declare @heure time(7), @date datetime2(7), @id int
	Select @heure = heureDebut, @date = dateRendezVous, @id=rendezVousID from deleted;
	begin
		update Disponibilites.Disponibilite
		set rendezVousID = Null, statut = 'Libre'
		where @heure = heureDebut and @date=dateDisponibilite;
		Delete Disponibilites.RendezVous where rendezVousID = @id;
		Delete Photos.Photo where rendezVousID = @id;
	end
end
go
Delete Disponibilites.RendezVous where rendezVousID = 196;
go


/****** TODO Object:  Trigger trg_AjoutPhoto    ******/
create trigger Photos.trg_AjoutPhoto 
on Photos.photo
for Insert
as 
begin
	declare @id int
	Select  @id=rendezVousID from inserted;
	begin
		update Disponibilites.RendezVous
		set statutPhoto = 'réalisée'
		where rendezVousID = @id
		update Disponibilites.Disponibilite
		set statut = 'Complèté'
		where rendezVousID = @id
	end
end
go
SET IDENTITY_INSERT Photos.Photo ON 
INSERT Photos.Photo([photoId], [nom], [rendezVousID]) VALUES (420, '420_PhotoDrole.jpg',420)
SET IDENTITY_INSERT Photos.Photo OFF