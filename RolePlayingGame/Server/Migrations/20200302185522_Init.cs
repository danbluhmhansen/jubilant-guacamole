namespace RolePlayingGame.Server.Migrations
{
	using Microsoft.EntityFrameworkCore.Migrations;

	using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

	public partial class Init : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PlayerCharacters",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					BaseVigor = table.Column<long>(nullable: false),
					BaseMana = table.Column<long>(nullable: false),
					MaxVigor = table.Column<long>(nullable: false),
					MaxMana = table.Column<long>(nullable: false),
					Vigor = table.Column<long>(nullable: false),
					Mana = table.Column<long>(nullable: false),
					Temperature = table.Column<int>(nullable: false),
					Strength = table.Column<long>(nullable: false),
					Agility = table.Column<long>(nullable: false),
					Intelligence = table.Column<long>(nullable: false),
					Instinct = table.Column<long>(nullable: false),
					Charisma = table.Column<long>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PlayerCharacters", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PlayerCharacters");
		}
	}
}
