using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public static class Controller
	{
		public static List<Element> ElementosForm =new List<Element>();


		public static void addElemnt (Element elemento, Container parent)
		{
			parent.AddElem(elemento);
			MainWindow.ReDraw((Panel)App.formulario.DrawElement());
		}
		public static void SelectItem (Element elemento)
		{
			MainWindow.GenerateDataGrid(elemento.GenerateDataGrid());
		}
		public static void RemoveElement (Element elemento, Container parent){
			parent.RemoveElem(elemento);
			MainWindow.ReDraw((Panel)App.formulario.DrawElement());
		}
		

	}
}


//			WinformsGenerator.Button b=new WinformsGenerator.Button();
//			Type btype = b.GetType();
//			foreach (PropertyInfo info in btype.GetProperties())
//			{
//				Console.WriteLine(info.ToString());
//			}