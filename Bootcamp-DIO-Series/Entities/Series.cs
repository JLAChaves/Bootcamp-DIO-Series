using Bootcamp_DIO_Series.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_DIO_Series.Entities
{
    public class Series : EntitiyBase
    {
        private Gener Gener { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }

        public Series(int id, Gener gener, string title, string description, int year)
        {
            Id = id;
            Gener = gener;
            Title = title;
            Description = description;
            Year = year;
            Excluded = false;
        }

        public override string ToString()
        {
            string text = "";
            text += "Gener: " + Gener + Environment.NewLine;
            text += "Title: " + Title + Environment.NewLine;
            text += "Description : " + Description + Environment.NewLine;
            text += "Year: " + Year + Environment.NewLine;
            text += "Excluded: " + Excluded;
            return text;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public void Delete()
        {
            Excluded = true;
        }
    }
}
