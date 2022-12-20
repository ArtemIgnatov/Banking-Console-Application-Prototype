using System;
using System.Collections.Generic;
namespace HW_13
{
    public class Menu
    {
        public delegate void AccountHandler(string message, Client client); // Добавляем делегат для послеующий обработки события
        public event AccountHandler? Notify; // Добавляем событие
        


        public void Start()
        {
            //Создаем коллекцию клиентов с автопараметрами
            Client cl = new Client();
            List<Client> clients = cl.NumOfClientsCreation(10);

            //Создаем менеджера по умолчанию
            Manager user = new Manager();

            Console.WriteLine("Кто входит в систему?\n" +
                "1 - консультант\n" +
                "2 - менеджер");
            var chose = Console.ReadLine();
            switch (chose)
            {
                case "1":
                    //Делаем консульанта из менеджера
                    user = new Consultant();
                    Console.WriteLine("Выполнен вход как консультант");
                    break;
                case "2":
                    Console.WriteLine("Выполнен вход как менеджер");
                    break;
            }

            bool flag = true;

            while (flag is true)
            {
                Console.WriteLine(
                    "Выерите вариант введя число:\n" +
                    "1 - вывести данные на экран\n" +
                    "2 - измнить фамилию клиента\n" +
                    "3 - измнить имя клиента\n" +
                    "4 - измнить отчество клиента\n" +
                    "5 - измнить номер телефона клиента\n" +
                    "6 - измнить номер паспорта клиента\n" +
                    "7 - добавить нового клиента\n" +
                    "8 - перевод средств между счетами клиента\n" +
                    "9 - открытие депозитного счета клиенту\n" +
                    "10 - пополненние счетов клиента с помощью наличных\n" +
                    "11 - перевод средств между клиентами\n" +
                    "12 - выход из программы");


                string dateNow = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                string newChanges = string.Empty; // Для фиксации изменений
                string userNow = user.GetType().ToString().Substring(6); // Определяем кем были сделаны измнения
                int num = 0;




                var action = Console.ReadLine();
                switch (action)
                {
                    case "1": //Вывод информации
                        user.ShowInfo(clients);
                        break;
                    case "2": //Изменение фамилии
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.SecondNameChange(clients[num]);
                        //newChanges = $"\n#{dateNow} {userNow}: second name";
                        //clients[num].Changes += newChanges;


                        Notify?.Invoke($"\n#{dateNow} {userNow}: изменение фамилии", clients[num]);

                        break;
                    case "3": //Изменение имени
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.FirstNameChange(clients[num]);
                        //newChanges = $"\n#{dateNow} {userNow}: first name";
                        //clients[num].Changes += newChanges;

                        Notify?.Invoke($"\n#{dateNow} {userNow}: изменение имени", clients[num]);

                        break;
                    case "4": //Изменение отчества
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.PatronymicChange(clients[num]);
                        //newChanges = $"\n#{dateNow} {userNow}: patronymic";
                        //clients[num].Changes += newChanges;

                        Notify?.Invoke($"\n#{dateNow} {userNow}: изменение отчества", clients[num]);

                        break;
                    case "5": //Изменение мобильного номера
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.MobNumChange(clients[num]);
                        //newChanges = $"\n#{dateNow} {userNow}: mobile number";
                        //clients[num].Changes += newChanges;

                        Notify?.Invoke($"\n#{dateNow} {userNow}: изменение мобильного номера", clients[num]);

                        break;
                    case "6": //Изменение паспортных данных
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.IdNumChange(clients[num]);
                        //newChanges = $"\n#{dateNow} {userNow}: id number";
                        //clients[num].Changes += newChanges;

                        Notify?.Invoke($"\n#{dateNow} {userNow}: изменение номера паспорта", clients[num]);

                        break;
                    case "7": //Добавление нового клиента
                        user.AddClient(clients);
                        break;
                    case "8": // Перевод средств между счетами клиента
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.MoneyTransferInside(clients[num]);

                        Notify?.Invoke($"\n#{dateNow} {userNow}: перевод средств между своими счетами", clients[num]);

                        break;
                    case "9": // Открытие депозитного счета клиенту
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.OpenDepAcc(clients[num]);


                        Notify?.Invoke($"\n#{dateNow} {userNow}: открытие депозитного счета", clients[num]);

                        break;
                    case "10": // пополненние счетов клиента с помощью наличных
                        Console.WriteLine("Введите Id клиента:");
                        num = Convert.ToInt32(Console.ReadLine());
                        user.CashRefill(clients[num]);

                        Notify?.Invoke($"\n#{dateNow} {userNow}: пополнение счета наличными", clients[num]);

                        break;
                    case "11": // перевод средств между клиентами
                        Console.WriteLine("Введите Id клиента отправителя:");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Id клиента получателя:");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                        user.MoneyTransferBetween(clients[num], clients[num2]);

                        Notify?.Invoke($"\n#{dateNow} {userNow}: перевод средств клиенту " +
                            $"{clients[num2].FirstName} {clients[num2].SecondName}", clients[num]);

                        break;
                    case "12": //Выходи из программы
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод действия, введите 1 или 2\n");
                        break;
                }

            }

        }
    }
}
