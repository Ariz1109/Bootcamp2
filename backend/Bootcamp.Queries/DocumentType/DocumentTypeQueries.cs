using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    public class DocumentTypeQueries : IDocumentTypeQueries
    {
        private readonly string _connectionstring;

        public DocumentTypeQueries(IConfiguration configuration)
        {
            _connectionstring = configuration["ConnectionStrings:Connection"];
        }
        public async Task<IEnumerable<DocumentTypeViewModel>> GetAll()
        {
            IEnumerable<DocumentTypeViewModel> result = new List<DocumentTypeViewModel>();

            using (var connection = new SqlConnection(_connectionstring))
            {
                result = await connection.QueryAsync<DocumentTypeViewModel>("[dbo].[Usp_Sel_DocumentType]",commandType: System.Data.CommandType.StoredProcedure);
            }
            Console.WriteLine(result);
            return result;
        }
    }
}
