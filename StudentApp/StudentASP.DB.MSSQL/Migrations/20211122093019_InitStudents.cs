using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    public partial class InitStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
               columns: new[] {"Id", "NumberGroup", "FirstName", "LastName" },
               values: new object[,]
               {
                    {1, 134, "Михаил", "Киров"},
                    {2, 134, "Виктория", "Рогожина"},
                    {3, 134, "Сергей", "Громов"},
                    {4, 134, "Лиза", "Стогова"},
                    {5, 134, "Артем", "Гуров"},

                    {6, 135, "Дмитрий", "Носков"},
                    {7, 135, "Денис", "Баринов"},
                    {8, 135, "Елена", "Смирнова"},
                    {9, 135, "Игорь", "Трофимов"},
                    {10, 135, "Оксана", "Тимофеева"},

                    {11, 136, "Людмила", "Никифорова"},
                    {12, 136, "Кирилл", "Кросов"},
                    {13, 136, "Никита", "Гончаров"},
                    {14, 136, "Анастасия", "Кирова"},
                    {15, 136, "Светлана", "Прохорова"}
                });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
