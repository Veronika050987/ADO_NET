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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.comboBoxGroupsFilter = new System.Windows.Forms.ComboBox();
			this.comboBoxGroupsDirection = new System.Windows.Forms.ComboBox();
			this.labelGroupsDirection = new System.Windows.Forms.Label();
			this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.dataGridViewDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridViewDisciplines = new System.Windows.Forms.DataGridView();
			this.tabControl1.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
			this.tabPageDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).BeginInit();
			this.tabPageDisciplines.SuspendLayout();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageStudents);
			this.tabControl1.Controls.Add(this.tabPageGroups);
			this.tabControl1.Controls.Add(this.tabPageDirections);
			this.tabControl1.Controls.Add(this.tabPageDisciplines);
			this.tabControl1.Controls.Add(this.tabPageTeachers);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 450);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.statusStrip);
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 25);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 421);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Location = new System.Drawing.Point(3, 396);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(786, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewStudents.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.RowHeadersWidth = 51;
			this.dataGridViewStudents.RowTemplate.Height = 24;
			this.dataGridViewStudents.Size = new System.Drawing.Size(786, 397);
			this.dataGridViewStudents.TabIndex = 0;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.comboBoxGroupsFilter);
			this.tabPageGroups.Controls.Add(this.comboBoxGroupsDirection);
			this.tabPageGroups.Controls.Add(this.labelGroupsDirection);
			this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 421);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// comboBoxGroupsFilter
			// 
			this.comboBoxGroupsFilter.FormattingEnabled = true;
			this.comboBoxGroupsFilter.Location = new System.Drawing.Point(448, 6);
			this.comboBoxGroupsFilter.Name = "comboBoxGroupsFilter";
			this.comboBoxGroupsFilter.Size = new System.Drawing.Size(162, 24);
			this.comboBoxGroupsFilter.TabIndex = 3;
			this.comboBoxGroupsFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupsFilter_SelectedIndexChanged);
			// 
			// comboBoxGroupsDirection
			// 
			this.comboBoxGroupsDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroupsDirection.FormattingEnabled = true;
			this.comboBoxGroupsDirection.Location = new System.Drawing.Point(177, 7);
			this.comboBoxGroupsDirection.Name = "comboBoxGroupsDirection";
			this.comboBoxGroupsDirection.Size = new System.Drawing.Size(194, 24);
			this.comboBoxGroupsDirection.TabIndex = 2;
			this.comboBoxGroupsDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupsDirection_SelectedIndexChanged);
			// 
			// labelGroupsDirection
			// 
			this.labelGroupsDirection.AutoSize = true;
			this.labelGroupsDirection.Location = new System.Drawing.Point(24, 11);
			this.labelGroupsDirection.Name = "labelGroupsDirection";
			this.labelGroupsDirection.Size = new System.Drawing.Size(124, 16);
			this.labelGroupsDirection.TabIndex = 1;
			this.labelGroupsDirection.Text = "Education direction:";
			// 
			// dataGridViewGroups
			// 
			this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGroups.Location = new System.Drawing.Point(0, 37);
			this.dataGridViewGroups.Name = "dataGridViewGroups";
			this.dataGridViewGroups.RowHeadersWidth = 51;
			this.dataGridViewGroups.RowTemplate.Height = 24;
			this.dataGridViewGroups.Size = new System.Drawing.Size(789, 381);
			this.dataGridViewGroups.TabIndex = 0;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.dataGridViewDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 25);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(792, 421);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// dataGridViewDirections
			// 
			this.dataGridViewDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDirections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewDirections.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewDirections.Name = "dataGridViewDirections";
			this.dataGridViewDirections.RowHeadersWidth = 51;
			this.dataGridViewDirections.RowTemplate.Height = 24;
			this.dataGridViewDirections.Size = new System.Drawing.Size(786, 415);
			this.dataGridViewDirections.TabIndex = 0;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Controls.Add(this.dataGridViewDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 25);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 421);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.dataGridView1);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 25);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeachers.Size = new System.Drawing.Size(792, 421);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(786, 415);
			this.dataGridView1.TabIndex = 0;
			// 
			// dataGridViewDisciplines
			// 
			this.dataGridViewDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDisciplines.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewDisciplines.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewDisciplines.Name = "dataGridViewDisciplines";
			this.dataGridViewDisciplines.RowHeadersWidth = 51;
			this.dataGridViewDisciplines.RowTemplate.Height = 24;
			this.dataGridViewDisciplines.Size = new System.Drawing.Size(786, 410);
			this.dataGridViewDisciplines.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "Academy_PD_411";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
			this.tabPageDirections.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).EndInit();
			this.tabPageDisciplines.ResumeLayout(false);
			this.tabPageTeachers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridViewDirections;
		private System.Windows.Forms.DataGridView dataGridViewGroups;
		private System.Windows.Forms.ComboBox comboBoxGroupsDirection;
		private System.Windows.Forms.Label labelGroupsDirection;
		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.ComboBox comboBoxGroupsFilter;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.DataGridView dataGridViewDisciplines;
	}
}

