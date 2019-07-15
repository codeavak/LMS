using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models.Catalog
{
    public class AssetDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorOrDirector { get; set; }

        public string Type { get; set; }

        public int Year { get; set; }

        public string ISBN { get; set; }

        public string DeweyNumber { get; set; }

        public string Status { get; set; }

        public decimal Price { get; set; }

        public string CurrentLocation { get; set; }

        public string ImgUrl { get; set; }

        public string PatronName { get; set; }

        public Checkout LatestCheckout { get; set; }

        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }

        public IEnumerable<AssetHoldModel> CurrentHolds { get; set; }
    }

    public class AssetHoldModel
    {
        public string PatronName { get; set; }
        public string HoldPlaced { get; set; }
    }
}
