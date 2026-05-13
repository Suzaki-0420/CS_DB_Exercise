using CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Sample.Infrastructures.Accessors;
using CS_DB_Sample.Infrastructures.Entities;
namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new EmployeeAccessor(new AppDbContext());

        Console.Write("社員Idを入力してください->");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("演習-11 指定された社員Idの社員を削除する");
        var employee = new EmployeeEntity { Id = id };

        employee = accessor.DeleteById(employee);
        if (employee == null)
        {
            Console.WriteLine($"社員Id:{id}の社員は存在しないため削除できませんでした");
        }
        else
        {
            Console.WriteLine($"社員Id:{id}の社員を削除しました");
        }

    }
}
