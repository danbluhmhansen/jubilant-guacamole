namespace RolePlayingGame.Shared.Combat
{
	using RolePlayingGame.Shared.Health;

	public class StandardMeleeAttack : BaseAttack
	{
		public StandardMeleeAttack() : base("Melee", 1000, new StandardMeleeDamage(), AppendageType.Arm)
		{
		}
	}
}
