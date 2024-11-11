using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoTabelaMusicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento"}, new object[] { "Good Times", 2013 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "1999", 2014 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Price Tag", 2011 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Heroes", 1977 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Aquarela", 2004 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Se eu não te amasse tanto assim", 2003});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Shake it Off ", 2014 });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Back to Black ", 2006});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Flashlight", 2015});

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[] { "Video Games", 2011});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
