namespace RolePlayingGame.Shared.Combat
{
	public abstract class BaseAttack : IAttack
	{
		protected BaseAttack(string name, int attack, int damage)
		{
			this.Name = name;
			this.Attack = attack;
			this.Damage = damage;
		}

		public string Name { get; }

		public int Attack { get; }

		public int Damage { get; }
	}
}
