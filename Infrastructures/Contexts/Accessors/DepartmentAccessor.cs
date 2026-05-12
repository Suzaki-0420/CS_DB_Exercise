using CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Sample.Infrastructures.Accessors;

public class DepartementAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public DepartementAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<DepartmentEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var departments = _context.Departments.ToList();
        return departments;
    }
    public DepartmentEntity? FindById(int departmentId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Departments.Find(departmentId);
        return department;
    }
}