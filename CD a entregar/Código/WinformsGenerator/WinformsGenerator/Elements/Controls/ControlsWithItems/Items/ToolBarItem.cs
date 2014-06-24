using System;
using System.Reflection;

namespace WinformsGenerator
{
	public class ToolBarItem:Item
	{
		private static int  numelem=0;
		public ToolBarItem ():base()
		{
			this.Name="ToolBarItem"+ToolBarItem.numelem.ToString();
			ToolBarItem.numelem++;
			this.Text=this.Name;
		}
		public override Item CopyItem ()
		{
			var item = new ToolBarItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ToolBarItem).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
	}
}

