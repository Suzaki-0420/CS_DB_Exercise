using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CS_DB_Sample.Infrastructures.Entities;

[Table("item")]
public class ItemEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }         // 商品Id（主キー）
    [Column("name")]
    public string? Name { get; set; }   // 商品
    [Column("price")]
    public int Price { get; set; }     // 値段
    [Column("category_id")]
    public int CategoryId { get; set; }     // 値段


    public override string ToString()
    {
        return $"商品Id:{Id} , 商品名:{Name} , 単価Id:{Price} , カテゴリId:{CategoryId}";
    }
}