using System.Collections.Generic;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvvmCrossTableTest.Touch.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           

			var source = new TableSource(TableView)
			{
				UseAnimations = true,
				AddAnimation = UITableViewRowAnimation.Left,
				RemoveAnimation = UITableViewRowAnimation.Right
			};

			this.AddBindings(new Dictionary<object, string>
				{
					{source, "ItemsSource Kittens"}
				});

			TableView.Source = source;


			var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
			set.Bind(Label).To(vm => vm.Hello);
			set.Bind(TextField).To(vm => vm.Hello);

			set.Bind(source).To(vm => vm.Kittens);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailedCommand);
			set.Apply();
			TableView.ReloadData();
        }



 

		public class TableSource : MvxStandardTableViewSource
		{
			public TableSource(UITableView tableView)
				//: base(tableView, "KittenCell", "KittenCell")
				:base(tableView)
			{
				tableView.RegisterClassForCellReuse(typeof(UITableViewCell), cellReuseIdentifier);
			}

			bool originalLayerSet = false;

			System.nfloat cornerRadius;

			System.nfloat borderWidth;

			CoreGraphics.CGColor borderColor;

			UIColor bgColor;

			public override System.nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}
			public override System.nint RowsInSection(UITableView tableview, System.nint section)
			{
				return 4;
			}
			public override System.nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
			{
				return 5;
			}

			private void restoreCell(UITableViewCell cell)
			{
				if (originalLayerSet)
				{
					cell.Layer.BorderColor = borderColor;
					cell.Layer.BorderWidth = borderWidth;
					cell.Layer.CornerRadius = cornerRadius;
					cell.BackgroundColor = bgColor;
				}
				cell.ClipsToBounds = false;
			}

			private void highlightCell(UITableViewCell cell)
			{
				cell.Layer.BorderColor = UIColor.Black.CGColor;

				cell.Layer.BorderWidth = 1;

				cell.Layer.CornerRadius = 8;

				cell.BackgroundColor = UIColor.Gray;

				cell.ClipsToBounds = true;
			}

			NSIndexPath[] indexPaths = new NSIndexPath[4];

			int currentIndex = 0;

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				


				var tappedIndex = indexPaths[0];
				if (tappedIndex != null)
				{
					var oldCell = tableView.CellAt(tappedIndex);
					restoreCell(oldCell);
				}
				var cell = tableView.CellAt(indexPath);
				highlightCell(cell);

				indexPaths[0] = indexPath;

				//indexPaths![myQuiz.currentIndex] = indexPath

				//myQuiz.setCurrentAnswerIndex(index: indexPath.section)


				base.RowSelected(tableView, indexPath);
			}
			string cellReuseIdentifier = "cell";


			protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
			{
				
				var cell = tableView.DequeueReusableCell(cellReuseIdentifier, indexPath);
				cell.BackgroundColor = UIColor.White;
				if (!originalLayerSet)
				{
					cornerRadius = cell.Layer.CornerRadius;
					borderWidth = cell.Layer.BorderWidth;
					borderColor = cell.Layer.BorderColor;
					bgColor = cell.BackgroundColor;
					originalLayerSet = true;
				}
				else
				{
					restoreCell(cell);
				}
				cell.TextLabel.Text = item.ToString();

				return cell;
			}

			//public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			//{
			//	base.RowSelected(tableView, indexPath);
			//}
		}
    }
}
