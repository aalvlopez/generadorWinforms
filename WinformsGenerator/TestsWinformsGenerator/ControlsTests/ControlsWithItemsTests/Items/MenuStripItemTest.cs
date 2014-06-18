using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class MenuStripItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.MenuStripItem menuItem = new WinformsGenerator.MenuStripItem ();
			menuItem.Name = "element";
			menuItem.Text = "element";

			WinformsGenerator.MenuStripItem menuItemTest = (WinformsGenerator.MenuStripItem)menuItem.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.MenuStripItem), menuItemTest);
			Assert.AreEqual (menuItem.Name,menuItemTest.Name);
			Assert.AreEqual (menuItem.Text,menuItemTest.Text);
		}
		[Test ()]
		public void AddItemTest ()
		{
			WinformsGenerator.MenuStripItem menuItem = new WinformsGenerator.MenuStripItem ();
			Assert.IsEmpty (menuItem.items);
			menuItem.AddItem ();
			Assert.IsNotEmpty (menuItem.items);
		}
	}
}

