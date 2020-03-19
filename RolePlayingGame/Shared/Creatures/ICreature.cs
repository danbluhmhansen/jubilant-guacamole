namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Models;

	public interface ICreature
	{
		int Defence { get; }

		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get; }

		IAttack Attack();

		IBodyPart? Defend(IAttack attack);
	}
}
