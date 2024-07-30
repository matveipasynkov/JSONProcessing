using System;
namespace Library;

/// <summary>
/// Класс, содержащий реализацию различных видов сортировок и сопутствующих методов к ним.
/// </summary>
public static class Sortings
{
    /// <summary>
    /// Данный метод реализует сортировку пузырьком.
    /// Внимание: По полю Purchases JSON сортируется по кол-ву элементов в данном массиве (!!!).
    /// </summary>
    /// <param name="customers"></param>
    /// <returns></returns>
    public static Customer[] BubbleSort(Customer[] customers)
    {
        PrintInstructionsForSorting();

        string field = Checks.CheckField();

        bool flagStopBubbleSort = false;

        while (!flagStopBubbleSort)
        {
            flagStopBubbleSort = true;

            for (int i = 0; i < customers.Length - 1; ++i)
            {
                switch (field)
                {
                    case "CustomerId":

                        if (customers[i].CustomerId > customers[i + 1].CustomerId)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "Name":

                        if (customers[i].Name.CompareTo(customers[i + 1].Name) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "Email":

                        if (customers[i].Email.CompareTo(customers[i + 1].Email) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "Age":

                        if (customers[i].Age > customers[i + 1].Age)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "City":

                        if (customers[i].City.CompareTo(customers[i + 1].City) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "IsPremium":

                        if (Convert.ToInt32(customers[i].IsPremium) > Convert.ToInt32(customers[i + 1].IsPremium))
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "Purchases":

                        if (customers[i].Purchases.Length > customers[i + 1].Purchases.Length)
                        {
                            customers = Swap(customers, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;
                }
            }
        }

        return customers;
    }

    /// <summary>
    /// Данный метод реализует сортировку вставками.
    /// Внимание: По полю Purchases JSON сортируется по кол-ву элементов в данном массиве (!!!).
    /// </summary>
    /// <param name="customers"></param>
    /// <returns></returns>
    public static Customer[] InsertionSort(Customer[] customers)
    {
        PrintInstructionsForSorting();

        string field = Checks.CheckField();

        for (int j = 1; j < customers.Length; ++j)
        {
            for (int i = j - 1; i >= 0; --i)
            {
                switch (field)
                {
                    case "CustomerId":

                        if (customers[i].CustomerId > customers[i + 1].CustomerId)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "Name":

                        if (customers[i].Name.CompareTo(customers[i + 1].Name) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "Email":

                        if (customers[i].Email.CompareTo(customers[i + 1].Email) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "Age":

                        if (customers[i].Age > customers[i + 1].Age)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "City":

                        if (customers[i].City.CompareTo(customers[i + 1].City) > 0)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "IsPremium":

                        if (Convert.ToInt32(customers[i].IsPremium) > Convert.ToInt32(customers[i + 1].IsPremium))
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;

                    case "Purchases":

                        if (customers[i].Purchases.Length > customers[i + 1].Purchases.Length)
                        {
                            customers = Swap(customers, i, i + 1);
                        }

                        break;
                }
            }
        }

        return customers;
    }

    /// <summary>
    /// Данный метод реализует обмен значениями между объектами массива типа Customer[].
    /// </summary>
    /// <param name="customers"></param>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <returns></returns>
    public static Customer[] Swap(Customer[] customers, int index1, int index2)
    {
        Customer tmp = customers[index1];
        customers[index1] = customers[index2];
        customers[index2] = tmp;

        return customers;
    }

    /// <summary>
    /// Данный метод выводит инструкции по сортировке для пользователя.
    /// </summary>
    public static void PrintInstructionsForSorting()
    {
        Console.WriteLine("Доступные поля данных: CustomerId, Name, Email, Age, City, IsPremium, Purchases.");
        Console.WriteLine("В случае с Purchases сортировка будет происходить по количеству элементов.");
        Console.WriteLine("По какому полю вы хотите отсортировать данные?");
    }
}

