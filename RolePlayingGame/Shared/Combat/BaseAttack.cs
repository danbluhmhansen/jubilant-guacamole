namespace RolePlayingGame.Shared.Combat
{
	using RolePlayingGame.Shared.Health;

	public abstract class BaseAttack : IAttack
	{
		protected BaseAttack(string name, int attack, IDamage damage, AppendageType appendages)
		{
			this.Name = name;
			this.Attack = attack;
			this.Damage = damage;
			this.Appendages = appendages;
		}

		public string Name { get; }

		public int Attack { get; }

		public IDamage Damage { get; }

		public AppendageType Appendages { get; }

		public override string ToString() => this.Name;
	}
}
