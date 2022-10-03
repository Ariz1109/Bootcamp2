using Bootcamp.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Bootcamp.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly string _connectionString;
        public PersonRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:Connection"];

        }

        public async Task<int> Create(Person person) {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", person.Name);
            parameters.Add("@Lastame", person.Lastname);
            parameters.Add("@DocumentTypeId", person.DocumentTypeId);
            parameters.Add("@DocumentNumer", person.DocumentNumer);

            using (var connection = new SqlConnection(_connectionString)) {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Person]",parameters,commandType:System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        
        public async Task<int> Delete(int id) {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@IdPerson", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Del_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;

        }

        public async Task<int> Read(int id) {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@IdPerson", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Sel_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
