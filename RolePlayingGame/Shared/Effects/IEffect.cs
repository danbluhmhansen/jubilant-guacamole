namespace RolePlayingGame.Shared.Effects
{
	using System;

	public interface IEffect
	{
		Guid Id { get; }
		EffectEvent EffectEvent { get; }
		object? Affect(params object[] vs);
	}
	public enum EffectEvent
	{
		OnAttack,
		OnDefend,
		OnDamage,
	}
}
