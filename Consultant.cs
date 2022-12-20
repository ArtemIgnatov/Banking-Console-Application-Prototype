using System;
using System.Collections.Generic;

namespace HW_13
{
    public class Consultant : Manager
    {
        /// <summary>
        /// Смена номера телефона
        /// </summary>
        /// <param name="client"></param>
        public override void MobNumChange(Client client)
        {
            char key = 'д';
            do
            {
                Console.WriteLine("Введите новый номер телефона для изменения:");
                string str = Console.ReadLine();
                if (String.IsNullOrEmpty(str) || str.Contains(" "))
                {
                    Console.WriteLine("Данная строка не может быть пустой!");
                    Console.WriteLine("Ввести заново? н/д");
                    key = Console.ReadKey(true).KeyChar;
                }
                else
                {
                    client.MobileNumber = str;
                    break;
                }
            } while (char.ToLower(key) == 'д');
        }

        /// <summary>
        /// Смена имени
        /// </summary>
        /// <param name="client"></param>
        public override void FirstNameChange(Client client)
        {
            Console.WriteLine("Данное действие недоступно для консультанта");
        }

        /// <summary>
        /// Смена фамилии
        /// </summary>
        /// <param name="client"></param>
        public override void SecondNameChange(Client client)
        {
            Console.WriteLine("Данное действие недоступно для консультанта");
        }

        /// <summary>
        /// Смена отчества
        /// </summary>
        /// <param name="client"></param>
        public override void PatronymicChange(Client client)
        {
            Console.WriteLine("Данное действие недоступно для консультанта");
        }

        /// <summary>
        /// Смена номера паспорта
        /// </summary>
        /// <param name="client"></param>
        public override void IdNumChange(Client client)
        {
            Console.WriteLine("Данное действие недоступно для консультанта");
        }

        /// <summary>
        /// Вывод коллекции клиентов
        /// </summary>
        /// <param name="clients"></param>
        public override void ShowInfo(List<Client> clients)
        {
            foreach (var c in clients)
            {
                Console.WriteLine(string.Format("First Name: {0,-10} | Second Name: {1,-15} | " +
                "Patronymic: {2 ,-15} | Mobile Number: {3, -11} | Id Number: данные недоступны | Id {4, -4} " +
                "\nChanges: {5, -100} \n Bank account: данные недоступны \n Deposite account: данные недоступны  \n",
                c.FirstName,
                c.SecondName,
                c.Patronymic,
                c.MobileNumber,
                c.IndexClient,
                c.Changes
                ));
            }
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="clients"></param>
        public override void AddClient(List<Client> clients)
        {
            Console.WriteLine("Данное действие недоступно для консультанта");
        }

    }
}
