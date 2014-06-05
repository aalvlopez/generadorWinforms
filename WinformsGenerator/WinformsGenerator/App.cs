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
			App.WriteXML();
			App.ReadXml();
		}
		 
		public static void WriteXML()
	    {
	        System.Xml.Serialization.XmlSerializer writer = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamWriter file = new System.IO.StreamWriter("p.xml");
	        writer.Serialize(file,(Element) Controller.GetForm());
	        file.Close();
	    }
		public static void ReadXml()
	    {
	       System.Xml.Serialization.XmlSerializer reader = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamReader file = new System.IO.StreamReader("p.xml");
			WinformsGenerator.Form f = (WinformsGenerator.Form)reader.Deserialize(file);
	        file.Close();

			Application.Run(f.DrawForm());
	    }
	}
}

