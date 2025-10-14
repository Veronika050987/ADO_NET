using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy_PD_411
{
	public partial class Login : Form
	{
		public string connectionString = "Data Source=LAPTOP-4AUB2J6T\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public Login()
		{
			InitializeComponent();
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string username = textBoxUserName.Text;
			string password = textBoxPassword.Text;

			if (ValidateUser(username, password))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private bool ValidateUser(string username, string password)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@Username", username);
					command.Parameters.AddWithValue("@Password", password);

					int userCount = (int)command.ExecuteScalar();

					return userCount > 0;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false; 
				}
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
