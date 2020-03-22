namespace RolePlayingGame.Shared.Combat
{
	public abstract class BaseAttack : IAttack
	{
		protected BaseAttack(int attack, int damage)
		{
			this.Attack = attack;
			this.Damage = damage;
		}

		public int Attack { get; }
		public int Damage { get; }
	}
}
