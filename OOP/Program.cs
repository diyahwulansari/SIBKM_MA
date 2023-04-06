using System;

class Program
{
    static void Main(string[] args)
    {
        //Movies movie = new Movies("The Shawshank Redemption", 1994, "Frank Darabont", 9.3);
        //movie.MovieIntroduction();

        //Movies movie1 = new Movies("Avengers: Endgame", 2019, "Anthony Russo, Joe Russo", 8.4);
        //Movies movie2 = new ActionMovie("Die Hard", 1988, "John McTiernan", 8.2);
        //Movies movie3 = new DramaMovie("Forrest Gump", 1994, "Robert Zemeckis", 8.8);

        //movie1.MovieIntroduction();
        //Console.WriteLine();
        //movie2.MovieIntroduction();
        //Console.WriteLine();
        //movie3.MovieIntroduction();

        //Movies movie = new Movies("The Shawshank Redemption", 1994, "Frank Darabont", 9.3);
        //Console.WriteLine("Title: " + movie.GetTitle());
        //movie.SetTitle("The Godfather");
        //Console.WriteLine("New Title: " + movie.GetTitle());

    }
}

class Movies
{
    private string title;
    private int year;
    private string director;
    private double rating;

    public Movies(string title, int year, string director, double rating)
    {
        this.title = title;
        this.year = year;
        this.director = director;
        this.rating = rating;
    }

    //implementasikan encapsulation
    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public int GetYear()
    {
        return year;
    }

    public void SetYear(int year)
    {
        this.year = year;
    }

    public string GetDirector()
    {
        return director;
    }

    public void SetDirector(string director)
    {
        this.director = director;
    }

    public double GetRating()
    {
        return rating;
    }

    public void SetRating(double rating)
    {
        this.rating = rating;
    }

    public virtual void MovieIntroduction()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Year: " + year);
        Console.WriteLine("Director: " + director);
        Console.WriteLine("Rating: " + rating);
    }
}

// Implementasi inheritance dengan ActionMovie dan DramaMovie sebagai child class
class ActionMovie : Movies
{
    public ActionMovie(string title, int year, string director, double rating) : base(title, year, director, rating)
    {
    }

    public override void MovieIntroduction()
    {
        Console.WriteLine("Action Movie");
        base.MovieIntroduction();
    }
}

class DramaMovie : Movies
{
    public DramaMovie(string title, int year, string director, double rating) : base(title, year, director, rating)
    {
    }

    public override void MovieIntroduction()
    {
        Console.WriteLine("Drama Movie");
        base.MovieIntroduction();
    }
}
