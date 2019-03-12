using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewOrientationError.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Mainpage
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
