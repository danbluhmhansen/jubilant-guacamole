namespace RolePlayingGame.Shared.Combat
{
	using RolePlayingGame.Shared.Health;

	public class Attack : BaseAttack
	{
		public Attack(string name, int attack, int damage, AppendageType appendages) : base(name, attack, damage, appendages) { }
	}
}
