namespace RolePlayingGame.Server.Models
{
	public class PlayerCharacterModel
	{
		public int Id { get; set; }

		// Base resources
		public uint BaseVigor { get; set; }
		public uint BaseMana { get; set; }

		// Max resources
		public uint MaxVigor { get; set; }
		public uint MaxMana { get; set; }

		// Current resources
		public uint Vigor { get; set; }
		public uint Mana { get; set; }
		public int Temperature { get; set; }

		// Attributes
		public uint Strength { get; set; }
		public uint Agility { get; set; }
		public uint Intelligence { get; set; }
		public uint Instinct { get; set; }
		public uint Charisma { get; set; }
	}
}
