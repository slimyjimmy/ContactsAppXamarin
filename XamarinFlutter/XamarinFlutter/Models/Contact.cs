using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFlutter.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PathToPhoto { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
    }
}
