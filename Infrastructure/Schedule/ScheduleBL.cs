using Dapper;
using MySqlConnector;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Model;

namespace Tasks.Schedule
{
    public class ScheduleBL
    {
        public string connectString = "Server=localhost;User=root;Password=binh1008;Database=quanlyluong";
        public IEnumerable<Employee> getListEmployeeSchedule()
        {
            try
            {
                var sqlConnector = new MySqlConnection(connectString);
                var sqlQuery = "Proc_Get_ListSchedule" ;
                var res = sqlConnector.Query<Employee>(sqlQuery, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return res;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> sendPaycheckAuto()
        {
            string message = string.Empty;

            List<Employee> employees = getListEmployeeSchedule().ToList();

            if (employees.Count > 0)
            {
                var client = new RestClient($"https://localhost:7101/");

                var request = new RestRequest("api/Schedule/sendNow")
                       .AddJsonBody(employees)
                       .AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUb2tlbiIsImp0aSI6Ijc4ZTQzOWUxLWE3MWItNGNjNC05MmNhLTA4NjQxNjUxYjQzYyIsImlhdCI6IjQvOS8yMDIzIDY6MTQ6MzggUE0iLCJTU0lEIjoiMTFmNzA4OWItMzNlNi0zNzFhLWY4MTctNzAwMGY0NTVmM2Q1IiwiZXhwIjoxNjgxMTUwNDc4LCJpc3MiOiJJc3N1ZXIiLCJhdWQiOiJBdWRpZW5jZSJ9.3SCYCrS-JQAMWop-Ae3Ne8XSMssMa00LfUpEyTiTD-s");

                var response = await client.ExecutePostAsync<List<Employee>>(request);
            }


            return message;
        }

    }
}
