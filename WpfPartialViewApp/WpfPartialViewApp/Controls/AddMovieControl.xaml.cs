using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfPartialViewApp.Controls
{
    /// <summary>
    /// Interaction logic for AddMovieControl.xaml
    /// </summary>
    public partial class AddMovieControl : UserControl
    {
        public MainWindow MainWindow { get; set; }

        public AddMovieControl()
        {
            InitializeComponent();
            genreComboBox.ItemsSource = EnumHelper.GetGenreDescriptionValues();
        }

        private bool Validate(out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                errorMessage = "Введите название";
                return false;
            }
            if (genreComboBox.SelectedValue == null)
            {
                errorMessage = "Укажите жанр";
                return false;
            }
            if (string.IsNullOrWhiteSpace(yearTextBox.Text))
            {
                errorMessage = "Введите год";
                return false;
            }

            try
            {
                new DateTime(Convert.ToInt32(yearTextBox.Text), 1, 1);
            }
            catch
            {
                errorMessage = "Неверный формат для поля 'Год'";
                return false;
            }

            if (string.IsNullOrWhiteSpace(countryTextBox.Text))
            {
                errorMessage = "Введите название страны";
                return false;
            }
            if (string.IsNullOrWhiteSpace(directorTextBox.Text))
            {
                errorMessage = "Введите имя режиссера";
                return false;
            }
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                errorMessage = "Введите описание";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fileTextBox.Text))
            {
                errorMessage = "Укажите файл с изображением";
                return false;
            }

            return true;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (!Validate(out errorMessage))
            {
                MessageBox.Show(MainWindow, errorMessage);
                return;
            }

            var image = new BitmapImage(new Uri(fileTextBox.Text));

            var movie = new Movie()
            {
                Name = nameTextBox.Text,
                Genre = ((KeyValuePair<Genre, string>)genreComboBox.SelectedValue).Key,
                Year = new DateTime(Convert.ToInt32(yearTextBox.Text), 1 ,1),
                Director = directorTextBox.Text,
                Country = countryTextBox.Text,
                Description = descriptionTextBox.Text,
                Poster = image
            };

            MainWindow.Movies.Add(movie);
            MainWindow.movieListBox.SelectedItem = movie;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.placeholder.Content = null;
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg; *.jpeg; *.png";
            
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                fileTextBox.Text = dlg.FileName;
            }
        }

    }
}
