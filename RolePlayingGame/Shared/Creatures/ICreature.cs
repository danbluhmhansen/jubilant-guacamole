namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;

	public interface ICreature
	{
		// Base resources
		int BaseVigour { get; }
		int BaseMana { get; }

		// Max resources
		int MaxVigour { get; }
		int MaxMana { get; }

		// Current resources
		int Vigour { get; }
		int Mana { get; }
		int Temperature { get; }

		int Defence { get; }

		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get; }

		List<IEquipment> Equipment { get; }

		IEnumerable<IAttack> Attacks();

		IBodyPart? Defend(IAttack attack);
	}
}
