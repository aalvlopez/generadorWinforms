using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class StatusBarTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.StatusBar status = new WinformsGenerator.StatusBar ();
			status.Name = "element";
			status.Text = "element";
			status.Anchor = AnchorStyles.None;
			status.Dock = DockStyle.Left;
			status.BackColor = Color.White;
			status.Size = new Size (100, 100);
			status.Location = new Point (0, 0);

			System.Windows.Forms.StatusBar statusTest = (System.Windows.Forms.StatusBar)status.DrawElement ();

			System.Windows.Forms.StatusBar StatusReal = new System.Windows.Forms.StatusBar ();
			StatusReal.Name = "element";
			StatusReal.Text = "element";
			StatusReal.Anchor = AnchorStyles.None;
			StatusReal.Dock = DockStyle.Left;
			StatusReal.BackColor = Color.White;
			StatusReal.Size = new Size (100, 100);
			StatusReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (StatusReal.GetType (), statusTest);
			Assert.AreEqual (StatusReal.Name, statusTest.Name);
			Assert.AreEqual (StatusReal.Text, statusTest.Text);
			Assert.AreEqual (StatusReal.Anchor, statusTest.Anchor);
			Assert.AreEqual (StatusReal.Dock, statusTest.Dock);
			Assert.AreEqual (StatusReal.BackColor, statusTest.BackColor);
			Assert.AreEqual (StatusReal.Size, statusTest.Size);
			Assert.AreEqual (StatusReal.Location, statusTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.StatusBar status = new WinformsGenerator.StatusBar ();
			status.Name = "element";
			status.Text = "element";
			status.Anchor = AnchorStyles.None;
			status.Dock = DockStyle.Left;
			status.BackColor = Color.White;
			status.Size = new Size (100, 100);
			status.Location = new Point (0, 0);

			WinformsGenerator.Element statusTest = status.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.StatusBar), statusTest);
			Assert.AreEqual (status.Name,((WinformsGenerator.StatusBar)statusTest).Name);
			Assert.AreEqual (status.Text,((WinformsGenerator.StatusBar)statusTest).Text);
			Assert.AreEqual (status.Anchor,((WinformsGenerator.StatusBar)statusTest).Anchor);
			Assert.AreEqual (status.Dock,((WinformsGenerator.StatusBar)statusTest).Dock);
			Assert.AreEqual (status.BackColor,((WinformsGenerator.StatusBar)statusTest).BackColor);
			Assert.AreEqual (status.Size,((WinformsGenerator.StatusBar)statusTest).Size);
			Assert.AreEqual (status.Location,((WinformsGenerator.StatusBar)statusTest).Location);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.StatusBar status = new WinformsGenerator.StatusBar ();
			Assert.IsEmpty (status.items);
			status.AddItem ();
			Assert.IsNotEmpty (status.items);
		}
	}
}