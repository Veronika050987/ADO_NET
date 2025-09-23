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

namespace Academy_PD_411
{
	public partial class MainForm : Form
	{
		string connectionString = "Data Source=LAPTOP-4AUB2J6T\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Dictionary<string, int> d_groupDirection;
		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(connectionString);
			//LoadDirections();
			//LoadGroups();
			dataGridViewDirections.DataSource = Select("*", "Directions");
			dataGridViewGroups.DataSource = Select
				(
				"group_id,group_name,direction", "Groups,Directions", "direction=direction_id"
				);
			d_groupDirection = LoadDataToComboBox("*", "Directions");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxGroupsDirection.SelectedIndex = 0;
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
		void LoadDirections()
		{
			string cmd =
@"SELECT direction_id AS N'ID',direction_name AS N'Direction', COUNT(group_id) AS N'Groups number'
FROM Groups
RIGHT	JOIN Directions ON (direction=direction_id)
GROUP BY direction_id,direction_name
;";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while(reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewDirections.DataSource = table;
		}
	

		void LoadGroups()
		{
			string cmd = 
				@"SELECT 
group_id AS N'ID',group_name AS N'Group',COUNT(stud_id) AS N'Students number',direction_name AS N'Education direction'
FROM Students 
RIGHT	JOIN Groups		ON ([group]=group_id)
		JOIN Directions	ON (direction=direction_id)
GROUP BY group_id, group_name, direction, direction_name;";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewGroups.DataSource = table;
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
			dataGridViewGroups.DataSource = Select
			(
				"group_id,group_name,direction", 
				"Groups,Directions", 
				condition				
			);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadGroupsToComboBox();
		}

		private void LoadGroupsToComboBox()
		{
			DataTable groupsTable = Select("group_id, group_name", "Groups");
			comboBoxGroupsFilter.DataSource = groupsTable;
			comboBoxGroupsFilter.DisplayMember = "group_name";
			comboBoxGroupsFilter.ValueMember = "group_id";
			comboBoxGroupsFilter.SelectedIndex = -1; // чтобы ничего не было выбрано по умолчанию
		}

		private void comboBoxGroupsFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterStudentsByGroup();
		}

		private void FilterStudentsByGroup()
		{
			if (comboBoxGroupsFilter.SelectedValue == null)
			{
				dataGridViewGroups.DataSource = Select
				(
					"group_id,group_name,direction,direction_name",
					"Groups,Directions",
					"direction=direction_id"
				);
				return;
			}

			int selectedGroupId;

			if (comboBoxGroupsFilter.SelectedValue is int)
			{
				selectedGroupId = (int)comboBoxGroupsFilter.SelectedValue;
			}
			else
			{
				if (int.TryParse(comboBoxGroupsFilter.SelectedValue.ToString(), out selectedGroupId))
				{
					// Преобразование успешно
				}
				else
				{			
					return;
				}
			}

			// Сформируйте условие для фильтрации
			string condition = $"direction=direction_id AND group_id = {selectedGroupId}";

			// Выполните запрос с условием фильтрации
			dataGridViewGroups.DataSource = Select
			(
				"group_id,group_name,direction,direction_name",
				"Groups,Directions",
				condition
			);
		}
	}
}
