using CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Sample.Infrastructures.Accessors;
namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new EmployeeAccessor(new AppDbContext());
        // すべての部署を取得する

        Console.Write("部署Idを入力してください->");
        int id = int.Parse(Console.ReadLine());

        // 指定した部署Idの部署を取得する(存在する部署Id)
        var department = accessor.FindByDeptId(id);//EnployeeAcessorのメソッド

        Console.WriteLine("演習-07 employeeテーブルから部署Idで該当社員を取得する");

        if (department == null)
        {
            Console.WriteLine($"部署Id:{id}の部署に所属する社員は存在しません");
        }
        else
        {
            Console.WriteLine(department!.ToString());
        }
    }
}
