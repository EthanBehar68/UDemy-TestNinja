using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDemyTestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        // This should be tested with integration tests
        // Not suited for unit testing
        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }

    }
}
