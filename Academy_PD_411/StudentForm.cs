using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//#define COMPRESS;

namespace Academy_PD_411
{
	public partial class StudentForm : Form
	{
		internal Student Student { get; set; }
		Connector connector;
		//private byte[] selectedPhotoBytes = null;
		public StudentForm()
		{
			InitializeComponent();
			connector = new Connector();
			DataTable groups = connector.Select("*", "Groups");
			comboBoxGroup.DataSource = groups;
			comboBoxGroup.DisplayMember = "group_name";
			comboBoxGroup.ValueMember = "group_id";
		}
#if COMPRESS
		void Compress()
		{
			Student.LastName = textBoxLastName.Text;
			Student.FirstName = textBoxFirstName.Text;
			Student.MiddleName = textBoxMiddleName.Text;
			Student.Email = textBoxEmail.Text;
			Student.Phone = textBoxPhone.Text;
			Student.Group = Convert.ToInt32(comboBoxGroup.SelectedValue);
		}

#endif
		//private void buttonBrowsePhoto_Click(object sender, EventArgs e)
		//{
		//	OpenFileDialog openFileDialog = new OpenFileDialog();
		//	openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
		//	if (openFileDialog.ShowDialog() == DialogResult.OK)
		//	{
		//		try
		//		{
		//			// Read the image file into a byte array
		//			selectedPhotoBytes = File.ReadAllBytes(openFileDialog.FileName);

		//			// Display the image in the PictureBox
		//			using (MemoryStream ms = new MemoryStream(selectedPhotoBytes))
		//			{
		//				pictureBoxPhoto.Image = Image.FromStream(ms);
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//			selectedPhotoBytes = null;
		//			pictureBoxPhoto.Image = null;
		//		}
		//	}
		//}
		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
			   string.IsNullOrWhiteSpace(textBoxFirstName.Text))
			{
				MessageBox.Show("Last Name and First Name are required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				Student = new Student
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirthDate.Value.ToString("yyyyMMdd"),
					textBoxEmail.Text,
					textBoxPhone.Text,
					Convert.ToInt32(comboBoxGroup.SelectedValue)
				);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error creating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
	}
}
