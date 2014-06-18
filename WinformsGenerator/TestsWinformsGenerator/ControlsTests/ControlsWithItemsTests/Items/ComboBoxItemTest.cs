using NUnit.Framework;
using System;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class ComboBoxItemTest
	{
		[Test ()]
		public void CopyItemTest ()
		{
			WinformsGenerator.ComboBoxItem combo = new WinformsGenerator.ComboBoxItem ();
			combo.Name = "element";
			combo.Text = "element";

			WinformsGenerator.ComboBoxItem comboTest = (WinformsGenerator.ComboBoxItem)combo.CopyItem ();

			Assert.IsInstanceOfType (typeof(WinformsGenerator.ComboBoxItem), comboTest);
			Assert.AreEqual (combo.Name,comboTest.Name);
			Assert.AreEqual (combo.Text,comboTest.Text);
		}
	}
}

