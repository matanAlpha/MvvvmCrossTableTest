using System;
namespace MvvvmCrossTableTest.Core
{
	public class Kitten : Animal
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }

		public override string ToString()
		{
			return string.Format("[Kitten: Name={0}, ImageUrl={1}]", Name, ImageUrl);
		}
	}
}
