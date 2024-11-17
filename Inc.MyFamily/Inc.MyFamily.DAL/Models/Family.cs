using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Models;

[Table("Family")]
public partial class Family
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string? Surname { get; set; }

    public bool? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [InverseProperty("Family")]
    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    [InverseProperty("Family")]
    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
