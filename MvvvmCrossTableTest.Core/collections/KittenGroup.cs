using System;
using System.Collections.Generic;

namespace MvvvmCrossTableTest.Core
{
	public class KittenGroup : List<Kitten>
	{
		public string Title { get; set; }

		public KittenGroup(IEnumerable<Kitten> collection) : base(collection)
		{

		}
	}
}
