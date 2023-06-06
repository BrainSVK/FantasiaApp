using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fantasia.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Obtiaznost = table.Column<int>(type: "int", nullable: false),
                    MaxZ = table.Column<int>(type: "int", nullable: false),
                    AktZ = table.Column<int>(type: "int", nullable: false),
                    MaxZNep = table.Column<int>(type: "int", nullable: false),
                    AktZNep = table.Column<int>(type: "int", nullable: false),
                    RandSilaUtok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boj", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FyzUtoky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazovFyzUtoku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FyzImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazovFunkcie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FyzUtoky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagUtoky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazovMagUtoku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazovFunkcie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagUtoky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VieUtoky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazovVieUtoku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VieImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazovFunkcie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VieUtoky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FyzickaSila = table.Column<int>(type: "int", nullable: false),
                    MagickaSila = table.Column<int>(type: "int", nullable: false),
                    Viera = table.Column<int>(type: "int", nullable: false),
                    Stamina = table.Column<int>(type: "int", nullable: false),
                    Vitalita = table.Column<int>(type: "int", nullable: false),
                    Stastie = table.Column<int>(type: "int", nullable: false),
                    VolneStaty = table.Column<int>(type: "int", nullable: false),
                    FyzUtokyId = table.Column<int>(type: "int", nullable: false),
                    MagUtokyId = table.Column<int>(type: "int", nullable: false),
                    VieUtokyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postava_FyzUtoky_FyzUtokyId",
                        column: x => x.FyzUtokyId,
                        principalTable: "FyzUtoky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postava_MagUtoky_MagUtokyId",
                        column: x => x.MagUtokyId,
                        principalTable: "MagUtoky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postava_VieUtoky_VieUtokyId",
                        column: x => x.VieUtokyId,
                        principalTable: "VieUtoky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hrac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PostavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hrac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hrac_Postava_PostavaId",
                        column: x => x.PostavaId,
                        principalTable: "Postava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hrac_PostavaId",
                table: "Hrac",
                column: "PostavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PostavaId",
                table: "Image",
                column: "PostavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Postava_FyzUtokyId",
                table: "Postava",
                column: "FyzUtokyId");

            migrationBuilder.CreateIndex(
                name: "IX_Postava_MagUtokyId",
                table: "Postava",
                column: "MagUtokyId");

            migrationBuilder.CreateIndex(
                name: "IX_Postava_VieUtokyId",
                table: "Postava",
                column: "VieUtokyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boj");

            migrationBuilder.DropTable(
                name: "Hrac");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Postava");

            migrationBuilder.DropTable(
                name: "FyzUtoky");

            migrationBuilder.DropTable(
                name: "MagUtoky");

            migrationBuilder.DropTable(
                name: "VieUtoky");
        }
    }
}
