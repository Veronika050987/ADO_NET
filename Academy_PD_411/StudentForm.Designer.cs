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
			this.labelLastName = new System.Windows.Forms.Label();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelGroup = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.comboBoxGroup = new System.Windows.Forms.ComboBox();
			this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
			this.buttonBrowsePhoto = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(88, 20);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(69, 16);
			this.labelLastName.TabIndex = 0;
			this.labelLastName.Text = "Фамилия:";
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(121, 64);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(36, 16);
			this.labelFirstName.TabIndex = 1;
			this.labelFirstName.Text = "Имя:";
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Location = new System.Drawing.Point(84, 108);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(73, 16);
			this.labelMiddleName.TabIndex = 2;
			this.labelMiddleName.Text = "Отчество:";
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Location = new System.Drawing.Point(48, 152);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(109, 16);
			this.labelBirthDate.TabIndex = 3;
			this.labelBirthDate.Text = "Дата рождения:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(113, 196);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(44, 16);
			this.labelEmail.TabIndex = 4;
			this.labelEmail.Text = "Email:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(87, 240);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(70, 16);
			this.labelPhone.TabIndex = 5;
			this.labelPhone.Text = "Телефон:";
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
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(170, 17);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(216, 22);
			this.textBoxLastName.TabIndex = 7;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(170, 61);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(216, 22);
			this.textBoxFirstName.TabIndex = 8;
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.Location = new System.Drawing.Point(170, 105);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(216, 22);
			this.textBoxMiddleName.TabIndex = 9;
			// 
			// dateTimePickerBirthDate
			// 
			this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerBirthDate.Location = new System.Drawing.Point(170, 149);
			this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
			this.dateTimePickerBirthDate.Size = new System.Drawing.Size(216, 22);
			this.dateTimePickerBirthDate.TabIndex = 10;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(170, 193);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(216, 22);
			this.textBoxEmail.TabIndex = 11;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(170, 237);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(216, 22);
			this.textBoxPhone.TabIndex = 12;
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
			// pictureBoxPhoto
			// 
			this.pictureBoxPhoto.Location = new System.Drawing.Point(430, 20);
			this.pictureBoxPhoto.Name = "pictureBoxPhoto";
			this.pictureBoxPhoto.Size = new System.Drawing.Size(245, 239);
			this.pictureBoxPhoto.TabIndex = 14;
			this.pictureBoxPhoto.TabStop = false;
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
			// StudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 369);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowsePhoto);
			this.Controls.Add(this.pictureBoxPhoto);
			this.Controls.Add(this.comboBoxGroup);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.dateTimePickerBirthDate);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelGroup);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.labelLastName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "StudentForm";
			this.Text = "StudentForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.Label labelGroup;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.ComboBox comboBoxGroup;
		private System.Windows.Forms.PictureBox pictureBoxPhoto;
		private System.Windows.Forms.Button buttonBrowsePhoto;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
	}
}