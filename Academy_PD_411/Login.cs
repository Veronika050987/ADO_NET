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

		private const string DefaultUsername = "user2";
		private const string DefaultPassword = "222";

		public Login()
		{
			InitializeComponent();

			if (textBoxUserName != null && textBoxPassword != null)
			{
				textBoxUserName.Text = DefaultUsername;
				textBoxPassword.Text = DefaultPassword;
			}
			else
			{
				// Обработка ошибки, если элементы не найдены
				Console.WriteLine("ВНИМАНИЕ: Не найдены элементы textBoxUserName или textBoxPassword в форме Login!");
				MessageBox.Show("Ошибка: Не найдены элементы ввода логина/пароля.  Обратитесь к разработчику.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.DialogResult = DialogResult.Cancel;  // Отменяем открытие основной формы
				this.Close();
			}
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string user_name = textBoxUserName.Text;
			string password = textBoxPassword.Text;

			if (ValidateUser(user_name, password))
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private bool ValidateUser(string user_name, string password)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();

					string query = "SELECT COUNT(*) FROM Users WHERE user_name = @user_name AND password = @password";
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@user_name", user_name);
					command.Parameters.AddWithValue("@password", password);

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
