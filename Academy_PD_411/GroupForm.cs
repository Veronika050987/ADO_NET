using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy_PD_411
{
	public partial class GroupForm : Form
	{
		private TextBox textBoxGroupName;
		private Label Direction;
		private ComboBox comboBoxDirection;
		private Button buttonSave;
		private Button buttonCancel;
		private Label Group_name;

		public int? GroupId { get; set; } // Nullable int для случая добавления (нет ID)
		public string GroupName { get; set; }
		public int DirectionId { get; set; }

		public GroupForm()
		{
			InitializeComponent();
		}

		public GroupForm(int groupId, string groupName, int directionId) : this()
		{
			GroupId = groupId;
			GroupName = groupName;
			DirectionId = directionId;

			// Инициализация полей формы данными для редактирования
			textBoxGroupName.Text = GroupName;
			comboBoxDirection.SelectedValue = DirectionId;
		}

		private void GroupForm_Load(object sender, EventArgs e)
		{
			// Загрузка направлений в ComboBox
			MainForm mainForm = (MainForm)this.Owner;
			if (mainForm != null)
			{
				//comboBoxDirection.DataSource = mainForm.GetDirectionsDataSource(); // Создайте этот метод в MainForm
				comboBoxDirection.DisplayMember = "direction_name"; // Или другое поле для отображения
				comboBoxDirection.ValueMember = "direction_id";

				// Установка выбранного элемента для редактирования
				if (GroupId.HasValue)
				{
					comboBoxDirection.SelectedValue = DirectionId;
				}
			}

			if (GroupId.HasValue)
			{
				this.Text = "Edit group";
			}
			else
			{
				this.Text = "Add group";
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			// Проверка на пустые значения (валидация)
			if (string.IsNullOrWhiteSpace(textBoxGroupName.Text))
			{
				MessageBox.Show("Please, enter group name: ");
				return;
			}

			if (comboBoxDirection.SelectedItem == null)
			{
				MessageBox.Show("Please, choose a direction: ");
				return;
			}

			GroupName = textBoxGroupName.Text;
			DirectionId = (int)comboBoxDirection.SelectedValue; // Получаем ID направления

			DialogResult = DialogResult.OK; // Указываем, что сохранение прошло успешно
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel; // Указываем, что сохранение отменено
			Close();
		}

		private void InitializeComponent()
		{
			this.Group_name = new System.Windows.Forms.Label();
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.Direction = new System.Windows.Forms.Label();
			this.comboBoxDirection = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Group_name
			// 
			this.Group_name.AutoSize = true;
			this.Group_name.Location = new System.Drawing.Point(12, 9);
			this.Group_name.Name = "Group_name";
			this.Group_name.Size = new System.Drawing.Size(81, 16);
			this.Group_name.TabIndex = 0;
			this.Group_name.Text = "Group name";
			// 
			// textBoxGroupName
			// 
			this.textBoxGroupName.Location = new System.Drawing.Point(12, 38);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(224, 22);
			this.textBoxGroupName.TabIndex = 1;
			// 
			// Direction
			// 
			this.Direction.AutoSize = true;
			this.Direction.Location = new System.Drawing.Point(12, 80);
			this.Direction.Name = "Direction";
			this.Direction.Size = new System.Drawing.Size(60, 16);
			this.Direction.TabIndex = 2;
			this.Direction.Text = "Direction";
			// 
			// comboBoxDirection
			// 
			this.comboBoxDirection.FormattingEnabled = true;
			this.comboBoxDirection.Location = new System.Drawing.Point(12, 111);
			this.comboBoxDirection.Name = "comboBoxDirection";
			this.comboBoxDirection.Size = new System.Drawing.Size(352, 24);
			this.comboBoxDirection.TabIndex = 3;
			// 
			// buttonSave
			// 
			this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.buttonSave.Location = new System.Drawing.Point(68, 207);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(96, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.buttonCancel.Location = new System.Drawing.Point(213, 207);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(102, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			// 
			// GroupForm
			// 
			this.ClientSize = new System.Drawing.Size(380, 263);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxDirection);
			this.Controls.Add(this.Direction);
			this.Controls.Add(this.textBoxGroupName);
			this.Controls.Add(this.Group_name);
			this.Name = "GroupForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
