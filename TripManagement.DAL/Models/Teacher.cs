using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TripManagementDAL.Models;

[Index("ClassId", Name = "UQ__Teachers__CB1927C165C27DAA", IsUnique = true)]
[Index("TeacherId", Name = "UQ__Teachers__EDF25965B02D0023", IsUnique = true)]
public partial class Teacher
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string TeacherId { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Teacher")]
    public virtual Class Class { get; set; } = null!;
}
