using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class LabelTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.Label lbl = new WinformsGenerator.Label ();
			lbl.Name = "element";
			lbl.Text = "element";
			lbl.Anchor = AnchorStyles.None;
			lbl.Dock = DockStyle.Fill;
			lbl.TextAlign = ContentAlignment.BottomCenter;
			lbl.BackColor = Color.White;
			lbl.Size = new Size (100, 100);
			lbl.Location = new Point (0, 0);

			System.Windows.Forms.Label lblTest = (System.Windows.Forms.Label)lbl.DrawElement ();

			System.Windows.Forms.Label lblReal = new System.Windows.Forms.Label ();
			lblReal.Name = "element";
			lblReal.Text = "element";
			lblReal.Anchor = AnchorStyles.None;
			lblReal.Dock = DockStyle.Fill;
			lblReal.TextAlign = ContentAlignment.BottomCenter;
			lblReal.BackColor = Color.White;
			lblReal.Size = new Size (100, 100);
			lblReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (lblReal.GetType (), lblTest);
			Assert.AreEqual (lblReal.Name, lblTest.Name);
			Assert.AreEqual (lblReal.Text, lblTest.Text);
			Assert.AreEqual (lblReal.Anchor, lblTest.Anchor);
			Assert.AreEqual (lblReal.Dock, lblTest.Dock);
			Assert.AreEqual (lblReal.TextAlign, lblTest.TextAlign);
			Assert.AreEqual (lblReal.BackColor, lblTest.BackColor);
			Assert.AreEqual (lblReal.Size, lblTest.Size);
			Assert.AreEqual (lblReal.Location, lblTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.Label lbl = new WinformsGenerator.Label ();
			lbl.Name = "element";
			lbl.Text = "element";
			lbl.Anchor = AnchorStyles.None;
			lbl.Dock = DockStyle.Fill;
			lbl.TextAlign = ContentAlignment.BottomCenter;
			lbl.BackColor = Color.White;
			lbl.Size = new Size (100, 100);
			lbl.Location = new Point (0, 0);

			WinformsGenerator.Element lblTest = lbl.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.Label), lblTest);
			Assert.AreEqual (lbl.Name,((WinformsGenerator.Label)lblTest).Name);
			Assert.AreEqual (lbl.Text,((WinformsGenerator.Label)lblTest).Text);
			Assert.AreEqual (lbl.Anchor,((WinformsGenerator.Label)lblTest).Anchor);
			Assert.AreEqual (lbl.Dock,((WinformsGenerator.Label)lblTest).Dock);
			Assert.AreEqual (lbl.TextAlign, ((WinformsGenerator.Label)lblTest).TextAlign);
			Assert.AreEqual (lbl.BackColor,((WinformsGenerator.Label)lblTest).BackColor);
			Assert.AreEqual (lbl.Size,((WinformsGenerator.Label)lblTest).Size);
			Assert.AreEqual (lbl.Location,((WinformsGenerator.Label)lblTest).Location);
		}
	}
}

