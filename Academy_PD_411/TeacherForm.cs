using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;

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

		public TeacherForm(short teacherId) :this()
		{
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id = {teacherId}");

				textBoxLastName.Text = teacher.Rows[0][1].ToString();
				textBoxFirstName.Text = teacher.Rows[0][2].ToString();
				textBoxMiddleName.Text = teacher.Rows[0][3].ToString();
				
				dateTimePickerBirthDate.Value = Convert.ToDateTime(teacher.Rows[0][4]);
				textBoxEmail.Text = teacher.Rows[0][5].ToString();
				textBoxPhone.Text = teacher.Rows[0][6].ToString();

				textBoxTeacherId.Text = teacher.Rows[0][0].ToString();

			try
			{
				pictureBoxTeacherPhoto.Image = connector.DownLoadPhoto(teacherId, "Teachers", "photo");
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void InitForm()
		{
			textBoxLastName.Text = "Амелькин";
			textBoxFirstName.Text = "Кирилл";
			textBoxMiddleName.Text = "Вадимович";
			dateTimePickerBirthDate.Value = new DateTime(1967, 02, 04);
			textBoxEmail.Text = "kirill@gmail.com";
			textBoxPhone.Text = "+7(152)457-11-20";
			textBoxTeacherId.Text = new Random().Next(1, 32767).ToString();
		}

		//void Compress()
		//{
		//	Teacher.LastName = textBoxLastName.Text;
		//	Teacher.FirstName = textBoxFirstName.Text;
		//	Teacher.MiddleName = textBoxMiddleName.Text;
		//	Teacher.Email = textBoxEmail.Text;
		//	Teacher.Phone = textBoxPhone.Text;
		//}
		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (!short.TryParse(textBoxTeacherId.Text, out short teacherIdValue))
			{
				MessageBox.Show("Invalid Teacher ID format. Please enter a number in range from -32768 to 32767.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Teacher = new Teacher
			(
				textBoxLastName.Text,
				textBoxFirstName.Text,
				textBoxMiddleName.Text,
				dateTimePickerBirthDate.Text,
				textBoxEmail.Text,
				textBoxPhone.Text,
				teacherIdValue,
				pictureBoxTeacherPhoto.Image
			);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter =
				"JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pictureBoxTeacherPhoto.Image = Image.FromFile(dialog.FileName);
			}
		}
	}
}
