using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Models;

public partial class Child
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(9)]
    [Unicode(false)]
    public string? BiologicalSex { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Login { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Password { get; set; }

    public int FamilyId { get; set; }

    [ForeignKey("FamilyId")]
    [InverseProperty("Children")]
    public virtual Family Family { get; set; } = null!;
}
