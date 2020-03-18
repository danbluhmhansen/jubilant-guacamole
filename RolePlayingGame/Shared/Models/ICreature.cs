namespace RolePlayingGame.Shared.Models
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	public interface ICreature
	{
		int Defence { get; }

		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get => BodyParts.Sum(bodyPart => bodyPart.Size); }

		IAttack Attack();

		void Defend(IAttack attack)
		{
			var hitChance = RandomExtensions.Random.Next(attack.Attack);
			if (hitChance < Defence)
				return;

			var total = 0;
			var bodyPartChance = RandomExtensions.Random.Next(BodyParts.Where(bodyPart => bodyPart.Status != BodyPartStatus.Destroyed).Sum(bodyPart => bodyPart.Size));
			var bodyPart = BodyParts
				.Where(bodyPart => bodyPart.Status != BodyPartStatus.Destroyed)
				.OrderBy(bp => bp.Size)
				.Select(bp => (BodyPart: bp, Chance: total += bp.Size))
				.First(x => bodyPartChance < x.Chance)
				.BodyPart;
			bodyPart.Damage(attack);
		}
	}
}
