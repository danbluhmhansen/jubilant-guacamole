namespace RolePlayingGame.Shared.Resources
{
	public class BaseResource : IResource
	{
		protected BaseResource(int resource)
		{
			this.Base = resource;
			this.Current = resource;
			this.Max = resource;
		}

		public int Base { get; protected set; }
		public int Current { get; protected set; }
		public int Max { get; protected set; }

		public int Adjust(int amount, bool allowOverflow = false) =>
			allowOverflow ? (this.Current += amount) : amount > this.Max - this.Current ? this.Current = this.Max : this.Current += amount;

		public IResource Temporary(int amount, bool ignoreCurrent = false)
		{
			if (!ignoreCurrent)
				this.Current += amount;
			this.Max += amount;
			return this;
		}

		public IResource Permanent(int amount, bool ignoreCurrent = false)
		{
			if (!ignoreCurrent)
				this.Current += amount;
			this.Base += amount;
			this.Max += amount;
			return this;
		}
	}
}
