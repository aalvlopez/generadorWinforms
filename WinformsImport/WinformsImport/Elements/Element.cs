using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinformsImport
{

	
	[XmlInclude(typeof(WinformsImport.Form))]
	[XmlInclude(typeof(WinformsImport.Button))]
	[XmlInclude(typeof(WinformsImport.TextBox))]
	[XmlInclude(typeof(WinformsImport.Label))]
	[XmlInclude(typeof(WinformsImport.Border))]
	[XmlInclude(typeof(WinformsImport.HBox))]
	[XmlInclude(typeof(WinformsImport.VBox))]
	[XmlInclude(typeof(WinformsImport.Grid))]
	public abstract class Element
	{ 
		public DockStyle Dock {
			get;
			set;
		}
		public String Name {
			get;
			set;
		}
		public String Text {
			get;
			set;
		}
		public Point Location{
			get;
			set;
		}
		public Size Size{
			get;
			set;
		}
		public AnchorStyles Anchor {
			get;
			set;
		}

		Color backColor = Color.FromArgb(255,255,255);

		[XmlIgnore]
		public Color BackColor 
		{
		    get { return backColor; }
		    set { backColor = value; }
		}
		[XmlElement("BackColor")]
		public string BackColorHtml
		{
		    get { return ColorTranslator.ToHtml(backColor); }
		    set { BackColor = ColorTranslator.FromHtml(value); }
		}


		public Element ()
		{
			
			this.Text="prueba";
			this.Dock=DockStyle.None;
			this.Name=this.GetType().ToString();
			this.Location=new Point(0,0);
			this.Anchor=AnchorStyles.None;
			this.BackColor=Color.Gray;
		}
		public abstract System.Windows.Forms.Control DrawElement();
	}
}

