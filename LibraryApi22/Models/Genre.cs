﻿namespace LibraryApi22.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Book> Books { get; set; }
    }
}
