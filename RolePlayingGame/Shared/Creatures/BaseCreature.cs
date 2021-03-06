﻿namespace RolePlayingGame.Shared.Creatures
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
		protected BaseCreature(
			string name, IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IAppendage> appendages,
			IEnumerable<IAttack> attacks, IEnumerable<IEquipment>? equipment = default, IEnumerable<IEffect>? effects = default)
		{
			this.Name = name;
			this.Vigour = vigour;
			this.Mana = mana;
			this.Temperature = temperature;
			this.Defence = defence;
			this.Appendages = appendages;

			this.attacks = attacks.ToList();

			this.Equipment = equipment?.ToList() ?? new List<IEquipment>();
			this.Effects = effects?.ToList() ?? new List<IEffect>();
		}

		private readonly List<IAttack> attacks;

		public string Name { get; protected set; }

		public IResource Vigour { get; }

		public IResource Mana { get; }

		public int Temperature { get; protected set; }

		public int Defence { get; protected set; }

		public virtual int Size => this.Appendages.Sum(appendage => appendage.Size);

		public IEnumerable<IAppendage> Appendages { get; }

		public List<IEquipment> Equipment { get; }

		public List<IEffect> Effects { get; }

		public virtual int AdjustTemperature(int amount) => this.Temperature += amount;

		public virtual IAttack Attack(AppendageType appendage) => this.attacks.FirstOrDefault(attack => attack.Appendages.HasAnyFlags(appendage));

		public virtual IEnumerable<IAttack> Attacks() => this.attacks;

		public virtual IAppendage? Defend(IAttack attack, IEnumerable<IEffect>? effects = default)
		{
			if (effects == default)
				effects = Enumerable.Empty<IEffect>();

			var result = this.Effects
				.Concat(effects.ExceptBy(this.Effects, effect => effect.Id))
				.Where(effect => effect.EffectEvent == EffectEvent.OnDefend)
				.Select(effect => (Success: effect.Affect(attack).TryConvert<int>(out var res), Result: res))
				.Where(x => x.Success)
				.Sum(x => x.Result);

			if (this.Defence.Roll(attack.Attack + result))
				return default;

			var total = 0;

			var targetAppendage = this.Appendages
				.OrderBy(appendage => appendage.Size)
				.Select(appendage => (Appendage: appendage, TargetNumber: total += appendage.Size))
				.First(appendageWithTargetNumber => appendageWithTargetNumber.TargetNumber.Roll(this.Size))
				.Appendage;

			return targetAppendage.Damage(attack, this.Effects);
		}

		public override string ToString() => this.Name;
	}
}
