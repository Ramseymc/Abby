using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abby.Models;

public class Note
{

    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Date { get; set; }

    public string Body { get; set; }
}
