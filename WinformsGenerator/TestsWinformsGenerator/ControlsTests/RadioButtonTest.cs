using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class RadioButtonTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.RadioButton radioB = new WinformsGenerator.RadioButton ();
			radioB.Name = "element";
			radioB.Text = "element";
			radioB.Anchor = AnchorStyles.None;
			radioB.Dock = DockStyle.Fill;
			radioB.TextAlign = ContentAlignment.TopRight;
			radioB.BackColor = Color.White;
			radioB.Size = new Size (100, 100);
			radioB.Location = new Point (0, 0);
			radioB.Checked = true;

			System.Windows.Forms.RadioButton RadioBTest = (System.Windows.Forms.RadioButton)radioB.DrawElement ();

			System.Windows.Forms.RadioButton radioBReal = new System.Windows.Forms.RadioButton ();
			radioBReal.Name = "element";
			radioBReal.Text = "element";
			radioBReal.Anchor = AnchorStyles.None;
			radioBReal.Dock = DockStyle.Fill;
			radioBReal.TextAlign =ContentAlignment.TopRight;
			radioBReal.BackColor = Color.White;
			radioBReal.Size = new Size (100, 100);
			radioBReal.Location = new Point (0, 0);
			radioBReal.Checked = true;

			Assert.IsInstanceOfType (radioBReal.GetType (), RadioBTest);
			Assert.AreEqual (radioBReal.Name, RadioBTest.Name);
			Assert.AreEqual (radioBReal.Text, RadioBTest.Text);
			Assert.AreEqual (radioBReal.Anchor, RadioBTest.Anchor);
			Assert.AreEqual (radioBReal.Dock, RadioBTest.Dock);
			Assert.AreEqual (radioBReal.TextAlign, RadioBTest.TextAlign);
			Assert.AreEqual (radioBReal.BackColor, RadioBTest.BackColor);
			Assert.AreEqual (radioBReal.Size, RadioBTest.Size);
			Assert.AreEqual (radioBReal.Location, RadioBTest.Location);
			Assert.AreEqual (radioBReal.Checked, RadioBTest.Checked);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.RadioButton RadioB = new WinformsGenerator.RadioButton ();
			RadioB.Name = "element";
			RadioB.Text = "element";
			RadioB.Anchor = AnchorStyles.None;
			RadioB.Dock = DockStyle.Fill;
			RadioB.TextAlign = ContentAlignment.TopRight;
			RadioB.BackColor = Color.White;
			RadioB.Size = new Size (100, 100);
			RadioB.Location = new Point (0, 0);
			RadioB.Checked = true;

			WinformsGenerator.Element RadioBTest = RadioB.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.RadioButton), RadioBTest);
			Assert.AreEqual (RadioB.Name,((WinformsGenerator.RadioButton)RadioBTest).Name);
			Assert.AreEqual (RadioB.Text,((WinformsGenerator.RadioButton)RadioBTest).Text);
			Assert.AreEqual (RadioB.Anchor,((WinformsGenerator.RadioButton)RadioBTest).Anchor);
			Assert.AreEqual (RadioB.Dock,((WinformsGenerator.RadioButton)RadioBTest).Dock);
			Assert.AreEqual (RadioB.TextAlign, ((WinformsGenerator.RadioButton)RadioBTest).TextAlign);
			Assert.AreEqual (RadioB.BackColor,((WinformsGenerator.RadioButton)RadioBTest).BackColor);
			Assert.AreEqual (RadioB.Size,((WinformsGenerator.RadioButton)RadioBTest).Size);
			Assert.AreEqual (RadioB.Location,((WinformsGenerator.RadioButton)RadioBTest).Location);
			Assert.AreEqual (RadioB.Checked, ((WinformsGenerator.RadioButton)RadioBTest).Checked);
		}
	}
}

