﻿namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Effects;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public class Human : BaseCreature
	{
		public Human(string name = "Human", IEnumerable<IEquipment>? equipment = default, IEnumerable<IEffect>? effects = default) : base(
			name, new Vigour(500), new Mana(500), 500, 500,
			new Appendage("Head", AppendageType.Head, 60, 500).Yield(
				new Appendage("Body", AppendageType.Torso, 160, 500),
				new Appendage("Left arm", AppendageType.Arm, 80, 500),
				new Appendage("Right arm", AppendageType.Arm, 80, 500),
				new Appendage("Left leg", AppendageType.Leg, 100, 500),
				new Appendage("Right leg", AppendageType.Leg, 100, 500)),
			new StandardMeleeAttack().Yield(), equipment, effects)
		{ }

		public Human(
			string name, IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IAppendage> appendages,
			IEnumerable<IAttack> attacks, IEnumerable<IEquipment>? equipment = default, IEnumerable<IEffect>? effects = default)
			: base(name, vigour, mana, temperature, defence, appendages, attacks, equipment, effects)
		{
		}
	}
}
