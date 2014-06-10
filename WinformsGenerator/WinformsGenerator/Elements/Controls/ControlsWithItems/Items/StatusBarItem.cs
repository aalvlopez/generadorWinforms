using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class StatusBarItem:Item
	{
		private static int  numelem=0;
		public StatusBarItem ():base()
		{
			this.Name="StatusBarItem"+StatusBarItem.numelem.ToString();
			StatusBarItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new StatusBarItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.StatusBarItem).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
	}
}

