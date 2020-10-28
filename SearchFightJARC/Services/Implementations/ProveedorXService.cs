using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProveedorX : BaseService, IService
    {
        public ProveedorX() : base()
        {
        }

        public async Task<long> GetResults(string word)
        {
            Random rnd = new Random();
            return await Task.FromResult(rnd.Next(1,1000)); 
        }

    }
}
