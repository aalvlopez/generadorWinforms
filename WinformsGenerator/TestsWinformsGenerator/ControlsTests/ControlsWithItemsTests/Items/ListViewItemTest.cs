using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ListViewItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.ListViewItem lvItem = new WinformsGenerator.ListViewItem ();
			lvItem.Name = "element";
			lvItem.Text = "element";

			WinformsGenerator.ListViewItem lvItemTest = (WinformsGenerator.ListViewItem)lvItem.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ListViewItem), lvItemTest);
			Assert.AreEqual (lvItem.Name,lvItemTest.Name);
			Assert.AreEqual (lvItem.Text,lvItemTest.Text);
		}
		[Test ()]
		public void AddItemTest ()
		{
			WinformsGenerator.ListViewItem lvItem = new WinformsGenerator.ListViewItem ();
			Assert.IsEmpty (lvItem.items);
			lvItem.AddItem ();
			Assert.IsNotEmpty (lvItem.items);
		}
	}
}

