
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
			this.splitterLeft = new System.Windows.Forms.Splitter ();
			this.splitterRight = new System.Windows.Forms.Splitter ();

			this.menuStrip1 = new WinformsGenerator.WindowMenuStrip ();
			
			this.menuStrip1.SuspendLayout ();
			this.panelCenter.SuspendLayout ();
			this.panelTreeView.SuspendLayout ();
			this.panelPropertries.SuspendLayout ();
			this.SuspendLayout ();


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
			this.menuStrip1.EnablePaste();
		}
		public void DisablePaste(){
			this.menuStrip1.DisablePaste();
		}

		public void EnableSave(){
			this.menuStrip1.EnableSave();
		}

		public void DisableSave(){
			this.menuStrip1.DisableSave();
		}

		public void EnableCopy(){
			this.menuStrip1.EnableCopy();
		}

		public void DisableCopy(){
			this.menuStrip1.DisableCopy();
		}

		public void EnableCut(){
			this.menuStrip1.EnableCut();
		}

		public void DisableCut(){
			this.menuStrip1.DisableCut();
		}

		public void EnableDelete ()
		{
			this.menuStrip1.EnableDelete();
		}

		public void DisableDelete ()
		{
			this.menuStrip1.DisableDelete();
		}

		public void EnablePlay ()
		{
			this.menuStrip1.EnablePlay();
		}

		public void DisableStop ()
		{
			this.menuStrip1.DisableStop();

		}
		//splitters
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.Splitter splitterRight;

		//menuStrip
		
		private WinformsGenerator.WindowMenuStrip menuStrip1;

		//Secciones
        public WorkSpace panelCenter= new WorkSpace();
		public TreeViewComponents panelTreeView = new TreeViewComponents();
		public Properties panelPropertries = new Properties();

    }
}
