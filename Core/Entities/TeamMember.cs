using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class TeamMember
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required,MaxLength(200)]
    public string? Position { get; set; }
    [Required,MinLength(100)]
    public string? Description { get; set; }
    public string? Twitter { get; set; }
    public string? Facebook { get; set; }
    public string? Linkedin { get; set; }

}
