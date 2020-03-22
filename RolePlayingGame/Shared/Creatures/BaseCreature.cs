namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public abstract class BaseCreature : ICreature
	{
		protected BaseCreature(IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IBodyPart> bodyParts)
		{
			this.Vigour = vigour;
			this.Mana = mana;
			this.Temperature = temperature;
			this.Defence = defence;
			this.BodyParts = bodyParts;
		}

		public IResource Vigour { get; }

		public IResource Mana { get; }

		public int Temperature { get; }

		public int Defence { get; }

		public virtual int Size => this.BodyParts.Sum(bodyPart => bodyPart.Size);

		public IEnumerable<IBodyPart> BodyParts { get; }

		public List<IEquipment> Equipment { get; } = new List<IEquipment>();

		public virtual IEnumerable<IAttack> Attacks() => Enumerable.Empty<IAttack>();

		public virtual IBodyPart? Defend(IAttack attack)
		{
			if (this.Defence.Roll(attack.Attack))
				return default;

			var total = 0;
			return this.BodyParts
				.OrderBy(bodyPart => bodyPart.Size)
				.Select(bodyPart => (BodyPart: bodyPart, TargetNumber: total += bodyPart.Size))
				.First(bodyPartWithTargetNumber => bodyPartWithTargetNumber.TargetNumber.Roll(this.Size))
				.BodyPart
				.Damage(attack);
		}
	}
}
