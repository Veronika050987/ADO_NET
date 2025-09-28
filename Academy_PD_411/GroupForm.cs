using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Academy_PD_411
{
	public partial class GroupForm : Form
	{
		private TextBox textBoxGroupName;
		private Label labelDirection;
		private ComboBox comboBoxDirection;
		private Button buttonSave;
		private Button buttonCancel;
		private Label labelGroupName;

		private string connectionString;
		private Dictionary<string, int> groupDirections;
		private int? groupId;

		public GroupForm(string connectionString, Dictionary<string, int> groupDirections, int? groupId = null)
		{
			InitializeComponent();
			this.connectionString = connectionString;
			this.groupDirections = groupDirections;
			this.groupId = groupId;

			// Заполнение ComboBox направлениями (НЕПОСРЕДСТВЕННО ИЗ СЛОВАРЯ)
			comboBoxDirection.Items.Clear();
			foreach (string directionName in groupDirections.Keys)
			{
				comboBoxDirection.Items.Add(directionName);
			}

			if (groupId.HasValue)
			{
				LoadGroupData(groupId.Value);
			}
			else
			{
				textBoxGroupName.Focus();
			}
		}

		private void LoadGroupData(int groupId)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT group_name, direction FROM Groups WHERE group_id = @groupId";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@groupId", groupId);

				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						textBoxGroupName.Text = reader["group_name"].ToString();
						int directionId = Convert.ToInt32(reader["direction"]);

						// Найдите направление в словаре по ID
						string directionName = groupDirections.FirstOrDefault(x => x.Value == directionId).Key;

						comboBoxDirection.SelectedItem = directionName;
					}
				}
			}
		}

		private void InitializeComponent()
		{
			this.labelGroupName = new System.Windows.Forms.Label();
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.labelDirection = new System.Windows.Forms.Label();
			this.comboBoxDirection = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
		
			this.labelGroupName.AutoSize = true;
			this.labelGroupName.Location = new System.Drawing.Point(25, 13);
			this.labelGroupName.Name = "labelGroupName";
			this.labelGroupName.Size = new System.Drawing.Size(84, 16);
			this.labelGroupName.TabIndex = 0;
			this.labelGroupName.Text = "Group name:";
			
			this.textBoxGroupName.Location = new System.Drawing.Point(133, 13);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(100, 22);
			this.textBoxGroupName.TabIndex = 1;
		
			this.labelDirection.AutoSize = true;
			this.labelDirection.Location = new System.Drawing.Point(28, 56);
			this.labelDirection.Name = "labelDirection";
			this.labelDirection.Size = new System.Drawing.Size(63, 16);
			this.labelDirection.TabIndex = 2;
			this.labelDirection.Text = "Direction:";
			
			this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDirection.FormattingEnabled = true;
			this.comboBoxDirection.Location = new System.Drawing.Point(133, 56);
			this.comboBoxDirection.Name = "comboBoxDirection";
			this.comboBoxDirection.Size = new System.Drawing.Size(336, 24);
			this.comboBoxDirection.TabIndex = 3;
		
			this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.buttonSave.Location = new System.Drawing.Point(31, 166);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.buttonCancel.Location = new System.Drawing.Point(394, 166);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			
			this.ClientSize = new System.Drawing.Size(517, 253);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxDirection);
			this.Controls.Add(this.labelDirection);
			this.Controls.Add(this.textBoxGroupName);
			this.Controls.Add(this.labelGroupName);
			this.Name = "GroupForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(textBoxGroupName.Text))
				{
					MessageBox.Show("Пожалуйста, введите название группы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					textBoxGroupName.Focus();
					return;
				}

				if (comboBoxDirection.SelectedItem == null)
				{
					MessageBox.Show("Пожалуйста, выберите направление.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					comboBoxDirection.Focus();
					return;
				}

				// Нормализация и обрезка строки
				string selectedDirection = comboBoxDirection.SelectedItem.ToString().Trim().Normalize();

				// Проверка наличия ключа в словаре
				if (!groupDirections.ContainsKey(selectedDirection))
				{
					MessageBox.Show($"Направление '{selectedDirection}' не найдено в словаре.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return; // Прекратить выполнение, если направление не найдено
				}

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query;
					if (groupId.HasValue)
					{
						query = "UPDATE Groups SET group_name = @groupName, direction = @direction WHERE group_id = @groupId";
					}
					else
					{
						query = "INSERT INTO Groups (group_name, direction) VALUES (@groupName, @direction)";
					}

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@groupName", textBoxGroupName.Text);
					command.Parameters.AddWithValue("@direction", groupDirections[selectedDirection]);

					if (groupId.HasValue)
					{
						command.Parameters.AddWithValue("@groupId", groupId);
					}

					command.ExecuteNonQuery();

					MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
