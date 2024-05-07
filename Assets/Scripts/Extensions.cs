using System.Collections.Generic;
using UnityEngine;

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
}
