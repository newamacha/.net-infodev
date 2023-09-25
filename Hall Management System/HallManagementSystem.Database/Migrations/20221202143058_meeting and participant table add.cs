using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HallManagementSystem.Database.Migrations
{
    public partial class meetingandparticipanttableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingTopic = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMeeting_tbHall_HallId",
                        column: x => x.HallId,
                        principalTable: "tbHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMeetingParticipantDetails",
                columns: table => new
                {
                    Participant_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMeetingParticipantDetails", x => x.Participant_Id);
                    table.ForeignKey(
                        name: "FK_tbMeetingParticipantDetails_tbMeeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "tbMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbMeeting_HallId",
                table: "tbMeeting",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMeetingParticipantDetails_MeetingId",
                table: "tbMeetingParticipantDetails",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbMeetingParticipantDetails");

            migrationBuilder.DropTable(
                name: "tbMeeting");
        }
    }
}
