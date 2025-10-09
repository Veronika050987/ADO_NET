namespace Academy_PD_411
{
	partial class TeacherForm
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
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
			this.labelEmail = new System.Windows.Forms.Label();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.labelPhone = new System.Windows.Forms.Label();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.pictureBoxTeacherPhoto = new System.Windows.Forms.PictureBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelTeacherID = new System.Windows.Forms.Label();
			this.textBoxTeacherId = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeacherPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(97, 30);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(69, 16);
			this.labelLastName.TabIndex = 0;
			this.labelLastName.Text = "Фамилия:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(172, 24);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(254, 22);
			this.textBoxLastName.TabIndex = 1;
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(130, 68);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(36, 16);
			this.labelFirstName.TabIndex = 2;
			this.labelFirstName.Text = "Имя:";
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(172, 62);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(254, 22);
			this.textBoxFirstName.TabIndex = 3;
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Location = new System.Drawing.Point(93, 110);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(73, 16);
			this.labelMiddleName.TabIndex = 4;
			this.labelMiddleName.Text = "Отчество:";
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.Location = new System.Drawing.Point(172, 104);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(254, 22);
			this.textBoxMiddleName.TabIndex = 5;
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Location = new System.Drawing.Point(57, 148);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(109, 16);
			this.labelBirthDate.TabIndex = 6;
			this.labelBirthDate.Text = "Дата рождения:";
			// 
			// dateTimePickerBirthDate
			// 
			this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerBirthDate.Location = new System.Drawing.Point(172, 142);
			this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
			this.dateTimePickerBirthDate.Size = new System.Drawing.Size(254, 22);
			this.dateTimePickerBirthDate.TabIndex = 7;
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(122, 192);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(44, 16);
			this.labelEmail.TabIndex = 8;
			this.labelEmail.Text = "Email:";
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(172, 186);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(254, 22);
			this.textBoxEmail.TabIndex = 9;
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(96, 241);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(70, 16);
			this.labelPhone.TabIndex = 10;
			this.labelPhone.Text = "Телефон:";
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(172, 235);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(254, 22);
			this.textBoxPhone.TabIndex = 11;
			// 
			// pictureBoxTeacherPhoto
			// 
			this.pictureBoxTeacherPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxTeacherPhoto.Location = new System.Drawing.Point(496, 30);
			this.pictureBoxTeacherPhoto.Name = "pictureBoxTeacherPhoto";
			this.pictureBoxTeacherPhoto.Size = new System.Drawing.Size(234, 301);
			this.pictureBoxTeacherPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxTeacherPhoto.TabIndex = 12;
			this.pictureBoxTeacherPhoto.TabStop = false;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.BackColor = System.Drawing.Color.Fuchsia;
			this.buttonBrowse.Location = new System.Drawing.Point(125, 385);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 13;
			this.buttonBrowse.Text = "Обзор";
			this.buttonBrowse.UseVisualStyleBackColor = false;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(496, 385);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 14;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(655, 385);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			// 
			// labelTeacherID
			// 
			this.labelTeacherID.AutoSize = true;
			this.labelTeacherID.Location = new System.Drawing.Point(146, 284);
			this.labelTeacherID.Name = "labelTeacherID";
			this.labelTeacherID.Size = new System.Drawing.Size(20, 16);
			this.labelTeacherID.TabIndex = 16;
			this.labelTeacherID.Text = "ID";
			// 
			// textBoxTeacherId
			// 
			this.textBoxTeacherId.Location = new System.Drawing.Point(172, 278);
			this.textBoxTeacherId.Name = "textBoxTeacherId";
			this.textBoxTeacherId.Size = new System.Drawing.Size(254, 22);
			this.textBoxTeacherId.TabIndex = 17;
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.textBoxTeacherId);
			this.Controls.Add(this.labelTeacherID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.pictureBoxTeacherPhoto);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.dateTimePickerBirthDate);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelLastName);
			this.Name = "TeacherForm";
			this.Text = "TeacherForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeacherPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.PictureBox pictureBoxTeacherPhoto;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelTeacherID;
		private System.Windows.Forms.TextBox textBoxTeacherId;
	}
}