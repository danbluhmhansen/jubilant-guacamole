namespace RolePlayingGame.Shared.Models
{
	using System.Collections.Generic;

	public interface ICreature
	{
		IEnumerable<IBodyPart> BodyParts { get; }

		IAttack Attack();

		void Defend(IAttack attack)
		{

		}
	}
}
