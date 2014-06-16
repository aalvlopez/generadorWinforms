using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class DataGridViewTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.DataGridView dataG = new WinformsGenerator.DataGridView ();
			dataG.Name = "element";
			dataG.Anchor = AnchorStyles.None;
			dataG.Dock = DockStyle.Left;
			dataG.BackColor = Color.White;
			dataG.Size = new Size (100, 100);
			dataG.Location = new Point (0, 0);

			System.Windows.Forms.DataGridView dataGTest = (System.Windows.Forms.DataGridView)dataG.DrawElement ();

			System.Windows.Forms.DataGridView dataGReal = new System.Windows.Forms.DataGridView ();
			dataGReal.Name = "element";
			dataGReal.Anchor = AnchorStyles.None;
			dataGReal.Dock = DockStyle.Left;
			dataGReal.BackColor = Color.White;
			dataGReal.Size = new Size (100, 100);
			dataGReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (dataGReal.GetType (), dataGTest);
			Assert.AreEqual (dataGReal.Name, dataGTest.Name);
			Assert.AreEqual (dataGReal.Anchor, dataGTest.Anchor);
			Assert.AreEqual (dataGReal.Dock, dataGTest.Dock);
			Assert.AreEqual (dataGReal.BackColor, dataGTest.BackColor);
			Assert.AreEqual (dataGReal.Size, dataGTest.Size);
			Assert.AreEqual (dataGReal.Location, dataGTest.Location);
			Assert.AreEqual (dataGReal.ColumnCount, dataGTest.Columns.Count);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.DataGridView dataG = new WinformsGenerator.DataGridView ();
			dataG.Name = "element";
			dataG.Anchor = AnchorStyles.None;
			dataG.Dock = DockStyle.Left;
			dataG.BackColor = Color.White;
			dataG.Size = new Size (100, 100);
			dataG.Location = new Point (0, 0);

			WinformsGenerator.Element dataGTest = dataG.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.DataGridView), dataGTest);
			Assert.AreEqual (dataG.Name,((WinformsGenerator.DataGridView)dataGTest).Name);
			Assert.AreEqual (dataG.Anchor,((WinformsGenerator.DataGridView)dataGTest).Anchor);
			Assert.AreEqual (dataG.Dock,((WinformsGenerator.DataGridView)dataGTest).Dock);
			Assert.AreEqual (dataG.BackColor,((WinformsGenerator.DataGridView)dataGTest).BackColor);
			Assert.AreEqual (dataG.Size,((WinformsGenerator.DataGridView)dataGTest).Size);
			Assert.AreEqual (dataG.Location,((WinformsGenerator.DataGridView)dataGTest).Location);
			Assert.AreEqual (dataG.Columns.Count,((WinformsGenerator.DataGridView)dataGTest).Columns.Count);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.DataGridView dataG = new WinformsGenerator.DataGridView ();
			Assert.IsEmpty (dataG.items);
			dataG.AddItem ();
			Assert.IsNotEmpty (dataG.items);
		}
	}
}