using System;
using System.Collections.Generic;
namespace HW_13
{
	public class Client
	{
		static Random randomize = new Random();
		static Client()
		{
			randomize = new Random();
		}

		/// <summary>
		/// Создание клиента
		/// </summary>
		/// <param name="SecondName"></param>
		/// <param name="FirstName"></param>
		/// <param name="Patronymic"></param>
		/// <param name="MobileNumber"></param>
		/// <param name="IdNumber"></param>
		public Client(string SecondName, string FirstName, string Patronymic,
		string MobileNumber, string IdNumber, string IndexClient, string Changes, NotDepositeAccount NotDepAcc, DepositeAccount DepAcc)
		{
			if (SecondName == String.Empty) { SecondName = $"{Guid.NewGuid().ToString().Substring(0, 5)}"; }
			this.secondName = SecondName;

			if (FirstName == String.Empty) { FirstName = $"{Guid.NewGuid().ToString().Substring(0, 5)}"; }
			this.firstName = FirstName;

			if (Patronymic == String.Empty) { Patronymic = $"{Guid.NewGuid().ToString().Substring(0, 5)}"; }
			this.patronymic = Patronymic;

			if (MobileNumber == String.Empty) { MobileNumber = $"0000000000"; }
			this.mobileNumber = MobileNumber;

			if (IdNumber == String.Empty) { IdNumber = $"0000 000000"; }
			this.idNumber = IdNumber;

			this.indexClient = IndexClient;

			this.changes = Changes;

			NotDepAcc = new NotDepositeAccount();
			this.notDepAcc = NotDepAcc;

			if (DepAcc is null) depAcc = new DepositeAccount();

		}

		/// <summary>
		/// Создание клиента с автопарамерами
		/// </summary>
		public Client() : this("", "", "", "", "", "", "", new NotDepositeAccount(), null)
		{ }

		private string secondName; // Поле фамилии
		private string firstName; // Поле имени
		private string patronymic; // Поле отчества
		private string mobileNumber; // Поле мобильного номера телефона
		private string idNumber; // Поле номера паспорта
		private string indexClient; // Индекс клиента в базе данных
		private string changes; // Информация об изменениях
		private NotDepositeAccount notDepAcc; // Не депозитный аккаунт
		private DepositeAccount depAcc; // Депозитный аккаунт


		/// <summary>
        /// Не депозитный счет
        /// </summary>
		public string NotDepAcc
		{
			get { return this.notDepAcc.AccountInformation(); }
			set { this.notDepAcc = new NotDepositeAccount(); }
		}

		/// <summary>
		/// Не депозитный счет
		/// </summary>
		public string DepAcc
		{
			get { return this.depAcc.AccountInformation(); }
			set { this.depAcc = new DepositeAccount(); }
		}

		/// <summary>
		/// Фамилия
		/// </summary>
		public string SecondName
		{
			get { return this.secondName; }
			set { this.secondName = value; }
		}

		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		/// <summary>
		/// Отчество
		/// </summary>
		public string Patronymic
		{
			get { return this.patronymic; }
			set { this.patronymic = value; }
		}

		/// <summary>
		/// Мобильный телефон
		/// </summary>
		public string MobileNumber
		{
			get { return this.mobileNumber; }
			set { this.mobileNumber = value; }
		}

		/// <summary>
		/// Серия и номер паспорта
		/// </summary>
		public string IdNumber
		{
			get { return this.idNumber; }
			set { this.idNumber = value; }
		}

		/// <summary>
		/// Индекс
		/// </summary>
		public string IndexClient
		{
			get { return this.indexClient; }
			set { this.indexClient = value; }
		}

		/// <summary>
		/// Внесенные изменения
		/// </summary>
		public string Changes
		{
			get { return this.changes; }
			set { this.changes = value; }
		}

		///// <summary>
  //      /// Запись сообщения об измменениях
  //      /// </summary>
  //      /// <param name="message"></param>
		//public delegate void AccountHandler(string message);

		///// <summary>
  //      /// Определения события
  //      /// </summary>
  //      public event AccountHandler? Notify;

