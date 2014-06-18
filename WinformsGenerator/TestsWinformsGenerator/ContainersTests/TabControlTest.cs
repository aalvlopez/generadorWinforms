using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class TabControlTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.TabControl tabCon = new WinformsGenerator.TabControl ();
			tabCon.Name = "container";
			tabCon.Anchor = AnchorStyles.None;
			tabCon.Dock = DockStyle.Fill;
			tabCon.BackColor = Color.White;
			tabCon.Size = new Size (100, 100);
			tabCon.Location = new Point (0, 0);

			System.Windows.Forms.TabControl tabConTest = (System.Windows.Forms.TabControl)tabCon.DrawElement ();

			System.Windows.Forms.TabControl tabConReal = new System.Windows.Forms.TabControl ();
			tabConReal.Name = "container";
			tabConReal.Anchor = AnchorStyles.None;
			tabConReal.Dock = DockStyle.Fill;
			tabConReal.BackColor = Color.White;
			tabConReal.Size = new Size (100, 100);
			tabConReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (tabConReal.GetType (), tabConTest);
			Assert.AreEqual (tabConReal.Name, tabConTest.Name);
			Assert.AreEqual (tabConReal.Anchor, tabConTest.Anchor);
			Assert.AreEqual (tabConReal.Dock, tabConTest.Dock);
			Assert.AreEqual (tabConReal.BackColor, tabConTest.BackColor);
			Assert.AreEqual (tabConReal.Size, tabConTest.Size);
			Assert.AreEqual (tabConReal.Location, tabConTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.TabControl tabCon = new WinformsGenerator.TabControl ();
			tabCon.Name = "container";
			tabCon.Anchor = AnchorStyles.None;
			tabCon.Dock = DockStyle.Fill;
			tabCon.BackColor = Color.White;
			tabCon.Size = new Size (100, 100);
			tabCon.Location = new Point (0, 0);

			WinformsGenerator.Element tabConTest = tabCon.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.TabControl), tabConTest);
			Assert.AreEqual (tabCon.Name,((WinformsGenerator.TabControl)tabConTest).Name);
			Assert.AreEqual (tabCon.Anchor,((WinformsGenerator.TabControl)tabConTest).Anchor);
			Assert.AreEqual (tabCon.Dock,((WinformsGenerator.TabControl)tabConTest).Dock);
			Assert.AreEqual (tabCon.BackColor,((WinformsGenerator.TabControl)tabConTest).BackColor);
			Assert.AreEqual (tabCon.Size,((WinformsGenerator.TabControl)tabConTest).Size);
			Assert.AreEqual (tabCon.Location,((WinformsGenerator.TabControl)tabConTest).Location);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.TabControl tabCon = new WinformsGenerator.TabControl ();
			Assert.IsEmpty (tabCon.elementos);
			tabCon.AddElem (new WinformsGenerator.TabPage());
			Assert.IsNotEmpty (tabCon.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.TabPage), tabCon.elementos [0]);
		}
	}
}

