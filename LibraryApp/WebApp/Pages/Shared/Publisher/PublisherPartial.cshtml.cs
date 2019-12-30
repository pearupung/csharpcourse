using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Publisher
{
    public class PublisherPartialModel
    {
        public SelectList? PublishersSelectlist { get; set; }
        public int? Publisher { get; set; }
        public string? NewPublisher { get; set; }


        public PublisherPartialModel()
        {
        }

        public PublisherPartialModel(SelectList publishersSelectList)
        {
            PublishersSelectlist = publishersSelectList;
        }
    }
}