using System.Collections.Generic;
using System.Threading.Tasks;
using WebAdvert_SearchApi.Models;

namespace WebAdvert_SearchApi.Services
{
    public interface ISearchService
    {
        Task<List<AdvertType>> Search(string keyword);
    }
}
