using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class TreeViewTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.TreeView tree = new WinformsGenerator.TreeView ();
			tree.Name = "element";
			tree.Anchor = AnchorStyles.None;
			tree.Dock = DockStyle.Left;
			tree.BackColor = Color.White;
			tree.Size = new Size (100, 100);
			tree.Location = new Point (0, 0);

			System.Windows.Forms.TreeView treeTest = (System.Windows.Forms.TreeView)tree.DrawElement ();

			System.Windows.Forms.TreeView treeReal = new System.Windows.Forms.TreeView ();
			treeReal.Name = "element";
			treeReal.Text = "element";
			treeReal.Anchor = AnchorStyles.None;
			treeReal.Dock = DockStyle.Left;
			treeReal.BackColor = Color.White;
			treeReal.Size = new Size (100, 100);
			treeReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (treeReal.GetType (), treeTest);
			Assert.AreEqual (treeReal.Name, treeTest.Name);
			Assert.AreEqual (treeReal.Anchor, treeTest.Anchor);
			Assert.AreEqual (treeReal.Dock, treeTest.Dock);
			Assert.AreEqual (treeReal.BackColor, treeTest.BackColor);
			Assert.AreEqual (treeReal.Size, treeTest.Size);
			Assert.AreEqual (treeReal.Location, treeTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.TreeView tree = new WinformsGenerator.TreeView ();
			tree.Name = "element";
			tree.Anchor = AnchorStyles.None;
			tree.Dock = DockStyle.Left;
			tree.BackColor = Color.White;
			tree.Size = new Size (100, 100);
			tree.Location = new Point (0, 0);

			WinformsGenerator.Element treeTest = tree.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.TreeView), treeTest);
			Assert.AreEqual (tree.Name,((WinformsGenerator.TreeView)treeTest).Name);
			Assert.AreEqual (tree.Text,((WinformsGenerator.TreeView)treeTest).Text);
			Assert.AreEqual (tree.Anchor,((WinformsGenerator.TreeView)treeTest).Anchor);
			Assert.AreEqual (tree.Dock,((WinformsGenerator.TreeView)treeTest).Dock);
			Assert.AreEqual (tree.BackColor,((WinformsGenerator.TreeView)treeTest).BackColor);
			Assert.AreEqual (tree.Size,((WinformsGenerator.TreeView)treeTest).Size);
			Assert.AreEqual (tree.Location,((WinformsGenerator.TreeView)treeTest).Location);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.TreeView tree = new WinformsGenerator.TreeView ();
			Assert.IsEmpty (tree.items);
			tree.AddItem ();
			Assert.IsNotEmpty (tree.items);
		}
	}
}