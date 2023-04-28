using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingAppQa.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory",
                table: "Scope");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory",
                table: "Tools");

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory1",
                table: "Tools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory",
                table: "TimeOut",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory",
                table: "TestCase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory",
                table: "TaskReview",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory1",
                table: "Scope",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory1",
                table: "Risk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserHistoryIdUserHistory",
                table: "ConsolidationReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_UserHistoryIdUserHistory1",
                table: "Tools",
                column: "UserHistoryIdUserHistory1");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOut_UserHistoryIdUserHistory",
                table: "TimeOut",
                column: "UserHistoryIdUserHistory");

            migrationBuilder.CreateIndex(
                name: "IX_TestCase_UserHistoryIdUserHistory",
                table: "TestCase",
                column: "UserHistoryIdUserHistory");

            migrationBuilder.CreateIndex(
                name: "IX_TaskReview_UserHistoryIdUserHistory",
                table: "TaskReview",
                column: "UserHistoryIdUserHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Scope_UserHistoryIdUserHistory1",
                table: "Scope",
                column: "UserHistoryIdUserHistory1");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_UserHistoryIdUserHistory1",
                table: "Risk",
                column: "UserHistoryIdUserHistory1");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidationReport_UserHistoryIdUserHistory",
                table: "ConsolidationReport",
                column: "UserHistoryIdUserHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidationReport_UserHistory_UserHistoryIdUserHistory",
                table: "ConsolidationReport",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory",
                table: "Risk",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory1",
                table: "Risk",
                column: "UserHistoryIdUserHistory1",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory",
                table: "Scope",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory1",
                table: "Scope",
                column: "UserHistoryIdUserHistory1",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskReview_UserHistory_UserHistoryIdUserHistory",
                table: "TaskReview",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCase_UserHistory_UserHistoryIdUserHistory",
                table: "TestCase",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOut_UserHistory_UserHistoryIdUserHistory",
                table: "TimeOut",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory",
                table: "Tools",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory1",
                table: "Tools",
                column: "UserHistoryIdUserHistory1",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidationReport_UserHistory_UserHistoryIdUserHistory",
                table: "ConsolidationReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory1",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory",
                table: "Scope");

            migrationBuilder.DropForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory1",
                table: "Scope");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskReview_UserHistory_UserHistoryIdUserHistory",
                table: "TaskReview");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCase_UserHistory_UserHistoryIdUserHistory",
                table: "TestCase");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOut_UserHistory_UserHistoryIdUserHistory",
                table: "TimeOut");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory1",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_UserHistoryIdUserHistory1",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_TimeOut_UserHistoryIdUserHistory",
                table: "TimeOut");

            migrationBuilder.DropIndex(
                name: "IX_TestCase_UserHistoryIdUserHistory",
                table: "TestCase");

            migrationBuilder.DropIndex(
                name: "IX_TaskReview_UserHistoryIdUserHistory",
                table: "TaskReview");

            migrationBuilder.DropIndex(
                name: "IX_Scope_UserHistoryIdUserHistory1",
                table: "Scope");

            migrationBuilder.DropIndex(
                name: "IX_Risk_UserHistoryIdUserHistory1",
                table: "Risk");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidationReport_UserHistoryIdUserHistory",
                table: "ConsolidationReport");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory1",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory",
                table: "TimeOut");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory",
                table: "TestCase");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory",
                table: "TaskReview");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory1",
                table: "Scope");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory1",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "UserHistoryIdUserHistory",
                table: "ConsolidationReport");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_UserHistory_UserHistoryIdUserHistory",
                table: "Risk",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_UserHistory_UserHistoryIdUserHistory",
                table: "Scope",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_UserHistory_UserHistoryIdUserHistory",
                table: "Tools",
                column: "UserHistoryIdUserHistory",
                principalTable: "UserHistory",
                principalColumn: "IdUserHistory",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
