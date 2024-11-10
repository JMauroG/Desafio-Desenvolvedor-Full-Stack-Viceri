using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "herois");

            migrationBuilder.CreateTable(
                name: "Herois",
                schema: "herois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    NomeHeroi = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Herois", x => x.Id));

            migrationBuilder.CreateTable(
                name: "Superpoderes",
                schema: "herois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Superpoder = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Superpoderes", x => x.Id));

            migrationBuilder.CreateTable(
                name: "HeroisSuperpoderes",
                schema: "herois",
                columns: table => new
                {
                    HeroisId = table.Column<int>(type: "int", nullable: false),
                    SuperpoderesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisSuperpoderes", x => new { x.HeroisId, x.SuperpoderesId });
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Herois_HeroisId",
                        column: x => x.HeroisId,
                        principalSchema: "herois",
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Superpoderes_SuperpoderesId",
                        column: x => x.SuperpoderesId,
                        principalSchema: "herois",
                        principalTable: "Superpoderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperpoderes_SuperpoderesId",
                schema: "herois",
                table: "HeroisSuperpoderes",
                column: "SuperpoderesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisSuperpoderes",
                schema: "herois");

            migrationBuilder.DropTable(
                name: "Herois",
                schema: "herois");

            migrationBuilder.DropTable(
                name: "Superpoderes",
                schema: "herois");
        }
    }
