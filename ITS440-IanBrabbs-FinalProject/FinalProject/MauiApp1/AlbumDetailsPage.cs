using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class AlbumDetailsPage : ContentPage
    {
        //Constructor that takes a selectedAlbum parameter.
        public AlbumDetailsPage(Album selectedAlbum)
        {
            //Labels to display album details.
            var artistLabel = new Label
            {
                //Formatted text is the detail type is bolded, but the actual info is normal.
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Artist Name: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.Artist, FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var albumNameLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Album Name: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.AlbumName, FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var yearLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Year Released: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.Year.ToString(), FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var genreLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Genre: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.Genre, FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var runtimeLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Runtime: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.Runtime, FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var numberOfSongsLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Number of Songs: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.NumberOfSongs.ToString(), FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var ratingLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Rating: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = $"{selectedAlbum.Rating:F1}/10.0", FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var listenDateLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Date Listened: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.ListenDate.ToShortDateString(), FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            var notesLabel = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "Notes: ", FontAttributes = FontAttributes.Bold, TextColor = Colors.Black },
                        new Span { Text = selectedAlbum.Notes, FontAttributes = FontAttributes.None, TextColor = Colors.Black }
                    }
                }
            };

            //Button to delete an album entry.
            var deleteButton = new Button
            {
                Text = "Delete Album Entry",
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0),
                BackgroundColor = Color.FromArgb("#A31319")
            };

            //Event handler for the deleteButton.
            deleteButton.Clicked += async (sender, e) =>
            {
                //Display a confirmation dialog before deleting.
                bool answer = await DisplayAlert("Confirm Deletion", 
                    "Are you sure you want to delete this album entry? You cannot undo this action."
                    , "Yes", "No");

                if (answer)
                {
                    //Delete the album from the database.
                    App.Database.Delete(selectedAlbum);

                    //Navigate back to the MainPage.
                    await Navigation.PopAsync();
                }
            };

            //Button to edit an album entry.
            var editButton = new Button
            {
                Text = "Edit Album Details",
                FontAttributes = FontAttributes.Bold, 
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0),
                BackgroundColor = Color.FromArgb("#1F7A34")
            };

            //Event handler for the editButton.
            editButton.Clicked += (sender, e) =>
            {
                //Navigate to EditDetailsPage
                Navigation.PushAsync(new EditDetailsPage(selectedAlbum));
            };

            //StackLayout to organize the labels and buttons.
            var contentStackLayout = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 20),
                Children =
                {
                    artistLabel ,
                    albumNameLabel,
                    yearLabel,
                    genreLabel,
                    runtimeLabel,
                    numberOfSongsLabel,
                    listenDateLabel,
                    ratingLabel,
                    notesLabel,
                    editButton,
                    deleteButton
                }
            };
            //ScrollView to allow for scrolling if need be.
            var scrollView = new ScrollView { Content = contentStackLayout };
            Content = scrollView;
            //Background Color and Header Title
            this.BackgroundColor = Color.FromArgb("#BAD3EA");
            Title = "View Album Details";
        }
    }
}