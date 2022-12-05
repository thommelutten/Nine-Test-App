using NineTestApp.Application.Colors.Queries.GetColors;

namespace NineTestApp.WebUI.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Colors = new List<ColorDto>();
        }
        public List<ColorDto> Colors { get; set; }
    }
}
