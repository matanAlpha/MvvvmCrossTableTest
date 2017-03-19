using System;
using System.Collections.Generic;

namespace MvvvmCrossTableTest.Core
{
	public class SmallFixedViewModel : BaseSampleViewModel
	{
		private List<Kitten> _kittens;

		public SmallFixedViewModel()
		{
			Kittens = new List<Kitten>(CreateKittens(10));
		}

		public List<Kitten> Kittens
		{
			get { return _kittens; }
			set
			{
				_kittens = value;
				RaisePropertyChanged(() => Kittens);
			}
		}
	}
}
