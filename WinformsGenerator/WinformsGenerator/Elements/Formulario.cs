using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	

	public class Formulario:Container
	{
		public Formulario ():base()
		{
		}
		public Formulario (String id, DockStyle style, String name):base(id, style, name){
		}
		public override void drawElement ()
		{
			throw new System.NotImplementedException ();
		}
	}
}

