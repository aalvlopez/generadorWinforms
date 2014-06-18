using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class DataGridRowTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.DataGridRow row = new WinformsGenerator.DataGridRow ();
			row.Name = "element";
			row.Text = "element";
			row.Values = "uno,dos,tres";

			WinformsGenerator.DataGridRow rowTest = (WinformsGenerator.DataGridRow)row.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.DataGridRow), rowTest);
			Assert.AreEqual (row.Name,rowTest.Name);
			Assert.AreEqual (row.Text,rowTest.Text);
			Assert.AreEqual (row.Values,rowTest.Values);
		}
	}
}

