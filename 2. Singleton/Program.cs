using System;
using System.Collections.Generic;

public class PrintJob
{
    public int Id { get; set; }
    public string Content { get; set; }

    public PrintJob(int id, string content)
    {
        Id = id;
        Content = content;
    }
}

public class PrintBuffer
{
    private static PrintBuffer _instance;
    private Queue<PrintJob> _buffer;

    private PrintBuffer()
    {
        _buffer = new Queue<PrintJob>();
    }

    public static PrintBuffer GetInstance()
    {
        if (_instance == null)
        {
            _instance = new PrintBuffer();
        }
        return _instance;
    }

    public void AddJob(PrintJob job)
    {
        _buffer.Enqueue(job);
    }

    public void PrintNextJob()
    {
        if (_buffer.Count > 0)
        {
            PrintJob job = _buffer.Dequeue();
            Console.WriteLine($"Printing job {job.Id}: {job.Content}");
        }
        else
        {
            Console.WriteLine("No jobs in the buffer.");
        }
    }
}

// Example usage
class Program
{
    static void Main()
    {
        PrintBuffer printBuffer = PrintBuffer.GetInstance();

        printBuffer.AddJob(new PrintJob(1, "Document 1"));
        printBuffer.AddJob(new PrintJob(2, "Document 2"));

        printBuffer.PrintNextJob();
        printBuffer.PrintNextJob();
        printBuffer.PrintNextJob(); // Should indicate no jobs in the buffer
    }
}
