using System;
using System.Windows.Forms;
using System.Xml.Serialization;

// Main class

namespace WinformsGenerator
{
	 
	public class App
	{

		public static void Main ()
		{

			Controller.GetForm().Name="Formulario";
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Controller.RefreshTreeView();
			Application.EnableVisualStyles();
            Application.Run(Controller.GetWindow());
		}
		 
		public static void WriteXML(String name)
	    {
	        System.Xml.Serialization.XmlSerializer writer = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamWriter file = new System.IO.StreamWriter(name);
	        writer.Serialize(file,(Element) Controller.GetForm());
	        file.Close();
	    }
		public static void ReadXml(String name)
	    {
	       System.Xml.Serialization.XmlSerializer reader = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamReader file = new System.IO.StreamReader(name);
			WinformsGenerator.Form f = (WinformsGenerator.Form)reader.Deserialize(file);
	        file.Close();

			Application.Run(f.DrawForm());
	    }
	}
}

