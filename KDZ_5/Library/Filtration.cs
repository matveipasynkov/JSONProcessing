using System;
namespace Library;

/// <summary>
/// Данный класс содержит методы реализации фильтрации данных.
/// </summary>
public static class Filtration
{
    /// <summary>
    /// Данный метод реализовывает фильтрацию данных.
    /// </summary>
    /// <param name="customers"></param>
    /// <returns></returns>
	public static Customer[] FiltrationByValue(Customer[] customers)
	{
		Customer[] result = new Customer[0];

		Console.WriteLine("Доступные поля данных: CustomerId, Name, Email, Age, City, IsPremium, Purchases.");
		Console.WriteLine("По какому полю вы хотите отфильтровать данные?");

		string field = Checks.CheckField();

		switch (field)
		{
			case "CustomerId":

				int customerId = Checks.CheckCustomerId();

				foreach (Customer customer in customers)
				{
					if (customer.CustomerId == customerId)
					{
						Array.Resize(ref result, result.Length + 1);
						result[^1] = customer;
					}
				}

				break;

			case "Name":

                Console.Write("Введите значение Name: ");

				string name = Console.ReadLine();

				foreach (Customer customer in customers)
				{
					if (customer.Name == name)
					{
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
				}

				break;

			case "Email":

                Console.Write("Введите значение Email: ");

                string email = Console.ReadLine();

                foreach (Customer customer in customers)
                {
                    if (customer.Email == email)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
                }

                break;

			case "Age":

				int age = Checks.CheckAge();

                foreach (Customer customer in customers)
                {
                    if (customer.Age == age)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
                }

                break;

			case "City":

                Console.Write("Введите значение City: ");

                string city = Console.ReadLine();

                foreach (Customer customer in customers)
                {
                    if (customer.City == city)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
                }

                break;

            case "IsPremium":

                bool isPremium = Checks.CheckIsPremium();

                foreach (Customer customer in customers)
                {
                    if (customer.IsPremium == isPremium)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
                }

                break;

            case "Purchases":

                int count = Checks.CheckCountOfPurchases();

                string[] valuesOfPurchases = new string[count];

                for (int i = 0; i < count; ++i)
                {
                    Console.Write($"Введите {i + 1}-ое значение Purchases: ");

                    valuesOfPurchases[i] = Console.ReadLine();
                }

                foreach (Customer customer in customers)
                {
                    bool flagValueInPurchases = true;

                    for (int i = 0; i < count; ++i)
                    {
                        if (Array.IndexOf(customer.Purchases, valuesOfPurchases[i]) == -1)
                        {
                            flagValueInPurchases = false;
                        }
                    }

                    if (flagValueInPurchases)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[^1] = customer;
                    }
                }

                break;
        }

        return result;
	}
}

