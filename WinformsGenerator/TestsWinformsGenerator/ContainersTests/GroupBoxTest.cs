using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class GroupBoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.GroupBox group = new WinformsGenerator.GroupBox ();
			group.Name = "container";
			group.Text = "container";
			group.Anchor = AnchorStyles.None;
			group.Dock = DockStyle.Fill;
			group.BackColor = Color.White;
			group.Size = new Size (100, 100);
			group.Location = new Point (0, 0);

			System.Windows.Forms.GroupBox groupTest = (System.Windows.Forms.GroupBox)group.DrawElement ();

			System.Windows.Forms.GroupBox groupReal = new System.Windows.Forms.GroupBox ();
			groupReal.Name = "container";
			groupReal.Text = "container";
			groupReal.Anchor = AnchorStyles.None;
			groupReal.Dock = DockStyle.Fill;
			groupReal.BackColor = Color.White;
			groupReal.Size = new Size (100, 100);
			groupReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (groupReal.GetType (), groupTest);
			Assert.AreEqual (groupReal.Name, groupTest.Name);
			Assert.AreEqual (groupReal.Text, groupTest.Text);
			Assert.AreEqual (groupReal.Anchor, groupTest.Anchor);
			Assert.AreEqual (groupReal.Dock, groupTest.Dock);
			Assert.AreEqual (groupReal.BackColor, groupTest.BackColor);
			Assert.AreEqual (groupReal.Size, groupTest.Size);
			Assert.AreEqual (groupReal.Location, groupTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.GroupBox group = new WinformsGenerator.GroupBox ();
			group.Name = "container";
			group.Text = "container";
			group.Anchor = AnchorStyles.None;
			group.Dock = DockStyle.Fill;
			group.BackColor = Color.White;
			group.Size = new Size (100, 100);
			group.Location = new Point (0, 0);

			WinformsGenerator.Element groupTest = group.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.GroupBox), groupTest);
			Assert.AreEqual (group.Name,((WinformsGenerator.GroupBox)groupTest).Name);
			Assert.AreEqual (group.Text,((WinformsGenerator.GroupBox)groupTest).Text);
			Assert.AreEqual (group.Anchor,((WinformsGenerator.GroupBox)groupTest).Anchor);
			Assert.AreEqual (group.Dock,((WinformsGenerator.GroupBox)groupTest).Dock);
			Assert.AreEqual (group.BackColor,((WinformsGenerator.GroupBox)groupTest).BackColor);
			Assert.AreEqual (group.Size,((WinformsGenerator.GroupBox)groupTest).Size);
			Assert.AreEqual (group.Location,((WinformsGenerator.GroupBox)groupTest).Location);
		}
		[Test ()]
		public void AddElemTest ()
		{
			WinformsGenerator.GroupBox group = new WinformsGenerator.GroupBox ();
			Assert.IsEmpty (group.elementos);
			group.AddElem (new WinformsGenerator.Button());
			Assert.IsNotEmpty (group.elementos);
			Assert.IsInstanceOfType (typeof(WinformsGenerator.Button), group.elementos [0]);
		}
	}
}

