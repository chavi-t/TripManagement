using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TripManagementDAL.Models;

[Index("StudentId", Name = "UQ__Students__32C52B9822B6F78B", IsUnique = true)]
public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string StudentId { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class Class { get; set; } = null!;
}
