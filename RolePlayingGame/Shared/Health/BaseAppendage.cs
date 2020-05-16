namespace RolePlayingGame.Shared.Health
{
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Effects;

	public abstract class BaseAppendage : IAppendage
	{
		protected BaseAppendage(string name, AppendageType type, int size, int toughness, AppendageStatus status = default, IEnumerable<IInjury>? injuries = default, IEnumerable<IEffect>? effects = default)
		{
			this.Name = name;
			this.Type = type;
			this.Size = size;
			this.Toughness = toughness;
			this.Status = status;

			this.Injuries = injuries?.ToList() ?? new List<IInjury>();
			this.Effects = effects?.ToList() ?? new List<IEffect>();
		}

		public string Name { get; }
		public AppendageType Type { get; }
		public AppendageStatus Status { get; protected set; }
		public int Size { get; }
		public int Toughness { get; }

		public List<IInjury> Injuries { get; }
		public List<IEffect> Effects { get; }

		public IAppendage Damage(IAttack attack, IEnumerable<IEffect>? effects = default)
		{
			if (effects == default)
				effects = Enumerable.Empty<IEffect>();

			var result = this.Effects
				.Concat(effects.ExceptBy(this.Effects, effect => effect.Id))
				.Where(effect => effect.EffectEvent == EffectEvent.OnDamage)
				.Select(effect => (Success: effect.Affect(attack.Damage).TryConvert<int>(out var res), Result: res))
				.Where(x => x.Success)
				.Sum(x => x.Result);

			if (this.Toughness.Roll(attack.Damage.Amount + result))
				return this;

			if (this.Status != AppendageStatus.Destroyed)
				this.Status++;

			return this;
		}

		public override string ToString() => this.Name;
	}
}
