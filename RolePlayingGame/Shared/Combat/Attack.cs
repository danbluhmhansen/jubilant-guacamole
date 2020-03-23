namespace RolePlayingGame.Shared.Combat
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Health;

	public class Attack : BaseAttack
	{
		public Attack(string name, int attack, int damage, IEnumerable<AppendageType> appendages) : base(name, attack, damage, appendages) { }
	}
}
