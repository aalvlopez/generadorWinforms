using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class BorderTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.Border border = new WinformsGenerator.Border ();
			border.Name = "container";
			border.Anchor = AnchorStyles.None;
			border.Dock = DockStyle.Fill;
			border.BackColor = Color.White;
			border.Size = new Size (100, 100);
			border.Location = new Point (0, 0);

			System.Windows.Forms.Panel borderTest = (System.Windows.Forms.Panel)border.DrawElement ();

			System.Windows.Forms.Panel borderReal = new System.Windows.Forms.Panel ();
			borderReal.Name = "container";
			borderReal.Anchor = AnchorStyles.None;
			borderReal.Dock = DockStyle.Fill;
			borderReal.BackColor = Color.White;
			borderReal.Size = new Size (100, 100);
			borderReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (borderReal.GetType (), borderTest);
			Assert.AreEqual (borderReal.Name, borderTest.Name);
			Assert.AreEqual (borderReal.Anchor, borderTest.Anchor);
			Assert.AreEqual (borderReal.Dock, borderTest.Dock);
			Assert.AreEqual (borderReal.BackColor, borderTest.BackColor);
			Assert.AreEqual (borderReal.Size, borderTest.Size);
			Assert.AreEqual (borderReal.Location, borderTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.Border border = new WinformsGenerator.Border ();
			border.Name = "container";
			border.Anchor = AnchorStyles.None;
			border.Dock = DockStyle.Fill;
			border.BackColor = Color.White;
			border.Size = new Size (100, 100);
			border.Location = new Point (0, 0);

			WinformsGenerator.Element borderTest = border.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.Border), borderTest);
			Assert.AreEqual (border.Name,((WinformsGenerator.Border)borderTest).Name);
			Assert.AreEqual (border.Anchor,((WinformsGenerator.Border)borderTest).Anchor);
			Assert.AreEqual (border.Dock,((WinformsGenerator.Border)borderTest).Dock);
			Assert.AreEqual (border.BackColor,((WinformsGenerator.Border)borderTest).BackColor);
			Assert.AreEqual (border.Size,((WinformsGenerator.Border)borderTest).Size);
			Assert.AreEqual (border.Location,((WinformsGenerator.Border)borderTest).Location);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.Border border = new WinformsGenerator.Border ();
			Assert.IsEmpty (border.elementos);
			border.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (border.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), border.elementos [0]);
		}
	}
}

