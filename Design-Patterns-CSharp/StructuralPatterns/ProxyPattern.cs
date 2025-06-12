using System;

namespace Design_Patterns_CSharp.StructuralPatterns;

interface IFileReader
{
    void LoadFile();
}

class FileReader : IFileReader
{
    private readonly string fileName;

    public FileReader(string fileName)
    {
        this.fileName = fileName;
    }
    public void LoadFile()
    {
        Console.WriteLine($"Loading file {fileName}");
    }
}

class FileReaderProxy : IFileReader
{
    private readonly string fileName;
    Lazy<FileReader> fileReader;
    private HashSet<string> allowedExtensions = [".txt", ".docx"];

    public FileReaderProxy(string fileName)
    {
        if (!allowedExtensions.Contains(Path.GetExtension(fileName)))
        {
            throw new ArgumentException("Only files with extension of .txt or .docx are supported.");
        }

        this.fileName = fileName;
        fileReader = new Lazy<FileReader>(() => new FileReader(fileName));
    }

    public void LoadFile() => fileReader.Value.LoadFile();
}

public class ProxyPatternDemo
{
    public static void Run()
    {
        IFileReader fileReader = new FileReaderProxy("test.txt");
        fileReader.LoadFile();
    }
}
