using System;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public abstract class ItemAnidado:Item
	{
		public List<Item> items;
		public ItemAnidado ():base()
		{
			this.items = new List<Item>();
		}
		public void RemoveItem(Item i){
			this.items.Remove(i);
		}
		public abstract override Item CopyItem ();
		public abstract void AddItem();
	}
}

