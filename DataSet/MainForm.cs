using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Data.SqlClient;
using System.Configuration;

namespace DataSet
{
	public partial class MainForm : Form
	{
		string connectionString = "";
		SqlConnection connection = null;
		System.Data.DataSet GroupsRelatedData = null;
		public MainForm()
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);

			LoadGroupsRelatedData();

			comboBoxGroups.DataSource = GroupsRelatedData.Tables["Groups"];
			comboBoxGroups.DisplayMember = "group_name";
			comboBoxGroups.ValueMember = "group_id";
			comboBoxGroups.SelectedIndex = -1;

			comboBoxDirections.DataSource = GroupsRelatedData.Tables["Directions"];
			comboBoxDirections.DisplayMember = "direction_name";
			comboBoxDirections.ValueMember = "direction_id";
			comboBoxDirections.AccessibleDefaultActionDescription = "All directions";
			comboBoxDirections.SelectedIndex = -1;
		}

		void LoadGroupsRelatedData()
		{
			//1) DataSet creation
			GroupsRelatedData = new System.Data.DataSet(nameof(GroupsRelatedData));

			//2) Add tables into DataSet
			const string dsTable_Directions = "Directions";
			const string dstDirections_col_direction_id = "direction_id";
			const string dstDirections_col_direction_name = "direction_name";
			GroupsRelatedData.Tables.Add(dsTable_Directions);
			//add champs into table
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dstDirections_col_direction_id);
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dstDirections_col_direction_name);
			//primarykey choice from champs
			GroupsRelatedData.Tables[dsTable_Directions].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Directions].Columns[dstDirections_col_direction_id] };

			const string dsTable_Groups = "Groups";
			const string dstGroups_col_group_id = "group_id";
			const string dstGroups_col_group_name = "group_name";
			const string dstGroups_col_direction = "direction";
			const string dstGroups_col_learning_days = "learning_days";
			const string dstGroups_col_start_time = "start_time";
			GroupsRelatedData.Tables.Add(dsTable_Groups);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dstGroups_col_group_id);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dstGroups_col_group_name);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dstGroups_col_direction);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dstGroups_col_learning_days);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dstGroups_col_start_time);
			GroupsRelatedData.Tables[dsTable_Groups].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Groups].Columns[dstGroups_col_group_id] };

			//3) Relations between tables
			string dsRelation_Groups_Directions = "GroupsDirections";
			GroupsRelatedData.Relations.Add
				(
				dsRelation_Groups_Directions,
				GroupsRelatedData.Tables[dsTable_Directions].Columns[dstDirections_col_direction_id],//parent field = primary key
				GroupsRelatedData.Tables[dsTable_Groups].Columns[dstGroups_col_direction]//child field = foreign key
				);
			//4) Add data into table
			string directions_cmd = "SELECT * FROM Directions";
			string groups_cmd = "SELECT * FROM Groups";

			SqlDataAdapter directionsAdapter = new SqlDataAdapter(directions_cmd, connection);
			SqlDataAdapter groupsAdapter = new SqlDataAdapter(groups_cmd, connection);

			directionsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Directions]);
			groupsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Groups]);

			AllocConsole();
			foreach (DataRow row in GroupsRelatedData.Tables[dsTable_Directions].Rows)
			{
				Console.WriteLine($"{row[dstDirections_col_direction_id]}\t{row[dstDirections_col_direction_name]}");
			}
			Console.WriteLine("\n==================\n");
	
			DataRow[] RPO = GroupsRelatedData.Tables[dsTable_Directions].Rows[0].GetChildRows(dsRelation_Groups_Directions);
			for (int i=0; i < RPO.Length;i++)
			{
				for(int j = 0; j < RPO[i].ItemArray.Length;j++)
				{
					Console.Write($"RPO{RPO[i].ItemArray[j]}\t\t");
				}
				Console.WriteLine();
			}
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		private void comboBoxDirections_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			object selectedValue = (sender as ComboBox).SelectedValue;
			if (selectedValue?.ToString() != selectedValue?.GetType().ToString())
			{
				string filter = $"direction = {selectedValue.ToString()}";
				Console.WriteLine(filter);
				GroupsRelatedData.Tables["Groups"].DefaultView.RowFilter = filter;
			}
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			GroupsRelatedData.Tables["Groups"].DefaultView.RowFilter = "";
			comboBoxDirections.SelectedIndex = -1;
			comboBoxGroups.SelectedIndex = -1;
		}
	}
}
