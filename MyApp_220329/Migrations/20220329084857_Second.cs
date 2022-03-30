using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyApp_220329.Migrations
{
    public partial class Second : Migration
    {
        // 스키마 업데이트 역할 - 수정 사항 기록
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Teachers",
                nullable: true);
        }

        // 스키마 복원 역할 - 수정 전 사항 기록
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Students",
                nullable: false,
                defaultValue: "");
        }
    }
}
