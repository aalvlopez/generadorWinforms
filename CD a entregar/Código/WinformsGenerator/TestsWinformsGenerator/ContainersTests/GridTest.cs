using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class GridTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.Grid grid = new WinformsGenerator.Grid ();
			grid.Name = "container";
			grid.Anchor = AnchorStyles.None;
			grid.Dock = DockStyle.Fill;
			grid.BackColor = Color.White;
			grid.Size = new Size (100, 100);
			grid.Location = new Point (0, 0);
			grid.NumRows = 2;
			grid.NumColumns = 3;

			System.Windows.Forms.TableLayoutPanel gridTest = (System.Windows.Forms.TableLayoutPanel)grid.DrawElement ();

			System.Windows.Forms.TableLayoutPanel gridReal = new System.Windows.Forms.TableLayoutPanel ();
			gridReal.Name = "container";
			gridReal.Anchor = AnchorStyles.None;
			gridReal.Dock = DockStyle.Fill;
			gridReal.BackColor = Color.White;
			gridReal.Size = new Size (100, 100);
			gridReal.Location = new Point (0, 0);
			gridReal.ColumnCount = 3;
			gridReal.RowCount = 2;

			Assert.IsInstanceOfType (gridReal.GetType (), gridTest);
			Assert.AreEqual (gridReal.Name, gridTest.Name);
			Assert.AreEqual (gridReal.Anchor, gridTest.Anchor);
			Assert.AreEqual (gridReal.Dock, gridTest.Dock);
			Assert.AreEqual (gridReal.BackColor, gridTest.BackColor);
			Assert.AreEqual (gridReal.Size, gridTest.Size);
			Assert.AreEqual (gridReal.Location, gridTest.Location);
			Assert.AreEqual (gridReal.ColumnCount, gridTest.ColumnCount);
			Assert.AreEqual (gridReal.RowCount, gridTest.RowCount);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.Grid grid = new WinformsGenerator.Grid ();
			grid.Name = "container";
			grid.Anchor = AnchorStyles.None;
			grid.Dock = DockStyle.Fill;
			grid.BackColor = Color.White;
			grid.Size = new Size (100, 100);
			grid.Location = new Point (0, 0);

			WinformsGenerator.Element gridTest = grid.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.Grid), gridTest);
			Assert.AreEqual (grid.Name,((WinformsGenerator.Grid)gridTest).Name);
			Assert.AreEqual (grid.Anchor,((WinformsGenerator.Grid)gridTest).Anchor);
			Assert.AreEqual (grid.Dock,((WinformsGenerator.Grid)gridTest).Dock);
			Assert.AreEqual (grid.BackColor,((WinformsGenerator.Grid)gridTest).BackColor);
			Assert.AreEqual (grid.Size,((WinformsGenerator.Grid)gridTest).Size);
			Assert.AreEqual (grid.Location,((WinformsGenerator.Grid)gridTest).Location);
			Assert.AreEqual (grid.NumColumns, ((WinformsGenerator.Grid)gridTest).NumColumns);
			Assert.AreEqual (grid.NumRows, ((WinformsGenerator.Grid)gridTest).NumRows);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.Grid grid = new WinformsGenerator.Grid ();
			Assert.IsEmpty (grid.elementos);
			grid.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (grid.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), grid.elementos [0]);
		}
		[Test ()]
		public void AddRowTest ()
		{
			WinformsGenerator.Grid grid = new WinformsGenerator.Grid ();
			Assert.AreEqual (0, grid.NumRows);
			grid.AddRow ();
			Assert.AreEqual (1, grid.NumRows);
		}
		[Test ()]
		public void AddColumnTest ()
		{
			WinformsGenerator.Grid grid = new WinformsGenerator.Grid ();
			Assert.AreEqual (0, grid.NumColumns);
			grid.AddColumn ();
			Assert.AreEqual (1, grid.NumColumns);
		}
	}
}

