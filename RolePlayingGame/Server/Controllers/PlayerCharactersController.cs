namespace RolePlayingGame.Server.Controllers
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using AutoMapper;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using RolePlayingGame.Server.Models;
	using RolePlayingGame.Shared.Models;

	[Route("api/[controller]")]
	[ApiController]
	public class PlayerCharactersController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public PlayerCharactersController(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GET: api/PlayerCharacters
		[HttpGet]
		public async ValueTask<IEnumerable<PlayerCharacter>> GetPlayerCharacters() => mapper.Map<IEnumerable<PlayerCharacter>>(await context.PlayerCharacters.ToListAsync());

		// GET: api/PlayerCharacters/5
		[HttpGet("{id}")]
		public async ValueTask<PlayerCharacter?> GetPlayerCharacter(int id) => mapper.Map<PlayerCharacter>(await context.PlayerCharacters.FindAsync(id));

		// PUT: api/PlayerCharacters/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async ValueTask<PlayerCharacter?> PutPlayerCharacterModel(int id)
		{
			var playerCharacter = mapper.Map<PlayerCharacter>(await context.PlayerCharacters.FindAsync(id));

			if (await TryUpdateModelAsync(playerCharacter))
			{
				context.PlayerCharacters.Update(mapper.Map<PlayerCharacterModel>(playerCharacter));
				await context.SaveChangesAsync();
				return playerCharacter;
			}
			else
			{
				return default;
			}
		}

		// POST: api/PlayerCharacters
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async ValueTask<PlayerCharacter?> PostPlayerCharacterModel(PlayerCharacter playerCharacter)
		{
			context.PlayerCharacters.Add(mapper.Map<PlayerCharacterModel>(playerCharacter));
			await context.SaveChangesAsync();

			return playerCharacter;
		}

		// DELETE: api/PlayerCharacters/5
		[HttpDelete("{id}")]
		public async ValueTask<PlayerCharacter?> DeletePlayerCharacterModel(int id)
		{
			var playerCharacter = mapper.Map<PlayerCharacter>(await context.PlayerCharacters.FindAsync(id));
			if (playerCharacter == default)
				return null;

			context.PlayerCharacters.Remove(mapper.Map<PlayerCharacterModel>(playerCharacter));
			await context.SaveChangesAsync();

			return playerCharacter;
		}
	}
}
