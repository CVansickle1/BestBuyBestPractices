using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Departement> GetAllDepartments()
        {
            return _connection.Query<Departement>("SELECT * FROM departments");
        }

        public void InsertDepartement(string newDepartment)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name)",
                new { name = newDepartment});
        }
    }
}
