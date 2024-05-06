using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Luzin_Patrakov_321
{
    internal class AnimeFestivalNews
    {
        public string Date { get; set; }
        public string News { get; set; }

        public AnimeFestivalNews(string date, string news)
        {
            Date = date;
            News = news;
        }
    }
}
