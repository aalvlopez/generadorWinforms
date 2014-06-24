using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ToolBarItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.ToolBarItem tool = new WinformsGenerator.ToolBarItem ();
			tool.Name = "element";
			tool.Text = "element";

			WinformsGenerator.ToolBarItem toolTest = (WinformsGenerator.ToolBarItem)tool.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ToolBarItem), toolTest);
			Assert.AreEqual (tool.Name,toolTest.Name);
			Assert.AreEqual (tool.Text,toolTest.Text);
		}
	}
}

