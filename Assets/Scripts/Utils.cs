using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Utils
{
    public static void PrintList<T>(List<T> listToPrint, string listName = "List")
    {
        if (listToPrint == null)
        {
            Debug.Log(listName + " is null.");
            return;
        }

        if (listToPrint.Count == 0)
        {
            Debug.Log(listName + " is empty.");
            return;
        }

        // Use StringBuilder for efficient string concatenation
        StringBuilder sb = new StringBuilder();

        // Print a message before printing the values of the list
        sb.Append(listName).Append(" contents (").Append(listToPrint.Count).Append(" items): [");

        // Loop through the list and append each item
        for (int i = 0; i < listToPrint.Count; i++)
        {
            sb.Append(listToPrint[i]);
            // Add a comma and space for all but the last item
            if (i < listToPrint.Count - 1)
            {
                sb.Append(", ");
            }
        }

        sb.Append("]");

        // Print the final, formatted string to the console
        Debug.Log(sb.ToString());
    }

    public static T GetRandomElement<T>(this T[] array)
    {
        if (array == null || array.Length == 0) return default(T);

        T randomElement = array[Random.Range(0, array.Length)];
        return randomElement;
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        if (list == null || list.Count == 0) return default(T);

        T randomElement = list[Random.Range(0, list.Count)];
        return randomElement;
    }

    public static Color HexToColor(string hex)
    {
        // Add the '#' if it's missing.
        if (!hex.StartsWith("#"))
        {
            hex = "#" + hex;
        }

        // Use Unity's built-in converter.
        if (ColorUtility.TryParseHtmlString(hex, out Color color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning("Could not parse hex color: " + hex);
            // Return a bright, obvious color to indicate an error.
            return Color.magenta;
        }
    }
}
