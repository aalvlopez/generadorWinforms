using System;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public static class Controller
	{
		public static List<Element> ElementosForm =new List<Element>();


		public static void addElemnt (Element elemento, Formulario parent)
		{
			parent.addElem(elemento);
		}
		public static void addElemnt (Element elemento, Container parent)
		{
			parent.addElem(elemento);
		}
		public static void removeElement (){
			//A ver como lo hago
		}
		

	}
}


//			WinformsGenerator.Button b=new WinformsGenerator.Button();
//			Type btype = b.GetType();
//			foreach (PropertyInfo info in btype.GetProperties())
//			{
//				Console.WriteLine(info.ToString());
//			}