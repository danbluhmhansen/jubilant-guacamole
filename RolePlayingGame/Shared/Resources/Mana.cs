namespace RolePlayingGame.Shared.Resources
{
	public class Mana : IResource
	{
		public Mana(int mana)
		{
			this.Base = mana;
			this.Current = mana;
			this.Max = mana;
		}

		public int Base { get; }
		public int Current { get; }
		public int Max { get; }
	}
}
