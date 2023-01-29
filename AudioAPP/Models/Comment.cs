using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class Comment
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string ?Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Author { get; set; }

        public int AudioId { get; set; }
    }
}
