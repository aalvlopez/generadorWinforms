using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Label:Control
	{
		
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Label ():base()
		{
			this.TextAlign=ContentAlignment.MiddleRight;
		}
		public Label (String id, DockStyle style, String name, String text,ContentAlignment textAlign):base(id, style, name,text){
			this.TextAlign=textAlign;
		}

		public override void drawElement (){
			System.Windows.Forms.Label label = new System.Windows.Forms.Label();
			label.Dock=this.Dock;
			label.Name=this.Name;
			label.Text=this.Text;
			label.TextAlign=this.TextAlign;

			WorkSpace.panelWork.SuspendLayout();
			WorkSpace.panelWork.Controls.Add(label);
			WorkSpace.panelWork.ResumeLayout(false);
		}
	}
}

