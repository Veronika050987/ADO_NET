namespace Academy_PD_411
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.statusStripStudents = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelStudents = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.statusStripGroups = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelGroups = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.statusStripDirections = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelDirections = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridViewDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.statusStripDisciplines = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelDisciplines = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridViewDisciplines = new System.Windows.Forms.DataGridView();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.statusStripTeachers = new System.Windows.Forms.StatusStrip();
			this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
			this.toolStripStatusLabelTeachers = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			this.statusStripStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			this.statusStripGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
			this.tabPageDirections.SuspendLayout();
			this.statusStripDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).BeginInit();
			this.tabPageDisciplines.SuspendLayout();
			this.statusStripDisciplines.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).BeginInit();
			this.tabPageTeachers.SuspendLayout();
			this.statusStripTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageStudents);
			this.tabControl1.Controls.Add(this.tabPageGroups);
			this.tabControl1.Controls.Add(this.tabPageDirections);
			this.tabControl1.Controls.Add(this.tabPageDisciplines);
			this.tabControl1.Controls.Add(this.tabPageTeachers);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 450);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.statusStripStudents);
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 25);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 421);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			this.tabPageStudents.Click += new System.EventHandler(this.tabPageStudents_Click);
			// 
			// statusStripStudents
			// 
			this.statusStripStudents.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStudents});
			this.statusStripStudents.Location = new System.Drawing.Point(3, 392);
			this.statusStripStudents.Name = "statusStripStudents";
			this.statusStripStudents.Size = new System.Drawing.Size(786, 26);
			this.statusStripStudents.TabIndex = 1;
			this.statusStripStudents.Text = "statusStripStudents";
			// 
			// toolStripStatusLabelStudents
			// 
			this.toolStripStatusLabelStudents.Name = "toolStripStatusLabelStudents";
			this.toolStripStatusLabelStudents.Size = new System.Drawing.Size(99, 20);
			this.toolStripStatusLabelStudents.Text = "TotalStudents";
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewStudents.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.RowHeadersWidth = 51;
			this.dataGridViewStudents.RowTemplate.Height = 24;
			this.dataGridViewStudents.Size = new System.Drawing.Size(786, 375);
			this.dataGridViewStudents.TabIndex = 0;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.statusStripGroups);
			this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 421);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// statusStripGroups
			// 
			this.statusStripGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGroups});
			this.statusStripGroups.Location = new System.Drawing.Point(3, 392);
			this.statusStripGroups.Name = "statusStripGroups";
			this.statusStripGroups.Size = new System.Drawing.Size(786, 26);
			this.statusStripGroups.TabIndex = 1;
			this.statusStripGroups.Text = "statusStripGroups";
			// 
			// toolStripStatusLabelGroups
			// 
			this.toolStripStatusLabelGroups.Name = "toolStripStatusLabelGroups";
			this.toolStripStatusLabelGroups.Size = new System.Drawing.Size(89, 20);
			this.toolStripStatusLabelGroups.Text = "TotalGroups";
			// 
			// dataGridViewGroups
			// 
			this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewGroups.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewGroups.Name = "dataGridViewGroups";
			this.dataGridViewGroups.RowHeadersWidth = 51;
			this.dataGridViewGroups.RowTemplate.Height = 24;
			this.dataGridViewGroups.Size = new System.Drawing.Size(786, 415);
			this.dataGridViewGroups.TabIndex = 0;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.statusStripDirections);
			this.tabPageDirections.Controls.Add(this.dataGridViewDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 25);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(792, 421);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// statusStripDirections
			// 
			this.statusStripDirections.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripDirections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDirections});
			this.statusStripDirections.Location = new System.Drawing.Point(3, 392);
			this.statusStripDirections.Name = "statusStripDirections";
			this.statusStripDirections.Size = new System.Drawing.Size(786, 26);
			this.statusStripDirections.TabIndex = 1;
			this.statusStripDirections.Text = "statusStripDirections";
			this.statusStripDirections.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
			// 
			// toolStripStatusLabelDirections
			// 
			this.toolStripStatusLabelDirections.Name = "toolStripStatusLabelDirections";
			this.toolStripStatusLabelDirections.Size = new System.Drawing.Size(109, 20);
			this.toolStripStatusLabelDirections.Text = "TotalDirections";
			// 
			// dataGridViewDirections
			// 
			this.dataGridViewDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDirections.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewDirections.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewDirections.Name = "dataGridViewDirections";
			this.dataGridViewDirections.RowHeadersWidth = 51;
			this.dataGridViewDirections.RowTemplate.Height = 24;
			this.dataGridViewDirections.Size = new System.Drawing.Size(786, 415);
			this.dataGridViewDirections.TabIndex = 0;
			this.dataGridViewDirections.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDirections_CellContentClick);
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Controls.Add(this.statusStripDisciplines);
			this.tabPageDisciplines.Controls.Add(this.dataGridViewDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 25);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 421);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// statusStripDisciplines
			// 
			this.statusStripDisciplines.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripDisciplines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDisciplines});
			this.statusStripDisciplines.Location = new System.Drawing.Point(3, 392);
			this.statusStripDisciplines.Name = "statusStripDisciplines";
			this.statusStripDisciplines.Size = new System.Drawing.Size(786, 26);
			this.statusStripDisciplines.TabIndex = 1;
			this.statusStripDisciplines.Text = "statusStripDisciplines";
			// 
			// toolStripStatusLabelDisciplines
			// 
			this.toolStripStatusLabelDisciplines.Name = "toolStripStatusLabelDisciplines";
			this.toolStripStatusLabelDisciplines.Size = new System.Drawing.Size(113, 20);
			this.toolStripStatusLabelDisciplines.Text = "TotalDisciplines";
			// 
			// dataGridViewDisciplines
			// 
			this.dataGridViewDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDisciplines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewDisciplines.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewDisciplines.Name = "dataGridViewDisciplines";
			this.dataGridViewDisciplines.RowHeadersWidth = 51;
			this.dataGridViewDisciplines.RowTemplate.Height = 24;
			this.dataGridViewDisciplines.Size = new System.Drawing.Size(786, 415);
			this.dataGridViewDisciplines.TabIndex = 0;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.statusStripTeachers);
			this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 25);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeachers.Size = new System.Drawing.Size(792, 421);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// statusStripTeachers
			// 
			this.statusStripTeachers.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripTeachers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTeachers});
			this.statusStripTeachers.Location = new System.Drawing.Point(3, 392);
			this.statusStripTeachers.Name = "statusStripTeachers";
			this.statusStripTeachers.Size = new System.Drawing.Size(786, 26);
			this.statusStripTeachers.TabIndex = 1;
			this.statusStripTeachers.Text = "statusStripTeachers";
			this.statusStripTeachers.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripTeachers_ItemClicked);
			// 
			// dataGridViewTeachers
			// 
			this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTeachers.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewTeachers.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewTeachers.Name = "dataGridViewTeachers";
			this.dataGridViewTeachers.RowHeadersWidth = 51;
			this.dataGridViewTeachers.RowTemplate.Height = 24;
			this.dataGridViewTeachers.Size = new System.Drawing.Size(786, 415);
			this.dataGridViewTeachers.TabIndex = 0;
			this.dataGridViewTeachers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeachers_CellContentClick);
			// 
			// toolStripStatusLabelTeachers
			// 
			this.toolStripStatusLabelTeachers.Name = "toolStripStatusLabelTeachers";
			this.toolStripStatusLabelTeachers.Size = new System.Drawing.Size(99, 20);
			this.toolStripStatusLabelTeachers.Text = "TotalTeachers";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "Academy_PD_411";
			this.tabControl1.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			this.statusStripStudents.ResumeLayout(false);
			this.statusStripStudents.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			this.statusStripGroups.ResumeLayout(false);
			this.statusStripGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
			this.tabPageDirections.ResumeLayout(false);
			this.tabPageDirections.PerformLayout();
			this.statusStripDirections.ResumeLayout(false);
			this.statusStripDirections.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).EndInit();
			this.tabPageDisciplines.ResumeLayout(false);
			this.tabPageDisciplines.PerformLayout();
			this.statusStripDisciplines.ResumeLayout(false);
			this.statusStripDisciplines.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).EndInit();
			this.tabPageTeachers.ResumeLayout(false);
			this.tabPageTeachers.PerformLayout();
			this.statusStripTeachers.ResumeLayout(false);
			this.statusStripTeachers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.DataGridView dataGridViewTeachers;
		private System.Windows.Forms.DataGridView dataGridViewDirections;
		private System.Windows.Forms.StatusStrip statusStripDirections;
		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.DataGridView dataGridViewGroups;
		private System.Windows.Forms.DataGridView dataGridViewDisciplines;
		private System.Windows.Forms.StatusStrip statusStripStudents;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStudents;
		private System.Windows.Forms.StatusStrip statusStripGroups;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGroups;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDirections;
		private System.Windows.Forms.StatusStrip statusStripDisciplines;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDisciplines;
		private System.Windows.Forms.StatusStrip statusStripTeachers;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTeachers;
	}
}

