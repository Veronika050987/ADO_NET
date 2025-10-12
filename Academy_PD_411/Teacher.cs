using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy_PD_411
{
	class Teacher : Human
	{
		public short ID { get; set; }
		public Teacher() { }
		public Teacher(short teacher_id)
		{
			Connector connector = new Connector();
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id={teacher_id}");
			ID = teacher_id;
			LastName = teacher.Rows[0][1].ToString();
			FirstName = teacher.Rows[0][2].ToString();
			MiddleName = teacher.Rows[0][3].ToString();
			BirthDate = teacher.Rows[0][4].ToString();
			Email = teacher.Rows[0][5].ToString();
			Phone = teacher.Rows[0][6].ToString();
			try
			{
				Photo = connector.DownLoadPhoto(teacher_id, "Teachers", "photo");
			}
			catch (Exception)
			{
			}
		}
		public Teacher
		(
			string last_name, string first_name, string middle_name,
			string birth_date, string email, string phone,
			Image photo
		)
		{
			LastName = last_name;
			FirstName = first_name;
			MiddleName = middle_name;
			BirthDate = birth_date;
			Email = email;
			Phone = phone;
			Photo = photo;
			//Photo = SerializePhoto(photo);
		}
		public override string ToString()
		{
			return $"{base.ToString()}";
		}
		public override string ToStringUpdate()
		{
			return $"{base.ToStringUpdate()}";
		}
	}
}
