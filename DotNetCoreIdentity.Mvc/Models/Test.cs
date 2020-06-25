using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "某人")]
        public string Someone { get; set; }
        [Required]
        [Display(Name = "某事")]
        public string Something { get; set; }

    }
}
