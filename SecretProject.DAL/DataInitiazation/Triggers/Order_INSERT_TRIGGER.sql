CREATE TRIGGER Order_INSERT_TRIGGER ON Orders
    AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
                  
    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
    
    DECLARE @Id INT
        
    SELECT @Id = INSERTED.Id
    FROM INSERTED
          
    UPDATE dbo.Orders
    SET DateCreated = GETDATE()
    WHERE Id = @Id
END