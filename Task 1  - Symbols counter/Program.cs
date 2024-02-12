using System;
using System.Linq; //Подключение пространства имен Linq -> методы Distinct и Count


namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your phrase"); //Предложение ввести фразу

                string phrase = Console.ReadLine(); //Метод ReadLine -> ввод переменной в консоли (строки)
                
                var character = phrase.Distinct(); 
                //Cпомощью var задается локальная переменная без определенного типа -> т.к. во фразе могут быть и символы и буквы и цифры
                //Метод Distinct удаляет дублирующиеся элементы из коллекции

                Console.WriteLine("Different characters \n{0}", character.Count());
                //Метод Count подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
                // \n -> Перевод на другюу строку
            }
        }
    }
}
