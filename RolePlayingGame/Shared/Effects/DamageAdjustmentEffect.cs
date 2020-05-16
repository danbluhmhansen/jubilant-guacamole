namespace RolePlayingGame.Shared.Effects
{
	using System;

	using RolePlayingGame.Shared.Combat;

	public class DamageAdjustmentEffect : IEffect
	{
		public DamageAdjustmentEffect(int amount, DamageType damageType = default)
		{
			this.Amount = amount;
			this.DamageType = damageType;
		}

		public Guid Id => Guid.Parse("70d47453-32e5-4843-ba69-1e01c214e273");
		public EffectEvent EffectEvent => EffectEvent.OnDamage;

		public int Amount { get; }
		public DamageType DamageType { get; }

		public object? Affect(params object[] vs) =>
			vs[0].TryConvert<IDamage>(out var damage) && damage.Type == this.DamageType ? this.Amount : default;
	}
}
