namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;

	public abstract class BaseCreature : ICreature
	{
		protected BaseCreature(int vigour, int mana, int temperature, int defence, IEnumerable<IBodyPart> bodyParts)
		{
			this.BaseVigour = vigour;
			this.MaxVigour = vigour;
			this.Vigour = vigour;

			this.BaseMana = mana;
			this.MaxMana = mana;
			this.Mana = mana;

			this.Temperature = temperature;

			this.Defence = defence;

			this.BodyParts = bodyParts;
		}

		public int BaseVigour { get; }
		public int BaseMana { get; }

		public int MaxVigour { get; }
		public int MaxMana { get; }

		public int Vigour { get; }
		public int Mana { get; }
		public int Temperature { get; }

		public int Defence { get; }

		public virtual int Size => this.BodyParts.Sum(bodyPart => bodyPart.Size);

		public IEnumerable<IBodyPart> BodyParts { get; }
		public List<IEquipment> Equipment { get; } = new List<IEquipment>();

		public virtual IEnumerable<IAttack> Attacks() => Enumerable.Empty<IAttack>();
		public virtual IBodyPart? Defend(IAttack attack)
		{
			var hitChance = RandomExtensions.Random.Next(attack.Attack);
			if (hitChance < this.Defence)
				return default;

			var total = 0;
			var bodyPartChance = RandomExtensions.Random.Next(this.BodyParts.Where(bodyPart => bodyPart.Status != BodyPartStatus.Destroyed).Sum(bodyPart => bodyPart.Size));
			var bodyPart = this.BodyParts
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
