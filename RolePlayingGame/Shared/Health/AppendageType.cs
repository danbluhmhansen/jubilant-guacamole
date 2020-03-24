using System;

namespace RolePlayingGame.Shared.Health
{
	[Flags]
	public enum AppendageType
	{
		Torso = 0b1,
		Head = 0b10,
		Arm = 0b100,
		Leg = 0b1000,
		Tail = 0b10000,
		Wing = 0b100000,
		Tentacle = 0b1000000,
		Limbs = Arm | Leg,
		UpperBody = Torso | Head | Arm | Wing,
		LowerBody = Leg | Tail
	}
}
