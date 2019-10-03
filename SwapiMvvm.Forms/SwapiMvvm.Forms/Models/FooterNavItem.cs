using SwapiMvvm.Forms.Services.Models;
using Xamarin.Forms;

namespace SwapiMvvm.Forms.Models
{
    public class FooterNavItem
    {
        #region Public

        public AppSection AppSection { get; set; }

        public bool IsSelected { get; set; }

        public Color ButtonBackground { get; set; }

        public string LabelText { get; set; }

        public Style LabelStyle { get; set; }

        public string Image { get; set; }

        public Command<AppSection> NavigationCommand { get; set; }

        #endregion
    }
}