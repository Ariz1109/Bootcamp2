using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    internal class IPersonQueries
    {
        Task<IEnumerable<DocumentTypeViewModel>> GetAll();
    }
}
