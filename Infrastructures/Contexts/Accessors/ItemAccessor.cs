using CS_DB_Sample.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using CS_DB_Sample.Infrastructures.Contexts;

namespace CS_DB_Sample.Infrastructures.Accessors;

public class ItemAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;

    //コンストラクタ
    public ItemAccessor(AppDbContext context)
    {
        _context = context;
    }


    public ItemEntity? UpdateById(ItemEntity item)
    {
        // 商品Idを指定して商品を取得する
        var result = _context.Items.Find(item.Id);
        if (item == null)
        {
            return null; // 商品が見つからない場合はnullを返す
        }
        // 商品名と単価を変更する
        result!.Name = item.Name;
        result.Price = item.Price;
        // 変更を永続化する
        _context.SaveChanges();
        return item;
    }

    /// <summary>
    /// 複数の商品を更新する
    /// </summary>
    /// <param name="items">変更対象の商品</param>
    public void UpdateRange(List<ItemEntity> items)
    {
        // 商品を更新する
        _context.Items.UpdateRange(items);
        // 変更を永続化する
        _context.SaveChanges();
    }

    public ItemEntity? DeleteById(ItemEntity item)
    {
        var result = _context.Items.Find(item.Id);
        if (result == null)
        {
            return null;// 商品が見つからない場合はnullを返す
        }
        // 商品を削除する
        var delResult = _context.Items.Remove(result);
        // 削除を永続化する
        _context.SaveChanges();
        return delResult.Entity;
    }

    public void DeleteRange(List<ItemEntity> items)
    {
        // 商品を削除する
        _context.Items.RemoveRange(items);
        // 削除を永続化する
        _context.SaveChanges();
    }
}