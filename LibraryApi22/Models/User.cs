﻿namespace LibraryApi22.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public HashSet<Book> Books { get; set; }


    }
}
