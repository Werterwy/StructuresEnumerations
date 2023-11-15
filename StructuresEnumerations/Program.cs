using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StructuresEnumerations
{
    class Program
    {

        /// <summary>
        /// Метод для вывода полной информации обо всех сотрудниках
        /// </summary>
        /// <param name="employees"></param>
        static void PrintAllEmployees(Employee[] employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        /// <summary>
        /// Метод для вывода полной информации о сотрудниках выбранной должности
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="position"></param>
        static void PrintEmployeesByPosition(Employee[] employees, string position)
        {
            var filteredEmployees = employees.Where(e => e.Position == position);
            Console.WriteLine($"Информация о сотрудниках на должности {position}:");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee);
            }
        }

       
        /// <summary>
        /// Метод для вывода информации о менеджерах с зарплатой выше средней зарплаты клерков
        /// </summary>
        /// <param name="employees"></param>
        static void PrintManagersAboveClerksAverageSalary(Employee[] employees)
        {
            decimal clerksAverageSalary = employees.Where(e => e.Position == "Clerk").Average(e => e.Salary);
            var managers = employees.Where(e => e.Position == "Manager" && e.Salary > clerksAverageSalary)
                                    .OrderBy(e => e.LastName);
            Console.WriteLine("Менеджеры с зарплатой выше средней зарплаты клерков:");
            foreach (var manager in managers)
            {
                Console.WriteLine(manager);
            }
        }

        /// <summary>
        /// Метод для вывода информации о сотрудниках, принятых на работу позже определенной даты
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="filterDate"></param>
        static void PrintEmployeesHiredAfterDate(Employee[] employees, DateTime filterDate)
        {
            var filteredEmployees = employees.Where(e => e.HireDate > filterDate)
                                             .OrderBy(e => e.LastName);
            Console.WriteLine($"Сотрудники, принятые на работу после {filterDate:d}:");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee);
            }
        }

       
        /// <summary>
        /// Метод для вывода информации о сотрудниках по полу
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="gender"></param>
        static void PrintEmployeesByGender(Employee[] employees, char gender)
        {
            var filteredEmployees = employees.Where(e => e.Gender == gender || gender == ' ');
            Console.WriteLine($"Информация о сотрудниках по полу ({gender}):");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee);
            }
        }


        static void Main()
        {
            Console.Write("Сколько сотрудников будет в компании(больше двух и сотоящий из одного Clerk и Manager): ");
            int numberOfEmployees = int.Parse(Console.ReadLine());

            // Создание массива сотрудников
            Employee[] employees = new Employee[numberOfEmployees];

            // Заполнение массива данными о сотрудниках
            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"Введите информацию о сотруднике {i + 1}:");
                Console.WriteLine("Введите по порядку всю информацию о сотруднике");
                Console.WriteLine("1. Имя:\n 2. Фамилию:\n 3. Дату и время воступление(например, \"dd.MM.yyyy HH:mm:ss\"):\n 4. Позицию:\n 5. Зарплату:\n 6. Пол(мужчина-M, женщина-F): ");
                employees[i] = new Employee
                {
                    
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine(),
                    HireDate = DateTime.Parse(Console.ReadLine()),
                    Position = Console.ReadLine(),
                    Salary = decimal.Parse(Console.ReadLine()),
                    Gender = char.Parse(Console.ReadLine())
                };
            }

            // a. Вывести полную информацию обо всех сотрудниках
            Console.WriteLine("Вся информация о сотрудниках:");
            PrintAllEmployees(employees);

            // b. Вывести полную информацию о сотрудниках выбранной должности
            Console.Write("Введите должность для поиска: ");
            string positionToSearch = Console.ReadLine();
            PrintEmployeesByPosition(employees, positionToSearch);

            // c. Найти менеджеров с зарплатой выше средней зарплаты клерков
            PrintManagersAboveClerksAverageSalary(employees);

            // d. Вывести информацию о сотрудниках, принятых на работу позже определенной даты
            Console.Write("Введите дату для фильтрации (в формате dd.mm.yyyy): ");
            DateTime filterDate = DateTime.Parse(Console.ReadLine());
            PrintEmployeesHiredAfterDate(employees, filterDate);

            // e. Вывести информацию о сотрудниках по полу
            Console.Write("Введите пол для фильтрации (м/ж): ");
            char genderFilter = char.Parse(Console.ReadLine());
            PrintEmployeesByGender(employees, genderFilter);
        }

    }
}
