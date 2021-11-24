using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    public partial class InitScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Scores",
             columns: new[] { "Value", "Date", "SubjectId", "StudentId" },
             values: new object[,]
                    {
                            {4, DateTime.Now, 1, 1},
                            {4, DateTime.Now, 1, 1},
                            {5, DateTime.Now, 1, 1},

                            {4, DateTime.Now, 2, 1},
                            {5, DateTime.Now, 2, 1},
                            {4, DateTime.Now, 2, 1},

                            {5, DateTime.Now, 3, 1},
                            {5, DateTime.Now, 3, 1},
                            {4, DateTime.Now, 3, 1},


                            {2, DateTime.Now, 1, 2},
                            {3, DateTime.Now, 1, 2},
                            {3, DateTime.Now, 1, 2},

                            {4, DateTime.Now, 2, 2},
                            {3, DateTime.Now, 2, 2},
                            {3, DateTime.Now, 2, 2},

                            {2, DateTime.Now, 3, 2},
                            {4, DateTime.Now, 3, 2},
                            {3, DateTime.Now, 3, 2},


                            {4, DateTime.Now, 1, 3},
                            {3, DateTime.Now, 1, 3},
                            {4, DateTime.Now, 1, 3},

                            {4, DateTime.Now, 2, 3},
                            {4, DateTime.Now, 2, 3},
                            {4, DateTime.Now, 2, 3},

                            {4, DateTime.Now, 3, 3},
                            {4, DateTime.Now, 3, 3},
                            {3, DateTime.Now, 3, 3},


                            {5, DateTime.Now, 1, 4},
                            {5, DateTime.Now, 1, 4},
                            {4, DateTime.Now, 1, 4},

                            {5, DateTime.Now, 2, 4},
                            {5, DateTime.Now, 2, 4},
                            {4, DateTime.Now, 2, 4},

                            {5, DateTime.Now, 3, 4},
                            {5, DateTime.Now, 3, 4},
                            {4, DateTime.Now, 3, 4},


                            {2, DateTime.Now, 1, 5},
                            {3, DateTime.Now, 1, 5},
                            {2, DateTime.Now, 1, 5},

                            {2, DateTime.Now, 2, 5},
                            {3, DateTime.Now, 2, 5},
                            {2, DateTime.Now, 2, 5},

                            {2, DateTime.Now, 3, 5},
                            {3, DateTime.Now, 3, 5},
                            {3, DateTime.Now, 3, 5},


                            {2, DateTime.Now, 1, 6},
                            {3, DateTime.Now, 1, 6},
                            {3, DateTime.Now, 1, 6},

                            {4, DateTime.Now, 2, 6},
                            {3, DateTime.Now, 2, 6},
                            {3, DateTime.Now, 2, 6},

                            {2, DateTime.Now, 3, 6},
                            {4, DateTime.Now, 3, 6},
                            {3, DateTime.Now, 3, 6},


                            {4, DateTime.Now, 1, 7},
                            {3, DateTime.Now, 1, 7},
                            {3, DateTime.Now, 1, 7},

                            {4, DateTime.Now, 2, 7},
                            {3, DateTime.Now, 2, 7},
                            {3, DateTime.Now, 2, 7},

                            {4, DateTime.Now, 3, 7},
                            {4, DateTime.Now, 3, 7},
                            {3, DateTime.Now, 3, 7},


                            {4, DateTime.Now, 1, 8},
                            {4, DateTime.Now, 1, 8},
                            {4, DateTime.Now, 1, 8},

                            {4, DateTime.Now, 2, 8},
                            {3, DateTime.Now, 2, 8},
                            {3, DateTime.Now, 2, 8},

                            {4, DateTime.Now, 3, 8},
                            {4, DateTime.Now, 3, 8},
                            {3, DateTime.Now, 3, 8},


                            {2, DateTime.Now, 1, 9},
                            {3, DateTime.Now, 1, 9},
                            {3, DateTime.Now, 1, 9},

                            {3, DateTime.Now, 2, 9},
                            {3, DateTime.Now, 2, 9},
                            {3, DateTime.Now, 2, 9},

                            {3, DateTime.Now, 3, 9},
                            {4, DateTime.Now, 3, 9},
                            {3, DateTime.Now, 3, 9},


                            {4, DateTime.Now, 1, 10},
                            {3, DateTime.Now, 1, 10},
                            {4, DateTime.Now, 1, 10},

                            {4, DateTime.Now, 2, 10},
                            {3, DateTime.Now, 2, 10},
                            {4, DateTime.Now, 2, 10},

                            {4, DateTime.Now, 3, 10},
                            {4, DateTime.Now, 3, 10},
                            {4, DateTime.Now, 3, 10},


                            {4, DateTime.Now, 1, 11},
                            {5, DateTime.Now, 1, 11},
                            {4, DateTime.Now, 1, 11},

                            {4, DateTime.Now, 2, 11},
                            {5, DateTime.Now, 2, 11},
                            {4, DateTime.Now, 2, 11},

                            {4, DateTime.Now, 3, 11},
                            {5, DateTime.Now, 3, 11},
                            {4, DateTime.Now, 3, 11},


                            {5, DateTime.Now, 1, 12},
                            {3, DateTime.Now, 1, 12},
                            {5, DateTime.Now, 1, 12},

                            {5, DateTime.Now, 2, 12},
                            {5, DateTime.Now, 2, 12},
                            {4, DateTime.Now, 2, 12},

                            {5, DateTime.Now, 3, 12},
                            {5, DateTime.Now, 3, 12},
                            {4, DateTime.Now, 3, 12},

                            {4, DateTime.Now, 1, 13},
                            {3, DateTime.Now, 1, 13},
                            {3, DateTime.Now, 1, 13},

                            {3, DateTime.Now, 2, 13},
                            {3, DateTime.Now, 2, 13},
                            {4, DateTime.Now, 2, 13},

                            {3, DateTime.Now, 3, 13},
                            {3, DateTime.Now, 3, 13},
                            {4, DateTime.Now, 3, 13},

                            {5, DateTime.Now, 1, 14},
                            {5, DateTime.Now, 1, 14},
                            {5, DateTime.Now, 1, 14},

                            {5, DateTime.Now, 2, 14},
                            {5, DateTime.Now, 2, 14},
                            {5, DateTime.Now, 2, 14},

                            {5, DateTime.Now, 3, 14},
                            {5, DateTime.Now, 3, 14},
                            {5, DateTime.Now, 3, 14},

                            {5, DateTime.Now, 1, 15},
                            {4, DateTime.Now, 1, 15},
                            {4, DateTime.Now, 1, 15},

                            {4, DateTime.Now, 2, 15},
                            {4, DateTime.Now, 2, 15},
                            {5, DateTime.Now, 2, 15},

                            {4, DateTime.Now, 3, 15},
                            {5, DateTime.Now, 3, 15},
                            {5, DateTime.Now, 3, 15}
                     });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
