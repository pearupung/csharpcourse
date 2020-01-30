using System.Collections.Generic;
using Domain;

namespace NewMusicWebApp.DTO
{
    public class IndexDto
    {
        public Dictionary<Dj, Dictionary<Track, Performer>> IndexDictionary { get; set; }
    }
}