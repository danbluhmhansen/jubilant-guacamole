namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	using RolePlayingGame.Shared.Models;

	public abstract class BaseCreature : ICreature
	{
		protected BaseCreature(int vigor, int mana, int temperature, int defence, IEnumerable<IBodyPart> bodyParts, IEnumerable<IEquipment> equipment)
		{
			BaseVigor = vigor;
			MaxVigor = vigor;
			Vigor = vigor;

			BaseMana = mana;
			MaxMana = mana;
			Mana = mana;

			Temperature = temperature;

			Defence = defence;

			BodyParts = bodyParts;
			Equipment = (ICollection<IEquipment>)equipment;
		}

		public int BaseVigor { get; }
		public int BaseMana { get; }

		public int MaxVigor { get; }
		public int MaxMana { get; }

		public int Vigor { get; }
		public int Mana { get; }
		public int Temperature { get; }

		public int Defence { get; }

		public virtual int Size => BodyParts.Sum(bodyPart => bodyPart.Size);

		public IEnumerable<IBodyPart> BodyParts { get; }
		public ICollection<IEquipment> Equipment { get; }

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
