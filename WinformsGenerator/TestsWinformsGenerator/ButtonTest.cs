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
			btn.BackColor = Color.White;
			btn.Size = new Size (100, 100);
			btn.Location = new Point (0, 0);

			System.Windows.Forms.Button btnTest = (System.Windows.Forms.Button)btn.DrawElement ();

			System.Windows.Forms.Button btnReal = new System.Windows.Forms.Button ();
			btnReal.Name = "btn";
			btnReal.Text = "btn";
			btnReal.Anchor = AnchorStyles.None;
			btnReal.Dock = DockStyle.Fill;
			btnReal.BackColor = Color.White;
			btnReal.Size = new Size (100, 100);
			btnReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (btnReal.GetType (), btnTest);
			Assert.AreEqual (btnReal.Name, btnTest.Name);
			Assert.AreEqual (btnReal.Text, btnTest.Text);
			Assert.AreEqual (btnReal.Anchor, btnTest.Anchor);
			Assert.AreEqual (btnReal.Dock, btnTest.Dock);
			Assert.AreEqual (btnReal.BackColor, btnTest.BackColor);
			Assert.AreEqual (btnReal.Size, btnTest.Size);
			Assert.AreEqual (btnReal.Location, btnTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{

		}
	}
}

