using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfPartialViewApp
{
    public class Movie
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime Year { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public BitmapImage Poster { get; set; }
        public string Description { get; set; }
    }

}
