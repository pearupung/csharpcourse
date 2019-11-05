using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Library
    {
        public int LibraryId { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}