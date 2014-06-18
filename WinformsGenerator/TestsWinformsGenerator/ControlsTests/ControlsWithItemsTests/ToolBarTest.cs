using NUnit.Framework;
using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ToolBarTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.ToolBar tool = new WinformsGenerator.ToolBar ();
			tool.Name = "element";
			tool.Anchor = AnchorStyles.None;
			tool.Dock = DockStyle.Left;
			tool.BackColor = Color.White;
			tool.Size = new Size (100, 100);
			tool.Location = new Point (0, 0);

			System.Windows.Forms.ToolBar toolTest = (System.Windows.Forms.ToolBar)tool.DrawElement ();

			System.Windows.Forms.ToolBar toolReal = new System.Windows.Forms.ToolBar ();
			toolReal.Name = "element";
			toolReal.Anchor = AnchorStyles.None;
			toolReal.Dock = DockStyle.Left;
			toolReal.BackColor = Color.White;
			toolReal.Size = new Size (100, 100);
			toolReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (toolReal.GetType (), toolTest);
			Assert.AreEqual (toolReal.Name, toolTest.Name);
			Assert.AreEqual (toolReal.Anchor, toolTest.Anchor);
			Assert.AreEqual (toolReal.Dock, toolTest.Dock);
			Assert.AreEqual (toolReal.BackColor, toolTest.BackColor);
			Assert.AreEqual (toolReal.Size, toolTest.Size);
			Assert.AreEqual (toolReal.Location, toolTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.ToolBar tool = new WinformsGenerator.ToolBar ();
			tool.Name = "element";
			tool.Anchor = AnchorStyles.None;
			tool.Dock = DockStyle.Left;
			tool.BackColor = Color.White;
			tool.Size = new Size (100, 100);
			tool.Location = new Point (0, 0);

			WinformsGenerator.Element toolTest = tool.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ToolBar), toolTest);
			Assert.AreEqual (tool.Name,((WinformsGenerator.ToolBar)toolTest).Name);
			Assert.AreEqual (tool.Anchor,((WinformsGenerator.ToolBar)toolTest).Anchor);
			Assert.AreEqual (tool.Dock,((WinformsGenerator.ToolBar)toolTest).Dock);
			Assert.AreEqual (tool.BackColor,((WinformsGenerator.ToolBar)toolTest).BackColor);
			Assert.AreEqual (tool.Size,((WinformsGenerator.ToolBar)toolTest).Size);
			Assert.AreEqual (tool.Location,((WinformsGenerator.ToolBar)toolTest).Location);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.ToolBar tool = new WinformsGenerator.ToolBar ();
			Assert.IsEmpty (tool.items);
			tool.AddItem ();
			Assert.IsNotEmpty (tool.items);
		}
	}
}