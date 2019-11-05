using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public string Address { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}