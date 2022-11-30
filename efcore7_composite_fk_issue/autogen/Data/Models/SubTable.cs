using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Data.Models;

[Table("sub_table")]
public partial class SubTable
{
    [Key]
    [Column("sub_id")]
    public long SubId { get; set; }

    [Column("base_type_id")]
    public int BaseTypeId { get; set; }

    public virtual BaseTable BaseTable { get; set; } = null!;
}
