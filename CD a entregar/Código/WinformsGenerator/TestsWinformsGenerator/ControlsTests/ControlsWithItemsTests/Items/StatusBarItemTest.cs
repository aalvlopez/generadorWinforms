using NUnit.Framework;
using System;
using System.Windows.Forms;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class StatusBarItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.StatusBarItem status = new WinformsGenerator.StatusBarItem ();
			status.Name = "element";
			status.Text = "element";
			status.BorderStyle = StatusBarPanelBorderStyle.Raised;

			WinformsGenerator.StatusBarItem statusTest = (WinformsGenerator.StatusBarItem)status.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.StatusBarItem), statusTest);
			Assert.AreEqual (status.Name,statusTest.Name);
			Assert.AreEqual (status.Text,statusTest.Text);
			Assert.AreEqual (status.BorderStyle,statusTest.BorderStyle);
		}
	}
}

