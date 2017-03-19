using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MvvvmCrossTableTest.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }

		private List<Kitten> _kittens;

		public FirstViewModel()
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

		private readonly KittenGenerator _kittenGenerator = new KittenGenerator();
		private readonly Random _random = new Random();

		protected Kitten CreateKitten(int kidId)
		{
			return _kittenGenerator.CreateNewKitten(kidId);
		}

		protected Kitten CreateKittenNamed(string name,int kitId)
		{
			var kitten = CreateKitten(kitId);
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

		public ICommand SelectionChangedCommand
		{
			get { return new MvxCommand(() =>
			{
				_hello = "tt";
			}); }
		}
		public ICommand ShowDetailedCommand
		{
			get
			{
				return new MvxCommand(() =>
		  {
			 _hello = "ff";
		  });
			}
		}
    }
}
