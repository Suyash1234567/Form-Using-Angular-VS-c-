/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [EnrollmentId]
      ,[StateId]
      ,[CityId]
      ,[ConstituencyId]
      ,[WardNumberId]
      ,[EnrollerName]
      ,[FatherName]
      ,[DOB]
      ,[Email]
      ,[PhoneNumber]
      ,[DateCreated]
      ,[EnrollmentNumber]
  FROM [MyDotnetDataBase].[dbo].[VoterEnrollment]

 select * from VoterEnrollment;



