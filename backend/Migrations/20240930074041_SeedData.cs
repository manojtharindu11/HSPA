using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @UserID INT;

                --------------------------
                -- Create User
                --------------------------
                IF NOT EXISTS (SELECT Id FROM Users WHERE Username = 'Demo')
                BEGIN
                    INSERT INTO Users (Username, Password, PasswordKey, LastUpdatedOn, LastUpdatedBy)
                    VALUES (
                        'Demo',
                        0x4D5544D09B8319B423F6D4E054360D5289B57A98781A66B276E00C57919FDCD599BF45623D48CC81F535748F560AF0F70C8C7F3B4C3DB672562B5DD0E5E7C297,
                        0x44A0BD5BFD689DF399346200A1117C33BEDF5869C17A7CB3DC6D8598A93845DB333B379AA90931D8D4E5F2CC7B1A4A96A7DB71B186DBCDCDC53B0A95440E4EDD7473668627970FBD9BB0BA17530CCAB2D9446A1902BD6AC12FE691FE09DD78A43398B89111056145843060026A414FFA8C5E75B474E187AD753D2872038D9FDD,
                        GETDATE(),
                        0
                    );
                    SET @UserID = (SELECT Id FROM Users WHERE Username = 'Demo');
                END

                --------------------------
                -- Seed Property Types
                --------------------------
                IF NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'House')
                BEGIN
                    INSERT INTO PropertyTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('House', GETDATE(), @UserID);
                END

                IF NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'Apartment')
                BEGIN
                    INSERT INTO PropertyTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('Apartment', GETDATE(), @UserID);
                END

                IF NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'Duplex')
                BEGIN
                    INSERT INTO PropertyTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('Duplex', GETDATE(), @UserID);
                END

                --------------------------
                -- Seed Furnishing Types
                --------------------------
                IF NOT EXISTS (SELECT Name FROM FurnishingTypes WHERE Name = 'Fully')
                BEGIN
                    INSERT INTO FurnishingTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('Fully', GETDATE(), @UserID);
                END

                IF NOT EXISTS (SELECT Name FROM FurnishingTypes WHERE Name = 'Semi')
                BEGIN
                    INSERT INTO FurnishingTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('Semi', GETDATE(), @UserID);
                END

                IF NOT EXISTS (SELECT Name FROM FurnishingTypes WHERE Name = 'Unfurnished')
                BEGIN
                    INSERT INTO FurnishingTypes (Name, LastUpdatedOn, LastUpdatedBy)
                    VALUES ('Unfurnished', GETDATE(), @UserID);
                END

                --------------------------
                -- Seed Cities
                --------------------------
                IF NOT EXISTS (SELECT TOP 1 Id FROM Cities)
                BEGIN
                    INSERT INTO Cities (Name, LastUpdatedBy, LastUpdatedOn, Country)
                    VALUES 
                        ('New York', @UserID, GETDATE(), 'USA'),
                        ('Houston', @UserID, GETDATE(), 'USA'),
                        ('Los Angeles', @UserID, GETDATE(), 'USA'),
                        ('New Delhi', @UserID, GETDATE(), 'India'),
                        ('Bangalore', @UserID, GETDATE(), 'India');
                END

                --------------------------
                -- Seed Properties for Sell
                --------------------------
                IF NOT EXISTS (SELECT TOP 1 Name FROM Properties WHERE Name = 'White House Demo')
                BEGIN
                    INSERT INTO Properties (SellRent, Name, PropertyTypeId, BHK, FurnishingTypeId, Price, BuiltArea, CarpetArea, Address, Address2, CityId, FloorNo, TotalFloors, ReadyToMove, MainEntrance, Security, Gated, Maintenance, EstPossessionOn, Age, Description, PostedOn, PostedBy, LastUpdatedOn, LastUpdatedBy)
                    VALUES 
                        (1, 'White House Demo', (SELECT Id FROM PropertyTypes WHERE Name = 'Apartment'), 2, (SELECT Id FROM FurnishingTypes WHERE Name = 'Fully'), 1800, 1400, 900, '6 Street', 'Golf Course Road', (SELECT TOP 1 Id FROM Cities), 3, 3, 1, 'East', 0, 1, 300, '2019-01-01', 0, 'Well Maintained builder floor available for rent at prime location...', GETDATE(), @UserID, GETDATE(), @UserID);
                END

                --------------------------
                -- Seed Properties for Rent
                --------------------------
                IF NOT EXISTS (SELECT TOP 1 Name FROM Properties WHERE Name = 'Birla House Demo')
                BEGIN
                    INSERT INTO Properties (SellRent, Name, PropertyTypeId, BHK, FurnishingTypeId, Price, BuiltArea, CarpetArea, Address, Address2, CityId, FloorNo, TotalFloors, ReadyToMove, MainEntrance, Security, Gated, Maintenance, EstPossessionOn, Age, Description, PostedOn, PostedBy, LastUpdatedOn, LastUpdatedBy)
                    VALUES 
                        (2, 'Birla House Demo', (SELECT Id FROM PropertyTypes WHERE Name = 'Apartment'), 2, (SELECT Id FROM FurnishingTypes WHERE Name = 'Fully'), 1800, 1400, 900, '6 Street', 'Golf Course Road', (SELECT TOP 1 Id FROM Cities), 3, 3, 1, 'East', 0, 1, 300, '2019-01-01', 0, 'Well Maintained builder floor available for rent at prime location...', GETDATE(), @UserID, GETDATE(), @UserID);
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DECLARE @UserID INT;
                SET @UserID = (SELECT Id FROM Users WHERE Username = 'Demo');

                DELETE FROM Properties WHERE PostedBy = @UserID;
                DELETE FROM PropertyTypes WHERE LastUpdatedBy = @UserID;
                DELETE FROM FurnishingTypes WHERE LastUpdatedBy = @UserID;
                DELETE FROM Cities WHERE LastUpdatedBy = @UserID;
                DELETE FROM Users WHERE Username = 'Demo';
            ");
        }
    }
}
