using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class MonthCalendarTest
	{
		[Test ()]
		public void DrawTest ()
		{
			WinformsGenerator.MonthCalendar calen = new WinformsGenerator.MonthCalendar ();
			calen.Name = "element";
			calen.Text = "element";
			calen.Anchor = AnchorStyles.None;
			calen.Dock = DockStyle.Left;
			calen.BackColor = Color.White;
			calen.Size = new Size (100, 100);
			calen.Location = new Point (0, 0);
			calen.CalendarDimensions = new Size (3, 4);

			System.Windows.Forms.MonthCalendar calenTest = (System.Windows.Forms.MonthCalendar)calen.DrawElement ();

			System.Windows.Forms.MonthCalendar calenReal = new System.Windows.Forms.MonthCalendar ();
			calenReal.Name = "element";
			calenReal.Anchor = AnchorStyles.None;
			calenReal.Dock = DockStyle.Left;
			calenReal.BackColor = Color.White;
			calenReal.Size = new Size (100, 100);
			calenReal.Location = new Point (0, 0);
			calenReal.CalendarDimensions = new Size (3, 4);

			Assert.IsInstanceOfType (calenReal.GetType (), calenTest);
			Assert.AreEqual (calenReal.Name, calenTest.Name);
			Assert.AreEqual (calenReal.Anchor, calenTest.Anchor);
			Assert.AreEqual (calenReal.Dock, calenTest.Dock);
			Assert.AreEqual (calenReal.BackColor, calenTest.BackColor);
			Assert.AreEqual (calenReal.Size, calenTest.Size);
			Assert.AreEqual (calenReal.Location, calenTest.Location);
			Assert.AreEqual (calenReal.CalendarDimensions, calenTest.CalendarDimensions);

		}
		[Test ()]
		public void CopyElemTest ()
		{
			WinformsGenerator.MonthCalendar calen = new WinformsGenerator.MonthCalendar ();
			calen.Name = "element";
			calen.Anchor = AnchorStyles.None;
			calen.Dock = DockStyle.Left;
			calen.BackColor = Color.White;
			calen.Size = new Size (100, 100);
			calen.Location = new Point (0, 0);
			calen.CalendarDimensions = new Size (3, 4);

			WinformsGenerator.Element calenTest = calen.CopyElem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.MonthCalendar), calenTest);
			Assert.AreEqual (calen.Name,((WinformsGenerator.MonthCalendar)calenTest).Name);
			Assert.AreEqual (calen.Anchor,((WinformsGenerator.MonthCalendar)calenTest).Anchor);
			Assert.AreEqual (calen.Dock,((WinformsGenerator.MonthCalendar)calenTest).Dock);
			Assert.AreEqual (calen.BackColor,((WinformsGenerator.MonthCalendar)calenTest).BackColor);
			Assert.AreEqual (calen.Size,((WinformsGenerator.MonthCalendar)calenTest).Size);
			Assert.AreEqual (calen.Location,((WinformsGenerator.MonthCalendar)calenTest).Location);
			Assert.AreEqual (calen.CalendarDimensions,((WinformsGenerator.MonthCalendar)calenTest).CalendarDimensions);
		}
	}
}

