using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class ListViewSubItem:Item
	{
		private static int  numelem=0;
		public ListViewSubItem ():base()
		{
			this.Name="ListViewSubItem"+ListViewSubItem.numelem.ToString();
			ListViewSubItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new ListViewSubItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ListViewSubItem).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}

	}
}

