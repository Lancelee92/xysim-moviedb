using Microsoft.EntityFrameworkCore.Migrations;

namespace xysimmoviedb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    title = table.Column<string>(nullable: true),
                    overview = table.Column<string>(nullable: true),
                    original_title = table.Column<string>(nullable: true),
                    original_language = table.Column<string>(nullable: true),
                    release_date = table.Column<string>(nullable: true),
                    poster_path = table.Column<string>(nullable: true),
                    backdrop_path = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vote_count = table.Column<int>(nullable: false),
                    popularity = table.Column<float>(nullable: false),
                    vote_average = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
