using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Academy_PD_411
{
	public partial class TeacherForm : Form
	{
		internal Teacher Teacher { get; set; }
		Connector connector;
		public TeacherForm()
		{
			InitializeComponent();
			connector = new Connector();

			InitForm();
		}
		public TeacherForm(int teacher_id) : this()
		{
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id={teacher_id}");

			textBoxLastName.Text = teacher.Rows[0][1].ToString();
			textBoxFirstName.Text = teacher.Rows[0][2].ToString();
			textBoxMiddleName.Text = teacher.Rows[0][3].ToString();

			dateTimePickerBirthDate.Value = Convert.ToDateTime(teacher.Rows[0][4]);
			textBoxEmail.Text = teacher.Rows[0][5].ToString();
			textBoxPhone.Text = teacher.Rows[0][6].ToString();
			labelID.Visible = true;
			labelID.Text = $"ID: {teacher.Rows[0][0].ToString()}";

			try
			{
				pictureBoxPhoto.Image = connector.DownLoadPhoto(teacher_id, "Teachers", "photo");
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		void InitForm()
		{
			textBoxLastName.Text = "Ковтун";
			textBoxFirstName.Text = "Олег";
			textBoxMiddleName.Text = "Анатольевич";
			dateTimePickerBirthDate.Value = new DateTime(1985, 01, 16);
			textBoxEmail.Text = "olezhek@gmail.com";
			textBoxPhone.Text = "+7(253)406-71-78";
		}
		void Compress()
		{
			Teacher.LastName = textBoxLastName.Text;
			Teacher.FirstName = textBoxFirstName.Text;
			Teacher.MiddleName = textBoxMiddleName.Text;
			Teacher.Email = textBoxEmail.Text;
			Teacher.Phone = textBoxPhone.Text;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Teacher = new Teacher
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirthDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					pictureBoxPhoto.Image
				);
		}

		private void buttonBrowsePhoto_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter =
				"JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pictureBoxPhoto.Image = Image.FromFile(dialog.FileName);
			}

		}
	}
}
