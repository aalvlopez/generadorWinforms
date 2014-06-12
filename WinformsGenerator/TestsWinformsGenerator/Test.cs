using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			WinformsGenerator.Controller.init ();
			WinformsGenerator.Form appForm = WinformsGenerator.Controller.GetForm ();
			appForm.Size = new Size (1000, 800);
			appForm.Anchor = AnchorStyles.None;
			appForm.BackColor = Color.White;
			appForm.Dock = DockStyle.Fill;
			appForm.Location = new Point (0, 0);
			appForm.Name = "form";
			appForm.Text = "form";

			WinformsGenerator.Button btn = new WinformsGenerator.Button ();
			btn.Dock = DockStyle.None;
			btn.Anchor = AnchorStyles.None;
			btn.BackColor = Color.White;
			btn.Location = new Point (0, 0);
			btn.Name = "btn";
			btn.Size = new Size (60, 25);
			btn.Text = "btn";
			WinformsGenerator.Controller.addElemnt (btn);
			System.Windows.Forms.Form form = WinformsGenerator.Controller.GetForm ().DrawForm ();

			System.Windows.Forms.Form formTest = new System.Windows.Forms.Form ();
			formTest.Size = new Size (1000, 800);
			formTest.Size = new Size (1000, 800);
			formTest.Anchor = AnchorStyles.None;
			formTest.BackColor = Color.White;
			formTest.Dock = DockStyle.Fill;
			formTest.Location = new Point (0, 0);
			formTest.Name = "form";
			formTest.Text = "form";

			System.Windows.Forms.Button btnTest = new System.Windows.Forms.Button ();
			btnTest.Dock = DockStyle.None;
			btnTest.Anchor = AnchorStyles.None;
			btnTest.BackColor = Color.White;
			btnTest.Location = new Point (0, 0);
			btnTest.Name = "btn";
			btnTest.Size = new Size (60, 25);
			btnTest.Text = "btn";
			formTest.Controls.Add (btnTest);

			formTest.Show (null);
			Application.Run (form);

			Assert.AreEqual( form, formTest);
			
		}
	}
}

