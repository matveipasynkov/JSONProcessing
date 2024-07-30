using System;
namespace Library;

/// <summary>
/// Данный класс содержит методы, которые взаимодействуют с пользователем (например, выводят меню на консоль, данные и т.д.).
/// </summary>
public static class InteractWithUser
{
	/// <summary>
	/// Данная переменная содержит путь к открытому файлу.
	/// </summary>
    static string openedFile = "";

	/// <summary>
	/// Данный Enum содержит тип получения данных.
	/// </summary>
    enum TypeOfGettingData
	{
		Standart,
		FromFile
	}

	/// <summary>
	/// Данный Enum содержит тип команды: сортировка и фильтрация.
	/// </summary>
	enum MenuCommand
	{
        Sorting = 1,
		Filtration = 2
	}

	/// <summary>
	/// Данный Enum содержит тип сохранения данных.
	/// </summary>
	enum TypeOfSavingData
	{
		Standart = 1,
		InFile = 2,
		Nothing = 3
	}

	/// <summary>
	/// Данный Enum содержит тип сохранения в файл: в существующий файл или создать новый.
	/// </summary>
	enum TypeOfFile
	{
		Exist,
		NotExist
	}

	/// <summary>
	/// Данный метод выводит приветственное сообщение.
	/// </summary>
	public static void PrintEntryMessage()
	{
		Console.WriteLine("Здравствуйте!");
		Console.WriteLine("Как вы хотите передать JSON с данными: через файл или через консоль?");
	}

	/// <summary>
	/// Данный метод получает данные из файла или консоли.
	/// </summary>
	/// <returns></returns>
	public static Customer[] GetTheData()
	{
		PrintEntryMessage();

        int cmd = Checks.CheckEntryMessage();

		TypeOfGettingData typeOfGetting = (TypeOfGettingData)cmd;

		Customer[] customers = new Customer[0];

		if (typeOfGetting == TypeOfGettingData.Standart)
		{
			Console.WriteLine("Введите данные: ");

			customers = JsonParser.ReadJson();
        }
		else
		{
			string path = Checks.CheckPathOfInput();

			var encoding = Console.InputEncoding;

            using (StreamReader reader = new StreamReader(path))
			{
				Console.SetIn(reader);

				customers = JsonParser.ReadJson();
            }

			StreamReader readerConsole = new StreamReader(Console.OpenStandardInput(), encoding: encoding);
			Console.SetIn(readerConsole);

			openedFile = path;
		}

		return customers;
	}

	/// <summary>
	/// Данный метод выводит команды меню.
	/// </summary>
	public static void PrintMenu()
	{
		Console.WriteLine("Доступные команды:");
		Console.WriteLine("	1. Отсортировать данные по одному из полей.");
		Console.WriteLine("	2. Выполнить фильтрацию по одному из полей.");
	}

	/// <summary>
	/// Данный метод реализует полностью меню: от получения данных до их сохранения.
	/// </summary>
	public static void Menu()
	{
		Customer[] customers = GetTheData();

		Console.Clear();

		PrintMenu();

		MenuCommand cmd = (MenuCommand)Checks.CheckMenuCommand();
		Customer[] result = new Customer[0];

		Console.Clear();

		switch (cmd)
		{
			case MenuCommand.Filtration:

				result = Filtration.FiltrationByValue(customers);

				break;

			case MenuCommand.Sorting:

				// В качестве альтернативного решения можно использовать другие виды сортировок.
				// Реализация альтернативных сортировок доступна в классе Sortings, например: InsertionSort.
				result = Sortings.BubbleSort(customers);

				break;
		}

		Console.Clear();

		// Пустой json я не сохраняю.
		if (result.Length > 0)
		{
			SaveTheData(result);
		}
		else
		{
			Console.WriteLine("Результат - пустой JSON.");
		}

        Console.WriteLine("Выполнено!");
		openedFile = "";
    }

	/// <summary>
	/// Данный метод реализует сохранение результата фильтрации или сортировки.
	/// </summary>
	/// <param name="customers"></param>
	public static void SaveTheData(Customer[] customers)
	{
		PrintSaveTheData();

		TypeOfSavingData typeOfSaving = (TypeOfSavingData)Checks.CheckTypeOfSavingData();

		switch (typeOfSaving)
		{
			case TypeOfSavingData.Standart:

				JsonParser.WriteJson(customers);
				Console.WriteLine();

				break;

			case TypeOfSavingData.InFile:

				Console.WriteLine("Вы хотите перезаписать файл, из которого были получены данные, или записать в новый?");
				Console.WriteLine("Обращаем внимание, что в случае, если данные были получены с консоли, то перезапись файла будет равносильна сохранению в новый.");

				TypeOfFile typeOfFile = (TypeOfFile)Checks.CheckTypeOfFile();

				string path = "";

				switch (typeOfFile)
				{
					case TypeOfFile.Exist:

						if (openedFile != "")
						{
							path = openedFile;
						}
						else
						{
							Console.WriteLine("Вы вводили данные с консоли, поэтому такая функция недоступна.");
							Console.WriteLine("Вам будет предложено сохранить данные в новый файл.");
							path = Checks.CheckPathOfOutput();
						}

						break;

					case TypeOfFile.NotExist:

						path = Checks.CheckPathOfOutput();

						break;
				}

                var encoding = Console.OutputEncoding;

                using (StreamWriter writer = new StreamWriter(path))
                {
                    Console.SetOut(writer);
					JsonParser.WriteJson(customers);
                }

                StreamWriter writerConsole = new StreamWriter(Console.OpenStandardOutput(), encoding: encoding);
				writerConsole.AutoFlush = true;
                Console.SetOut(writerConsole);

                break;
		}
	}

	/// <summary>
	/// Данный метод выводит пользователю вопрос: как он хочет вывести/сохранить данные?
	/// </summary>
	public static void PrintSaveTheData()
	{
        Console.WriteLine("Как вы хотите сохранить данные?");
        Console.WriteLine("	1. Вывести на консоль.");
        Console.WriteLine("	2. Сохранить в файл.");
        Console.WriteLine("	3. Я не хочу выводить/сохранять данные.");
    }
}