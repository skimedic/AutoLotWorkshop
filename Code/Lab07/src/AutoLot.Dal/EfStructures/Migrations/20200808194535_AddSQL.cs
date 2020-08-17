// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - 20200808194535_AddSQL.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/08
// See License.txt for more information
// ==================================

using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class AddSQL : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.DropView(migrationBuilder);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateView(migrationBuilder);
        }
    }
}