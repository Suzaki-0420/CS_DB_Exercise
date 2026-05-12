using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CS_DB_Sample.Infrastructures.Entities;

[Table("department")]
public class DepartmentEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }         // 部署Id（主キー）
    [Column("name")]
    public string? Name { get; set; }   // 部署名

    public override string ToString()
    {
        return $"部署Id:{Id} , 部署名:{Name}";
    }
}