using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackSystem.Persistence.Postgres.Entities;

[Table("feedback")]
public class FeedbackEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("service")]
    public string Service { get; set; } = string.Empty;
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("created_datetime")]
    public DateTime CreatedDatetime { get; set; }
}
