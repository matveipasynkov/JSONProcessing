using System;
namespace Library;

/// <summary>
/// Данный класс содержит методы различных проверок данных, введённых пользователем.
/// </summary>
public static class Checks
{
	/// <summary>
	/// Данный метод возвращает проверенную команду пользователя в ответ на приветственное сообщение.
	/// </summary>
	/// <returns></returns>
	public static int CheckEntryMessage()
	{
		bool flagEntryMessage = false;

		int cmd = 0;

		while (!flagEntryMessage)
		{
			Console.Write("Введите команду (0 - через консоль, 1 - через файл): ");

			string msg = Console.ReadLine();

			if (int.TryParse(msg, out cmd))
			{
				if (cmd >= 0 && cmd <= 1)
				{
					flagEntryMessage = true;
				}
			}

			if (!flagEntryMessage)
			{
                Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
            }
		}

		return cmd;
	}

	/// <summary>
	/// Данный метод возвращает проверенный путь к входному файлу.
	/// </summary>
	/// <returns></returns>
	public static string CheckPathOfInput()
	{
		bool flagPath = false;

		string path = "";

		while (!flagPath)
		{
			Console.Write("Введите путь: ");

			path = Console.ReadLine();

			try
			{
				File.ReadAllLines(path);

				if (path[^5..] == ".json")
				{
					flagPath = true;
				}
				else
				{
					Console.Write("Файл неверного формата. Попробуйте ещё раз. ");
				}
			}
			catch
			{
				Console.Write("Введён неверный путь. Попробуйте ещё раз. ");
			}
		}

		return path;
	}

	/// <summary>
	/// Данный метод возвращает проверенную команду меню от пользователя.
	/// </summary>
	/// <returns></returns>
	public static int CheckMenuCommand()
	{
		bool flagMenuCommand = false;

		int cmd = 0;

		while (!flagMenuCommand)
		{
			Console.Write("Введите команду: ");

			string msg = Console.ReadLine();

			if (int.TryParse(msg, out cmd))
			{
				if (cmd >= 1 && cmd <= 2)
				{
					flagMenuCommand = true;
				}
			}

			if (!flagMenuCommand)
			{
				Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
			}
		}

		return cmd;
	}

	/// <summary>
	/// Данный метод возвращает проверенное поле класса Customer от пользователя.
	/// </summary>
	/// <returns></returns>
	public static string CheckField()
	{
		bool flagField = false;

		string[] types = { "CustomerId", "Name", "Email", "Age", "City", "IsPremium", "Purchases" };

		string cmd = "";

		while (!flagField)
		{
			Console.Write("Введите название поля: ");

			cmd = Console.ReadLine();

			int index = Array.IndexOf(types, cmd);

			if (index != -1)
			{
				flagField = true;
			}
			else
			{
				Console.Write("Введено неверное поле. Попробуйте ещё раз. ");
			}
		}

		return cmd;
	}

	/// <summary>
	/// Данный метод проверяет корректность введённого значения CustomerId.
	/// </summary>
	/// <returns></returns>
	public static int CheckCustomerId()
	{
		bool flagCustomerId = false;

		int id = 0;

		while (!flagCustomerId)
		{
            Console.Write("Введите значение CustomerId: ");

            string value = Console.ReadLine();

			if (int.TryParse(value, out id))
			{
				if (id >= 1)
				{
					flagCustomerId = true;
				}
				else
				{
                    Console.Write("CustomerId должен быть не меньше 1. Попробуйте ещё раз. ");
                }
			}
			else
			{
				Console.Write("Введён неверный CustomerId. Попробуйте ещё раз. ");
			}
        }

		return id;
	}

    /// <summary>
    /// Данный метод проверяет корректность введённого значения Age.
    /// </summary>
    /// <returns></returns>
    public static int CheckAge()
	{
		bool flagCheckAge = false;

		int age = 0;

		while (!flagCheckAge)
		{
            Console.Write("Введите значение Age: ");

            string value = Console.ReadLine();

			if (int.TryParse(value, out age))
			{
				if (age >= 1)
				{
					flagCheckAge = true;
				}
				else
				{
					Console.Write("Возраст не может быть меньше 1. Попробуйте ещё раз. ");
				}
			}
			else
			{
				Console.Write("Возраст должен быть числом. Попробуйте ещё раз. ");
			}
        }

		return age;
	}

