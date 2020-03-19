namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	using RolePlayingGame.Shared.Models;

	public abstract class BaseCreature : ICreature
	{
		protected BaseCreature(int defence, IEnumerable<IBodyPart> bodyParts)
		{
			this.Defence = defence;
			this.BodyParts = bodyParts;
		}

		public int Defence { get; }
		public IEnumerable<IBodyPart> BodyParts { get; }
		public virtual int Size => BodyParts.Sum(bodyPart => bodyPart.Size);

		public abstract IAttack Attack();
		public IBodyPart? Defend(IAttack attack)
		{
			var hitChance = RandomExtensions.Random.Next(attack.Attack);
			if (hitChance < Defence)
				return default;

			var total = 0;
			var bodyPartChance = RandomExtensions.Random.Next(BodyParts.Where(bodyPart => bodyPart.Status != BodyPartStatus.Destroyed).Sum(bodyPart => bodyPart.Size));
			var bodyPart = BodyParts
				.Where(bodyPart => bodyPart.Status != BodyPartStatus.Destroyed)
				.OrderBy(bp => bp.Size)
				.Select(bp => (BodyPart: bp, Chance: total += bp.Size))
				.First(x => bodyPartChance < x.Chance)
				.BodyPart;
			bodyPart.Damage(attack);
			return bodyPart;
		}
	}
}
