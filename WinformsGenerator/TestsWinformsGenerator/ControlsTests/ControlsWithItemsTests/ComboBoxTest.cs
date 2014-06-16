using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ComboBoxTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.ComboBox combo = new WinformsGenerator.ComboBox ();
			combo.Name = "element";
			combo.Text = "element";
			combo.Anchor = AnchorStyles.None;
			combo.Dock = DockStyle.Left;
			combo.BackColor = Color.White;
			combo.Size = new Size (100, 100);
			combo.Location = new Point (0, 0);

			System.Windows.Forms.ComboBox comoTest = (System.Windows.Forms.ComboBox)combo.DrawElement ();

			System.Windows.Forms.ComboBox comboReal = new System.Windows.Forms.ComboBox ();
			comboReal.Name = "element";
			comboReal.Text = "element";
			comboReal.Anchor = AnchorStyles.None;
			comboReal.Dock = DockStyle.Left;
			comboReal.BackColor = Color.White;
			comboReal.Size = new Size (100, 100);
			comboReal.Location = new Point (0, 0);

			Assert.IsInstanceOfType (comboReal.GetType (), comoTest);
			Assert.AreEqual (comboReal.Name, comoTest.Name);
			Assert.AreEqual (comboReal.Text, comoTest.Text);
			Assert.AreEqual (comboReal.Anchor, comoTest.Anchor);
			Assert.AreEqual (comboReal.Dock, comoTest.Dock);
			Assert.AreEqual (comboReal.BackColor, comoTest.BackColor);
			Assert.AreEqual (comboReal.Size, comoTest.Size);
			Assert.AreEqual (comboReal.Location, comoTest.Location);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.ComboBox combo = new WinformsGenerator.ComboBox ();
			combo.Name = "element";
			combo.Text = "element";
			combo.Anchor = AnchorStyles.None;
			combo.Dock = DockStyle.Left;
			combo.BackColor = Color.White;
			combo.Size = new Size (100, 100);
			combo.Location = new Point (0, 0);

			WinformsGenerator.Element comboTest = combo.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ComboBox), comboTest);
			Assert.AreEqual (combo.Name,((WinformsGenerator.ComboBox)comboTest).Name);
			Assert.AreEqual (combo.Text,((WinformsGenerator.ComboBox)comboTest).Text);
			Assert.AreEqual (combo.Anchor,((WinformsGenerator.ComboBox)comboTest).Anchor);
			Assert.AreEqual (combo.Dock,((WinformsGenerator.ComboBox)comboTest).Dock);
			Assert.AreEqual (combo.BackColor,((WinformsGenerator.ComboBox)comboTest).BackColor);
			Assert.AreEqual (combo.Size,((WinformsGenerator.ComboBox)comboTest).Size);
			Assert.AreEqual (combo.Location,((WinformsGenerator.ComboBox)comboTest).Location);
		}
		[Test ()]
		public void AddItemTest()
		{
			WinformsGenerator.ComboBox combo = new WinformsGenerator.ComboBox ();
			Assert.IsEmpty (combo.items);
			combo.AddItem ();
			Assert.IsNotEmpty (combo.items);
		}
	}
}