using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_13

{
    public class Manager
    {
        

        /// <summary>
        /// Смена номера телефона
        /// </summary>
        /// <param name="client"></param>
        public virtual void MobNumChange(Client client)
        {
            char key = 'д';
            do
            {
                Console.WriteLine("Введите номер телефона клиента:");
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
        public virtual void FirstNameChange(Client client)
        {
            Console.WriteLine("Введите имя клиента:");
            string nam = Console.ReadLine();
            client.FirstName = nam;
        }

        /// <summary>
        /// Смена фамилии
        /// </summary>
        /// <param name="client"></param>
        public virtual void SecondNameChange(Client client)
        {
            Console.WriteLine("Введите фамилию клиента:");
            string nam = Console.ReadLine();
            client.SecondName = nam;
        }

        /// <summary>
        /// Смена отчества
        /// </summary>
        /// <param name="client"></param>
        public virtual void PatronymicChange(Client client)
        {
            Console.WriteLine("Введите отчество клиента:");
            string nam = Console.ReadLine();
            client.Patronymic = nam;
        }

        /// <summary>
        /// Смена номера паспорта
        /// </summary>
        /// <param name="client"></param>
        public virtual void IdNumChange(Client client)
        {
            Console.WriteLine("Введите номер паспорта клиента:");
            string id = Console.ReadLine();
            client.IdNumber = id;
        }

        /// <summary>
        /// Вывод коллекции клиентов
        /// </summary>
        /// <param name="clients"></param>
        public virtual void ShowInfo(List<Client> clients)
        {
            foreach (var c in clients)
            {
                Console.WriteLine(string.Format("Second Name: {0,-10} | First Name:  {1,-15} | " +
                "Patronymic: {2 ,-15} | Mobile Number: {3, -11} | Id Number: {4, -12} | Id {5, -4} " +
                "\nChanges: {6, -100}\n Bank account: {7, -50} \n Deposite account: {8,-50} \n",
                c.SecondName,
                c.FirstName,
                c.Patronymic,
                c.MobileNumber,
                c.IdNumber,
                c.IndexClient,
                c.Changes,
                c.NotDepAcc,
                c.DepAcc
                ));
                
            }
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="clients"></param>
        public virtual void AddClient(List<Client> clients)
        {
            Client newClient = new Client();
            SecondNameChange(newClient);
            FirstNameChange(newClient);
            PatronymicChange(newClient);
            MobNumChange(newClient);
            IdNumChange(newClient);
            newClient.IndexClient = (clients.Count()).ToString();
            clients.Add(newClient);
        }

        /// <summary>
        /// Открытие депозитного счета клиенту
        /// </summary>
        /// <param name="client"></param>
        public virtual void OpenDepAcc(Client client)
        {
            client.OpenDepAcc();
        }

        /// <summary>
        /// Перевод средств между счетами одного клиента
        /// </summary>
        /// <param name="client"></param>
        public virtual void MoneyTransferInside(Client client)
        {
            Console.WriteLine(string.Format("Счета клиента:\n" +
                "Bank account: {0, -30} \n Deposite account: {1,-30} \n",
                client.NotDepAcc,
                client.DepAcc
                ));

            Console.WriteLine("Выберите счет зачисления:\n" +
              "1 - Недепозитный счет (основной)\n" +
              "2 - Депозитный счет (накопительный)\n" +
              "3 - Отмена");

            var chose = Console.ReadLine();
            switch (chose)
            {
                case "1":
                    Console.WriteLine("Перевод будет осуществлен с депозитного счета на основной");
                    client.TransferToNotDep();
                    break;
                case "2":
                    Console.WriteLine("Перевод будет осуществлен с основного счета на депозитный");
                    client.TransferToDep();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Некорректный ввод, введите 1 или 2\n");
                    break;
            }
        }

        /// <summary>
        /// Пополнение счетов клиента с помощью налички
        /// </summary>
        /// <param name="client"></param>
        public virtual void CashRefill(Client client)
        {
            client.AccountCashRefill();
        }

        /// <summary>
        /// Перевод средств между счетами двух клиентов
        /// </summary>
        /// <param name="clientFrom"></param>
        /// <param name="clientTo"></param>
        public virtual void MoneyTransferBetween(Client clientFrom, Client clientTo)
        {
            clientFrom.TransferToOtherClient(clientTo);
            
        }
    }
}
