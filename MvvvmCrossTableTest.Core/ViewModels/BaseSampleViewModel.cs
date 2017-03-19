using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace MvvvmCrossTableTest.Core
{
	public class BaseSampleViewModel : MvxViewModel
	{
		//private readonly DogGenerator _dogGenerator = new DogGenerator();
		private readonly KittenGenerator _kittenGenerator = new KittenGenerator();
		private readonly Random _random = new Random();

		protected Kitten CreateKitten(int id)
		{
			return _kittenGenerator.CreateNewKitten(id);
		}

		protected Kitten CreateKittenNamed(string name,int id)
		{
			var kitten = CreateKitten(id);
			kitten.Name = name;
			return kitten;
		}

		protected IEnumerable<Kitten> CreateKittens(int count)
		{
			for (var i = 0; i < count; i++)
			{
				yield return CreateKitten(i);
			}
		}

		protected IEnumerable<KittenGroup> CreateKittenGroups(int count)
		{
			for (var i = 0; i < count; i++)
			{
				yield return CreateKittenGroup(_random.Next(1, count));
			}
		}

		protected KittenGroup CreateKittenGroup(int numberOfKittens)
		{
			return _kittenGenerator.CreateNewKittenGroup(numberOfKittens);
		}

		//protected Dog CreateDog()
		//{
		//	return _dogGenerator.CreateNewDog();
		//}

		//protected IEnumerable<Dog> CreateDogs(int count)
		//{
		//	for (var i = 0; i < count; i++)
		//	{
		//		yield return CreateDog();
		//	}
		//}
	}
}
