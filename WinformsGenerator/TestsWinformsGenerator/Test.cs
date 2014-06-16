using NUnit.Framework;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace TestsWinformsGenerator
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void GeneralTest ()
		{
			// Crear un form con un VBox, un label y un textbox
			WinformsGenerator.Controller.init ();

			WinformsGenerator.Form f = WinformsGenerator.Controller.GetForm ();
			WinformsGenerator.VBox vb = new WinformsGenerator.VBox ();
			WinformsGenerator.HBox hb = new WinformsGenerator.HBox ();
			WinformsGenerator.Label lbl = new WinformsGenerator.Label ();
			WinformsGenerator.TextBox txt = new WinformsGenerator.TextBox ();

			f.AddElem (vb);
			vb.AddElem (hb);
			hb.AddElem (lbl);
			hb.AddElem (txt);

			lbl.Text = "Nombre:";
			lbl.Dock = DockStyle.Left;

			txt.Text = "";
			txt.Dock = DockStyle.Top;

			WinformsGenerator.Controller.SetSaveFile ("appGuiTest.xml");
			WinformsGenerator.Controller.SaveAsFile ();

			WinformsGenerator.Controller.OpenFile ();

			f = WinformsGenerator.Controller.GetForm ();

			Assert.IsNotEmpty (f.elementos);
			Assert.IsInstanceOfType (vb.GetType(), f.elementos[0]);
			Assert.IsNotEmpty (((WinformsGenerator.VBox)f.elementos [0]).elementos);
			Assert.IsInstanceOfType (hb.GetType(), vb.elementos[0]);
			Assert.IsNotEmpty (((WinformsGenerator.HBox)((WinformsGenerator.VBox)f.elementos [0]).elementos[0]).elementos);
			Assert.IsInstanceOfType (lbl.GetType(), hb.elementos[0]);
			Assert.IsInstanceOfType (txt.GetType(), hb.elementos[1]);
		}
	}
}

