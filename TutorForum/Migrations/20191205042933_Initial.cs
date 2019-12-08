using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorForum.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAQuestions",
                columns: table => new
                {
                    FAQuestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    QuestionHeader = table.Column<string>(nullable: true),
                    QuestionBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQuestions", x => x.FAQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    TutorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.TutorID);
                });

            migrationBuilder.CreateTable(
                name: "ForumQuestions",
                columns: table => new
                {
                    ForumQuestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionerMemberID = table.Column<int>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    QuestionHeader = table.Column<string>(nullable: true),
                    QuestionBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumQuestions", x => x.ForumQuestionID);
                    table.ForeignKey(
                        name: "FK_ForumQuestions_Members_QuestionerMemberID",
                        column: x => x.QuestionerMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionPostForumQuestionID = table.Column<int>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    ResponderMemberID = table.Column<int>(nullable: true),
                    ReplyBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK_Replies_ForumQuestions_QuestionPostForumQuestionID",
                        column: x => x.QuestionPostForumQuestionID,
                        principalTable: "ForumQuestions",
                        principalColumn: "ForumQuestionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replies_Members_ResponderMemberID",
                        column: x => x.ResponderMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumQuestions_QuestionerMemberID",
                table: "ForumQuestions",
                column: "QuestionerMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_QuestionPostForumQuestionID",
                table: "Replies",
                column: "QuestionPostForumQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ResponderMemberID",
                table: "Replies",
                column: "ResponderMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQuestions");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "ForumQuestions");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
