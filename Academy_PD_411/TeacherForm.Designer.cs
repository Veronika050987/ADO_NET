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
			this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelLastName = new System.Windows.Forms.Label();
			this.labelID = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonBrowsePhoto = new System.Windows.Forms.Button();
			this.comboBoxGroup = new System.Windows.Forms.ComboBox();
			this.labelGroup = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxPhoto
			// 
			this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPhoto.Location = new System.Drawing.Point(483, 3);
			this.pictureBoxPhoto.Name = "pictureBoxPhoto";
			this.pictureBoxPhoto.Size = new System.Drawing.Size(245, 285);
			this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPhoto.TabIndex = 61;
			this.pictureBoxPhoto.TabStop = false;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(223, 222);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(216, 22);
			this.textBoxPhone.TabIndex = 60;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(223, 178);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(216, 22);
			this.textBoxEmail.TabIndex = 59;
			// 
			// dateTimePickerBirthDate
			// 
			this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerBirthDate.Location = new System.Drawing.Point(223, 134);
			this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
			this.dateTimePickerBirthDate.Size = new System.Drawing.Size(216, 22);
			this.dateTimePickerBirthDate.TabIndex = 58;
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.Location = new System.Drawing.Point(223, 90);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(216, 22);
			this.textBoxMiddleName.TabIndex = 57;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(223, 46);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(216, 22);
			this.textBoxFirstName.TabIndex = 56;
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(223, 2);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(216, 22);
			this.textBoxLastName.TabIndex = 55;
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(140, 225);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(70, 16);
			this.labelPhone.TabIndex = 54;
			this.labelPhone.Text = "Телефон:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(166, 181);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(44, 16);
			this.labelEmail.TabIndex = 53;
			this.labelEmail.Text = "Email:";
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Location = new System.Drawing.Point(101, 137);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(109, 16);
			this.labelBirthDate.TabIndex = 52;
			this.labelBirthDate.Text = "Дата рождения:";
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Location = new System.Drawing.Point(137, 93);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(73, 16);
			this.labelMiddleName.TabIndex = 51;
			this.labelMiddleName.Text = "Отчество:";
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(174, 49);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(36, 16);
			this.labelFirstName.TabIndex = 50;
			this.labelFirstName.Text = "Имя:";
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(141, 5);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(69, 16);
			this.labelLastName.TabIndex = 49;
			this.labelLastName.Text = "Фамилия:";
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelID.Location = new System.Drawing.Point(71, 427);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(31, 25);
			this.labelID.TabIndex = 48;
			this.labelID.Text = "ID";
			this.labelID.Visible = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(649, 421);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 47;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(479, 421);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 46;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonBrowsePhoto
			// 
			this.buttonBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.buttonBrowsePhoto.Location = new System.Drawing.Point(309, 421);
			this.buttonBrowsePhoto.Name = "buttonBrowsePhoto";
			this.buttonBrowsePhoto.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowsePhoto.TabIndex = 45;
			this.buttonBrowsePhoto.Text = "Обзор";
			this.buttonBrowsePhoto.UseVisualStyleBackColor = false;
			this.buttonBrowsePhoto.Click += new System.EventHandler(this.buttonBrowsePhoto_Click);
			// 
			// comboBoxGroup
			// 
			this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroup.FormattingEnabled = true;
			this.comboBoxGroup.Location = new System.Drawing.Point(223, 380);
			this.comboBoxGroup.Name = "comboBoxGroup";
			this.comboBoxGroup.Size = new System.Drawing.Size(216, 24);
			this.comboBoxGroup.TabIndex = 44;
			// 
			// labelGroup
			// 
			this.labelGroup.AutoSize = true;
			this.labelGroup.Location = new System.Drawing.Point(146, 383);
			this.labelGroup.Name = "labelGroup";
			this.labelGroup.Size = new System.Drawing.Size(57, 16);
			this.labelGroup.TabIndex = 43;
			this.labelGroup.Text = "Группа:";
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBoxPhoto);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.dateTimePickerBirthDate);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.labelLastName);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowsePhoto);
			this.Controls.Add(this.comboBoxGroup);
			this.Controls.Add(this.labelGroup);
			this.Name = "TeacherForm";
			this.Text = "TeacherForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxPhoto;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.Label labelID;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonBrowsePhoto;
		private System.Windows.Forms.ComboBox comboBoxGroup;
		private System.Windows.Forms.Label labelGroup;
	}
}