namespace RolePlayingGame.Shared.Models
{
	using System.Collections.Generic;
	using System.Linq;

	public interface ICreature
	{
		IEnumerable<IBodyPart> BodyParts { get; }
		double Size { get => BodyParts.Select(bodyPart => bodyPart.Size).Sum(); }

		IAttack Attack();

		void Defend(IAttack attack)
		{
		}
	}
}
