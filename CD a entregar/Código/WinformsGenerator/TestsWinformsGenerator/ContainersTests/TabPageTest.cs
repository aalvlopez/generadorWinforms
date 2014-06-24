using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class TabPageTest
	{
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.TabPage tabCon = new WinformsGenerator.TabPage ();
			tabCon.Name = "btn";
			tabCon.Anchor = AnchorStyles.None;
			tabCon.Dock = DockStyle.Fill;
			tabCon.BackColor = Color.White;
			tabCon.Size = new Size (100, 100);
			tabCon.Location = new Point (0, 0);

			WinformsGenerator.Element tabConTest = tabCon.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.TabPage), tabConTest);
			Assert.AreEqual (tabCon.Name,((WinformsGenerator.TabPage)tabConTest).Name);
			Assert.AreEqual (tabCon.Anchor,((WinformsGenerator.TabPage)tabConTest).Anchor);
			Assert.AreEqual (tabCon.Dock,((WinformsGenerator.TabPage)tabConTest).Dock);
			Assert.AreEqual (tabCon.BackColor,((WinformsGenerator.TabPage)tabConTest).BackColor);
			Assert.AreEqual (tabCon.Size,((WinformsGenerator.TabPage)tabConTest).Size);
			Assert.AreEqual (tabCon.Location,((WinformsGenerator.TabPage)tabConTest).Location);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.TabPage tabCon = new WinformsGenerator.TabPage ();
			Assert.IsEmpty (tabCon.elementos);
			tabCon.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (tabCon.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), tabCon.elementos [0]);
		}
	}
}

