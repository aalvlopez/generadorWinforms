using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public static class Controller
	{

		private static WinformsGenerator.Form formulario = new WinformsGenerator.Form();
		private static MainWindow window= new MainWindow();

		public static void SelectItem (Element elemento)
		{
			Controller.window.GenerateDataGrid(elemento.GenerateDataGrid());
		}

		public static void addElemnt (Element elemento, Container parent)
		{
			parent.AddElem(elemento);
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		public static void RemoveElement (Element elemento, Container parent){
			parent.RemoveElem(elemento);
			Controller.window.ReDraw((Panel)Controller.formulario.DrawElement());
		}

		public static WinformsGenerator.Form GetForm ()
		{
			return Controller.formulario;
		}

		public static void RefreshTreeView ()
		{
			Controller.window.panelTreeView.RefreshTreeView ();
		}

		public static MainWindow GetWindow ()
		{
			return Controller.window;
		}
		public static System.Windows.Forms.Panel Draw(){
			return (Panel) Controller.formulario.DrawElement();
		}

		public static void ReDraw ()
		{
			Controller.window.ReDraw(Controller.Draw());
		}

	}
}