		/// <summary>
		/// Информация о клиенте
		/// </summary>
		/// <returns></returns>
		public string ClientInformation()
		{
			return String.Format("Second Name:{0,-10} | First Name: {1,-15} | " +
				"Patronymic: {2 ,-15} | Mobile Number: {3, -11} | Id Number: {4, -12} | Id {5, -4} " +
				"| Changes: {6, -30} \n {7, -30} \n {8,-30}",
				this.secondName,
				this.firstName,
				this.patronymic,
				this.mobileNumber,
				this.idNumber,
				this.indexClient,
				this.changes,
				this.notDepAcc.AccountInformation(),
				this.depAcc.AccountInformation()
				);

		}

		/// <summary>
		/// Создание коллекции авто клиентов
		/// </summary>
		/// <param name="j"></param>
		public List<Client> NumOfClientsCreation(int j)
		{
			//Создаем коллекцию для хранения клиентов
			List<Client> clients = new List<Client>();

			//Наполняем коллекцию клиентами савтопараметрами
			for (int i = 0; i < +j; i++)
			{
				clients.Add(new Client("", "", "", "", "", i.ToString(), "", new NotDepositeAccount(), null));
			}
			return clients;
		}

		/// <summary>
        /// Открытие депозитного счета клиенту
        /// </summary>
		public void OpenDepAcc()
        {
			Console.WriteLine("Введите срок вклада в месяцах (до 6 месяцев ставка 12%, свыше 6 месяцев 24%):");
			this.depAcc.Term = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Каким способом хотите пополнить счет\n" +
					"1 - переводом с недепозитного счета\n" +
					"2 - наличными");
			var chose = Console.ReadLine();
			switch (chose)
			{
				case "1":
					this.notDepAcc.MoneyTransfe(this.depAcc);
					break;
				case "2":
					this.depAcc.CashRefill();
					break;
				default:
					Console.WriteLine("Некорректный ввод, введите 1 или 2\n");
					break;
			}

		}

		/// <summary>
        /// Перевод на депозитый счет с обычного внутри одного клиента
        /// </summary>
		public void TransferToDep()
		{
			if (this.depAcc.AccountBalance == 0 || this.depAcc.Term == 0)
			{
				Console.WriteLine("Депозитный счет не открывался, хотите открыть?\n" +
                    "1 - да\n" +
                    "2 - нет");
				var chose = Console.ReadLine();
				switch (chose)
				{
                    case "1":
						OpenDepAcc();
                        break;
					case "2":
						break;
					default:
						Console.WriteLine("Некорректный ввод, введите 1 или 2\n");
						break;
				}
			}
            else
            {
				this.notDepAcc.MoneyTransfe(this.depAcc);
			}

		}

		/// <summary>
		/// Перевод на обычный счет с депозитного внутри одного клиента
		/// </summary>
		public void TransferToNotDep()
		{
			if (this.depAcc.AccountBalance == 0 || this.depAcc.Term == 0)
            {
				Console.WriteLine("Депозитный счет не открывался");
			}
			else
            {
				this.depAcc.MoneyTransfe(this.notDepAcc);
			}
		}

		/// <summary>
        /// Пополнение счета клиента с помощью наличных
        /// </summary>
		public void AccountCashRefill()
        {
			Console.WriteLine("Выберите счет пополнения с помощью наличных:\n" +
					"1 - Основной\n" +
					"2 - Депозитный\n" +
                    "3 - Отмена");
			var chose = Console.ReadLine();
			switch (chose)
			{
				case "1":
					this.notDepAcc.CashRefill();
					break;
				case "2":
					if (this.depAcc.AccountBalance == 0 || this.depAcc.Term == 0)
					{
						Console.WriteLine("Депозитный счет не открывался, хотите открыть?\n" +
							"1 - да\n" +
							"2 - нет");
						var chose2 = Console.ReadLine();
						switch (chose2)
						{
							case "1":
								OpenDepAcc();
								break;
							case "2":
								break;
							default:
								Console.WriteLine("Некорректный ввод, введите 1 или 2\n");
								break;
						}
					}
					else
					{
						this.depAcc.CashRefill();
					}
					break;
				case "3":
					break;
				default:
					Console.WriteLine("Некорректный ввод, введите 1 или 2\n");
					break;
			}
		}

		/// <summary>
        /// Перевод другому клиенту
        /// </summary>
        /// <param name="reciver"></param>
		public void TransferToOtherClient( Client reciver)
        {
			Console.WriteLine("Перевод может быть осуществлен только между недепозитными счетами клиентов!");
			this.notDepAcc.MoneyTransfe(reciver.notDepAcc);
			
		}
	}
}
