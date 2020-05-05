namespace RolePlayingGame.Shared.Combat
{
	public abstract class BaseDamage : IDamage
	{
		protected BaseDamage(int amount, DamageType type = DamageType.Physical)
		{
			this.Amount = amount;
			this.Type = type;
		}

		public DamageType Type { get; protected set; }
		public int Amount { get; protected set; }
	}
}
