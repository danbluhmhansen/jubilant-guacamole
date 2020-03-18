using System;

namespace RolePlayingGame.Shared
{
	public static class RandomExtensions
	{
		public static Random Random { get; } = Initialise();

		public static Random Initialise(int? seed = default) => seed.HasValue ? new Random(seed.Value) : new Random();

		public static bool Chance(this Random random, int chance, int? minValue = default, int? maxValue = default) =>
			(minValue.HasValue && maxValue.HasValue ? random.Next(minValue.Value, maxValue.Value) : maxValue.HasValue ? random.Next(maxValue.Value) : random.Next()) < chance;
	}
}
