using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class VBoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.VBox vb = new WinformsGenerator.VBox ();
			vb.Name = "container";
			vb.Anchor = AnchorStyles.None;
			vb.Dock = DockStyle.Fill;
			vb.BackColor = Color.White;
			vb.Size = new Size (100, 100);
			vb.Location = new Point (0, 0);
			vb.NumRows = 2;

			System.Windows.Forms.TableLayoutPanel vbTest = (System.Windows.Forms.TableLayoutPanel)vb.DrawElement ();

			System.Windows.Forms.TableLayoutPanel hbReal = new System.Windows.Forms.TableLayoutPanel ();
			hbReal.Name = "container";
			hbReal.Anchor = AnchorStyles.None;
			hbReal.Dock = DockStyle.Fill;
			hbReal.BackColor = Color.White;
			hbReal.Size = new Size (100, 100);
			hbReal.Location = new Point (0, 0);
			hbReal.ColumnCount = 1;
			hbReal.RowCount = 2;

			Assert.IsInstanceOfType (hbReal.GetType (), vbTest);
			Assert.AreEqual (hbReal.Name, vbTest.Name);
			Assert.AreEqual (hbReal.Anchor, vbTest.Anchor);
			Assert.AreEqual (hbReal.Dock, vbTest.Dock);
			Assert.AreEqual (hbReal.BackColor, vbTest.BackColor);
			Assert.AreEqual (hbReal.Size, vbTest.Size);
			Assert.AreEqual (hbReal.Location, vbTest.Location);
			Assert.AreEqual (hbReal.ColumnCount, vbTest.ColumnCount);
			Assert.AreEqual (hbReal.RowCount, vbTest.RowCount);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.VBox vb = new WinformsGenerator.VBox ();
			vb.Name = "container";
			vb.Anchor = AnchorStyles.None;
			vb.Dock = DockStyle.Fill;
			vb.BackColor = Color.White;
			vb.Size = new Size (100, 100);
			vb.Location = new Point (0, 0);

			WinformsGenerator.Element vbTest = vb.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.VBox), vbTest);
			Assert.AreEqual (vb.Name,((WinformsGenerator.VBox)vbTest).Name);
			Assert.AreEqual (vb.Anchor,((WinformsGenerator.VBox)vbTest).Anchor);
			Assert.AreEqual (vb.Dock,((WinformsGenerator.VBox)vbTest).Dock);
			Assert.AreEqual (vb.BackColor,((WinformsGenerator.VBox)vbTest).BackColor);
			Assert.AreEqual (vb.Size,((WinformsGenerator.VBox)vbTest).Size);
			Assert.AreEqual (vb.Location,((WinformsGenerator.VBox)vbTest).Location);
			Assert.AreEqual (vb.NumColumns, ((WinformsGenerator.VBox)vbTest).NumColumns);
			Assert.AreEqual (vb.NumRows, ((WinformsGenerator.VBox)vbTest).NumRows);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.VBox vb = new WinformsGenerator.VBox ();
			Assert.IsEmpty (vb.elementos);
			vb.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (vb.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), vb.elementos [0]);
		}

		public void AddColumnTest ()
		{
			WinformsGenerator.VBox vb = new WinformsGenerator.VBox ();
			Assert.AreEqual (0, vb.NumColumns);
			vb.AddColumn ();
			Assert.AreEqual (1, vb.NumColumns);
		}
	}
}

