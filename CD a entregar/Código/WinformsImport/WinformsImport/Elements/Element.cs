using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;

namespace WinformsImport
{

	
	[XmlInclude(typeof(WinformsImport.Form))]

	[XmlInclude(typeof(WinformsImport.Button))]
	[XmlInclude(typeof(WinformsImport.TextBox))]
	[XmlInclude(typeof(WinformsImport.Label))]
	[XmlInclude(typeof(WinformsImport.CheckBox))]
	[XmlInclude(typeof(WinformsImport.RadioButton))]
	[XmlInclude(typeof(WinformsImport.DateTimePicker))]
	[XmlInclude(typeof(WinformsImport.MonthCalendar))]
	[XmlInclude(typeof(WinformsImport.PictureBox))]
	[XmlInclude(typeof(WinformsImport.ProgressBar))]
	[XmlInclude(typeof(WinformsImport.Splitter))]
	
	[XmlInclude(typeof(WinformsImport.ComboBox))]
	[XmlInclude(typeof(WinformsImport.ToolBar))]
	[XmlInclude(typeof(WinformsImport.StatusBar))]
	[XmlInclude(typeof(WinformsImport.MenuStrip))]
	[XmlInclude(typeof(WinformsImport.TreeView))]
	[XmlInclude(typeof(WinformsImport.DataGridView))]
	[XmlInclude(typeof(WinformsImport.ListView))]
	
	[XmlInclude(typeof(WinformsImport.ComboBoxItem))]
	[XmlInclude(typeof(WinformsImport.DataGridRow))]
	[XmlInclude(typeof(WinformsImport.ToolBarItem))]
	[XmlInclude(typeof(WinformsImport.StatusBarItem))]
	[XmlInclude(typeof(WinformsImport.MenuStripItem))]
	[XmlInclude(typeof(WinformsImport.TreeViewItem))]
	[XmlInclude(typeof(WinformsImport.ListViewItem))]
	[XmlInclude(typeof(WinformsImport.ListViewSubItem))]
	
	[XmlInclude(typeof(WinformsImport.GroupBox))]
	[XmlInclude(typeof(WinformsImport.Border))]
	[XmlInclude(typeof(WinformsImport.HBox))]
	[XmlInclude(typeof(WinformsImport.VBox))]
	[XmlInclude(typeof(WinformsImport.Grid))]
	[XmlInclude(typeof(WinformsImport.TabControl))]
	[XmlInclude(typeof(WinformsImport.TabPage))]
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

		//Eventos

		public string Click {
			get;
			set;
		}
		public string DoubleClick {
			get;
			set;
		}
		public string Enter {
			get;
			set;
		}
		public string GotFocus {
			get;
			set;
		}
		public string LostFocus {
			get;
			set;
		}
		public string Leave {
			get;
			set;
		}
		public string KeyDown {
			get;
			set;
		}
		public string KeyPress {
			get;
			set;
		}
		public string KeyUp {
			get;
			set;
		}
		public string MouseClick {
			get;
			set;
		}
		public string MouseDoubleClick {
			get;
			set;
		}
		public string MouseDown {
			get;
			set;
		}
		public string MouseEnter {
			get;
			set;
		}
		public string MouseLeave {
			get;
			set;
		}
		public string MouseHover {
			get;
			set;
		}
		public string MouseUp {
			get;
			set;
		}
		public string MouseWheel {
			get;
			set;
		}
		public string Resize {
			get;
			set;
		}

		public Element (){}
		
		public virtual void SetEvents (System.Windows.Forms.Control control)
		{
			Assembly asm = Assembly.GetEntryAssembly();
			foreach (Type type in asm.GetTypes()) {
				foreach(MethodInfo method in type.GetMethods()){
					if(method.Name == this.Click && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.Click);
						MethodInfo m = type.GetMethod(method.Name);
						control.Click+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.DoubleClick && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.DoubleClick);
						MethodInfo m = type.GetMethod(method.Name);
						control.DoubleClick+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.Enter && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.Enter);
						MethodInfo m = type.GetMethod(method.Name);
						control.Enter+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.GotFocus && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.GotFocus);
						MethodInfo m = type.GetMethod(method.Name);
						control.GotFocus+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.LostFocus && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.LostFocus);
						MethodInfo m = type.GetMethod(method.Name);
						control.LostFocus+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.Leave && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.Leave);
						MethodInfo m = type.GetMethod(method.Name);
						control.Leave+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.KeyDown && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.KeyDown);
						MethodInfo m = type.GetMethod(method.Name);
						control.KeyDown+=delegate(object sender, KeyEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.KeyPress && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.KeyPress);
						MethodInfo m = type.GetMethod(method.Name);
						control.KeyPress+=delegate(object sender, KeyPressEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.KeyUp && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.KeyUp);
						MethodInfo m = type.GetMethod(method.Name);
						control.KeyUp+=delegate(object sender, KeyEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseClick && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseClick);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseClick+=delegate(object sender, MouseEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseDoubleClick && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseDoubleClick);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseDoubleClick+=delegate(object sender, MouseEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseDown && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseDown);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseDown+=delegate(object sender, MouseEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseEnter && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseEnter);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseEnter+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseLeave && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseLeave);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseLeave+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseHover && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseHover);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseHover+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};					}
					if(method.Name == this.MouseUp && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseUp);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseUp+=delegate(object sender, MouseEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.MouseWheel && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.MouseWheel);
						MethodInfo m = type.GetMethod(method.Name);
						control.MouseWheel+=delegate(object sender, MouseEventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}
					if(method.Name == this.Resize && method.IsStatic){
						Console.WriteLine(method.Name + "==" + this.Resize);
						MethodInfo m = type.GetMethod(method.Name);
						control.Resize+=delegate(object sender, EventArgs e) {
							m.Invoke(null , new Object[]{sender,e});
						};
					}

				}
			}

		}

		public abstract System.Windows.Forms.Control DrawElement();
	}
}

