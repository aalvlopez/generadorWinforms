using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class SplitterTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.Splitter split = new WinformsGenerator.Splitter ();
			split.Name = "element";
			split.Text = "element";
			split.Anchor = AnchorStyles.None;
			split.Dock = DockStyle.Left;
			split.BackColor = Color.White;
			split.Size = new Size (100, 100);
			split.Location = new Point (0, 0);

			System.Windows.Forms.Splitter splitTest = (System.Windows.Forms.Splitter)split.DrawElement ();

			System.Windows.Forms.Splitter splitReal = new System.Windows.Forms.Splitter ();
			splitReal.Name = "element";
			splitReal.Text = "element";
			splitReal.Anchor = AnchorStyles.None;
			splitReal.Dock = DockStyle.Left;
			splitReal.BackColor = Color.White;
			splitReal.Size = new Size (100, 100);
			splitReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (splitReal.GetType (), splitTest);
			Assert.AreEqual (splitReal.Name, splitTest.Name);
			Assert.AreEqual (splitReal.Text, splitTest.Text);
			Assert.AreEqual (splitReal.Anchor, splitTest.Anchor);
			Assert.AreEqual (splitReal.Dock, splitTest.Dock);
			Assert.AreEqual (splitReal.BackColor, splitTest.BackColor);
			Assert.AreEqual (splitReal.Size, splitTest.Size);
			Assert.AreEqual (splitReal.Location, splitTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.Splitter split = new WinformsGenerator.Splitter ();
			split.Name = "element";
			split.Text = "element";
			split.Anchor = AnchorStyles.None;
			split.Dock = DockStyle.Left;
			split.BackColor = Color.White;
			split.Size = new Size (100, 100);
			split.Location = new Point (0, 0);

			WinformsGenerator.Element splitTest = split.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.Splitter), splitTest);
			Assert.AreEqual (split.Name,((WinformsGenerator.Splitter)splitTest).Name);
			Assert.AreEqual (split.Text,((WinformsGenerator.Splitter)splitTest).Text);
			Assert.AreEqual (split.Anchor,((WinformsGenerator.Splitter)splitTest).Anchor);
			Assert.AreEqual (split.Dock,((WinformsGenerator.Splitter)splitTest).Dock);
			Assert.AreEqual (split.BackColor,((WinformsGenerator.Splitter)splitTest).BackColor);
			Assert.AreEqual (split.Size,((WinformsGenerator.Splitter)splitTest).Size);
			Assert.AreEqual (split.Location,((WinformsGenerator.Splitter)splitTest).Location);
		}
	}
}

