namespace Shared.Tests.Unit
{
	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Health;

	public class TestAttack : BaseAttack
	{
		public TestAttack(string name, int attack, IDamage damage, AppendageType appendages) : base(name, attack, damage, appendages) { }
	}
}
