using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresEnumerations
{
    // Определение интерфейса для сотрудника
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime HireDate { get; set; }
        string Position { get; set; }
        decimal Salary { get; set; }
        char Gender { get; set; }
    }

    // Определение структуры, реализующей интерфейс IEmployee
    public struct Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public char Gender { get; set; }

        // Перегрузка метода ToString() для удобного вывода информации о сотруднике
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Position: {Position}, Salary: {Salary:C}, Gender: {Gender}, Hire Date: {HireDate:d}";
        }
    }


}
