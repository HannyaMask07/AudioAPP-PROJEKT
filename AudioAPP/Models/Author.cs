using Microsoft.AspNetCore.Mvc;

namespace AudioAPP.Models
{
    public class Author
    {
        [HiddenInput]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
    }
}
