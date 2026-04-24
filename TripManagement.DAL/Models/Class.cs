using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TripManagementDAL.Models;

[Index("Name", Name = "UQ__Classes__737584F6FCCDB368", IsUnique = true)]
public partial class Class
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Class")]
    public virtual Teacher? Teacher { get; set; }
}
