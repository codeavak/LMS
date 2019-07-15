using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface ILibraryAsset
    {

        Task<IEnumerable<LibraryData.Models.LibraryAsset>> GetAll();
        Task<LibraryAsset> GetById(int id);
        void AddLibraryAsset(LibraryData.Models.LibraryAsset libraryAsset);
        Task<string> GetAuthorOrDirector(int id);
        Task<string> GetDeweyIndex(int id);
        Task<string> GetType(int id);
        Task<string> GetTitle(int id);
        Task<string> GetISBN(int id);
        Task<LibraryBranch> GetLibraryBranch(int id);

    }
}
