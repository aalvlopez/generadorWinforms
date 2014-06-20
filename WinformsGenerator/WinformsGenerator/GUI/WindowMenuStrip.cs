using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace WinformsGenerator
{
	public class WindowMenuStrip:System.Windows.Forms.MenuStrip
	{
		public WindowMenuStrip ()
		{
			String outPutDirectory = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().CodeBase);
			this.newForm = new ToolStripMenuItem ();
			this.copy = new ToolStripMenuItem ();
			this.cut = new ToolStripMenuItem ();
			this.paste = new ToolStripMenuItem ();
			this.delete = new ToolStripMenuItem ();
			this.open = new ToolStripMenuItem ();
			this.play = new ToolStripMenuItem ();
			this.stop = new ToolStripMenuItem ();
			this.save = new ToolStripMenuItem ();
			this.saveAs = new ToolStripMenuItem ();

			this.Name = "menuStrip1";
			this.Text = "menuStrip1";
			this.Items.AddRange (new ToolStripMenuItem[] {
          	this.newForm,
			this.open,
			this.save,
			this.saveAs,
			this.copy,
			this.cut,
			this.paste,
			this.delete,
			this.play,
			this.stop}
			);

			// 
			// archivoToolStripMenuItem
			// 

			//
			//newForm
			//
			this.newForm.Name = "newForm";
			this.newForm.Size = new Size (128, 128);
			this.newForm.ToolTipText="New Form";
			var imgFile = Path.Combine (outPutDirectory, "img/new.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.newForm.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = "img\\new.png";
				if (File.Exists (imgFile)) {
					this.newForm.Image = Image.FromFile (imgFile);
				}
			}
			Console.WriteLine(imgFile);
			this.newForm.Click+=delegate(object sender,EventArgs e) {
				Controller.NewForm();
				Controller.SetSaveFile(null);
				this.save.Enabled=false;
			};

			//
			//open
			//
			this.open.Name = "open";
			this.open.Size = new Size (128, 128);
			this.open.ToolTipText="Open file";
			
            imgFile = Path.Combine(outPutDirectory, "img/open.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.open.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile ="img\\open.png";
				if (File.Exists (imgFile)) {
					this.open.Image = Image.FromFile (imgFile);
				}
			}
			this.open.Click+=delegate(object sender, EventArgs e) {
				OpenFileDialog openD = new OpenFileDialog();
				openD.Filter = "xml files (*.xml)|*.xml" ;
				DialogResult result = openD.ShowDialog();
				if (result == DialogResult.OK)
				{
					Controller.SetSaveFile(openD.FileName);
					Controller.OpenFile();
					this.save.Enabled=true;
				}

			};

			//
			//save
			//
			this.save.Name = "save";
			this.save.Size = new Size (128, 128);
			this.save.ToolTipText="Save";

            imgFile = Path.Combine(outPutDirectory, "img/save.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.save.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile ="img\\save.png";
				if (File.Exists (imgFile)) {
					this.save.Image = Image.FromFile (imgFile);
				}
			}
			this.save.Enabled=false;
			this.save.Click+=delegate(object sender, EventArgs e) {
				Controller.SaveAsFile();
			};

			//
			//saveAs
			//
			this.saveAs.Name = "saveAs";
			this.saveAs.Size = new Size (128, 128);
			this.saveAs.ToolTipText="Save As";

            imgFile = Path.Combine(outPutDirectory, "img/saveAs.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.saveAs.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile ="img\\saveAs.png";
				if (File.Exists (imgFile)) {
					this.saveAs.Image = Image.FromFile (imgFile);
				}
			}
			this.saveAs.Click+=delegate(object sender, EventArgs e) {
				this.SaveAs();
			};
			
			//
			//copy
			//
			this.copy.Name = "copy";
			this.copy.Size = new Size (128, 128);
			this.copy.ToolTipText="Copy";

            imgFile = Path.Combine(outPutDirectory, "img/copy.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.copy.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile ="img\\copy.png";
				if (File.Exists (imgFile)) {
					this.copy.Image = Image.FromFile (imgFile);
				}
			}
			this.copy.Click+=delegate(object sender,EventArgs e){
				Controller.CopyNode();
			};
			
			//
			//cut
			//
			this.cut.Name = "cut";
			this.cut.Size = new Size (128, 128);
			this.cut.ToolTipText="Cut";

            imgFile = Path.Combine(outPutDirectory, "img/cut.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.cut.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile ="img\\cut.png";
				if (File.Exists (imgFile)) {
					this.cut.Image = Image.FromFile (imgFile);
				}
			}
			this.cut.Click+=delegate(object sender, EventArgs e){
				Controller.CopyNode();
				Controller.RemoveNode();
			};
			
			//
			//paste
			//
			this.paste.Name = "paste";
			this.paste.Size = new Size (128, 128);
			this.paste.ToolTipText="Paste";

            imgFile = Path.Combine(outPutDirectory, "img/paste.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.paste.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = "img\\paste.png";
				if (File.Exists (imgFile)) {
					this.paste.Image = Image.FromFile (imgFile);
				}
			}
			this.paste.Enabled=false;
			this.paste.Click+=delegate(object sender, EventArgs e){
				Controller.PasteNode();
			};
			
			//
			//delete
			//
			this.delete.Name = "delete";
			this.delete.Size = new Size (128, 128);
			this.delete.ToolTipText="Delete";

            imgFile = Path.Combine(outPutDirectory, "img/delete.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.delete.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = "img\\delete.png";
				if (File.Exists (imgFile)) {
					this.delete.Image = Image.FromFile (imgFile);
				}
			}
			this.delete.Click+=delegate(object sender, EventArgs e) {
				Controller.RemoveNode();
			};
			
			//
			//play
			//
			this.play.Name = "play";
			this.play.Size = new Size (128, 128);
			this.play.ToolTipText="Play";

            imgFile = Path.Combine(outPutDirectory, "img/play.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.play.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = "img\\play.png";
				if (File.Exists (imgFile)) {
					this.play.Image = Image.FromFile (imgFile);
				}
			}
			this.play.Click+=delegate(object sender, EventArgs e) {
				DialogResult result;
				if(Controller.GetSaveFile()==null){
					result= this.SaveAs();
					if(result==DialogResult.OK){
						Controller.Test();
						this.play.Enabled=false;
						this.stop.Enabled=true;
					}
				}else{
					Controller.SaveAsFile();
					Controller.Test();
					this.play.Enabled=false;
					this.stop.Enabled=true;
				}
			};
			this.play.ShortcutKeys=Keys.F5;
			
			//
			//stop
			//
			this.stop.Name = "stop";
			this.stop.Size = new Size (128, 128);
			this.stop.ToolTipText="Stop";

            imgFile = Path.Combine(outPutDirectory, "img/stop.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.stop.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = "img\\stop.png";
				if (File.Exists (imgFile)) {
					this.stop.Image = Image.FromFile (imgFile);
				}
			}
			this.stop.Enabled=false;
			this.stop.Click+=delegate(object sender, EventArgs e) {
				Controller.StopTest();
				this.play.Enabled=true;
				this.stop.Enabled=false;
			};
			this.stop.ShortcutKeys=Keys.Shift | Keys.F5;
			this.ShowItemToolTips=true;

		}

		public DialogResult SaveAs ()
		{
			SaveFileDialog saveD = new SaveFileDialog();
			saveD.DefaultExt="xml";
			saveD.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*" ;
			DialogResult result = saveD.ShowDialog();
			if (result == DialogResult.OK)
			{
				Controller.SetSaveFile(saveD.FileName);
				Controller.SaveAsFile();
				this.save.Enabled=true;
			}
			return result;
		}

		public void EnablePaste(){
			this.paste.Enabled=true;
		}

		public void DisablePaste(){
			this.paste.Enabled=false;
		}

		public void EnableSave(){
			this.save.Enabled=true;
		}

		public void DisableSave(){
			this.save.Enabled=false;
		}

		public void EnableCopy(){
			this.copy.Enabled=true;
		}

		public void DisableCopy(){
			this.copy.Enabled=false;
		}

		public void EnableCut(){
			this.cut.Enabled=true;
		}

		public void DisableCut(){
			this.cut.Enabled=false;
		}

		public void EnableDelete ()
		{
			this.delete.Enabled = true;
		}

		public void DisableDelete ()
		{
			this.delete.Enabled = false;
		}

		public void EnablePlay ()
		{
			this.play.Enabled = true;
		}

		public void DisableStop ()
		{
			this.stop.Enabled = false;
		}

		//Menu
		private System.Windows.Forms.ToolStripMenuItem newForm;
		private System.Windows.Forms.ToolStripMenuItem copy;
		private System.Windows.Forms.ToolStripMenuItem cut;
		private System.Windows.Forms.ToolStripMenuItem paste;
		private System.Windows.Forms.ToolStripMenuItem delete;
		private System.Windows.Forms.ToolStripMenuItem open;
		private System.Windows.Forms.ToolStripMenuItem play;
		private System.Windows.Forms.ToolStripMenuItem stop;
		private System.Windows.Forms.ToolStripMenuItem save;
		private System.Windows.Forms.ToolStripMenuItem saveAs;
	}
}

