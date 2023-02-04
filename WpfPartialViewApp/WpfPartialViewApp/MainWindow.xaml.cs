using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfPartialViewApp.Controls;

namespace WpfPartialViewApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DependencyProperty MoviesProperty =
            DependencyProperty.Register("Movies",
            typeof(IList<Movie>),
            typeof(MainWindow),
            new UIPropertyMetadata(new ObservableCollection<Movie>()));

        public IList<Movie> Movies
        {
            get { return (IList<Movie>)GetValue(MoviesProperty); }
            set { SetValue(MoviesProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            movieListBox.SelectionChanged += movieListBox_SelectionChanged;

            Movies.Add(new Movie
            {
                Name = "Человек дождя",
                Genre = Genre.Drama,
                Director = "Барри Левинсон",
                Year = new DateTime(1988, 1, 1),
                Country = "США",
                Poster = new BitmapImage(new Uri(@"pack://application:,,,/WpfPartialViewApp;component/Resources/Images/RainMan.jpg", UriKind.Absolute)),
                Description = "У Чарли, грубоватого и эгоистичного молодого повесы, в наследство от отца остались лишь розовые кусты да «Бьюик» 49-го года."
                + " Внезапным «сюрпризом» для него стало открытие того, что львиная доля наследства оставлена отцом его больному аутизмом брату Раймонду."
            });
            Movies.Add(new Movie
            {
                Name = "Матрица",
                Genre = Genre.SciFi,
                Director = "Энди Вачовски, Лана Вачовски",
                Year = new DateTime(1999, 1, 1),
                Country = "США, Австралия",
                Poster = new BitmapImage(new Uri(@"pack://application:,,,/WpfPartialViewApp;component/Resources/Images/matrix.jpg", UriKind.Absolute)),
                Description = "Жизнь Томаса Андерсона разделена на две части: днём он самый обычный офисный работник, получающий нагоняи от начальства,"
                + " а ночью превращается в хакера по имени Нео, и нет места в сети, куда он не смог бы дотянуться. Но однажды всё меняется — герой,"
                + " сам того не желая, узнаёт страшную правду: всё, что его окружает — не более, чем иллюзия, Матрица, а люди — всего лишь источник"
                + " питания для искусственного интеллекта, поработившего человечество. "
            });
            Movies.Add(new Movie
            {
                Name = "Профессионал",
                Genre = Genre.Action,
                Director = "Ален Бельмондо",
                Year = new DateTime(1981, 1, 1),
                Country = "Франция",
                Poster = new BitmapImage(new Uri(@"pack://application:,,,/WpfPartialViewApp;component/Resources/Images/Leprofessionnel.jpg", UriKind.Absolute)),
                Description = "Убить президента африканской республики. Такое задание получил секретный агент Жослен Бомон."
                + " Внезапно политика изменилась, и французское правительство сдает героя африканским властям. Сбежав с каторги,"
                + " волк-одиночка возвращается на родину с одной целью: довести задание до конца. А чернокожий лидер как раз приезжает"
                + " во Францию."
            });

            movieListBox.SelectedIndex = 0; 
        }

        void movieListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            var movie = listBox.SelectedItem as Movie;
            if (movie == null)
            {
                removeMovieButton.IsEnabled = false;
                placeholder.Content = null;
                return;
            }

            removeMovieButton.IsEnabled = true;
            placeholder.Content = new ShowMovieControl() { DataContext = movie };
        }

        private void removeMovieButton_Click(object sender, RoutedEventArgs e)
        {
            var movie = movieListBox.SelectedItem as Movie;
            if (movie == null)
            {
                return;
            }

            Movies.Remove(movie);
        }

        private void addMovieButton_Click(object sender, RoutedEventArgs e)
        {
            movieListBox.UnselectAll();
            placeholder.Content = new AddMovieControl() { MainWindow = this };
        }

    }
}
