using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class CheckoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.CheckBox checkB = new WinformsGenerator.CheckBox ();
			checkB.Name = "element";
			checkB.Text = "element";
			checkB.Anchor = AnchorStyles.None;
			checkB.Dock = DockStyle.Fill;
			checkB.TextAlign = ContentAlignment.TopRight;
			checkB.BackColor = Color.White;
			checkB.Size = new Size (100, 100);
			checkB.Location = new Point (0, 0);
			checkB.Checked = true;

			System.Windows.Forms.CheckBox checkBTest = (System.Windows.Forms.CheckBox)checkB.DrawElement ();

			System.Windows.Forms.CheckBox checkBReal = new System.Windows.Forms.CheckBox ();
			checkBReal.Name = "element";
			checkBReal.Text = "element";
			checkBReal.Anchor = AnchorStyles.None;
			checkBReal.Dock = DockStyle.Fill;
			checkBReal.TextAlign =ContentAlignment.TopRight;
			checkBReal.BackColor = Color.White;
			checkBReal.Size = new Size (100, 100);
			checkBReal.Location = new Point (0, 0);
			checkBReal.Checked = true;

			Assert.IsInstanceOfType (checkBReal.GetType (), checkBTest);
			Assert.AreEqual (checkBReal.Name, checkBTest.Name);
			Assert.AreEqual (checkBReal.Text, checkBTest.Text);
			Assert.AreEqual (checkBReal.Anchor, checkBTest.Anchor);
			Assert.AreEqual (checkBReal.Dock, checkBTest.Dock);
			Assert.AreEqual (checkBReal.TextAlign, checkBTest.TextAlign);
			Assert.AreEqual (checkBReal.BackColor, checkBTest.BackColor);
			Assert.AreEqual (checkBReal.Size, checkBTest.Size);
			Assert.AreEqual (checkBReal.Location, checkBTest.Location);
			Assert.AreEqual (checkBReal.Checked, checkBTest.Checked);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.CheckBox checkB = new WinformsGenerator.CheckBox ();
			checkB.Name = "element";
			checkB.Text = "element";
			checkB.Anchor = AnchorStyles.None;
			checkB.Dock = DockStyle.Fill;
			checkB.TextAlign = ContentAlignment.TopRight;
			checkB.BackColor = Color.White;
			checkB.Size = new Size (100, 100);
			checkB.Location = new Point (0, 0);
			checkB.Checked = true;

			WinformsGenerator.Element checkBTest = checkB.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.CheckBox), checkBTest);
			Assert.AreEqual (checkB.Name,((WinformsGenerator.CheckBox)checkBTest).Name);
			Assert.AreEqual (checkB.Text,((WinformsGenerator.CheckBox)checkBTest).Text);
			Assert.AreEqual (checkB.Anchor,((WinformsGenerator.CheckBox)checkBTest).Anchor);
			Assert.AreEqual (checkB.Dock,((WinformsGenerator.CheckBox)checkBTest).Dock);
			Assert.AreEqual (checkB.TextAlign, ((WinformsGenerator.CheckBox)checkBTest).TextAlign);
			Assert.AreEqual (checkB.BackColor,((WinformsGenerator.CheckBox)checkBTest).BackColor);
			Assert.AreEqual (checkB.Size,((WinformsGenerator.CheckBox)checkBTest).Size);
			Assert.AreEqual (checkB.Location,((WinformsGenerator.CheckBox)checkBTest).Location);
			Assert.AreEqual (checkB.Checked, ((WinformsGenerator.CheckBox)checkBTest).Checked);
		}
	}
}

