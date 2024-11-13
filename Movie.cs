using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseLab
{
    internal class Movie
    {
        public string title;
        public string category;
        public int yearReleased;
        public int timeMinutes;

        public Movie(string title, string category, int yearReleased, int timeMinutes)
        {
            this.title = title;
            this.category = category;
            this.yearReleased = yearReleased;
            this.timeMinutes = timeMinutes;
                       }
    }

}
