using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class ComboBoxItem:Item
	{
		private static int  numelem=0;
		public ComboBoxItem ():base()
		{
			this.Name="ComboBoxItem"+ComboBoxItem.numelem.ToString();
			ComboBoxItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new ComboBoxItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ComboBoxItem).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}

	}
}

