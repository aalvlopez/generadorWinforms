using System;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public abstract class ControlItems:Control
	{
		public List<Item> items;
		public ControlItems ():base()
		{
			this.items=new List<Item>();
		}
		public void RemoveItem (Item item)
		{
			this.items.Remove(item);
		}
		public abstract void AddItem();
		public override abstract System.Windows.Forms.Control DrawElement ();
		public override abstract Element NewElem ();
		public override abstract Element CopyElem ();
	}
}

