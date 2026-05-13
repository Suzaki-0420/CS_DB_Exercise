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

    public EmployeeEntity Create(EmployeeEntity employee)
    {
        var department = _context.Departments.Find(employee.DeptId);//部署が存在するか確認
        if (department == null)
        {
            return null; // 商品が見つからない場合はnullを返す
        }
        var result = _context.Employees.Add(employee);
        _context.SaveChanges();
        return result.Entity;
    }

    public EmployeeEntity UpdateById(EmployeeEntity employee)
    {
        var result = _context.Employees.Find(employee.Id);//部署が存在するか確認
        if (result == null)
        {
            return null; // 商品が見つからない場合はnullを返す
        }
        result!.Name = employee.Name;
        _context.SaveChanges();
        return result;
    }

    public EmployeeEntity DeleteById(EmployeeEntity employee)
    {
        var result = _context.Employees.Find(employee.Id);
        if (result == null)
        {
            return null; // 商品が見つからない場合はnullを返す
        }
        var delResult = _context.Employees.Remove(result);
        _context.SaveChanges();
        return result;
    }
}