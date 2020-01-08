using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Partials
{
    public class PickLanguageModel
    {
        public SelectList LanguagesSelectlist { get; set; }

        public int LanguageId { get; set; }
        public string NewLanguageName { get; set; }
        
        public PickLanguageModel(int language, SelectList languagesSelectList)
        {
            LanguageId = language;
            LanguagesSelectlist = languagesSelectList;
            
        }

        public PickLanguageModel()
        {
            
        }
    }
}