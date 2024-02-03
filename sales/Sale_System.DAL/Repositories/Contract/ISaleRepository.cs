using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sale_system.MODEL;

namespace Sale_System.DAL.Repositories.Contract
{
    public interface ISaleRepository : IGenerictRepository<Sale>
    {
        Task<Sale> Register(Sale model);
    }
}
