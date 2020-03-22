namespace RolePlayingGame.Shared
{
	using System;

	public static class RandomExtensions
	{
		private static Random? random;

		/// <summary>Gets the static randomiser or initialises a new one if it hasn't already been initialised.</summary>
		public static Random Random => random ?? Initialise();

		/// <summary>Initialise the static randomiser.</summary>
		/// <param name="seed">Optional seed to use when initialising.</param>
		/// <returns>Initialised randomiser.</returns>
		public static Random Initialise(int? seed = default) => random = seed.HasValue ? new Random(seed.Value) : new Random();

		/// <summary>Checks if a random number exceeds a <paramref name="targetNumber"/>.</summary>
		/// <param name="targetNumber">The number to exceed.</param>
		/// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
		/// <param name="minValue">The inclusive lower bound of the random number returned.</param>
		/// <returns>True if the random number exceeds the <paramref name="targetNumber"/>, otherwise false.</returns>
		public static bool Roll(this int targetNumber, int? maxValue = default, int? minValue = default) =>
			(minValue.HasValue && maxValue.HasValue ? Random.Next(minValue.Value, maxValue.Value) : maxValue.HasValue ? Random.Next(maxValue.Value) : Random.Next()) < targetNumber;
	}
}
