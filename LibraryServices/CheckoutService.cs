using LibraryData;
using LibraryData.Interfaces;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        private readonly LibraryContext _context;

        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }

        public async void Add(Checkout c)
        {
            await _context.Checkouts.AddAsync(c);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Checkout>> GetAll()
        {
            return await _context.Checkouts.ToListAsync();
        }

        public async Task<Checkout> GetById(int id)
        {
            return await _context.Checkouts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CheckoutHistory>> GetCheckoutHistory(int id)
        {
            return await _context.CheckoutHistories.Include(h => h.LibraryAsset).
                Include(h => h.LibraryCard).
                Where(h => h.LibraryAsset.Id == id).
                ToListAsync();
        }


        public async Task<IEnumerable<Holds>> GetCurrentHolds(int id)
        {
            return await _context.Holds.Include(h => h.LibraryAsset).
                Include(h => h.LibraryCard).
                Where(h => h.LibraryAsset.Id == id).
                ToListAsync();
        }

        public async void MarkFound(int assetId)
        {
            var now = DateTime.Now;
            var asset = await _context.LibraryAssets.FirstOrDefaultAsync(a => a.Id == assetId);

            _context.Update(asset);
            asset.Status = await _context.Status.FirstOrDefaultAsync(s => s.Name == "Available");

            //remove existing checkouts if item was lost and now is found!
            var checkout =await _context.Checkouts.FirstOrDefaultAsync(c => c.LibraryAsset.Id == assetId);
            if (checkout != null)
                _context.Checkouts.Remove(checkout);

            //close existing checkout
            var history = await _context.CheckoutHistories.FirstOrDefaultAsync(h => h.LibraryAsset.Id == assetId && h.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
            _context.SaveChanges();
        }

        public async void MarkLost(int assetId)
        {
            var asset = await _context.LibraryAssets.FirstOrDefaultAsync(a => a.Id == assetId);
            
            _context.Update(asset);
            asset.Status = await _context.Status.FirstOrDefaultAsync(s => s.Name == "Lost");
            _context.SaveChanges();
        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }


        public void CheckInItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Checkout> GetLatestCheckout(int assetId)
        {
            return await _context.Checkouts.OrderByDescending(c => c.Since).FirstOrDefaultAsync();
        }
    }
}
