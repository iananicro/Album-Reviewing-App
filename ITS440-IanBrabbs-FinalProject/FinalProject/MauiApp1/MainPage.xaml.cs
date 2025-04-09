namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Setting the title in the header.
            Title = "Album Reviewing Application";

            InitializeComponent();

            //Button for creating a new album entry.
            var createEntryButton = new Button
            {
                Text = "New Album Entry",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromArgb("#1F7A34")
            };

            //Event handler for createEntryButton
            createEntryButton.Clicked += (sender, e) =>
            {
                //Navigate to NewAlbumPage
                Navigation.PushAsync(new NewAlbumPage());
            };

            //List view for display all album entries.
            var albumsListView = new ListView
            {
                //Define the item template for each album.
                ItemTemplate = new DataTemplate(() =>
                {
                    var viewCell = new ViewCell();

                    //Labels for displaying  artist name and album name.
                    var artistLabel = new Label 
                    { 
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Colors.Black
                    };
                    artistLabel.SetBinding(Label.TextProperty, "Artist");

                    var albumNameLabel = new Label
                    {
                        TextColor = Colors.Black
                    };
                    albumNameLabel.SetBinding(Label.TextProperty, "AlbumName");

                    //StackLayout to organize labels.
                    var stackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {   
                            artistLabel,
                            albumNameLabel
                        }
                    };
                    viewCell.View = stackLayout;

                    return viewCell;
                })
            };

            //Event handler for item selection in albumsListView.
            albumsListView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                //Get the selected album.
                var selectedAlbum = (Album)e.SelectedItem;
                //Navigate to the AlbumDetailsPage for the selected album.
                Navigation.PushAsync(new AlbumDetailsPage(selectedAlbum));
                //Deselect the item.
                albumsListView.SelectedItem = null;
            };

            //StackLayout to organize the ListView and createEntryButton.
            var contentStackLayout = new StackLayout
            {
                Padding = new Thickness(10, 20, 10, 20),
                Children =
                {
                    albumsListView,
                    createEntryButton
                }
            };

            //Event handler for the appearing event of the page.
            this.Appearing += (sender, e) =>
            {
                //Refresh the albums list.
                RefreshAlbumsList(albumsListView);
            };
            //ScrollView to allow for scrolling if need be.
            var scrollView = new ScrollView { Content = contentStackLayout };
            Content = scrollView;
            this.BackgroundColor = Color.FromArgb("#CECED6");
        }
        //Method to refresh the albums list in the ListView.
        private void RefreshAlbumsList(ListView listView)
        {
            //Retrieve the list of albums from the database.
            var albums = App.Database.Table<Album>().ToList();
            listView.ItemsSource = albums;

            //Clear and set the item source again to simulate a refresh.
            listView.ItemsSource = null;
            listView.ItemsSource = albums;
        }
    }
}