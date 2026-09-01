using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuayThaiClub.Database.Migrations
{
  /// <inheritdoc />
  public partial class User_Update : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "EmailAddress",
          table: "User",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.AddColumn<string>(
          name: "UserName",
          table: "User",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.Sql(@"
            UPDATE u
SET u.UserName = a.UserName,
    u.EmailAddress = a.Email
FROM [User] u
INNER JOIN AspNetUsers a ON u.AppUserID = a.Id
WHERE u.UserName IS NULL OR u.EmailAddress IS NULL OR u.UserName = '';
          ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "EmailAddress",
          table: "User");

      migrationBuilder.DropColumn(
          name: "UserName",
          table: "User");
    }
  }
}
