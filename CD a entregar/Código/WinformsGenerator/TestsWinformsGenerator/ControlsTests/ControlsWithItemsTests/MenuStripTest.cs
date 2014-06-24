using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class MenuStripTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.MenuStrip menu = new WinformsGenerator.MenuStrip ();
			menu.Name = "element";
			menu.Anchor = AnchorStyles.None;
			menu.Dock = DockStyle.Left;
			menu.BackColor = Color.White;
			menu.Size = new Size (100, 100);
			menu.Location = new Point (0, 0);

			System.Windows.Forms.MenuStrip menuTest = (System.Windows.Forms.MenuStrip)menu.DrawElement ();

			System.Windows.Forms.MenuStrip menuReal = new System.Windows.Forms.MenuStrip ();
			menuReal.Name = "element";
			menuReal.Anchor = AnchorStyles.None;
			menuReal.Dock = DockStyle.Left;
			menuReal.BackColor = Color.White;
			menuReal.Size = new Size (100, 100);
			menuReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (menuReal.GetType (), menuTest);
			Assert.AreEqual (menuReal.Name, menuTest.Name);
			Assert.AreEqual (menuReal.Text, menuTest.Text);
			Assert.AreEqual (menuReal.Anchor, menuTest.Anchor);
			Assert.AreEqual (menuReal.Dock, menuTest.Dock);
			Assert.AreEqual (menuReal.BackColor, menuTest.BackColor);
			Assert.AreEqual (menuReal.Size, menuTest.Size);
			Assert.AreEqual (menuReal.Location, menuTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.MenuStrip menu = new WinformsGenerator.MenuStrip ();
			menu.Name = "element";
			menu.Anchor = AnchorStyles.None;
			menu.Dock = DockStyle.Left;
			menu.BackColor = Color.White;
			menu.Size = new Size (100, 100);
			menu.Location = new Point (0, 0);

			WinformsGenerator.Element menuTest = menu.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.MenuStrip), menuTest);
			Assert.AreEqual (menu.Name,((WinformsGenerator.MenuStrip)menuTest).Name);
			Assert.AreEqual (menu.Text,((WinformsGenerator.MenuStrip)menuTest).Text);
			Assert.AreEqual (menu.Anchor,((WinformsGenerator.MenuStrip)menuTest).Anchor);
			Assert.AreEqual (menu.Dock,((WinformsGenerator.MenuStrip)menuTest).Dock);
			Assert.AreEqual (menu.BackColor,((WinformsGenerator.MenuStrip)menuTest).BackColor);
			Assert.AreEqual (menu.Size,((WinformsGenerator.MenuStrip)menuTest).Size);
			Assert.AreEqual (menu.Location,((WinformsGenerator.MenuStrip)menuTest).Location);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.MenuStrip menu = new WinformsGenerator.MenuStrip ();
			Assert.IsEmpty (menu.items);
			menu.AddItem ();
			Assert.IsNotEmpty (menu.items);
		}
	}
}