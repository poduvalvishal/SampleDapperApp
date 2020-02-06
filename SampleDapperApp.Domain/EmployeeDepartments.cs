using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDapperApp.Domain
{
	public class EmployeeDepartments
	{
		public int EmployeeId { get; set; }
		public List<Department> Departments { get; set; }
	}
}
