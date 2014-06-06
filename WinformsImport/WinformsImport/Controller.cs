using System;
using System.IO;
using System.Windows.Forms;

namespace WinformsImport
{
	public static class Controller
	{
		private static WinformsImport.Form formulario;

		public static System.Windows.Forms.Panel Draw(){
			return (Panel) Controller.formulario.DrawElement();
		}

		public static System.Windows.Forms.Form OpenFile (String filename)
		{
			System.Xml.Serialization.XmlSerializer reader = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsImport.Element));
			

	        StreamReader file = new System.IO.StreamReader(filename);
			Controller.formulario= (WinformsImport.Form)reader.Deserialize(file);
	        file.Close();
			return Controller.formulario.DrawForm();
		}

	}
}