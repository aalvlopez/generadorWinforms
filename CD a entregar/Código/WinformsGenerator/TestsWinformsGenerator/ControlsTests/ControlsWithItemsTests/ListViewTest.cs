using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ListViewTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.ListView lv = new WinformsGenerator.ListView ();
			lv.Name = "element";
			lv.Anchor = AnchorStyles.None;
			lv.Dock = DockStyle.Left;
			lv.BackColor = Color.White;
			lv.Size = new Size (100, 100);
			lv.Location = new Point (0, 0);
			lv.CheckBoxes = true;
			lv.GridLines = true;
			lv.View = View.Details;

			System.Windows.Forms.ListView lvTest = (System.Windows.Forms.ListView)lv.DrawElement ();

			System.Windows.Forms.ListView lvReal = new System.Windows.Forms.ListView ();
			lvReal.Name = "element";
			lvReal.Anchor = AnchorStyles.None;
			lvReal.Dock = DockStyle.Left;
			lvReal.BackColor = Color.White;
			lvReal.Size = new Size (100, 100);
			lvReal.Location = new Point (0, 0);
			lvReal.CheckBoxes = true;
			lvReal.GridLines = true;
			lvReal.View = View.Details;

			Assert.IsInstanceOfType (lvReal.GetType (), lvTest);
			Assert.AreEqual (lvReal.Name, lvTest.Name);
			Assert.AreEqual (lvReal.Anchor, lvTest.Anchor);
			Assert.AreEqual (lvReal.Dock, lvTest.Dock);
			Assert.AreEqual (lvReal.BackColor, lvTest.BackColor);
			Assert.AreEqual (lvReal.Size, lvTest.Size);
			Assert.AreEqual (lvReal.Location, lvTest.Location);
			Assert.AreEqual (lvReal.Columns.Count, lvTest.Columns.Count);
			Assert.AreEqual (lvReal.CheckBoxes, lvTest.CheckBoxes);
			Assert.AreEqual (lvReal.GridLines, lvTest.GridLines);
			Assert.AreEqual (lvReal.View, lvTest.View);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.ListView lv = new WinformsGenerator.ListView ();
			lv.Name = "element";
			lv.Anchor = AnchorStyles.None;
			lv.Dock = DockStyle.Left;
			lv.BackColor = Color.White;
			lv.Size = new Size (100, 100);
			lv.Location = new Point (0, 0);
			lv.CheckBoxes = true;
			lv.GridLines = true;
			lv.View = View.Details;

			WinformsGenerator.Element lvTest = lv.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ListView), lvTest);
			Assert.AreEqual (lv.Name,((WinformsGenerator.ListView)lvTest).Name);
			Assert.AreEqual (lv.Anchor,((WinformsGenerator.ListView)lvTest).Anchor);
			Assert.AreEqual (lv.Dock,((WinformsGenerator.ListView)lvTest).Dock);
			Assert.AreEqual (lv.BackColor,((WinformsGenerator.ListView)lvTest).BackColor);
			Assert.AreEqual (lv.Size,((WinformsGenerator.ListView)lvTest).Size);
			Assert.AreEqual (lv.Location,((WinformsGenerator.ListView)lvTest).Location);
			Assert.AreEqual (lv.Columns.Count,((WinformsGenerator.ListView)lvTest).Columns.Count);
			Assert.AreEqual (lv.CheckBoxes,((WinformsGenerator.ListView)lvTest).CheckBoxes);
			Assert.AreEqual (lv.GridLines,((WinformsGenerator.ListView)lvTest).GridLines);
			Assert.AreEqual (lv.View,((WinformsGenerator.ListView)lvTest).View);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.ListView lv = new WinformsGenerator.ListView ();
			Assert.IsEmpty (lv.items);
			lv.AddItem ();
			Assert.IsNotEmpty (lv.items);
		}
	}
}