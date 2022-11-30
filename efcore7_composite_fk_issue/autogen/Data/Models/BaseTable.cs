using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Data.Models;

[Table("base_table")]
[Index("BaseId", "BaseTypeId", Name = "ak_base", IsUnique = true)]
public partial class BaseTable
{
    [Key]
    [Column("base_id")]
    public long BaseId { get; set; }

    [Column("base_type_id")]
    public int BaseTypeId { get; set; }

    public virtual ICollection<SubTable> SubTables { get; } = new List<SubTable>();
}
