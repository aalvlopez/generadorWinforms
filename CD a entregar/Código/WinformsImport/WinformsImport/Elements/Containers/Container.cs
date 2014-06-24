using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsImport
{
	public abstract class Container:Element
	{
		public List<Element> elementos;
		public Container ():base(){}

		public override abstract System.Windows.Forms.Control DrawElement ();
	}
}

