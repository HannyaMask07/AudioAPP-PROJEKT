using System.ComponentModel.DataAnnotations;

namespace AudioAPP.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int AudioId { get; set; }
        [Required]
        public string? Message { get; set; }

    }
}
