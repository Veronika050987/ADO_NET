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
		Dictionary<string, int> d_studentsGroup;
		Dictionary<string, int> d_disciplinesDirection;

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
				"group_id,group_name,learning_days,start_time,direction_name",
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
			
			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);

			d_groupDirection = LoadDataToDictionary("*", "Directions");
			d_studentsGroup = LoadDataToDictionary("*", "Groups");
			d_disciplinesDirection = LoadDataToDictionary("*", "Disciplines");

			FillComboBox(comboBoxGroupsDirection, d_groupDirection);
			FillComboBox(comboBoxStudentsDirection, d_groupDirection);

			FillComboBox(comboBoxStudentsGroup, d_studentsGroup);

			FillComboBox(comboBoxDirections, d_groupDirection);
			FillComboBox(comboBoxDisciplines, d_disciplinesDirection);

			//comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			//comboBoxStudentsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			//comboBoxStudentsGroup.Items.AddRange(d_studentsGroup.Keys.ToArray());
			comboBoxStudentsDirection.SelectedIndex = comboBoxGroupsDirection.SelectedIndex = 0;
			comboBoxStudentsGroup.SelectedIndex = 0;

			tabControl.SelectedIndex = 0;

			for (int i = 0; i < tabControl.TabCount; i++)
			{
				(this.Controls.Find($"dataGridView{tabControl.TabPages[i].Name.Remove(0, "tabPage".Length)}", true)[0] as DataGridView).RowsAdded
					+= new DataGridViewRowsAddedEventHandler(this.dataGridViewChanged);
			}

			dataGridViewGroups.CellDoubleClick += dataGridViewGroups_CellDoubleClick;
		}

		private void FillComboBox(ComboBox comboBox, Dictionary<string, int> data)
		{
			comboBox.Items.Clear();
			foreach (string key in data.Keys)
			{
				comboBox.Items.Add(key);
			}
		}

		private void dataGridViewGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				// Get the selected row
				DataGridViewRow row = dataGridViewGroups.Rows[e.RowIndex];

				// Extract group ID from the selected row (assuming group ID is in the first column)
				int groupId = Convert.ToInt32(row.Cells["group_id"].Value);

				// Open the group form for editing
				OpenGroupForm(groupId);
			}

		}

		void LoadTab(int i)
		{
			string tableName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
			DataGridView dataGridView = this.Controls.Find($"dataGridView{tableName}", true)[0] as DataGridView;
			dataGridView.DataSource = Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			
			if (i == 1) ConvertLearningDays();
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
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return table;
		}
		void ConvertLearningDays()
		{
			for(int i=0;i<dataGridViewGroups.RowCount;i++)
			{

				dataGridViewGroups.Rows[i].Cells["learning_days"].Value =
					new Week(Convert.ToByte(dataGridViewGroups.Rows[i].Cells["learning_days"].Value));
			}
		}

		Dictionary<string, int> LoadDataToDictionary(string fields, string tables, string condition = "")
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("All", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrWhiteSpace(condition))
				cmd += $" WHERE {condition}";
			
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
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
				condition += $" AND direction={d_groupDirection[comboBoxGroupsDirection.SelectedItem.ToString()]}";
			dataGridViewGroups.DataSource = Select
			(
				"group_id,group_name,direction",
				"Groups,Directions",
				condition
			);
		}
		[DllImport("kernel32.dll")]
		static extern void AllocConsole();

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadTab((sender as TabControl).SelectedIndex);
		}
		private void dataGridViewChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel.Text = $"{statusBarMessages[tabControl.SelectedIndex]}: {(sender as DataGridView).RowCount - 1}";
		}

		private void comboBoxStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = comboBoxStudentsDirection.SelectedItem.ToString() == "All" ? "" :
				$" direction={d_groupDirection[(sender as ComboBox).SelectedItem.ToString()]}";
			comboBoxStudentsGroup.Items.Clear();
			comboBoxStudentsGroup.Items.AddRange(LoadDataToDictionary("*", "Groups", condition).Keys.ToArray());
			dataGridViewStudents.DataSource = Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition + (string.IsNullOrEmpty(condition)? "" : $" AND {condition}")
				);
		}

		private void comboBoxStudentsGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition_group =
				comboBoxStudentsGroup.SelectedItem.ToString() == "All" ? "" :
				$"[group]={d_studentsGroup[comboBoxStudentsGroup.SelectedItem.ToString()]}";
			string condition_direction = comboBoxStudentsDirection.SelectedItem.ToString() == "All" ? "" :
				$" direction={d_groupDirection[comboBoxStudentsDirection.SelectedItem.ToString()]}";

			dataGridViewStudents.DataSource = Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition
					+ (string.IsNullOrWhiteSpace(condition_group) ? "" : $" AND {condition_group}")
					+ (string.IsNullOrWhiteSpace(condition_direction) ? "" :$" AND {condition_direction}")
				);
		}	

		private void buttonAddGroup_Click(object sender, EventArgs e)
		{
			OpenGroupForm(null);
		}

		private void OpenGroupForm(int? groupId)
		{
			GroupForm groupForm = new GroupForm(connectionString, d_groupDirection, groupId);
			groupForm.FormClosed += GroupForm_FormClosed;  // Subscribe to the FormClosed event
			groupForm.ShowDialog();
		}

		private void GroupForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if ((sender as GroupForm).DialogResult == DialogResult.OK)
				{
					// Обновляем DataGridView и ComboBox, только если данные были сохранены
					LoadTab(1);  // Предполагаем, что tabControl[1] - это Groups
					d_studentsGroup = LoadDataToDictionary("*", "Groups");
					FillComboBox(comboBoxStudentsGroup, d_studentsGroup);
				}
			}

		}

		private void comboBoxDirections_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = $"direction=direction_id";
			if (comboBoxDirections.SelectedIndex.ToString() != "All")
				condition += $" AND direction={d_groupDirection[(sender as ComboBox).SelectedItem.ToString()]}";
			comboBoxDirections.Items.Clear();
			comboBoxDirections.Items.AddRange(LoadDataToDictionary("*", "Disciplines", condition).Keys.ToArray());
			dataGridViewDisciplines.DataSource = Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition + (string.IsNullOrEmpty(condition) ? "" : $" AND {condition}")
				);
		}

		private void comboBoxDisciplines_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition_discipline =
			comboBoxDisciplines.SelectedItem.ToString() == "All" ? "" :
			$" discipline={d_disciplinesDirection[comboBoxDisciplines.SelectedItem.ToString()]}";
			string condition_direction = comboBoxDirections.SelectedItem.ToString() == "All" ? "" :
				$" direction={d_groupDirection[comboBoxDirections.SelectedItem.ToString()]}";

			dataGridViewDisciplines.DataSource = Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition
					+ (string.IsNullOrWhiteSpace(condition_discipline) ? "" : $" AND {condition_discipline}")
					+ (string.IsNullOrWhiteSpace(condition_direction) ? "" : $" AND {condition_direction}")
				);
		}
	}
}
