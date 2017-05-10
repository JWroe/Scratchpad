using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TribalTech.UI.Controls
{
	/// <summary>
	/// A custom panel.
	/// Behaves as follows: If all children will fit into the available vertical space, then stack them vertically like a stack panel.
	/// If the stacked children do not fit into available space, distribute them uniformly inside the panel instead. 
	/// All children are given all available space in the X axis. 
	/// </summary>
	public class NonInfiniteStackPanel : Panel
	{
		private List<UIElement> EnumerableChildren { get { return Children.Cast<UIElement>().ToList(); } }

		public NonInfiniteStackPanel()
		{
			ClipToBounds = true;
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			Size desiredSize;
			if (ChildrenAllFit(availableSize, out desiredSize))
			{
				return desiredSize;
			}

			LimitHeightOfChildren(availableSize);
			return availableSize;
		}
		protected override Size ArrangeOverride(Size finalSize)
		{
			var rect = new Rect(0, 0, finalSize.Width, 0);
			foreach (UIElement child in Children)
			{
				rect.Height = child.DesiredSize.Height;
				child.Arrange(rect);
				rect.Y += rect.Height;
			}
			return finalSize;
		}

		private void LimitHeightOfChildren(Size availableSize)
		{
			MeasureChildren(new Size(availableSize.Width, availableSize.Height / Children.Count));
		}
		private void MeasureChildren(Size size)
		{
			EnumerableChildren.ForEach(element => element.Measure(size));
		}
		private Size GetDesiredSizeOfChildren(Size availableSize)
		{
			//Limit size in x axis to available space, as panel doesn't limit this axis otherwise.
			MeasureChildren(new Size(availableSize.Width, double.PositiveInfinity));
			return new Size
			{
				Width = EnumerableChildren.Max(element => element.DesiredSize.Width),
				Height = EnumerableChildren.Sum(element => element.DesiredSize.Height),
			};
		}
		private bool ChildrenAllFit(Size availableSize, out Size desiredSize)
		{
			desiredSize = GetDesiredSizeOfChildren(availableSize);
			return desiredSize.Height <= availableSize.Height;
		}
	}
}
