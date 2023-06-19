using System;
using System.IO;

class Program
{
    static void Main()
    {
        string resultPath = @"C:\Users\Nazaw\Documents\UNIX OS Labs\Lab1\result.txt";

        string[] lines = File.ReadAllLines(resultPath);
        SortedDictionary<int, long> numOfFilesBySize = new SortedDictionary<int, long>();

        for (var i = 0; i < lines.Length; i += 1)
        {
            long fileSize;
            if (!long.TryParse(lines[i], out fileSize)) {
                continue;
            }

            int n = (Int32) Math.Floor(Math.Log2(fileSize / 1024));
            if(n < 0) {
                n = 0;
            }

            numOfFilesBySize[n] = numOfFilesBySize.GetValueOrDefault(n, 0) + 1;
        }

        using (StreamWriter writer = new StreamWriter("groupedFileSizes.txt"))
        {
            foreach (var pair in numOfFilesBySize)
            {
                writer.WriteLine(pair.Key.ToString() + ": " + pair.Value.ToString());
            }
        }
    }
}