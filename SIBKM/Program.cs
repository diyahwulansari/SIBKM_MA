using System;

public class movies
{
    static void Main(string[] args)
    {
    }
    
    public string title { get; set; } = default!;
    public int rating { get; set; } = default!;

    public movies()
    {
        Console.WriteLine($"{title} {rating}");
    }

    public movies(string title, int rating)
    {
        this.title= title;
        this.rating= rating;
    }

    public void introduction(int rating)
    {
        Console.WriteLine("Film ini berjudul " + title);
        Console.WriteLine("Film ini berhasil meraih rating sebesar "+ rating);
    }
}


