using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Models;

public partial class Parent
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string FullName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NickName { get; set; } = null!;

    [StringLength(9)]
    [Unicode(false)]
    public string BiologicalSex { get; set; } = null!;

    public int FamilyId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Login { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("FamilyId")]
    [InverseProperty("Parents")]
    public virtual Family Family { get; set; } = null!;
}
