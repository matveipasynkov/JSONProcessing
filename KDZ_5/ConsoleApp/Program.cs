// Пасынков Матвей Евгеньевич, КДЗ, Вариант 3.
using Library;

class Program
{
    static void Main()
    {
        do
        {
            try
            {
                // Очищаем консоль перед очередной итерацией.
                Console.Clear();

                InteractWithUser.Menu();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("На вход был подан пустой JSON-файл, или он неверного формата.");
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка.");
            }
            finally
            {
                Console.WriteLine("Нажмите ESC, чтобы завершить программу. Иначе нажмите любую другую кнопку.");
            }
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}