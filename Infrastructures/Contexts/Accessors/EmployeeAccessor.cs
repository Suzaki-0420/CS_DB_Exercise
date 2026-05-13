using CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Sample.Infrastructures.Accessors;

public class EmployeeAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }

    public EmployeeEntity? FindByDeptId(int deptId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Employees.Find(deptId);
        return department;
    }

    public List<EmployeeEntity> FindByContaintsName(string keyword)
    {
        return _context.Employees
            .Where(i => i.Name!.Contains(keyword))
            .ToList();
    }
}