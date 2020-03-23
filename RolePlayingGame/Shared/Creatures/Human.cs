namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public class Human : BaseCreature
	{
		public Human() : base(
			new Vigour(500),
			new Mana(500),
			500,
			500,
			new Appendage("Head", AppendageType.Head, 60, 500).Yield(
				new Appendage("Body", AppendageType.Body, 160, 500),
				new Appendage("Left arm", AppendageType.Arm, 80, 500),
				new Appendage("Right arm", AppendageType.Arm, 80, 500),
				new Appendage("Left leg", AppendageType.Leg, 100, 500),
				new Appendage("Right leg", AppendageType.Leg, 100, 500)),
			new StandardMeleeAttack().Yield())
		{ }

		public Human(
			IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IAppendage> appendages,
			IEnumerable<IAttack> attacks)
			: base(vigour, mana, temperature, defence, appendages, attacks) { }
	}
}
