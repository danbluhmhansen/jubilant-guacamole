using System.Collections.Generic;
using System.Linq;

namespace RolePlayingGame.Shared
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Yield<T>(this T obj)
		{
			yield return obj;
		}

		public static IEnumerable<T> Yield<T>(this T obj, T obj1) => obj.Yield().Append(obj1);

		public static IEnumerable<T> Yield<T>(this T obj, T obj1, T obj2) => obj.Yield().Append(obj1).Append(obj2);

		public static IEnumerable<T> Yield<T>(this T obj, T obj1, T obj2, T obj3) => obj.Yield().Append(obj1).Append(obj2).Append(obj3);

		public static IEnumerable<T> Yield<T>(this T obj, T obj1, T obj2, T obj3, T obj4) => obj.Yield().Append(obj1).Append(obj2).Append(obj3).Append(obj4);

		public static IEnumerable<T> Yield<T>(this T obj, T obj1, T obj2, T obj3, T obj4, T obj5) => obj.Yield().Append(obj1).Append(obj2).Append(obj3).Append(obj4).Append(obj5);

		public static IEnumerable<T> Yield<T>(params T[] objects)
		{
			foreach (var obj in objects)
			{
				yield return obj;
			}
		}
	}
}
