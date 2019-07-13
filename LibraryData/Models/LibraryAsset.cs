﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public int NumberOfCopies { get; set; }

        public virtual LibraryBranch Location { get; set; }
    }
}
