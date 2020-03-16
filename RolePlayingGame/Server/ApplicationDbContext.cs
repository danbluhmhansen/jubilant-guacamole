namespace RolePlayingGame.Server
{
	using System.Diagnostics.CodeAnalysis;

	using Microsoft.EntityFrameworkCore;

	using RolePlayingGame.Server.Models;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public ApplicationDbContext()
		{
		}

		public DbSet<PlayerCharacterModel> PlayerCharacters { get; set; }
	}
}
