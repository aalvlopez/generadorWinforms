using System;
using System.Collections.Generic;

namespace WinformsImport
{
	public abstract class ControlItems:Control
	{
		public List<Item> items;
		public ControlItems ():base(){}

		public override abstract System.Windows.Forms.Control DrawElement ();
	}
}

