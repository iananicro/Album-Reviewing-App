using SQLite;

namespace MauiApp1
{
    public partial class App : Application
    {
        //Static field to hold the SQLite Connection.
        public static SQLiteConnection Database;

        public App()
        {
            //Initialize the SQLite connection with the database.
            Database = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "musicdb.db3"));
            //Create the Album table if it doesn't exist.
            Database.CreateTable<Album>();

            var mainPage = new MainPage();
            var navigationPage = new NavigationPage(mainPage);

            //Customizing the navigation bar.
            navigationPage.BarBackgroundColor = Color.FromArgb("#3B4763");
            navigationPage.BarTextColor = Colors.White;
            
            MainPage = navigationPage;
        }
    }
}