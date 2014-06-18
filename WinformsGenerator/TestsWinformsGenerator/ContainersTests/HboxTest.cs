using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class HBoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.HBox hb = new WinformsGenerator.HBox ();
			hb.Name = "container";
			hb.Anchor = AnchorStyles.None;
			hb.Dock = DockStyle.Fill;
			hb.BackColor = Color.White;
			hb.Size = new Size (100, 100);
			hb.Location = new Point (0, 0);
			hb.NumColumns = 3;

			System.Windows.Forms.TableLayoutPanel hbTest = (System.Windows.Forms.TableLayoutPanel)hb.DrawElement ();

			System.Windows.Forms.TableLayoutPanel hbReal = new System.Windows.Forms.TableLayoutPanel ();
			hbReal.Name = "container";
			hbReal.Anchor = AnchorStyles.None;
			hbReal.Dock = DockStyle.Fill;
			hbReal.BackColor = Color.White;
			hbReal.Size = new Size (100, 100);
			hbReal.Location = new Point (0, 0);
			hbReal.ColumnCount = 3;
			hbReal.RowCount = 1;

			Assert.IsInstanceOfType (hbReal.GetType (), hbTest);
			Assert.AreEqual (hbReal.Name, hbTest.Name);
			Assert.AreEqual (hbReal.Anchor, hbTest.Anchor);
			Assert.AreEqual (hbReal.Dock, hbTest.Dock);
			Assert.AreEqual (hbReal.BackColor, hbTest.BackColor);
			Assert.AreEqual (hbReal.Size, hbTest.Size);
			Assert.AreEqual (hbReal.Location, hbTest.Location);
			Assert.AreEqual (hbReal.ColumnCount, hbTest.ColumnCount);
			Assert.AreEqual (hbReal.RowCount, hbTest.RowCount);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.HBox hb = new WinformsGenerator.HBox ();
			hb.Name = "container";
			hb.Anchor = AnchorStyles.None;
			hb.Dock = DockStyle.Fill;
			hb.BackColor = Color.White;
			hb.Size = new Size (100, 100);
			hb.Location = new Point (0, 0);

			WinformsGenerator.Element hbTest = hb.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.HBox), hbTest);
			Assert.AreEqual (hb.Name,((WinformsGenerator.HBox)hbTest).Name);
			Assert.AreEqual (hb.Anchor,((WinformsGenerator.HBox)hbTest).Anchor);
			Assert.AreEqual (hb.Dock,((WinformsGenerator.HBox)hbTest).Dock);
			Assert.AreEqual (hb.BackColor,((WinformsGenerator.HBox)hbTest).BackColor);
			Assert.AreEqual (hb.Size,((WinformsGenerator.HBox)hbTest).Size);
			Assert.AreEqual (hb.Location,((WinformsGenerator.HBox)hbTest).Location);
			Assert.AreEqual (hb.NumColumns, ((WinformsGenerator.HBox)hbTest).NumColumns);
			Assert.AreEqual (hb.NumRows, ((WinformsGenerator.HBox)hbTest).NumRows);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.HBox hb = new WinformsGenerator.HBox ();
			Assert.IsEmpty (hb.elementos);
			hb.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (hb.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), hb.elementos [0]);
		}

		public void AddColumnTest ()
		{
			WinformsGenerator.HBox hb = new WinformsGenerator.HBox ();
			Assert.AreEqual (0, hb.NumColumns);
			hb.AddColumn ();
			Assert.AreEqual (1, hb.NumColumns);
		}
	}
}

