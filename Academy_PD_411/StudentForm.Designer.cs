namespace Academy_PD_411
{
	partial class StudentForm
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
			this.labelGroup = new System.Windows.Forms.Label();
			this.comboBoxGroup = new System.Windows.Forms.ComboBox();
			this.buttonBrowsePhoto = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelID = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelGroup
			// 
			this.labelGroup.AutoSize = true;
			this.labelGroup.Location = new System.Drawing.Point(100, 284);
			this.labelGroup.Name = "labelGroup";
			this.labelGroup.Size = new System.Drawing.Size(57, 16);
			this.labelGroup.TabIndex = 6;
			this.labelGroup.Text = "Группа:";
			// 
			// comboBoxGroup
			// 
			this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroup.FormattingEnabled = true;
			this.comboBoxGroup.Location = new System.Drawing.Point(170, 281);
			this.comboBoxGroup.Name = "comboBoxGroup";
			this.comboBoxGroup.Size = new System.Drawing.Size(216, 24);
			this.comboBoxGroup.TabIndex = 13;
			// 
			// buttonBrowsePhoto
			// 
			this.buttonBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.buttonBrowsePhoto.Location = new System.Drawing.Point(260, 328);
			this.buttonBrowsePhoto.Name = "buttonBrowsePhoto";
			this.buttonBrowsePhoto.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowsePhoto.TabIndex = 15;
			this.buttonBrowsePhoto.Text = "Обзор";
			this.buttonBrowsePhoto.UseVisualStyleBackColor = false;
			this.buttonBrowsePhoto.Click += new System.EventHandler(this.buttonBrowsePhoto_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(430, 328);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 16;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(600, 328);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelID.Location = new System.Drawing.Point(22, 334);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(31, 25);
			this.labelID.TabIndex = 18;
			this.labelID.Text = "ID";
			this.labelID.Visible = false;
			// 
			// StudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 369);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowsePhoto);
			this.Controls.Add(this.comboBoxGroup);
			this.Controls.Add(this.labelGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "StudentForm";
			this.Text = "StudentForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelGroup;
		private System.Windows.Forms.ComboBox comboBoxGroup;
		private System.Windows.Forms.Button buttonBrowsePhoto;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelID;
	}
}