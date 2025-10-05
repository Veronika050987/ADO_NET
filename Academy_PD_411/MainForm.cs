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
using System.Configuration;

namespace Academy_PD_411
{
	public partial class MainForm : Form
	{
		string connectionString = "Data Source=LAPTOP-4AUB2J6T\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Dictionary<string, int> d_groupDirection;
		Dictionary<string, int> d_studentsGroup;

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

		private List<CheckedListBox> columnSelectionLists = new List<CheckedListBox>();
		private List<Button> showColumnButtons = new List<Button>();


		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			Console.WriteLine(connectionString);
			connection = new SqlConnection(connectionString);
			//LoadDirections();
			//LoadGroups();
			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);

			d_groupDirection = LoadDataToDictionary("*", "Directions");
			d_studentsGroup = LoadDataToDictionary("*", "Groups");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsGroup.Items.AddRange(d_studentsGroup.Keys.ToArray());
			comboBoxStudentsDirection.SelectedIndex = comboBoxGroupsDirection.SelectedIndex = 0;
			comboBoxStudentsGroup.SelectedIndex = 0;

			tabControl.SelectedIndex = 0;

			for (int i = 0; i < tabControl.TabCount; i++)
			{
				string tabPageName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
				DataGridView dataGridView = (DataGridView)this.Controls.Find($"dataGridView{tabPageName}", true)[0];

				dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridViewChanged);

				CheckedListBox columnSelectionList = new CheckedListBox();
				columnSelectionList.CheckOnClick = true;
				columnSelectionList.Visible = false;
				columnSelectionList.Tag = tabPageName;
				columnSelectionList.ItemCheck += ColumnSelectionList_ItemCheck;
				this.Controls.Add(columnSelectionList);
				columnSelectionLists.Add(columnSelectionList);

				Button showColumnsButton = new Button();
				showColumnsButton.Text = "Show/Hide Columns";
				showColumnsButton.Tag = tabPageName;
				showColumnsButton.Click += ShowColumnsButton_Click;
				showColumnsButton.Location = new Point(10, 10);

				showColumnsButton.BackColor = Color.LightBlue;
				showColumnsButton.ForeColor = Color.DarkBlue;
				showColumnsButton.FlatStyle = FlatStyle.Flat;
				showColumnsButton.FlatAppearance.BorderSize = 0;
				showColumnsButton.Font = new Font("Segoe UI", 7, FontStyle.Bold);

				tabControl.TabPages[i].Controls.Add(showColumnsButton);
				showColumnButtons.Add(showColumnsButton);
			}
		}

		void LoadTab(int i)
		{
			string tableName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
			DataGridView dataGridView = this.Controls.Find($"dataGridView{tableName}", true)[0] as DataGridView;
			DataTable dataTable = Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			dataGridView.DataSource = dataTable;

			AutoSizeColumns(dataGridView);

			if (i == 1) ConvertLearningDays();

			CheckedListBox columnSelectionList = columnSelectionLists[i];
			columnSelectionList.Items.Clear();
			foreach (DataColumn column in dataTable.Columns)
			{
				columnSelectionList.Items.Add(column.ColumnName, true);
			}

			Point dataGridViewLocation = dataGridView.Location;

			int yOffset = -columnSelectionList.Height - 5;

			columnSelectionList.Location = new Point(dataGridViewLocation.X, dataGridViewLocation.Y + yOffset);

		}

		private void AutoSizeColumns(DataGridView dataGridView)
		{
			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

			foreach (DataGridViewColumn column in dataGridView.Columns)
			{
				if (column.HeaderCell != null)
				{
					column.Width = Math.Max(column.Width, column.HeaderCell.Size.Width + 5);
				}
			}
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
		void Insert(string table, string fields, string values)
		{
			string cmd = $"INSERT {table}({fields}) VALUES ({values})";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		void ConvertLearningDays()
		{
			for (int i = 0; i < dataGridViewGroups.RowCount; i++)
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
					queries[0].Condition + (string.IsNullOrEmpty(condition) ? "" : $" AND {condition}")
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
					+ (string.IsNullOrWhiteSpace(condition_direction) ? "" : $" AND {condition_direction}")
				);
		}

		private void buttonAddStudent_Click(object sender, EventArgs e)
		{
			StudentForm student = new StudentForm();
			DialogResult result = student.ShowDialog();
			if (result == DialogResult.OK)
			{
				//Делаем INSERT в базу
				Insert
					(
					"Students",
					"last_name, first-name, middle_name, birth_date, email, phone, [group]",
					student.Student.ToString()
					);
			}
		}

		private void ColumnSelectionList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			CheckedListBox checkedListBox = (CheckedListBox)sender;
			string dataGridViewName = (string)checkedListBox.Tag;
			DataGridView dataGridView = (DataGridView)this.Controls.Find($"dataGridView{dataGridViewName}", true)[0];

			string columnName = checkedListBox.Items[e.Index].ToString();
			dataGridView.Columns[columnName].Visible = (e.NewValue == CheckState.Checked);
			AutoSizeColumns(dataGridView); // Re-adjust column widths after visibility changes
		}

		private void ShowColumnsButton_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string dataGridViewName = (string)button.Tag;
			DataGridView dataGridView = (DataGridView)this.Controls.Find($"dataGridView{dataGridViewName}", true)[0];

			CheckedListBox currentList = columnSelectionLists.FirstOrDefault(clb => (string)clb.Tag == dataGridViewName);
			if (currentList != null)
			{
				currentList.Visible = !currentList.Visible;

				Point dataGridViewLocation = dataGridView.Location;
				int yOffset = -currentList.Height;
				currentList.Location = new Point(dataGridViewLocation.X, dataGridViewLocation.Y + yOffset);

				AutoSizeColumns(dataGridView); // Re-adjust column widths after showing/hiding list
			}
		}
	}
}
