using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class TextBoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.TextBox txtBox = new WinformsGenerator.TextBox ();
			txtBox.Name = "element";
			txtBox.Text = "element";
			txtBox.Anchor = AnchorStyles.None;
			txtBox.Dock = DockStyle.Fill;
			txtBox.TextAlign = HorizontalAlignment.Center;
			txtBox.BackColor = Color.White;
			txtBox.Size = new Size (100, 100);
			txtBox.Location = new Point (0, 0);

			System.Windows.Forms.TextBox txtBoxTest = (System.Windows.Forms.TextBox)txtBox.DrawElement ();

			System.Windows.Forms.TextBox txtBoxReal = new System.Windows.Forms.TextBox ();
			txtBoxReal.Name = "element";
			txtBoxReal.Text = "element";
			txtBoxReal.Anchor = AnchorStyles.None;
			txtBoxReal.Dock = DockStyle.Fill;
			txtBoxReal.TextAlign = HorizontalAlignment.Center;
			txtBoxReal.BackColor = Color.White;
			txtBoxReal.Size = new Size (100, 100);
			txtBoxReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (txtBoxReal.GetType (), txtBoxTest);
			Assert.AreEqual (txtBoxReal.Name, txtBoxTest.Name);
			Assert.AreEqual (txtBoxReal.Text, txtBoxTest.Text);
			Assert.AreEqual (txtBoxReal.Anchor, txtBoxTest.Anchor);
			Assert.AreEqual (txtBoxReal.Dock, txtBoxTest.Dock);
			Assert.AreEqual (txtBoxReal.TextAlign, txtBoxTest.TextAlign);
			Assert.AreEqual (txtBoxReal.BackColor, txtBoxTest.BackColor);
			Assert.AreEqual (txtBoxReal.Size, txtBoxTest.Size);
			Assert.AreEqual (txtBoxReal.Location, txtBoxTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.TextBox txtBox = new WinformsGenerator.TextBox ();
			txtBox.Name = "element";
			txtBox.Text = "element";
			txtBox.Anchor = AnchorStyles.None;
			txtBox.Dock = DockStyle.Fill;
			txtBox.TextAlign = HorizontalAlignment.Center;
			txtBox.BackColor = Color.White;
			txtBox.Size = new Size (100, 100);
			txtBox.Location = new Point (0, 0);

			WinformsGenerator.Element txtBoxTest = txtBox.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.TextBox), txtBoxTest);
			Assert.AreEqual (txtBox.Name,((WinformsGenerator.TextBox)txtBoxTest).Name);
			Assert.AreEqual (txtBox.Text,((WinformsGenerator.TextBox)txtBoxTest).Text);
			Assert.AreEqual (txtBox.Anchor,((WinformsGenerator.TextBox)txtBoxTest).Anchor);
			Assert.AreEqual (txtBox.Dock,((WinformsGenerator.TextBox)txtBoxTest).Dock);
			Assert.AreEqual (txtBox.TextAlign, ((WinformsGenerator.TextBox)txtBoxTest).TextAlign);
			Assert.AreEqual (txtBox.BackColor,((WinformsGenerator.TextBox)txtBoxTest).BackColor);
			Assert.AreEqual (txtBox.Size,((WinformsGenerator.TextBox)txtBoxTest).Size);
			Assert.AreEqual (txtBox.Location,((WinformsGenerator.TextBox)txtBoxTest).Location);
		}
	}
}

