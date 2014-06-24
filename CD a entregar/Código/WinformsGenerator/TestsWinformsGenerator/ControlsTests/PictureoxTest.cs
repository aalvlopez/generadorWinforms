using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class PictureoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.PictureBox picB = new WinformsGenerator.PictureBox ();
			picB.Name = "element";
			picB.Text = "element";
			picB.Anchor = AnchorStyles.None;
			picB.Dock = DockStyle.Left;
			picB.BackColor = Color.White;
			picB.Size = new Size (100, 100);
			picB.Location = new Point (0, 0);
			picB.Image = "image.png";

			System.Windows.Forms.PictureBox picBTest = (System.Windows.Forms.PictureBox)picB.DrawElement ();

			System.Windows.Forms.PictureBox picBReal = new System.Windows.Forms.PictureBox ();
			picBReal.Name = "element";
			picBReal.Text = "element";
			picBReal.Anchor = AnchorStyles.None;
			picBReal.Dock = DockStyle.Left;
			picBReal.BackColor = Color.White;
			picBReal.Size = new Size (100, 100);
			picBReal.Location = new Point (0, 0);
			picB.Image = "image.png";

			Assert.IsInstanceOfType (picBReal.GetType (), picBTest);
			Assert.AreEqual (picBReal.Name, picBTest.Name);
			Assert.AreEqual (picBReal.Text, picBTest.Text);
			Assert.AreEqual (picBReal.Anchor, picBTest.Anchor);
			Assert.AreEqual (picBReal.Dock, picBTest.Dock);
			Assert.AreEqual (picBReal.BackColor, picBTest.BackColor);
			Assert.AreEqual (picBReal.Size, picBTest.Size);
			Assert.AreEqual (picBReal.Location, picBTest.Location);
			Assert.AreEqual (picBReal.Image, picBTest.Image);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.PictureBox picB = new WinformsGenerator.PictureBox ();
			picB.Name = "element";
			picB.Text = "element";
			picB.Anchor = AnchorStyles.None;
			picB.Dock = DockStyle.Left;
			picB.BackColor = Color.White;
			picB.Size = new Size (100, 100);
			picB.Location = new Point (0, 0);
			picB.Image = "image.png";

			WinformsGenerator.Element picBTest = picB.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.PictureBox), picBTest);
			Assert.AreEqual (picB.Name,((WinformsGenerator.PictureBox)picBTest).Name);
			Assert.AreEqual (picB.Text,((WinformsGenerator.PictureBox)picBTest).Text);
			Assert.AreEqual (picB.Anchor,((WinformsGenerator.PictureBox)picBTest).Anchor);
			Assert.AreEqual (picB.Dock,((WinformsGenerator.PictureBox)picBTest).Dock);
			Assert.AreEqual (picB.BackColor,((WinformsGenerator.PictureBox)picBTest).BackColor);
			Assert.AreEqual (picB.Size,((WinformsGenerator.PictureBox)picBTest).Size);
			Assert.AreEqual (picB.Location,((WinformsGenerator.PictureBox)picBTest).Location);
			Assert.AreEqual (picB.Image,((WinformsGenerator.PictureBox)picBTest).Image);
		}
	}
}

