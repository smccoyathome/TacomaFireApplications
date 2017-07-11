using System;
using Stubs._FarPoint.Win.Spread;

namespace Stubs._FarPoint.Win.Spread
{

	public class FpScrollBar
		: System.ComponentModel.Component
	{

		public FpScrollBarButtonCollection Buttons { get; set; }

		public IScrollBarRenderer Renderer { get; set; }

	}

}