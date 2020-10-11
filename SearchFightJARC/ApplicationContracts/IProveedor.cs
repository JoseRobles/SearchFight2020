using Domain;
using System.Collections.Generic;

namespace ApplicationContracts
{
    public interface IProveedor
    {
        List<ResultsByWord> GetResultsByWord(List<Search> listofWords);
    }
}
