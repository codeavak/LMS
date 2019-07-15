using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LibraryData;
using LibraryData.Models;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset

    {
        private readonly LibraryContext _Context;

        public LibraryAssetService(LibraryContext _context)
        {
            _Context = _context;
        }

        public async void AddLibraryAsset(LibraryData.Models.LibraryAsset libraryAsset)
        {
            await _Context.LibraryAssets.AddAsync(libraryAsset);
            await _Context.SaveChangesAsync();

        }

        public async Task<IEnumerable<LibraryData.Models.LibraryAsset>> GetAll()
        {
            return await _Context.LibraryAssets.
                Include(a => a.Status).
                Include(a => a.Location).ToListAsync();
        }

        public async Task<string> GetAuthorOrDirector(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                var video = await _Context.Videos.FirstOrDefaultAsync(a => a.Id == id);
                if (video == null)
                    return null;
                else return video.Director;

            }
            else return asset.Author;

        }

        public async Task<LibraryData.Models.LibraryAsset> GetById(int id)
        {
            return await _Context.LibraryAssets.
              Include(a => a.Status).
              Include(a => a.Location).FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<string> GetDeweyIndex(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                return null;
            }
            else return asset.DeweyIndex;
        }

        public async Task<string> GetISBN(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                return null;
            }
            else return asset.ISBN;
        }

        public async Task<LibraryBranch> GetLibraryBranch(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                 var videoAsset = await _Context.Videos.FirstOrDefaultAsync(a => a.Id == id);
                if (videoAsset == null)
                    return null;
                else return videoAsset.Location;
            }
            else return asset.Location;
        }

        public async Task<string> GetTitle(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                return null;
            }
            else return asset.Title;
        }

        public async Task<string> GetType(int id)
        {
            var asset = await _Context.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (asset == null)
            {
                var video = await _Context.Videos.FirstOrDefaultAsync(a => a.Id == id);
                if (video == null)
                    return null;
                else return "Video";

            }
            else return "Book";
        }
    }
}
