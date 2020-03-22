namespace RolePlayingGame.Shared.Resources
{
	public class Vigour : IResource
	{
		public Vigour(int vigour)
		{
			this.Base = vigour;
			this.Current = vigour;
			this.Max = vigour;
		}

		public int Base { get; }
		public int Current { get; }
		public int Max { get; }
	}
}
