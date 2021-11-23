using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    public partial class InitSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Subjects",
              columns: new[] { "Id", "Title", "TeacherId" },
              values: new object[,]
              {
                    {1, 0, 1},
                    {2, 1, 2},
                    {3, 2, 3}
              });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
