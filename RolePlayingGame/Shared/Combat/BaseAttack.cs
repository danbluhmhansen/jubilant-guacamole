namespace RolePlayingGame.Shared.Combat
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Health;

	public abstract class BaseAttack : IAttack
	{
		protected BaseAttack(string name, int attack, int damage, IEnumerable<AppendageType> appendages)
		{
			this.Name = name;
			this.Attack = attack;
			this.Damage = damage;
			this.Appendages = appendages;
		}

		public string Name { get; }

		public int Attack { get; }

		public int Damage { get; }

		public IEnumerable<AppendageType> Appendages { get; }
	}
}
