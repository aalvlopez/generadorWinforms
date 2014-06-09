
﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Reflection;

namespace WinformsGenerator
{
    public class MainWindow:System.Windows.Forms.Form
    {
		public MainWindow()
        {
            InitializeComponent();
        }
       
        private void InitializeComponent ()
		{
			String outPutDirectory = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().CodeBase);
			this.splitterLeft = new System.Windows.Forms.Splitter ();
			this.splitterRight = new System.Windows.Forms.Splitter ();
			this.newForm = new ToolStripMenuItem ();
			this.addForm = new ToolStripMenuItem ();
			this.copy = new ToolStripMenuItem ();
			this.cut = new ToolStripMenuItem ();
			this.paste = new ToolStripMenuItem ();
			this.delete = new ToolStripMenuItem ();
			this.open = new ToolStripMenuItem ();
			this.play = new ToolStripMenuItem ();
			this.stop = new ToolStripMenuItem ();
			this.save = new ToolStripMenuItem ();
			this.saveAs = new ToolStripMenuItem ();
			this.menuStrip1 = new MenuStrip ();
			
			this.menuStrip1.SuspendLayout ();
			this.panelCenter.SuspendLayout ();
			this.panelTreeView.SuspendLayout ();
			this.panelPropertries.SuspendLayout ();
			this.SuspendLayout ();
           
			// 
			// menuStrip1
			// 
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Items.AddRange (new ToolStripMenuItem[] {
          	this.newForm,
			this.addForm,
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
			
			var imgFile = Path.Combine (outPutDirectory, "img/new.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.newForm.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\new.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.newForm.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
				}
			}
			this.newForm.Click+=delegate(object sender,EventArgs e) {
				Controller.NuevoForm();
				Controller.SetSaveFile(null);
				this.save.Enabled=false;
			};

			//
			//open
			//
			this.open.Name = "open";
			this.open.Size = new Size (128, 128);
			
            imgFile = Path.Combine(outPutDirectory, "img/open.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.open.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\open.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.open.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/save.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.save.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\save.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.save.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/saveAs.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.saveAs.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\saveAs.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.saveAs.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/copy.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.copy.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\copy.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.copy.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/cut.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.cut.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\cut.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.cut.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/paste.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.paste.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\paste.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.paste.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/delete.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.delete.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\delete.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.delete.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
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
            imgFile = Path.Combine(outPutDirectory, "img/play.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.play.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\play.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.play.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
				}
			}
			this.play.Click+=delegate(object sender, EventArgs e) {
				DialogResult result;
				if(Controller.GetSaveFile()==null){
					result= this.SaveAs();
					if(result==DialogResult.OK){
						Controller.Test();
					}
				}else{
					Controller.SaveAsFile();
					Controller.Test();
				}
				this.play.Enabled=false;
				this.stop.Enabled=true;
			};
			this.play.ShortcutKeys=Keys.F5;
			
			//
			//stop
			//
			this.stop.Name = "stop";
			this.stop.Size = new Size (128, 128);
            imgFile = Path.Combine(outPutDirectory, "img/stop.png");
			if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
				this.stop.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
			} else {
				imgFile = Path.Combine (outPutDirectory, "img\\stop.png");
				if (File.Exists (imgFile.TrimStart ("file:".ToCharArray ()))) {
					this.stop.Image = Image.FromFile (imgFile.TrimStart ("file:".ToCharArray ()));
				}
			}
			this.stop.Enabled=false;
			this.stop.Click+=delegate(object sender, EventArgs e) {
				Controller.StopTest();
				this.play.Enabled=true;
				this.stop.Enabled=false;
			};
			this.stop.ShortcutKeys=Keys.Shift | Keys.F5;


			// 
            // panelTreeview
            // 
			this.panelTreeView.Dock = DockStyle.Left;
            this.panelTreeView.Name = "panelTreeview";
			this.panelTreeView.Size = new Size(300, 317);
			
            // 
            // splitterLeft
            // 
            this.splitterLeft.BorderStyle = BorderStyle.FixedSingle;
            this.splitterLeft.Name = "splitter1";
            this.splitterLeft.Dock = DockStyle.Left;
			this.splitterLeft.Size=new Size(5,317);


            // 
            // panelCenter
            // 
            this.panelCenter.BorderStyle = BorderStyle.FixedSingle;
            this.panelCenter.Dock = DockStyle.Fill;
            this.panelCenter.Name = "panel1";
            
            // 
            // splitterRight
            // 
            this.splitterRight.BorderStyle = BorderStyle.FixedSingle;
            this.splitterRight.Dock = DockStyle.Right;
            this.splitterRight.Name = "splitter2";
			this.splitterRight.Size=new Size(5,317);
            

			// 
            // panelProperties
            // 
			this.panelPropertries.Dock = DockStyle.Right;
            this.panelPropertries.Name = "panelTreeview";
            this.panelPropertries.Size = new Size(300, 317);

            // 
            // Form1
            // 
            this.Name = "Form1";
            this.Size = new Size(1158, 700);
			this.Text = "WinformsGenerator";

            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelPropertries);
			this.Controls.Add(this.panelTreeView);
			this.Controls.Add (this.menuStrip1);

			this.menuStrip1.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
			this.panelTreeView.ResumeLayout(false);
			this.panelPropertries.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		public void ReDraw(Panel panel){
			this.panelCenter.panelWork=panel;
			this.panelCenter.Controls.Clear();
			this.panelCenter.Controls.Add(this.panelCenter.panelWork);
		}
		public void GenerateDataGrid (System.Windows.Forms.DataGridView datagridView, System.Windows.Forms.DataGridView eventGrid)
		{
			this.panelPropertries.page1.Controls.Clear();
			this.panelPropertries.dataGridView1=datagridView;
			this.panelPropertries.page1.Controls.Add(this.panelPropertries.dataGridView1);
			this.panelPropertries.page2.Controls.Clear();
			this.panelPropertries.dataGridView2=eventGrid;
			this.panelPropertries.page2.Controls.Add(this.panelPropertries.dataGridView2);
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

		//splitters
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.Splitter splitterRight;

		//Menu
		private System.Windows.Forms.ToolStripMenuItem newForm;
		private System.Windows.Forms.ToolStripMenuItem addForm;
		private System.Windows.Forms.ToolStripMenuItem copy;
		private System.Windows.Forms.ToolStripMenuItem cut;
		private System.Windows.Forms.ToolStripMenuItem paste;
		private System.Windows.Forms.ToolStripMenuItem delete;
		private System.Windows.Forms.ToolStripMenuItem open;
		private System.Windows.Forms.ToolStripMenuItem play;
		private System.Windows.Forms.ToolStripMenuItem stop;
		private System.Windows.Forms.ToolStripMenuItem save;
		private System.Windows.Forms.ToolStripMenuItem saveAs;
		private System.Windows.Forms.MenuStrip menuStrip1;

		//Secciones
        public WorkSpace panelCenter= new WorkSpace();
		public TreeViewComponents panelTreeView = new TreeViewComponents();
		public Properties panelPropertries = new Properties();

    }
}
