using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ButtonTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.Button btn = new WinformsGenerator.Button ();
			btn.Name = "btn";
			btn.Text = "btn";
			btn.Anchor = AnchorStyles.None;
			btn.Dock = DockStyle.Fill;
			btn.TextAlign = ContentAlignment.BottomCenter;
			btn.BackColor = Color.White;
			btn.Size = new Size (100, 100);
			btn.Location = new Point (0, 0);

			System.Windows.Forms.Button btnTest = (System.Windows.Forms.Button)btn.DrawElement ();

			System.Windows.Forms.Button btnReal = new System.Windows.Forms.Button ();
			btnReal.Name = "btn";
			btnReal.Text = "btn";
			btnReal.Anchor = AnchorStyles.None;
			btnReal.Dock = DockStyle.Fill;
			btnReal.TextAlign = ContentAlignment.BottomCenter;
			btnReal.BackColor = Color.White;
			btnReal.Size = new Size (100, 100);
			btnReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (btnReal.GetType (), btnTest);
			Assert.AreEqual (btnReal.Name, btnTest.Name);
			Assert.AreEqual (btnReal.Text, btnTest.Text);
			Assert.AreEqual (btnReal.Anchor, btnTest.Anchor);
			Assert.AreEqual (btnReal.Dock, btnTest.Dock);
			Assert.AreEqual (btnReal.TextAlign, btnTest.TextAlign);
			Assert.AreEqual (btnReal.BackColor, btnTest.BackColor);
			Assert.AreEqual (btnReal.Size, btnTest.Size);
			Assert.AreEqual (btnReal.Location, btnTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.Button btn = new WinformsGenerator.Button ();
			btn.Name = "btn";
			btn.Text = "btn";
			btn.Anchor = AnchorStyles.None;
			btn.Dock = DockStyle.Fill;
			btn.TextAlign = ContentAlignment.BottomCenter;
			btn.BackColor = Color.White;
			btn.Size = new Size (100, 100);
			btn.Location = new Point (0, 0);

			WinformsGenerator.Element btnTest = btn.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), btnTest);
			Assert.AreEqual (btn.Name,((WinformsGenerator.Button)btnTest).Name);
			Assert.AreEqual (btn.Text,((WinformsGenerator.Button)btnTest).Text);
			Assert.AreEqual (btn.Anchor,((WinformsGenerator.Button)btnTest).Anchor);
			Assert.AreEqual (btn.Dock,((WinformsGenerator.Button)btnTest).Dock);
			Assert.AreEqual (btn.TextAlign, ((WinformsGenerator.Button)btnTest).TextAlign);
			Assert.AreEqual (btn.BackColor,((WinformsGenerator.Button)btnTest).BackColor);
			Assert.AreEqual (btn.Size,((WinformsGenerator.Button)btnTest).Size);
			Assert.AreEqual (btn.Location,((WinformsGenerator.Button)btnTest).Location);
		}
	}
}

