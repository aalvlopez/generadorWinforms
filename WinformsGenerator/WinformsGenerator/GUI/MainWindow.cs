
//Main Window
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinformsGenerator
{
    public class MainWindow:Form
    {
		public MainWindow()
        {
            InitializeComponent();
        }
       
        private void InitializeComponent()
        {
			this.splitterLeft = new Splitter();
            this.splitterRight = new Splitter();

			this.archivoToolStripMenuItem = new ToolStripMenuItem ();
			this.menuStrip1 = new MenuStrip ();

			MainWindow.panelCenter = new WorkSpace();
			this.panelTreeView = new TreeViewComponents();
			this.panelPropertries=new Properties();
			
			this.menuStrip1.SuspendLayout ();
            MainWindow.panelCenter.SuspendLayout();
			this.panelTreeView.SuspendLayout();
			this.panelPropertries.SuspendLayout();
            this.SuspendLayout();
           
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange (new ToolStripItem[] {
            this.archivoToolStripMenuItem}
			);
			this.menuStrip1.Location = new Point (0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size (888, 24);
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new Size (60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";

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
			this.splitterLeft.Size=new Size(5,317);
            this.splitterLeft.TabStop = false;


            // 
            // panelCenter
            // 
            MainWindow.panelCenter.BorderStyle = BorderStyle.FixedSingle;
            MainWindow.panelCenter.Dock = DockStyle.Fill;
            MainWindow.panelCenter.Name = "panel1";
            
            // 
            // splitterRight
            // 
            this.splitterRight.BorderStyle = BorderStyle.FixedSingle;
            this.splitterRight.Dock = DockStyle.Right;
            this.splitterRight.Name = "splitter2";
            this.splitterRight.TabStop = false;
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
            this.ClientSize = new Size(1158, 700);

            this.Controls.Add(this.splitterRight);
            this.Controls.Add(MainWindow.panelCenter);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelPropertries);
			this.Controls.Add(this.panelTreeView);
			this.Controls.Add (this.menuStrip1);

			this.menuStrip1.ResumeLayout(false);
            MainWindow.panelCenter.ResumeLayout(false);
			this.panelTreeView.ResumeLayout(false);
			this.panelPropertries.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		//splitters
        private Splitter splitterLeft;
        private Splitter splitterRight;

		//Menu
		private ToolStripMenuItem archivoToolStripMenuItem;
		private MenuStrip menuStrip1;

		//Secciones
        public static WorkSpace panelCenter;
		private TreeViewComponents panelTreeView;
		private Properties panelPropertries;

    }
}
