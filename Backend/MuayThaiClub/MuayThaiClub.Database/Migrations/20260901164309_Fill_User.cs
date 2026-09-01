using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuayThaiClub.Database.Migrations
{
    /// <inheritdoc />
    public partial class Fill_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.Sql(@"
                INSERT INTO [User] (AppUserID, PhotoUrl, DateOfBirth)
                SELECT ID, '', ISNULL(DateOfBirth, '0001-01-01')
                FROM AspNetUsers 
                WHERE NOT EXISTS (SELECT AppUserID FROM [User])
    ");
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
