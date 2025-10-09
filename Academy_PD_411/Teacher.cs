using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Academy_PD_411
{
	class Teacher : Person
	{
		public Teacher() : base() { }

		public short TeacherId { get; set; }

		public Teacher
		(
			string last_name, string first_name, string middle_name,
			string birth_date, string email, string phone,
			short teacherId,
			Image photo
		): base(last_name, first_name, middle_name, birth_date, email, phone, photo)
		{
			TeacherId = teacherId;
		}

		public override string ToString()
		{
			return $"N'{LastName}', N'{FirstName}', N'{MiddleName}', '{BirthDate}', N'{Email}', N'{Phone}', {TeacherId}";
		}

		public override string ToStringUpdate()
		{
			return $@"
{base.ToStringUpdate()},
teacher_id={TeacherId}
";
		}

	}
}
