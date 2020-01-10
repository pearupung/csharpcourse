using Microsoft.AspNetCore.Http;

namespace WebApp.Pages.Shared.Partials
{
    public class PickPictureModel
    {
        public IFormFile FormFile { get; set; }
    }
}