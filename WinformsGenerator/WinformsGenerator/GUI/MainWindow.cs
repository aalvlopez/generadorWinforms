
//Main Window
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xaml;


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
			
			this.menuStrip1.SuspendLayout ();
            MainWindow.panelCenter.SuspendLayout();
			MainWindow.panelTreeView.SuspendLayout();
			MainWindow.panelPropertries.SuspendLayout();
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
			MainWindow.panelTreeView.Dock = DockStyle.Left;
            MainWindow.panelTreeView.Name = "panelTreeview";
			MainWindow.panelTreeView.Size = new Size(300, 317);
			
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
			MainWindow.panelPropertries.Dock = DockStyle.Right;
            MainWindow.panelPropertries.Name = "panelTreeview";
            MainWindow.panelPropertries.Size = new Size(300, 317);

            // 
            // Form1
            // 
			
            this.Name = "Form1";
            this.Size = new Size(1158, 700);
			this.Text = "WinformsGenerator";

            this.Controls.Add(this.splitterRight);
            this.Controls.Add(MainWindow.panelCenter);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(MainWindow.panelPropertries);
			this.Controls.Add(MainWindow.panelTreeView);
			this.Controls.Add (this.menuStrip1);

			this.menuStrip1.ResumeLayout(false);
            MainWindow.panelCenter.ResumeLayout(false);
			MainWindow.panelTreeView.ResumeLayout(false);
			MainWindow.panelPropertries.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		public static void ReDraw(Panel panel){
			MainWindow.panelCenter.panelWork=panel;
			MainWindow.panelCenter.Controls.Clear();
			MainWindow.panelCenter.Controls.Add(MainWindow.panelCenter.panelWork);
		}
		public static void GenerateDataGrid (DataGridView datagridView)
		{
			MainWindow.panelPropertries.Controls.Clear();
			MainWindow.panelPropertries.dataGridView1=datagridView;
			MainWindow.panelPropertries.Controls.Add(MainWindow.panelPropertries.dataGridView1);
		}
		//splitters
        private Splitter splitterLeft;
        private Splitter splitterRight;

		//Menu
		private ToolStripMenuItem archivoToolStripMenuItem;
		private MenuStrip menuStrip1;

		//Secciones
        public static WorkSpace panelCenter= new WorkSpace();
		public static TreeViewComponents panelTreeView = new TreeViewComponents();
		public static Properties panelPropertries = new Properties();

    }
}
