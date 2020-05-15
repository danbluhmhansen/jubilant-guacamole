namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using EnumsNET;

	using MoreLinq;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Effects;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public abstract class BaseCreature : ICreature
	{
		protected BaseCreature(string name, IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IAppendage> appendages, IEnumerable<IAttack> attacks)
		{
			this.Name = name;
			this.Vigour = vigour;
			this.Mana = mana;
			this.Temperature = temperature;
			this.Defence = defence;
			this.Appendages = appendages;

			this.attacks = attacks.ToList();
		}

		private readonly List<IAttack> attacks;

		public string Name { get; protected set; }

		public IResource Vigour { get; }

		public IResource Mana { get; }

		public int Temperature { get; protected set; }

		public int Defence { get; protected set; }

		public virtual int Size => this.Appendages.Sum(appendage => appendage.Size);

		public IEnumerable<IAppendage> Appendages { get; }

		public List<IEquipment> Equipment { get; } = new List<IEquipment>();

		public List<IEffect> Effects { get; } = new List<IEffect>();

		public virtual int AdjustTemperature(int amount) => this.Temperature += amount;

		public virtual IAttack Attack(AppendageType appendage) => this.attacks.FirstOrDefault(attack => attack.Appendages.HasAnyFlags(appendage));

		public virtual IEnumerable<IAttack> Attacks() => this.attacks;

		public virtual IAppendage? Defend(IAttack attack)
		{
			if (this.Defence.Roll(attack.Attack))
				return default;

			var total = 0;
			return this.Appendages
				.OrderBy(appendage => appendage.Size)
				.Select(appendage => (Appendage: appendage, TargetNumber: total += appendage.Size))
				.First(appendageWithTargetNumber => appendageWithTargetNumber.TargetNumber.Roll(this.Size))
				.Appendage
				.Damage(attack);
		}

		public override string ToString() => this.Name;
	}
}
