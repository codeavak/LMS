using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryData.Interfaces
{
    public interface ICheckout
    {
        Task<IEnumerable<Checkout>> GetAll();
        Task<Checkout> GetById(int id);
        void Add(Checkout c);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId, int libraryCardId);
        Task<IEnumerable<CheckoutHistory>> GetCheckoutHistory(int id);

        void PlaceHold(int assetId, int libraryCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        Task<IEnumerable<Holds>> GetCurrentHolds(int id);

        Task<Checkout> GetLatestCheckout(int assetId);

        void MarkLost(int assetId);
        void MarkFound(int assetId);

    }
}
