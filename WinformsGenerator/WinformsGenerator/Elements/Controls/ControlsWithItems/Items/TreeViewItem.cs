using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class TreeViewItem:ItemAnidado
	{
		private static int  numelem=0;
		public TreeViewItem ():base()
		{
			this.Name="TreeViewItem"+TreeViewItem.numelem.ToString();
			TreeViewItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new TreeViewItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Item).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
		public override void AddItem ()
		{
			this.items.Add(new TreeViewItem());
		}
	}
}

