// See https://aka.ms/new-console-template for more information
using MovieDatabaseLab;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;

Console.WriteLine("****Welcome to Movie List Application****");
//creating list with the object of movie class
List<Movie> moviesList = new List<Movie>()
{
    new Movie("Catch me", "Adventure", 2015, 140),
    new Movie("Mrs.Doubtfire", "Comedy", 2016, 100),
    new Movie("Apollo 13", "Thriller", 2012, 120),
    new Movie("10,000 BC", "Drama", 2021, 130),
    new Movie("Groundhog day", "Thriller", 2018, 90),
    new Movie("Bambi", "Adventure", 2009, 90),
    new Movie("It's not me", "Comedy", 2001, 120),
    new Movie("Paycheck", "Thriller",2006, 130),
    new Movie("Cellular", "Drama",2009, 140),
    new Movie("Speed", "Adventure",2010, 100)
};

int movieCount = moviesList.Count();
Console.WriteLine($"There are {movieCount} movies in the list");

/*List<Movie> categoryList = moviesList.DistinctBy(x => x.category).ToList();
Console.WriteLine("Category List");

foreach (Movie categories in categoryList)
{
    Console.WriteLine(categories);
}*/
//getting distinct category value from list and populate it to array
string[] categoryList = moviesList.Select(x => x.category).Distinct().ToArray();
Dictionary<string, string> keyValueCategory = new Dictionary<string, string>();

    Console.WriteLine("------------Following Category Movies are available-----------");
int i = 1;
Array.Sort(categoryList);
//iterate through array to populate the key values for dictionary with categories and incrememt the value for category code
foreach ( string categories in categoryList)
{
    keyValueCategory.Add(categories, i.ToString());
    
    //Console.WriteLine(i +"       "+categories);
    i = i + 1;
}
foreach (var kvCategory in keyValueCategory)
{
    Console.WriteLine(kvCategory.Value +"\t"+kvCategory.Key);
}
    
do
{
    Console.WriteLine("What category are you interested in ?");
    string userCategory = Console.ReadLine().ToLower().Trim();
    //fetching the the key value of dictionary based on the user selected category
    foreach (var x in keyValueCategory) 
    {
        if (x.Value.ToLower() == userCategory || x.Key.ToLower() == userCategory)
        {
            userCategory =x.Key.ToLower();
        }
    }
    //displaying the values for corresponding category
    List<Movie> userSelectedMovie = moviesList.Where(x => x.category.ToLower() == userCategory).OrderBy(x => x.title).ToList();
    if (userSelectedMovie.Count > 0)
    {
        foreach (Movie movie in userSelectedMovie)
        {
            Console.WriteLine($"{movie.title} \t {movie.yearReleased} \t {movie.timeMinutes}");
        }
    }
    else { Console.WriteLine($"There is no moview under '{userCategory}'. Select one from Category list.");}
    
} while (GetPlayAgainAnswer() == true);
//method for asking to continue to play
bool GetPlayAgainAnswer(string strMessage = "Would you like to Continue? y/n")
{
    Console.WriteLine(strMessage);
    string userAnswer = Console.ReadLine();
    if (userAnswer.ToLower() != "y")
    {
        return false;
    }

    //Console.WriteLine("YEAH LETS PLAY");
    return true;
}
