using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ProgressBarTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.ProgressBar progress = new WinformsGenerator.ProgressBar ();
			progress.Name = "element";
			progress.Text = "element";
			progress.Anchor = AnchorStyles.None;
			progress.Dock = DockStyle.Left;
			progress.BackColor = Color.White;
			progress.Size = new Size (100, 100);
			progress.Location = new Point (0, 0);
			progress.Value = 27;

			System.Windows.Forms.ProgressBar progressTest = (System.Windows.Forms.ProgressBar)progress.DrawElement ();

			System.Windows.Forms.ProgressBar progressReal = new System.Windows.Forms.ProgressBar ();
			progressReal.Name = "element";
			progressReal.Text = "element";
			progressReal.Anchor = AnchorStyles.None;
			progressReal.Dock = DockStyle.Left;
			progressReal.BackColor = Color.White;
			progressReal.Size = new Size (100, 100);
			progressReal.Location = new Point (0, 0);
			progressReal.Value = 27;

			Assert.IsInstanceOfType (progressReal.GetType (), progressTest);
			Assert.AreEqual (progressReal.Name, progressTest.Name);
			Assert.AreEqual (progressReal.Text, progressTest.Text);
			Assert.AreEqual (progressReal.Anchor, progressTest.Anchor);
			Assert.AreEqual (progressReal.Dock, progressTest.Dock);
			Assert.AreEqual (progressReal.BackColor, progressTest.BackColor);
			Assert.AreEqual (progressReal.Size, progressTest.Size);
			Assert.AreEqual (progressReal.Location, progressTest.Location);
			Assert.AreEqual (progressReal.Value, progressTest.Value);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.ProgressBar progress = new WinformsGenerator.ProgressBar ();
			progress.Name = "element";
			progress.Text = "element";
			progress.Anchor = AnchorStyles.None;
			progress.Dock = DockStyle.Left;
			progress.BackColor = Color.White;
			progress.Size = new Size (100, 100);
			progress.Location = new Point (0, 0);
			progress.Value = 27;

			WinformsGenerator.Element progressTest = progress.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ProgressBar), progressTest);
			Assert.AreEqual (progress.Name,((WinformsGenerator.ProgressBar)progressTest).Name);
			Assert.AreEqual (progress.Text,((WinformsGenerator.ProgressBar)progressTest).Text);
			Assert.AreEqual (progress.Anchor,((WinformsGenerator.ProgressBar)progressTest).Anchor);
			Assert.AreEqual (progress.Dock,((WinformsGenerator.ProgressBar)progressTest).Dock);
			Assert.AreEqual (progress.BackColor,((WinformsGenerator.ProgressBar)progressTest).BackColor);
			Assert.AreEqual (progress.Size,((WinformsGenerator.ProgressBar)progressTest).Size);
			Assert.AreEqual (progress.Location,((WinformsGenerator.ProgressBar)progressTest).Location);
			Assert.AreEqual (progress.Value,((WinformsGenerator.ProgressBar)progressTest).Value);
		}
	}
}

