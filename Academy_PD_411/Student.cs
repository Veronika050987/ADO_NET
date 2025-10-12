using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Academy_PD_411
{
	class Student : Person
	{
		public int Group { get; set; }
		public Student() : base() { }

		public Student
		(
			string last_name, string first_name, string middle_name,
			string birth_date, string email, string phone,
			int group,
			Image photo
		): base(last_name, first_name, middle_name, birth_date, email, phone, photo)
		{
			Group = group;
		}

		public override string ToString()
		{
			return $"{base.ToString()},{Group}";
		}

		public override string ToStringUpdate()
		{
			return $@"{base.ToStringUpdate()},[group]={Group}";
		}
	}
}
