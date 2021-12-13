USE [Softbase]
GO

DELETE FROM [web].[__EFMigrationsHistory]
      WHERE MigrationId in ('20211203143755_Added_Priority', '20211203143855_Added_Lead', '20211209211310_Regenerated_LeadStatus4607',
 '20211210163028_Regenerated_LeadStatus5168',
'20211210171251_Added_OpportunityStage',
'20211210171936_Added_OpportunityType',
'20211210173937_Added_Opportunity')
GO


