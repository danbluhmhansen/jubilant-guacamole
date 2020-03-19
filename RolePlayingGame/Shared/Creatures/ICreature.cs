namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Models;

	public interface ICreature
	{
		// Base resources
		int BaseVigor { get; }
		int BaseMana { get; }

		// Max resources
		int MaxVigor { get; }
		int MaxMana { get; }

		// Current resources
		int Vigor { get; }
		int Mana { get; }
		int Temperature { get; }

		int Defence { get; }

		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get; }

		ICollection<IEquipment> Equipment { get; }

		IAttack Attack();

		IBodyPart? Defend(IAttack attack);
	}
}
