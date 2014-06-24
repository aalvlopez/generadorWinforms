using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class ListViewItem:ItemAnidado
	{
		private static int  numelem=0;
		public ListViewItem ():base()
		{
			this.Name="ListViewItem"+ListViewItem.numelem.ToString();
			ListViewItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new ListViewItem ();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ListViewItem).GetProperties()) {
				prop.SetValue (item, prop.GetValue (this, null), null);
			}
			foreach (ItemAnidado i in this.items) {
				item.items.Add (i.CopyItem ());
			}
			return item;
		}
		public override void AddItem ()
		{
			this.items.Add(new ListViewSubItem());
		}
	}
}

