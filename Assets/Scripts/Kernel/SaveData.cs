using System;
using System.Collections.Generic;

namespace Kernel
{
	[Serializable]
	public class SaveData
	{
		public List<string> Cards;

		public SaveData()
		{
			Cards = new List<string>();
		}
	}
}