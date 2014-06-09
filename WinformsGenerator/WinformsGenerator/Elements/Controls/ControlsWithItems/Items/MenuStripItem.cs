using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class MenuStripItem:ItemAnidado
	{
		private static int  numelem=0;
		public MenuStripItem ():base()
		{
			this.Name="MenuStripItem"+MenuStripItem.numelem.ToString();
			MenuStripItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new MenuStripItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Item).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
		public override void AddItem ()
		{
			this.items.Add(new MenuStripItem());
		}
	}
}

