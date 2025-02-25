using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleNotesApi.Models
{
    public class DescriptionTitleNote
    {

        [Required]
        [MinLength(5, ErrorMessage = "Description must be at least 5 chars")]
        public string Description { get; set; }


        [Required]
        [MinLength(3, ErrorMessage = "Description must be at least 5 chars")]
        public string Title { get; set; }

    }
}
