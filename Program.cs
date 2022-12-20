using System;
using System.Collections.Generic;
using System.Timers;

namespace HW_13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Инициализируем меню
            Menu menu = new Menu();
            menu.Notify += AddChanges; // Добавляем обработчик для события Notify
            menu.Start();

            // Обработчик события
            void AddChanges(string message, Client client) => client.Changes += message;
        }

        
    }

}       