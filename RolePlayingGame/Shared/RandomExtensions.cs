namespace RolePlayingGame.Shared
{
	using System;

	public static class RandomExtensions
	{
		private static Random? random;

		public static Random Random => random ?? Initialise();
		public static Random Initialise(int? seed = default) => random = seed.HasValue ? new Random(seed.Value) : new Random();

		public static bool Chance(this Random random, int chance, int? minValue = default, int? maxValue = default) =>
			(minValue.HasValue && maxValue.HasValue ? random.Next(minValue.Value, maxValue.Value) : maxValue.HasValue ? random.Next(maxValue.Value) : random.Next()) < chance;
	}
}
