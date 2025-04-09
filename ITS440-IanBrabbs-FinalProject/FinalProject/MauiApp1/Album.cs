using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1
{
    public class Album
    {
        //Primary Key and AutoIncriment attributes for AlbumId.
        [PrimaryKey, AutoIncrement]
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public string AlbumName { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Runtime { get; set; }
        public int NumberOfSongs { get; set; }
        public DateTime ListenDate { get; set; }
        public double Rating { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{Artist} - {AlbumName}";
        }
    }
}