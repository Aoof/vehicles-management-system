namespace Services;
using System;
using System.IO;

public static class FileHandler
{
    public static string FilePath { get; set; } = "VMS_SaveFile.dat";
    public static void WriteToFile(string path, string content)
    {
        Console.WriteLine("Writing to file...");
    }
}