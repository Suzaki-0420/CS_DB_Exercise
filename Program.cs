using CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Sample.Infrastructures.Accessors;
namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new EmployeeAccessor(new AppDbContext());
        // すべての部署を取得する

        Console.Write("キーワードを入力してください->");
        string keyword = Console.ReadLine();

        // 指定した部署Idの部署を取得する(存在する部署Id)
        var employee = accessor.FindByContaintsName(keyword);//EnployeeAcessorのメソッド

        Console.WriteLine("演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");

        if (employee.Count == 0)
        {
            Console.WriteLine($"キーワード:{keyword}が含まれる社員は存在しません");
        }
        else
        {
            foreach (var e in employee)
            {
                Console.WriteLine(e);
            }
        }
    }
}
