using Microsoft.EntityFrameworkCore.Migrations;

namespace FanSite.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaRefs",
                columns: table => new
                {
                    MediaRefID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceName = table.Column<string>(nullable: true),
                    LinkURL = table.Column<string>(nullable: true),
                    MediaType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRefs", x => x.MediaRefID);
                });

            migrationBuilder.CreateTable(
                name: "UserStories",
                columns: table => new
                {
                    UserStoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoryPost = table.Column<string>(maxLength: 2000, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStories", x => x.UserStoryID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CommentText = table.Column<string>(maxLength: 2000, nullable: false),
                    UserStoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_UserStories_UserStoryID",
                        column: x => x.UserStoryID,
                        principalTable: "UserStories",
                        principalColumn: "UserStoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserStoryID",
                table: "Comments",
                column: "UserStoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MediaRefs");

            migrationBuilder.DropTable(
                name: "UserStories");
        }
    }
}
