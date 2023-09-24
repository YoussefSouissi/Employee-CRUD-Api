using EmployeeApi.Models;
namespace EmployeeApi.Models.Services
{
    public class EmployeeService
    {
        static List<Employee> employeeList { get; }
        static int nextEmpId = 3;


        static EmployeeService()
        {
            employeeList = new List<Employee>() {
            new Employee { Id = 1, Name = "Youssef", Position = "Developer", Salary = 1200 },
            new Employee { Id = 2, Name = "Ahmed", Position = "CEO", Salary = 5000 }
        };
        }
        public static List<Employee> GetAll()
        {
            return employeeList;
        }
        public static Employee GetById(int id)
        {
            return employeeList.FirstOrDefault(emp => emp.Id == id);
        }
        public static void add(Employee employee)
        {
            employee.Id = nextEmpId++;
            employeeList.Add(employee);
        }
        public static void Update(Employee employee)
        {
            var index = employeeList.FindIndex(emp => emp.Id == employee.Id);
            if (index == -1)
                return;
            employeeList[index] = employee;

        }
        public static void delete(int id)
        {
            var employe = GetById(id);
            if (employe is null)
                return;
            employeeList.Remove(employe);

        }

    }
}
