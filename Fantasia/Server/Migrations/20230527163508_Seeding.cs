using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fantasia.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "FyzImageUrl", "NazovFunkcie", "NazovFyzUtoku" },
                values: new object[,]
                {
                    { 1, "/imgHracov/fiary1.png" },
                    { 2, "/imgHracov/postava2.png", },
                    { 3, "/imgHracov/demon3.png", },
                    { 3, "/imgHracov/devil4.png", }
                });

            migrationBuilder.InsertData(
               table: "FyzUtoky",
               columns: new[] { "Id", "FyzImageUrl", "NazovFunkcie", "NazovFyzUtoku" },
               values: new object[,]
               {
                    { 1, "/imgHracov/FlyingKick60.png", "flyingkick(this.src)", "FlyingKick" },
                    { 2, "/imgHracov/BodySlam60.png", "bodyslam(this.src)", "BodySlam" },
                    { 3, "/imgHracov/PunchGataling60.png", "punchgataling(this.src)", "PunchGataling" }
               });

            migrationBuilder.InsertData(
                table: "MagUtoky",
                columns: new[] { "Id", "MagImageUrl", "NazovFunkcie", "NazovMagUtoku" },
                values: new object[,]
                {
                    { 1, "/imgHracov/fireBall60.png", "fireball(this.src)", "FireBall" },
                    { 2, "/imgHracov/frostNova60.png", "frostnova(this.src)", "FrostNova" },
                    { 3, "/imgHracov/windSlash60.png", "windslash(this.src)", "WindSlash" }
                });

            migrationBuilder.InsertData(
                table: "VieUtoky",
                columns: new[] { "Id", "NazovFunkcie", "NazovVieUtoku", "VieImageUrl" },
                values: new object[,]
                {
                    { 1, "heal(this.src)", "Heal", "/imgHracov/heal60.png" },
                    { 2, "bonusDef(this.src)", "DefBonus", "/imgHracov/defBonus60.png" },
                    { 3, "bonusUtok(this.src)", "AttakeBonus", "/imgHracov/AttakeBonus60.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FyzUtoky",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FyzUtoky",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FyzUtoky",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MagUtoky",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MagUtoky",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MagUtoky",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VieUtoky",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VieUtoky",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VieUtoky",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
