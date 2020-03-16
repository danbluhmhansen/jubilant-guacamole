using System.Collections.Generic;

namespace RolePlayingGame.Shared.Models
{
	public class PlayerCharacter
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
		public IEnumerable<IBodyPart> BodyParts { get; set; }
	}
}