    /// <summary>
    /// Данный метод проверяет корректность введённого значения IsPremium.
    /// </summary>
    /// <returns></returns>
    public static bool CheckIsPremium()
	{
		bool flagCheckIsPremium = false;

		bool isPremium = false;

		while (!flagCheckIsPremium)
		{
			Console.Write("Введите значение IsPremium (true или false): ");

			string value = Console.ReadLine();

			if (value == "true")
			{
				isPremium = true;
				flagCheckIsPremium = true;
			}
			else if (value == "false")
			{
				flagCheckIsPremium = true;
			}
			else
			{
				Console.Write("Введено неверное значение IsPremium. Попробуйте ещё раз. ");
			}
		}

		return isPremium;
	}

	/// <summary>
	/// Данный метод возвращает корректное значение кол-во элементов массива Purchases от пользователя.
	/// </summary>
	/// <returns></returns>
	public static int CheckCountOfPurchases()
	{
		bool flagCheckCount = false;

		int count = 0;

		while (!flagCheckCount)
		{
			Console.Write("Введите количество значений Purchases, по которым вы хотите сделать фильтрацию: ");

			string value = Console.ReadLine();

			if (int.TryParse(value, out count))
			{
				if (count > 0)
				{
					flagCheckCount = true;
				}
				else
				{
					Console.Write("Количество значений должно быть больше 0. Попробуйте ещё раз. ");
				}
			}
			else
			{
				Console.Write("Количество значений должно быть целым числом. Попробуйте ещё раз. ");
			}
		}

		return count;
	}

	/// <summary>
	/// Данный метод возвращает корректный тип сохранения данных от пользователя.
	/// </summary>
	/// <returns></returns>
	public static int CheckTypeOfSavingData()
	{
        bool flagCheckTypeOfSaving = false;

        int typeOfSaving = 0;

		while (!flagCheckTypeOfSaving)
		{
			Console.Write("Введите команду: ");

			string value = Console.ReadLine();

			if (int.TryParse(value, out typeOfSaving))
			{
				if (typeOfSaving >= 1 && typeOfSaving <= 3)
				{
					flagCheckTypeOfSaving = true;
				}
				
			}

			if (!flagCheckTypeOfSaving)
			{
				Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
			}
		}

		return typeOfSaving;
    }

	/// <summary>
	/// Данный метод проверяет корректность типа сохранения в файл от пользователя.
	/// </summary>
	/// <returns></returns>
	public static int CheckTypeOfFile()
	{
		bool flagCheckTypeOfFile = false;

		int typeOfFile = 0;

		while (!flagCheckTypeOfFile)
		{
			Console.Write("Введите команду (0 - перезаписать открытый файл, 1 - записать в новый файл): ");

			string value = Console.ReadLine();

			if (int.TryParse(value, out typeOfFile))
			{
				if (typeOfFile >= 0 && typeOfFile <= 1)
				{
					flagCheckTypeOfFile = true;
				}
			}

			if (!flagCheckTypeOfFile)
			{
				Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
			}
		}

		return typeOfFile;
	}

	/// <summary>
	/// Данный метод возвращает корректный путь созданного файла, в который мы хотим сохранить данные.
	/// </summary>
	/// <returns></returns>
	public static string CheckPathOfOutput()
	{
		bool flagCheckPath = false;

		string path = "";

		while (!flagCheckPath)
		{
			Console.Write("Введите путь к файлу (он должен быть в .json формате): ");

			path = Console.ReadLine();

			if (!File.Exists(path) && path[^5..] == ".json")
			{
				try
				{
					File.Create(path).Dispose();
					flagCheckPath = true;
				}
				catch
				{
					Console.Write("Путь к файлу неверного формата. Попробуйте ещё раз. ");
				}
			}
			else
			{
				Console.Write("Файл уже существует или он не json-формата. Попробуйте ещё раз. ");
			}
		}

		return path;
	}

	/// <summary>
	/// Данный метод проверяет расположение скобок в JSON-файле.
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	public static bool CheckBrackets(string data)
	{
		bool flagCheckStartBracket = false, flagCheckEndBracket = false, flagInternalBrackets = true;

		bool OpenedInternalBracket = false;

		if (data[0] == '[')
		{
			flagCheckStartBracket = true;
		}

		if (data[^1] == ']')
		{
			flagCheckEndBracket = true;
		}

		for (int i = 0; i < data.Length; ++i)
		{
			if (data[i] == '{')
			{
				if (!OpenedInternalBracket)
				{
					OpenedInternalBracket = true;
				}
				else
				{
					flagInternalBrackets = false;
				}
			}
			else if (data[i] == '}')
			{
				if (OpenedInternalBracket && (data[i..(i + 2)] == "}," || data[i..(i + 3)] == "}\n]"))
				{
					OpenedInternalBracket = false;
				}
				else
				{
                    flagInternalBrackets = false;
				}
			}
		}

		return flagCheckStartBracket && flagCheckEndBracket && flagInternalBrackets;
	}
}