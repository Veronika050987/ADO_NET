using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
