using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleNotesApi.Models
{
    public class Note
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
