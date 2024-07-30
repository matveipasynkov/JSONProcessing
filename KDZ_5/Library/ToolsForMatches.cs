using System;
using System.Text.RegularExpressions;

namespace Library;

/// <summary>
/// Данный класс реализует дополнительные инструменты при работе с объектами типа Match и MatchCollection.
/// </summary>
public static class ToolsForMatches
{
    /// <summary>
    /// Данный метод возвращает массив строк из JSON'а, соотвествующих данному выражению.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
	public static string[] ArrayOfMatches(string data, string expression)
	{
        Regex regex = new Regex(expression);

        MatchCollection matches = regex.Matches(data);

        string[] result = new string[matches.Count];
        int index = 0;

        foreach (Match match in matches)
        {
            result[index] = match.Value;
            ++index;
        }

        return result;
    }

    /// <summary>
    /// Данный метод объединяет несколько массивов строк, найденных с помощью Match(es).
    /// </summary>
    /// <param name="values"></param>
    /// <param name="strings"></param>
    /// <param name="arrays"></param>
    /// <returns></returns>
    public static string[] ConcatenationOfMatches(string[] values, string[] strings, string[] arrays)
    {
        string[] allMatches = new string[values.Length + strings.Length + arrays.Length];

        int id = 0;

        for (int i = 0; i < allMatches.Length; i += 7)
        {
            allMatches[i] = values[3 * id];
            allMatches[i + 1] = strings[3 * id];
            allMatches[i + 2] = strings[3 * id + 1];
            allMatches[i + 3] = values[3 * id + 1];
            allMatches[i + 4] = strings[3 * id + 2];
            allMatches[i + 5] = values[3 * id + 2];
            allMatches[i + 6] = arrays[id];
            ++id;
        }

        return allMatches;
    }
}

