using SocialNetwork.BLL;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;

namespace SocialNetwork
{
    internal class Program
    {

     public static UserServise userServise = new UserServise();

        static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while (true)
            {
                Console.WriteLine("Для регистрации пользователя введите имя пользователя:");

                string firstName = Console.ReadLine();

                Console.Write("фамилия:");
                string lastName = Console.ReadLine();

                Console.Write("пароль:");
                string password = Console.ReadLine();

                Console.Write("почтовый адрес:");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userServise.Register(userRegistrationData);
                    Console.WriteLine("Регистрация произошла успешно!");
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректное значение.");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }



                Console.ReadLine();
            }

        }
    }
       
    
}
