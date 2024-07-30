namespace Library;
using System.Text.RegularExpressions;

/// <summary>
/// Класс JsonParser из условия.
/// </summary>
public static class JsonParser
{
    /// <summary>
    /// Данный Enum содержит признаки каждого объекта из JSON-файла.
    /// </summary>
    enum Features
    {
        customerId,
        name,
        email,
        age,
        city,
        isPremium,
        purchases
    }

    /// <summary>
    /// Метод ReadJson из условия.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static Customer[] ReadJson()
    {
        try
        {
            string data = "";

            bool flagEndOfInput = false;

            // Данные из файла или консоли считываются построчно (!!!).
            while (!flagEndOfInput)
            {
                string input = Console.ReadLine();

                if (input != "]")
                {
                    data += input + "\n";
                }
                else
                {
                    data += input;
                    flagEndOfInput = true;
                }
            }

            string[] values = ToolsForMatches.ArrayOfMatches(data: data, expression: @"""[^""]*"": [A-Za-z0-9]+");
            string[] strings = ToolsForMatches.ArrayOfMatches(data: data, expression: @"""[^""]*"":\s""[^""]*""");
            string[] arrays = ToolsForMatches.ArrayOfMatches(data: data, expression: @"""[^""]*"": \[[^\]]*\]");

            string[] allMatches = ToolsForMatches.ConcatenationOfMatches(values: values, strings: strings, arrays: arrays);

            Customer[] customers = new Customer[arrays.Length];

            // В данном цикле мы все найденные Matches в виде строк переводим в массив объектов типа Customer[].
            for (int i = 0; i < customers.Length; ++i)
            {
                int customerId = 0;
                string name = "";
                string email = "";
                int age = 0;
                string city = "";
                bool isPremium = true;
                string[] purchases = new string[0];

                for (int j = 0; j < 7; ++j)
                {
                    Features type = (Features)j;
                    string[] info = allMatches[i * 7 + j].Split(": ");

                    switch (type)
                    {
                        case Features.customerId:

                            customerId = int.Parse(info[1]);

                            break;

                        case Features.name:

                            name = info[1][1..^1];

                            break;

                        case Features.email:

                            email = info[1][1..^1];

                            break;

                        case Features.age:

                            age = int.Parse(info[1]);

                            break;

                        case Features.city:

                            city = info[1][1..^1];

                            break;

                        case Features.isPremium:

                            if (info[1] == "true")
                            {
                                isPremium = true;
                            }
                            else if (info[1] == "false")
                            {
                                isPremium = false;
                            }
                            else
                            {
                                throw new ArgumentException();
                            }

                            break;

                        case Features.purchases:

                            string[] parsed = info[1].Split("\n    ");
                            parsed[parsed.Length - 2] += ",";

                            purchases = new string[parsed.Length - 2];

                            for (int k = 0; k < purchases.Length; ++k)
                            {
                                purchases[k] = parsed[1 + k][3..^2];
                            }

                            break;
                    }
                }

                customers[i] = new Customer(customerId, name, email, age, city, isPremium, purchases);
            }

            // Проверка JSON'а на корректность.
            if (customers.Length == 0 || !Checks.CheckBrackets(data))
            {
                // Если JSON не корректен, то так как аргумент функции ReadJson не корректен (наш файл), мы соотвественно выкидываем ArgumentException.
                throw new ArgumentException();
            }

            return customers;
        }
        catch
        {
            // Если что-то пошло не так, то это значит, что JSON не корректен, и поэтому мы, как неправильному аргументу функции ReadJson, выкидываем ArgumentException.
            throw new ArgumentException();
        }
    }

    /// <summary>
    /// Метод WriteJson из условия.
    /// </summary>
    /// <param name="customers"></param>
    public static void WriteJson(Customer[] customers)
    {
        string result = "";

        result += "[\n";

        for (int i = 0; i < customers.Length; ++i)
        {
            Customer customer = customers[i];

            result += "  {\n";
            result += $"    \"customer_id\": {customer.CustomerId},\n";
            result += $"    \"name\": \"{customer.Name}\",\n";
            result += $"    \"email\": \"{customer.Email}\",\n";
            result += $"    \"age\": {customer.Age},\n";
            result += $"    \"city\": \"{customer.City}\",\n";
            result += $"    \"is_premium\": {customer.IsPremium.ToString().ToLower()},\n";
            result += $"    \"purchases\": [\n";

            foreach (string purchase in customer.Purchases[..^1])
            {
                result += $"      \"{purchase}\",\n";
            }

            result += $"      \"{customer.Purchases[^1]}\"\n";
            result += "    ]\n";

            if (i != customers.Length - 1)
            {
                result += "  },\n";
            }
            else
            {
                result += "  }\n";
            }
        }

        result += "]";

        Console.Write(result);
    }
}