using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public static class Extensions
	{
		public static void Shuffle<T>(this IList<T> ts)
		{
			for (int i = 0, count = ts.Count, last = count - 1; i != last; ++i)
			{
				var rnd = Random.Range(i, count);
				(ts[i], ts[rnd]) = (ts[rnd], ts[i]);
			}
		}

		public static Card Find(this IEnumerable<Card> list, string id)
		{
			foreach (var item in list)
			{
				if (item.ID.Equals(id))
				{
					return item;
				}
			}

			return null;
		}
	}
}
