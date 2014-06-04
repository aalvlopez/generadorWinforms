using System;
using System.Windows.Forms;
using System.Xml.Serialization;
// Main class

namespace WinformsGenerator
{
	 
	public class App
	{
		public static Formulario formulario = new Formulario();
		public static MainWindow m= new MainWindow();
		public static void Main ()
		{
			App.formulario.Name="Formulario";
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			MainWindow.panelTreeView.RefreshTreeView();
            Application.Run(App.m);
			App.WriteXML();
			App.ReadXml();
		}
		 
		public static void WriteXML()
	    {
	        System.Xml.Serialization.XmlSerializer writer = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamWriter file = new System.IO.StreamWriter("p.xml");
	        writer.Serialize(file,(Element) App.formulario);
	        file.Close();
	    }
		public static void ReadXml()
	    {
	       System.Xml.Serialization.XmlSerializer reader = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamReader file = new System.IO.StreamReader("p.xml");
			WinformsGenerator.Formulario f = (WinformsGenerator.Formulario)reader.Deserialize(file);
	        file.Close();

			Application.Run(f.DrawForm());
	    }
	}
}

