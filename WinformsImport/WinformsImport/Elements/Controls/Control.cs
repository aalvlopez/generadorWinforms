using System;
using System.Windows.Forms;

namespace WinformsImport
{
	public abstract class Control:Element
	{
		public Control ():base(){}
		public override abstract System.Windows.Forms.Control DrawElement ();
	}
}

