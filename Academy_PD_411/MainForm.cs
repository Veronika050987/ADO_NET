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
		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(connectionString);

			LoadAllTables();
		}

		void LoadAllTables()
		{
			string cmdStudents = "SELECT * FROM Students";
			DataTable studentsTable = LoadData(cmdStudents);
			dataGridViewStudents.DataSource = studentsTable;

			toolStripStatusLabelStudents.Text = "Total students: " + studentsTable.Rows.Count.ToString();

			string cmdGroups = "SELECT * FROM Groups";
			DataTable groupsTable = LoadData(cmdGroups);
			dataGridViewGroups.DataSource = groupsTable;

			toolStripStatusLabelGroups.Text = "Total groups: " + groupsTable.Rows.Count.ToString();

			string cmdDirections = "SELECT * FROM Directions";
			DataTable directionsTable = LoadData(cmdDirections);
			dataGridViewDirections.DataSource = directionsTable;

			toolStripStatusLabelDirections.Text = "Total directions: " + directionsTable.Rows.Count.ToString();

			string cmdDisciplines = "SELECT * FROM Disciplines";
			DataTable disciplinesTable = LoadData(cmdDisciplines);
			dataGridViewDisciplines.DataSource = disciplinesTable;

			toolStripStatusLabelDisciplines.Text = "Total disciplines: " + disciplinesTable.Rows.Count.ToString();

			string cmdTeachers = "SELECT * FROM Teachers";
			DataTable teachersTable = LoadData(cmdTeachers);
			dataGridViewTeachers.DataSource = teachersTable;

			toolStripStatusLabelTeachers.Text = "Total teachers: " + teachersTable.Rows.Count.ToString();

		}

		private DataTable LoadData(string commandText)
		{
			DataTable table = new DataTable();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(commandText, connection))
				{
					try
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{
								table.Columns.Add(reader.GetName(i));
							}

							while (reader.Read())
							{
								DataRow row = table.NewRow();
								for (int i = 0; i < reader.FieldCount; i++)
								{
									row[i] = reader[i];
								}
								table.Rows.Add(row);
							}
						}
					}
					catch (Exception ex)
					{						
						Console.WriteLine("Error loading data: " + ex.Message); 																				
					}
				}
			}
			return table;
		}

		private void dataGridViewDirections_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void tabPageStudents_Click(object sender, EventArgs e)
		{

		}

		private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void statusStripTeachers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void dataGridViewTeachers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		//void LoadDirections()
		//{
		//	string cmd = "SELECT * FROM Directions";
		//	SqlCommand command = new SqlCommand(cmd, connection);
		//	connection.Open();
		//	SqlDataReader reader = command.ExecuteReader();
		//	DataTable table = new DataTable();
		//	for (int i = 0; i < reader.FieldCount; i++)
		//		table.Columns.Add(reader.GetName(i));
		//	while(reader.Read())
		//	{
		//		DataRow row = table.NewRow();
		//		for (int i = 0; i < reader.FieldCount; i++)
		//			row[i] = reader[i];
		//		table.Rows.Add(row);
		//	}
		//	reader.Close();
		//	connection.Close();
		//	dataGridViewDirections.DataSource = table;
		//}


	}
}
