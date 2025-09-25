using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Academy_PD_411
{
	public partial class MainForm : Form
	{
		string connectionString = "Data Source=LAPTOP-4AUB2J6T\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Dictionary<string, int> d_groupDirection;
		DataTable directionsTable; // Добавляем поле для хранения данных о направлениях

		Query[] queries = new Query[]
		{
			new Query
			(
"stud_id,FORMATMESSAGE(N'%s %s %s',last_name,first_name,middle_name) AS N'Student', group_name AS N'Group',direction_name AS N'Direction'",
"Students,Groups,Directions",
"[group]=group_id AND direction=direction_id"
			),
			new Query
			(
				"group_id,group_name,direction_name",
				"Groups,Directions",
				"direction=direction_id"
			),
			new Query("*", "Directions"),
			new Query("*", "Disciplines"),
			new Query("*", "Teachers")
		};

		readonly string[] statusBarMessages = new string[]
		{
			"Students number ",
			"Groups number ",
			"Directions number ",
			"Disciplines number ",
			"Teachers number "
		};
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();			
			connection = new SqlConnection(connectionString);
			//LoadDirections();
			//LoadGroups();
			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);

			d_groupDirection = LoadDataToComboBox("*", "Directions");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxGroupsDirection.SelectedIndex = 0;

			tabControl.SelectedIndex = 1;

			LoadTab(tabControl.SelectedIndex);

			comboBoxGroupsDirection.SelectedIndexChanged += comboBoxGroupsDirection_SelectedIndexChanged;

			// Добавляем кнопки для добавления и редактирования
			Button addButton = new Button();
			addButton.Text = "Add group";
			addButton.Click += AddButton_Click;
			tabPageGroups.Controls.Add(addButton);

			Button editButton = new Button();
			editButton.Text = "Edit group";
			editButton.Click += EditButton_Click;
			tabPageGroups.Controls.Add(editButton);
			editButton.Location = new Point(addButton.Location.X, addButton.Location.Y + addButton.Height + 10);

			directionsTable = Select("*", "Directions");

			//for(int i = 0;i < tabControl.TabCount;i++)
			//{
			//	(this.Controls.Find($"dataGridView{tabControl.TabPages[i].Name.Remove(0, "tabPage".Length)}", true) [0] as DataGridView).RowsAdded 
			//		+= new DataGridViewRowsAddedEventHandler(this.dataGridViewChanged);
			//}
		}

		public DataTable GetDirectionsDataSource()
		{
			return directionsTable.Copy(); // Возвращаем копию, чтобы избежать случайных изменений
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			GroupForm groupForm = new GroupForm();
			groupForm.Owner = this; // Устанавливаем MainForm как Owner, чтобы GroupForm мог получить доступ к данным направлений
			DialogResult result = groupForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				// Получаем данные из формы
				string groupName = groupForm.GroupName;
				int directionId = groupForm.DirectionId;

				// Выполняем добавление в базу данных (пример)
				string insertQuery = "INSERT INTO Groups (group_name, direction) VALUES (@group_name, @direction)";
				try
				{
					using (SqlCommand command = new SqlCommand(insertQuery, connection))
					{
						command.Parameters.AddWithValue("@group_name", groupName);
						command.Parameters.AddWithValue("@direction", directionId);

						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error during group addition: {ex.Message}");
					return; // Прерываем дальнейшее выполнение при ошибке
				}

				// Обновляем DataGridView
				LoadTab(tabControl.SelectedIndex);
			}
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			// Проверяем, выбрана ли строка в DataGridView
			if (dataGridViewGroups.SelectedRows.Count > 0)
			{
				// Получаем данные из выбранной строки
				DataGridViewRow selectedRow = dataGridViewGroups.SelectedRows[0];
				int groupId = Convert.ToInt32(selectedRow.Cells["group_id"].Value);
				string groupName = selectedRow.Cells["group_name"].Value.ToString();
				int directionId = Convert.ToInt32(selectedRow.Cells["direction"].Value); // или direction_id в зависимости от структуры DataGridView

				// Создаем и отображаем форму редактирования
				GroupForm groupForm = new GroupForm(groupId, groupName, directionId);
				groupForm.Owner = this;
				DialogResult result = groupForm.ShowDialog();

				if (result == DialogResult.OK)
				{
					// Получаем данные из формы
					string newGroupName = groupForm.GroupName;
					int newDirectionId = groupForm.DirectionId;

					// Выполняем обновление в базе данных (пример)
					string updateQuery = "UPDATE Groups SET group_name = @group_name, direction = @direction WHERE group_id = @group_id";
					using (SqlCommand command = new SqlCommand(updateQuery, connection))
					{
						command.Parameters.AddWithValue("@group_name", newGroupName);
						command.Parameters.AddWithValue("@direction", newDirectionId);
						command.Parameters.AddWithValue("@group_id", groupId);

						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}

					// Обновляем DataGridView
					LoadTab(tabControl.SelectedIndex);
				}
			}
			else
			{
				MessageBox.Show("Please, choose a group for addition: ");
			}
		}

		void LoadTab(int i)
		{
			string tableName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
			DataGridView dataGridView = this.Controls.Find($"dataGridView{tableName}", true)[0] as DataGridView;
			dataGridView.DataSource = Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			
			UpdateStatusBar(i, dataGridView.RowCount);
			//toolStripStatusLabel.Text = $"{statusBarMessages[i]}: {dataGridView.RowCount - 1}";
		}

		void UpdateStatusBar(int tabIndex, int rowCount)
		{
			toolStripStatusLabel.Text = $"{statusBarMessages[tabIndex]}: {rowCount}";
		}
		void FillStatusBar(int i)
		{

		}

		DataTable Select(string fields, string tables, string condition = "")
		{
			DataTable table = new DataTable();
			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrWhiteSpace(condition)) cmd += $" WHERE {condition}";
			cmd += ";";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while(reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return table;
		}

		Dictionary<string,int> LoadDataToComboBox(string fields, string tables)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("All", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while(reader.Read())
			{
				//comboBoxGroupsDirection.Items.Add(reader[1]);
				dictionary.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
			}
			reader.Close();
			connection.Close();
			return dictionary;
		}

		private void comboBoxGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = $"direction=direction_id";
			if (comboBoxGroupsDirection.SelectedIndex.ToString() != "All") 
				condition +=$" AND direction={d_groupDirection[comboBoxGroupsDirection.SelectedItem.ToString()]}";
			//dataGridViewGroups.DataSource = Select
			DataTable data = Select
			(
				"group_id,group_name,direction", 
				"Groups,Directions", 
				condition				
			);
			dataGridViewGroups.DataSource = data;

			// Обновляем строку состояния на основе количества строк в dataGridViewGroups.
			UpdateStatusBar(tabControl.SelectedIndex, dataGridViewGroups.RowCount);
		}
		[DllImport("kernel32.dll")]
		static extern void AllocConsole();

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = (sender as TabControl).SelectedIndex;
			LoadTab((sender as TabControl).SelectedIndex);
		}
		//private void dataGridViewChanged(object sender, EventArgs e)
		//{
		//	toolStripStatusLabel.Text = $"{statusBarMessages[tabControl.SelectedIndex]}: {(sender as DataGridView).RowCount - 1}";
		//}
	}
}
