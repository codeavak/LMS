using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models.Catalog
{
    public class AssetIndexViewModel
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public string DeweyNumber { get; set; } 
        public int NumberOfCopies { get; set; }

        
    }
}
