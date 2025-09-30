namespace DataSet
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
			this.labelGroups = new System.Windows.Forms.Label();
			this.comboBoxGroups = new System.Windows.Forms.ComboBox();
			this.labelDirections = new System.Windows.Forms.Label();
			this.comboBoxDirections = new System.Windows.Forms.ComboBox();
			this.buttonReset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelGroups
			// 
			this.labelGroups.AutoSize = true;
			this.labelGroups.Location = new System.Drawing.Point(29, 63);
			this.labelGroups.Name = "labelGroups";
			this.labelGroups.Size = new System.Drawing.Size(54, 16);
			this.labelGroups.TabIndex = 0;
			this.labelGroups.Text = "Groups:";
			// 
			// comboBoxGroups
			// 
			this.comboBoxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroups.FormattingEnabled = true;
			this.comboBoxGroups.Location = new System.Drawing.Point(112, 55);
			this.comboBoxGroups.Name = "comboBoxGroups";
			this.comboBoxGroups.Size = new System.Drawing.Size(418, 24);
			this.comboBoxGroups.TabIndex = 1;
			// 
			// labelDirections
			// 
			this.labelDirections.AutoSize = true;
			this.labelDirections.Location = new System.Drawing.Point(29, 147);
			this.labelDirections.Name = "labelDirections";
			this.labelDirections.Size = new System.Drawing.Size(70, 16);
			this.labelDirections.TabIndex = 2;
			this.labelDirections.Text = "Directions:";
			// 
			// comboBoxDirections
			// 
			this.comboBoxDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDirections.FormattingEnabled = true;
			this.comboBoxDirections.Location = new System.Drawing.Point(112, 139);
			this.comboBoxDirections.Name = "comboBoxDirections";
			this.comboBoxDirections.Size = new System.Drawing.Size(418, 24);
			this.comboBoxDirections.TabIndex = 3;
			this.comboBoxDirections.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirections_SelectedIndexChanged_1);
			// 
			// buttonReset
			// 
			this.buttonReset.BackColor = System.Drawing.Color.Fuchsia;
			this.buttonReset.Location = new System.Drawing.Point(583, 97);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 23);
			this.buttonReset.TabIndex = 4;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = false;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 240);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.comboBoxDirections);
			this.Controls.Add(this.labelDirections);
			this.Controls.Add(this.comboBoxGroups);
			this.Controls.Add(this.labelGroups);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelGroups;
		private System.Windows.Forms.ComboBox comboBoxGroups;
		private System.Windows.Forms.Label labelDirections;
		private System.Windows.Forms.ComboBox comboBoxDirections;
		private System.Windows.Forms.Button buttonReset;
	}
}

