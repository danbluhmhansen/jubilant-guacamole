namespace RolePlayingGame.Shared.Combat
{
	public abstract class BaseAttack : IAttack
	{
		protected BaseAttack (int attack, int damage)
		{
			Attack = attack;
			Damage = damage;
		}

		public int Attack { get; }
		public int Damage { get; }
	}
}
