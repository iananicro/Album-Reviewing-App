using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class NewAlbumPage : ContentPage
    {
        public NewAlbumPage()
        {
            //Entry fields for showing placeholder data and keyboard type.
            var artistEntry = new Entry 
            { 
                Placeholder = "Enter an Artist Name",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
            };
            var albumNameEntry = new Entry 
            { 
                Placeholder = "Enter an Album Name",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
            };
            var yearEntry = new Entry 
            { 
                Placeholder = "Enter the Year Released",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
                Keyboard = Keyboard.Numeric 
            };
            var genreEntry = new Entry 
            { 
                Placeholder = "Enter the Genre",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
            };
            var runtimeEntry = new Entry 
            { 
                Placeholder = "Enter the Runtime",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
            };
            var numberOfSongsEntry = new Entry 
            { 
                Placeholder = "Enter the Number of Songs",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
                Keyboard = Keyboard.Numeric,
            };
            var listenDateEntry = new DatePicker 
            { 
                Date = DateTime.Now,
                TextColor = Color.FromArgb("#7A7A7A"),
            };
            var ratingEntry = new Entry 
            { 
                Placeholder = "Enter Rating out of 10.0",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
                Keyboard = Keyboard.Numeric,
            };
            var notesEntry = new Entry 
            { 
                Placeholder = "Enter Notes",
                PlaceholderColor = Color.FromArgb("#7A7A7A"),
            };
            //Button for saving new album details.
            var saveButton = new Button 
            { 
                Text = "Save Details",
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromArgb("#1F7A34"),
                VerticalOptions = LayoutOptions.Center,
            };
            //Event handler for saveButton.
            saveButton.Clicked += (sender, e) =>
            {
                //Retrieve values from the entry fields.
                string artist = artistEntry.Text;
                string albumName = albumNameEntry.Text;
                int year = int.Parse(yearEntry.Text);
                string genre = genreEntry.Text;
                string runtime = runtimeEntry.Text;
                int numberOfSongs = int.Parse(numberOfSongsEntry.Text);
                DateTime listenDate = listenDateEntry.Date;
                double rating = double.Parse(ratingEntry.Text);
                string notes = notesEntry.Text;

                //Create a new album instance with the entered detail.
                var newAlbum = new Album
                {
                    Artist = artist,
                    AlbumName = albumName,
                    Year = year,
                    Genre = genre,
                    Runtime = runtime,
                    NumberOfSongs = numberOfSongs,
                    ListenDate = listenDate,
                    Rating = rating,
                    Notes = notes,
                };

                //Insert the new album into the database.
                App.Database.Insert(newAlbum);

                //Navigate back the main menu.
                Navigation.PopAsync();
            };

            //StackLayout to organize labels, entry fields, buttons, etc.
            var contentStackLayout = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 20),
                Children =
                {
                    //Labels for each entry field.
                    new Label
                    {
                        Text = "Artist Name",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    artistEntry,
                    new Label
                    {
                        Text = "Album Name",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    albumNameEntry,
                    new Label
                    {
                        Text = "Year Released",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    yearEntry,
                    new Label
                    {
                        Text = "Genre",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    genreEntry,
                    new Label
                    {
                        Text = "Runtime",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    runtimeEntry,
                    new Label
                    {
                        Text = "Number of Songs",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    numberOfSongsEntry,
                    new Label
                    {
                        Text = "Date Listened",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    listenDateEntry,
                    new Label
                    {
                        Text = "Rating out of 10",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    ratingEntry,
                    new Label
                    {
                        Text = "Notes",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black,
                    },
                    notesEntry,
                    //Button for saving new album details.
                    saveButton
                }
            };
            //ScrollView to allow for scrolling if need be.
            var scrollView = new ScrollView { Content = contentStackLayout };
            Content = scrollView;
            //Background Color and Header Title
            this.BackgroundColor = Color.FromArgb("#CED6D5");
            Title = "New Album Entry";
        }
    }
}