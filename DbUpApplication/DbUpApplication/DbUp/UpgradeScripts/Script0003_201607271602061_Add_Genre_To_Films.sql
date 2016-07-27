CREATE TABLE [dbo].[Actors] (
    [ActorId] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.Actors] PRIMARY KEY ([ActorId])
)
CREATE TABLE [dbo].[FilmActors] (
    [Film_FilmId] [uniqueidentifier] NOT NULL,
    [Actor_ActorId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.FilmActors] PRIMARY KEY ([Film_FilmId], [Actor_ActorId])
)
CREATE INDEX [IX_Film_FilmId] ON [dbo].[FilmActors]([Film_FilmId])
CREATE INDEX [IX_Actor_ActorId] ON [dbo].[FilmActors]([Actor_ActorId])
ALTER TABLE [dbo].[FilmActors] ADD CONSTRAINT [FK_dbo.FilmActors_dbo.Films_Film_FilmId] FOREIGN KEY ([Film_FilmId]) REFERENCES [dbo].[Films] ([FilmId]) ON DELETE CASCADE
ALTER TABLE [dbo].[FilmActors] ADD CONSTRAINT [FK_dbo.FilmActors_dbo.Actors_Actor_ActorId] FOREIGN KEY ([Actor_ActorId]) REFERENCES [dbo].[Actors] ([ActorId]) ON DELETE CASCADE
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201607271611438_Add_Actors', N'DbUpApplication.Migrations.Configuration',  0x1F8B0800000000000400DD1ACB6EE336F05EA0FF20E8D416592BC95EDAC0DE45EA248BA09B6411278BDE0C5AA21DA214A58A5460A3E897F5D04FEA2F74A89745529425DB89D3224060939CE1BC6738E37FFEFA7BF8711952E719279C446CE49E0C8E5D07333F0A085B8CDC54CCDFFDE87EFCF0ED37C3CB205C3A5FCB73EFE53980647CE43E09119F791EF79F7088F820247E12F1682E067E147A2888BCD3E3E39FBC93130F030A177039CEF03E65828438FB025FC711F3712C52446FA200535EACC3CE24C3EADCA210F318F978E45ECC1EE3F338A6C4470268196410AE734E0902622698CE5D073116896CFBEC91E3894822B698C4B080E8C32AC6706E8E28C7050B67EBE35DB9393E95DC786BC012959F7211853D119EBC2FC4E3E9E05B09D9ADC40702BC04418B95E43A13E2C83DF74594B88E7ED3D99826F29445C0830CECC8D1368F2A9300CB917F47CE38A5224DF088E15424881E395FD2191CFF05AF1EA2DF301BB194D23A854023EC290BB0F42589629C88D53D9ED7E9BE0E5CC753813D1DBA82D50173F63EA5043EDF021568467165095E2B0EF9BF4400E604CEE13A3768F919B385781AB9F0D175AEC81207E54A81F59111F0250012496A5E728B9EC92293A376DD15A121779D7B4CB35DFE44E2DCB40772679A7104FB574914DE47B4002896A70F28596001D446E6DE244A135F2364E8AD6DA4D57224A2FE8623A10E6937F2FE6DCCA6847B7356A35D7281B99F90388F162F7CD727CC92D7F483D2D0B77384D2D89B1CA17492AD1DE11E0892DC6FE30E39ECA19D22A7625BD75843EFE020A5107314D74CBC3FED8D631C852166E2C56D7F9B78D01AE0AD669D4B659A9F514DBBB6D568DEF5FD3E267ECE79E4938C981A85A57FA94C5DB2C06971B65C0B252FA0083061226D1CAE1DB93F18326A465725B135BAA27069C537F46A9C6C66B02EE936AA1AC5AE325A9A723F769BF4B5418227AEEEDE77EC02532CB00312CA4ACE31E23E0A4C7304E507EA0A44049C80F740610C35388718439830C307613E89116D275C03EB918C2569D525FACE058E310B80C6767DEC767B758926B04DF2B1DA5BEE66002300022735022E6672152F4543EE80C74A913E78119474E39158275868F971EDD4AAAF18B6A7821765A6019D9B5D07E05C0F3614A54B68886A1253B155E9BC76A221DBEBCA6B8F4715D915BB86F6DB23500D41499FEE562A471DB955A27C33C7D6F0D42940699C57BADAC07F5348DA24C416119419A77285F5DBDECB1FF76513C0B374018637288E25E96BC862C599E42D81F1BB49FF877298E3F07CDEF05EAEA8AD6E02CDA305D67665F511E02B92707181049A2159038C83D038A63ABEC5B1CABB14DF3695557A5A795C7E2E9E02F6977B437C2CE0AF802F5940652C62DDDA4DB8AC2983284A6CCFEC7144D390B53EDADBF0E48FA63A927CC5C430F434168CB06E08CBC887AAE83B2926F780DDF5D2E4D61DD4D20C66936699F2EAF2B4A5C17DE8C4864179A5D611291BDDF1152FD13AA662E94DD9491974F7632D4542DDCE666CC06D96B37EE4E9F6637B3CB6612CEB813AAEE61AA10D4BF5DEABA3A916BBE3E9E7192F6D436AFE340DA9AA8DBAD84975B8C90E1AC3BAAC011AE4A31553A6547A49766AAFBF6BD7F7A3CCFAF6E899A3A6D64C65274EAF7A4CC51AC58F7EA432ABAA08D28A9D6151786C9E8B1895487EC47580F66712C82A64B2E2028703796030F99D8E29C97CA63C70831899632EF2D6927B7A7C72AACD55DECE8CC3E33CA05D061D079C34A48CFC9E62229F95644E70B253FF983DA3C47F42C977215A7E5FC764F6AEFA35F40FD6523F94783AB5D077C2A7B4C95F4A714DF9FC50CDDF9D55A93682898C4ABBB58177D2DF263B35FA36D72CC0CB91FB47067FE65CFF5AA4BA23E72E81C07AE61C3B7F6EE0A897EEB70E6DED69D8120A6DB9B19BAD4CF724CDFE22B504E8E9C630DD812205D31ED4DCDA806FACBFB4B6CDEBF68DD5BB8B6EA34640977EFD2E2DE8D76C38DB7A287D3D6CFF8DE676C3692A8F6BCA3315D7A8B4FF95E9745765CB93E0858C67E353E495CCA7EB5CEC9041472D197ACFE1FE1361C7DAF07983B32DB3136EE992A9BF43B38DAEF2D7EBC80D6611E838CFA796F94BD364CA3AD56AC2DB3CD3B00FBC36CCBB6C575826308D17D9A453DBB35D6391D2A6B15B35376A9DBE595A41465CD01BD69BA64E0ABF5AAF6A3FF3367DAED7CE66735FC94C9DC6BCE4F08CEE75B0D85F93AA8BE8EDE717191C9A3D32886EB55F18436CE564B146217F6FCCB0AFC4B5EACC359B476578D5282A8F68AF8A1B2C500041EF3C810704F2056CFB98F38CDDAF88A670E4329CE1E09ADDA5224E05B08CC3195DD58521C374DBFDD97454A5797897752CF83E58003209B080EFD8CF29A14145F755C30BC68242C6FF4F18D6735D423A1178B1AA30DD46AC23A2427C55DA7AC0614C0119BF6313F48CB7A1ED91E3CF7881FC55D9EAB423D9AC0855ECC30B8216090A7981630D0F5FC1868370F9E15FFD4FF2FF682F0000 , N'6.1.3-40302')