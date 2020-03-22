namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public interface ICreature
	{
		IResource Vigour { get; }
		IResource Mana { get; }

		int Temperature { get; }

		int Defence { get; }

		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get; }

		List<IEquipment> Equipment { get; }

		IEnumerable<IAttack> Attacks();

		IBodyPart? Defend(IAttack attack);
	}
}
