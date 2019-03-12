using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace C4S.MobileApp.Views.CustomsControls
{
    class CollectionViewWithOrientation : CollectionView
    {
        private GridItemsLayout GridItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical);

        public CollectionViewWithOrientation()
        {
            // Subscribe to changes of screen metrics
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;

            //Configure layout initial 
            ItemsLayout = GridItemsLayout;
            ConfigureLayout(DeviceDisplay.MainDisplayInfo.Orientation);
        }
        void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            // Process changes
            ConfigureLayout(e.DisplayInfo.Orientation);
        }

        void ConfigureLayout(DisplayOrientation displayOrientation)
        {
            GridItemsLayout.Span = displayOrientation == DisplayOrientation.Portrait ? 2 : 4;
        }
    }
}
