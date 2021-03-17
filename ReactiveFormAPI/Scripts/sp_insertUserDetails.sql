USE [ReactiveFormDB]
GO

/****** Object:  StoredProcedure [dbo].[insert_userDetails]    Script Date: 2021/03/16 15:57:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[insert_userDetails] @email nvarchar(150), @password nvarchar(150), @imageBase64 varchar(max)
as

begin

if not exists (select email from [user] where email = @email)

insert into [user](email, password, image)
values (@email, @password, @imageBase64)

else

raiserror('Email Already Exists', 16, 1)

end;

GO