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
			var newIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.new.png" ) );
			var copyIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.copy.png" ) );
			var cutIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.cut.png" ) );
			var deleteIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.delete.png" ) );
			var addIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.add.png" ) );
			var openIcon = new Bitmap( System.Reflection.Assembly.
					GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.open.png" ) );
			var pasteIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.paste.png" ) );
			var playIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.play.png" ) );
			var saveIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.save.png" ) );
			var saveAsIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.saveAs.png" ) );
			var stopIcon = new Bitmap( System.Reflection.Assembly.
				GetEntryAssembly().
				GetManifestResourceStream( "WinformsGenerator.img.stop.png" ) );

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
			this.newForm.Image = newIcon;
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
			this.open.Image = openIcon;

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
			this.save.Image = saveIcon;
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
			this.saveAs.Image = saveAsIcon;

			this.saveAs.Click+=delegate(object sender, EventArgs e) {
				this.SaveAs();
			};
			
			//
			//copy
			//
			this.copy.Name = "copy";
			this.copy.Size = new Size (128, 128);
			this.copy.ToolTipText="Copy";
			this.copy.Image = copyIcon;

			this.copy.Click+=delegate(object sender,EventArgs e){
				Controller.CopyNode();
			};
			
			//
			//cut
			//
			this.cut.Name = "cut";
			this.cut.Size = new Size (128, 128);
			this.cut.ToolTipText="Cut";
			this.cut.Image = cutIcon;

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
			this.paste.Image = pasteIcon;
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
			this.delete.Image = deleteIcon;

			this.delete.Click+=delegate(object sender, EventArgs e) {
				Controller.RemoveNode();
			};
			
			//
			//play
			//
			this.play.Name = "play";
			this.play.Size = new Size (128, 128);
			this.play.ToolTipText="Play";
			this.play.Image = playIcon;

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
			this.stop.Image = stopIcon;

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

