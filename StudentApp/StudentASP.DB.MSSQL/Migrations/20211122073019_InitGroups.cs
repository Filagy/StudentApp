using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    public partial class InitGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                  table: "Groups",
                      columns: new[] { "NumberGroup","TeacherClassroomId" },
                      values: new object[,]
                      {
                            { 134, 1},
                            { 135, 2},
                            { 136, 3}
                      });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
