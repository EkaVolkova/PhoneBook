using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// В книге содержится 6 записей.
/// Реализован её постраничный вывод, по 2 записи на страницу следующим образом:
///     Пользователь вводит номер страницы от 1 до 3 с консоли (получить можно через Console.ReadKey().KeyChar;).
///     Программа выводит записи с этой страницы (к примеру, если введёт 2, то должно показать Анатолия и Валерия). 
///     После работы программа не завершается, а снова ожидает ввод
///     
/// Контакты телефонной книги отсортированы сперва по имени, а затем по фамилии.
/// </summary>
namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            
            while (true)
            {
                //Просим пользователя ввести номер страницы
                Console.WriteLine("Enter page");

                // получаем символ с консоли
                var keyChar = Console.ReadKey().KeyChar;

                // очистка консоли от введенного текста
                Console.Clear();  

                //Проверяем парсится ли вообще наша страниц
                if (!int.TryParse(keyChar.ToString(), out int page))
                    continue;

                //Проверяем номер страницы
                if (page < 1 || page > (phoneBook.Count % 2 == 0 ? phoneBook.Count / 2 : phoneBook.Count / 2 + 1))
                    continue;

                //делаем выборку страницы
                var phonePageSortName = phoneBook.Skip((page - 1) * 2).Take(2).OrderBy(p => p.Name);
                var phonePageSortLastName = phoneBook.Skip((page - 1) * 2).Take(2).OrderBy(p => p.LastName);


                //вывод с сортировкой по имени
                Console.WriteLine("вывод с сортировкой по имени");
                foreach (var item in phonePageSortName)
                {
                    Console.WriteLine("Имя: {0} {1}, Телефон: {2}, Почта: {3}", item.Name, item.LastName, item.PhoneNumber, item.Email);
                }
                Console.WriteLine();

                //вывод с сортировкой по фамилии
                Console.WriteLine("вывод с сортировкой по фамилии");
                foreach (var item in phonePageSortLastName)
                {
                    Console.WriteLine("Имя: {0} {1}, Телефон: {2}, Почта: {3}", item.Name, item.LastName, item.PhoneNumber, item.Email);
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }

}
