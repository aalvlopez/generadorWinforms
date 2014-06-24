using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ListViewSubItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.ListViewSubItem lvSubItem = new WinformsGenerator.ListViewSubItem ();
			lvSubItem.Name = "element";
			lvSubItem.Text = "element";

			WinformsGenerator.ListViewSubItem lvSubItemTest = (WinformsGenerator.ListViewSubItem)lvSubItem.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ListViewSubItem), lvSubItemTest);
			Assert.AreEqual (lvSubItem.Name,lvSubItemTest.Name);
			Assert.AreEqual (lvSubItem.Text,lvSubItemTest.Text);
		}
	}
}

