using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public string? LanguageCode { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}