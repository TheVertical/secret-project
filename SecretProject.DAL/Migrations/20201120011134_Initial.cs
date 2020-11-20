using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretProject.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OcObject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomenclatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetNomenclatureProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OcObject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomenclatureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetNomenclatureProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetNomenclatureProperties_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NomenclatureId = table.Column<int>(type: "int", nullable: false),
                    OcObject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomenclatureGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    NomenclatureId = table.Column<int>(type: "int", nullable: false),
                    OcObject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomenclatureGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomenclatureGroups_NomenclatureGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "NomenclatureGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NomenclatureGroups_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetNomenclatureProperties_NomenclatureId",
                table: "GetNomenclatureProperties",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_NomenclatureId",
                table: "Manufacturers",
                column: "NomenclatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NomenclatureGroups_NomenclatureId",
                table: "NomenclatureGroups",
                column: "NomenclatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NomenclatureGroups_ParentId",
                table: "NomenclatureGroups",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetNomenclatureProperties");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "NomenclatureGroups");

            migrationBuilder.DropTable(
                name: "Nomenclatures");
        }
    }
}
