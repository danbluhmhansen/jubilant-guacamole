namespace RolePlayingGame.Server.Configuration
{
	using AutoMapper;

	using RolePlayingGame.Server.Models;
	using RolePlayingGame.Shared.Models;

	public static class AutoMapperConfiguration
	{
		public static IMapperConfigurationExpression MapConfiguration(this IMapperConfigurationExpression mapperConfigurationExpression)
		{
			mapperConfigurationExpression.CreateMap<PlayerCharacterModel, PlayerCharacter>();
			return mapperConfigurationExpression;
		}
	}
}
