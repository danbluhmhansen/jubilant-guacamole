namespace RolePlayingGame.Shared.Effects
{
	public abstract class BaseEffect : IEffect
	{
		protected BaseEffect(EffectType type)
		{
			this.Type = type;
		}

		public EffectType Type { get; protected set; }
	}
}
