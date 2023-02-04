using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPartialViewApp
{
    public enum Genre
    {
        [Description("Комедия")]
        Comedy,
        [Description("Фантастика")]
        SciFi,
        [Description("Боевик")]
        Action,
        [Description("Драма")]
        Drama,
        [Description("Хоррор")]
        Horror
    }
}
