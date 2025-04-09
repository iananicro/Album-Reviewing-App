using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class EditDetailsPage : ContentPage
    {
        //Private field to hold the album being edited.
        private Album editedAlbum;

        //EditDetailsPage Constructor that takes a selectedAlbum paramater.
        public EditDetailsPage(Album selectedAlbum)
        {
            //Initialize the editedAlbum field with the selectedAlbum.
            this.editedAlbum = selectedAlbum;

            //Entry fields and other UI elements for editing album info.
            var artistEntry = new Entry 
            { 
                Text = selectedAlbum.Artist,
            };
            var albumNameEntry = new Entry 
            { 
                Text = selectedAlbum.AlbumName,
            };
            var numberOfSongsEntry = new Entry 
            { 
                Keyboard = Keyboard.Numeric, 
                Text = selectedAlbum.NumberOfSongs.ToString(),
            };
            var ratingEntry = new Entry 
            { 
                Keyboard = Keyboard.Numeric, 
                Text = selectedAlbum.Rating.ToString(),
            };
            var runtimeEntry = new Entry 
            { 
                Text = selectedAlbum.Runtime,
            };
            var listenDateEntry = new DatePicker 
            { 
                Date = selectedAlbum.ListenDate,
            };
            var notesEntry = new Entry 
            { 
                Text = selectedAlbum.Notes,
            };
            var genreEntry = new Entry 
            { 
                Text = selectedAlbum.Genre,
            };
            var yearEntry = new Entry 
            { 
                Keyboard = Keyboard.Numeric, 
                Text = selectedAlbum.Year.ToString(), 
            };

            //Button for saving edited details.
            var saveButton = new Button 
            { 
                Text = "Save Edited Details",
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromArgb("#1F7A34"),
            };

            //Event handler for saveButton.
            saveButton.Clicked += (sender, e) =>
            {
                // Update the editedAlbum with the new user inputted values
                editedAlbum.Artist = artistEntry.Text;
                editedAlbum.AlbumName = albumNameEntry.Text;
                editedAlbum.NumberOfSongs = int.Parse(numberOfSongsEntry.Text);
                editedAlbum.Rating = double.Parse(ratingEntry.Text);
                editedAlbum.Runtime = runtimeEntry.Text;
                editedAlbum.ListenDate =  listenDateEntry.Date;
                editedAlbum.Notes = notesEntry.Text;
                editedAlbum.Genre = genreEntry.Text;
                editedAlbum.Year = int.Parse(yearEntry.Text);

                //Save changes to the database.
                App.Database.Update(editedAlbum);

                //Navigate back to the main page.
                Navigation.PopAsync();
            };

            //StackLayout to organize labels, entries, buttons, etc.
            var contentStackLayout = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 20),
                Children =
                {
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
                    saveButton
                }
            };
            //ScrollView to allow for scrolling if need be.
            var scrollView = new ScrollView { Content = contentStackLayout };
            Content = scrollView;
            //Background Color and Header Title
            this.BackgroundColor = Color.FromArgb("#EAE9D9");
            Title = "Edit Album Details";
        }
    }
}