using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Partials
{
    public class PickLanguageModel
    {
        public SelectList LanguagesSelectlist { get; set; }
        
        public int? Language { get; set; }
        public string? NewLanguage { get; set; }
        
        public PickLanguageModel()
        {
        }

        public PickLanguageModel(SelectList languagesSelectList)
        {
            LanguagesSelectlist = languagesSelectList;
        }
    }
}