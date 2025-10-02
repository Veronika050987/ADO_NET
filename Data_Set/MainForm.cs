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

namespace Data_Set
{
	public partial class MainForm : Form
	{
		private Cache dataCache;
		public MainForm()
		{
			InitializeComponent();

			try
			{
				dataCache = new Cache("PD_321");

				dataCache.AddTable("Directions", "SELECT * FROM Directions", new string[] { "direction_id" });
				dataCache.AddTable("Groups", "SELECT * FROM Groups", new string[] { "group_id" });

				dataCache.LoadData();

				PopulateComboBoxes();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error initializing MainForm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PopulateComboBoxes()
		{
			try
			{
				DataTable directionsTable = dataCache.GetTable("Directions");
				DataTable groupsTable = dataCache.GetTable("Groups");

				// Add "All Directions" Row
				DataRow allDirectionsRow = directionsTable.NewRow();

				// Use DBNull.Value if direction_id is a byte.  Int32 otherwise.
				if (directionsTable.Columns["direction_id"].DataType == typeof(byte) || directionsTable.Columns["direction_id"].DataType == typeof(Int16))
				{
					allDirectionsRow["direction_id"] = DBNull.Value;
				}
				else
				{
					allDirectionsRow["direction_id"] = -1;
				}

				allDirectionsRow["direction_name"] = "Все направления";
				directionsTable.Rows.InsertAt(allDirectionsRow, 0);

				DataRow allGroupsRow = groupsTable.NewRow();
				allGroupsRow["group_id"] = -1;
				allGroupsRow["group_name"] = "Все группы";

				if (groupsTable.Columns.Contains("direction"))
				{
					// Set 'direction' to DBNull if it's a byte or smallint, otherwise leave it as -1 (int)
					if (groupsTable.Columns["direction"].DataType == typeof(byte) || groupsTable.Columns["direction"].DataType == typeof(Int16))
					{
						allGroupsRow["direction"] = DBNull.Value;
					}
					else
					{
						allGroupsRow["direction"] = -1; //  Use -1 if the column type is Int32 (int)
					}
				}
				else
				{
					MessageBox.Show("Column 'direction' not found in Groups table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				allGroupsRow["learning_days"] = "";
				allGroupsRow["start_time"] = "";
				groupsTable.Rows.InsertAt(allGroupsRow, 0);

				comboBoxStudentsDirection.DataSource = directionsTable;
				comboBoxStudentsDirection.DisplayMember = "direction_name";
				comboBoxStudentsDirection.ValueMember = "direction_id";

				comboBoxStudentsGroup.DataSource = groupsTable;
				comboBoxStudentsGroup.DisplayMember = "group_name";
				comboBoxStudentsGroup.ValueMember = "group_id";

				// Always show all groups, regardless of the selected direction (as per your request)
				comboBoxStudentsGroup.DataSource = dataCache.GetTable("Groups");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error populating ComboBoxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void comboBoxStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		private void GetKeyValue(object sender, EventArgs e)
		{
			Console.WriteLine($"{(sender as ComboBox).Name}:\t{(sender as ComboBox).SelectedValue}");
		}
	}
}
