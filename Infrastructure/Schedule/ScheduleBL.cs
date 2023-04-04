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

            var client = new RestClient($"https://localhost:7101/");

            var request = new RestRequest("api/Schedule/sendNow")
                   .AddJsonBody(employees);

            var response = await client.ExecutePostAsync<List<Employee>>(request);


            return message;
        }

    }
}
