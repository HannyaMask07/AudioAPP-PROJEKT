using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class AudioLike
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string? Author { get; set; }

        public int AudioId { get; set; }
    }
}
