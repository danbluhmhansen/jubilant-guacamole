namespace RolePlayingGame.Shared.Health
{
	using System.Collections.Generic;

	public class Appendage : BaseAppendage
	{
		public Appendage(
			string name, AppendageType type, int size, int toughness, AppendageStatus status = AppendageStatus.Normal,
			IEnumerable<IInjury>? injuries = null) : base(name, type, size, toughness, status, injuries) { }
	}
}
