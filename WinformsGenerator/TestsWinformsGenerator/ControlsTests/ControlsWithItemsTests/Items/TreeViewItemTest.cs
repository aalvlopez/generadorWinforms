using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class TreeViewItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.TreeViewItem treeItem = new WinformsGenerator.TreeViewItem ();
			treeItem.Name = "element";
			treeItem.Text = "element";

			WinformsGenerator.TreeViewItem treeItemTest = (WinformsGenerator.TreeViewItem)treeItem.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.TreeViewItem), treeItemTest);
			Assert.AreEqual (treeItem.Name,treeItemTest.Name);
			Assert.AreEqual (treeItem.Text,treeItemTest.Text);
		}
		[Test ()]
		public void AddItemTest ()
		{
			WinformsGenerator.TreeViewItem treeItem = new WinformsGenerator.TreeViewItem ();
			Assert.IsEmpty (treeItem.items);
			treeItem.AddItem ();
			Assert.IsNotEmpty (treeItem.items);
		}
	}
}

