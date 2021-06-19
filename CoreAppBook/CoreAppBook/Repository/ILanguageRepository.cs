using CoreAppBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreAppBook.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}