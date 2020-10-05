using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.Models
{
    public class Category
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public int ID { get; set; }

        public override bool Equals(object obj)
        {
            if (Type == ((Category)obj).Type && Name == ((Category)obj).Name)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
