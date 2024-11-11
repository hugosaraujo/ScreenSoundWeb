using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] {"Nome", "Bio", "FotoPerfil" }, new object[] { "Nile Rodgers & CHIC", "Nile Rodgers & Chic: a combinação perfeita entre funk, R&B e disco, criando uma trilha sonora inesquecível para diversas gerações.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Charli XCX", "A rainha do hyperpop: Charli XCX reinventa a música pop com beats acelerados, vocais distorcidos e performances eletrizantes.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Jessie J", "Com uma voz poderosa e única, Jessie J é uma das maiores cantoras da atualidade, capaz de emocionar em cada nota.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "David Bowie", "O camaleão do rock: David Bowie, ícone da música, reinventou-se constantemente, explorando diversos estilos e desafiando as convenções.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Nadson, O Ferinha", "O fenômeno do arrocha: Nadson, O Ferinha, com suas músicas apaixonantes e ritmo contagiante, é a trilha sonora perfeita para os apaixonados.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Pablo", "O rei do arrocha: Pablo conquista o público com seu timbre marcante e músicas que embalam as noites de romance.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Taylor Swift", "A loirinha que transformou a indústria musical, passando do country para o pop e quebrando recordes a cada álbum.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Amy Winehouse", "A artista que mesclou elementos de jazz, R&B e soul, criando um som sofisticado e atemporal.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
