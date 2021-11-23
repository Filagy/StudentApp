using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    public partial class InitTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
               table: "Teachers",
               columns: new[] { "Id", "FirstName", "LastName" },
               values: new object[,]
               {
                    {1, "Дмитрий", "Мальцев"},
                    {2, "Виктор", "Соколов"},
                    {3, "Федор", "Стрельцов"}
               });

           
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
