using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class DateTimePickerTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.DateTimePicker split = new WinformsGenerator.DateTimePicker ();
			split.Name = "element";
			split.Anchor = AnchorStyles.None;
			split.Dock = DockStyle.Left;
			split.BackColor = Color.White;
			split.Size = new Size (100, 100);
			split.Location = new Point (0, 0);
			split.Format = DateTimePickerFormat.Custom;
			split.Value = new DateTime (2014, 10, 10, 10, 10, 10);

			System.Windows.Forms.DateTimePicker splitTest = (System.Windows.Forms.DateTimePicker)split.DrawElement ();

			System.Windows.Forms.DateTimePicker splitReal = new System.Windows.Forms.DateTimePicker ();
			splitReal.Name = "element";
			splitReal.Anchor = AnchorStyles.None;
			splitReal.Dock = DockStyle.Left;
			splitReal.BackColor = Color.White;
			splitReal.Size = new Size (100, 100);
			splitReal.Location = new Point (0, 0);
			splitReal.Format = DateTimePickerFormat.Custom;
			splitReal.Value = new DateTime (2014, 10, 10, 10, 10, 10);

			Assert.IsInstanceOfType (splitReal.GetType (), splitTest);
			Assert.AreEqual (splitReal.Name, splitTest.Name);
			Assert.AreEqual (splitReal.Anchor, splitTest.Anchor);
			Assert.AreEqual (splitReal.Dock, splitTest.Dock);
			Assert.AreEqual (splitReal.BackColor, splitTest.BackColor);
			Assert.AreEqual (splitReal.Size, splitTest.Size);
			Assert.AreEqual (splitReal.Location, splitTest.Location);
			Assert.AreEqual (splitReal.Format, splitTest.Format);
			Assert.AreEqual (splitReal.Value, splitTest.Value);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.DateTimePicker split = new WinformsGenerator.DateTimePicker ();
			split.Name = "element";
			split.Anchor = AnchorStyles.None;
			split.Dock = DockStyle.Left;
			split.BackColor = Color.White;
			split.Size = new Size (100, 100);
			split.Location = new Point (0, 0);
			split.Value = new DateTime (2014, 10, 10, 10, 10, 10);

			WinformsGenerator.Element splitTest = split.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.DateTimePicker), splitTest);
			Assert.AreEqual (split.Name,((WinformsGenerator.DateTimePicker)splitTest).Name);
			Assert.AreEqual (split.Anchor,((WinformsGenerator.DateTimePicker)splitTest).Anchor);
			Assert.AreEqual (split.Dock,((WinformsGenerator.DateTimePicker)splitTest).Dock);
			Assert.AreEqual (split.BackColor,((WinformsGenerator.DateTimePicker)splitTest).BackColor);
			Assert.AreEqual (split.Size,((WinformsGenerator.DateTimePicker)splitTest).Size);
			Assert.AreEqual (split.Location,((WinformsGenerator.DateTimePicker)splitTest).Location);
			Assert.AreEqual (split.Format,((WinformsGenerator.DateTimePicker)splitTest).Format);
			Assert.AreEqual (split.Value,((WinformsGenerator.DateTimePicker)splitTest).Value);
		}
	}
}

