using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//Main Window

namespace WinformsGenerator
{
	public class MainWindow : Form
	{

		public MainWindow ()
		{
			this.InitializeComponent ();
		}

		private void InitializeComponent ()
		{

			this.splitContainer1 = new System.Windows.Forms.SplitContainer ();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer ();
			this.treeView1 = new TreeViewComponents ();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip ();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.splitContainer1.Panel1.SuspendLayout ();
			this.splitContainer1.Panel2.SuspendLayout ();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout ();
			this.splitContainer2.SuspendLayout ();
			this.menuStrip1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point (0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add (this.treeView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add (this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size (888, 601);
			this.splitContainer1.SplitterDistance = 244;
			// 
			// splitContainer2
			// 
			
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Vertical;
			
            this.splitContainer2.Size = new System.Drawing.Size(590, 601);
            this.splitContainer2.SplitterDistance = 391;


			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem}
			);
			this.menuStrip1.Location = new System.Drawing.Point (0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size (888, 24);
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size (60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
            // dataGridView1
            // 
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "Nombre";
            this.dataGridView1.Columns[1].Name = "Valor";
			this.dataGridView1.Columns[0].MinimumWidth = 50;
			this.dataGridView1.Columns[1].MinimumWidth = 50;
			dataGridView1.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            string[] row0 = { "Dock", "Fill" };
            this.dataGridView1.Rows.Add(row0);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Width = this.splitContainer2.Panel2.Width;
			this.dataGridView1.Anchor = (AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom);
			this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (888, 625);
			this.Controls.Add (this.splitContainer1);
			this.Controls.Add (this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout (false);
			this.splitContainer1.Panel2.ResumeLayout (false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer1.ResumeLayout (false);
			this.splitContainer2.ResumeLayout (false);
			this.menuStrip1.ResumeLayout (false);
			this.menuStrip1.PerformLayout ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}




		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private TreeViewComponents treeView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}

