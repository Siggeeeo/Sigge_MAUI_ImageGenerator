using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ImageGenerator
{
    public partial class MainPage : ContentPage
    {
        private class  ImageItem
        {
            public string ImageName { get; set; }
            public string ImageDescription { get; set; }
            public bool IsFavorite { get; set; }
        }

        //private Dictionary<string, string> ImageList = new()
        private readonly List<ImageItem> _images=new()
            {
                new ImageItem { ImageName = "image1", ImageDescription = "Man" },
                new ImageItem { ImageName = "image2", ImageDescription = "Bird" },
                new ImageItem { ImageName = "image3", ImageDescription = "Big cat" },
                new ImageItem { ImageName = "image4", ImageDescription = "Autumn road" },
                new ImageItem { ImageName = "image5", ImageDescription = "Flowergirl" },
                new ImageItem { ImageName = "image6", ImageDescription = "Two small cats" },
                new ImageItem { ImageName = "image7", ImageDescription = "Cow" },
                new ImageItem { ImageName = "image8", ImageDescription = "Dog" },
                new ImageItem { ImageName = "image9", ImageDescription = "Palm tree" },
                new ImageItem { ImageName = "image10", ImageDescription = "City" }




            };


        private Random random = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageOnClicked(object? sender, EventArgs e)
        {
            ShowImageAndText();
        }

        private void ShowImageAndText()
        {

            //var singleKeys = ImageList.Keys.ToList(); // en lokal lista av det första paret i en Dictionary

            var pairs = ImageList.ElementAt(random.Next(ImageList.Count));

            Debug.WriteLine(pairs.Key + ": " + pairs.Value); // för testning i Output

            string showKey = GetImageFileEnding(pairs.Key); // detta då enbart Windows kräver filändelse

            ShowGallery.Source = showKey;

            ImageText.Text = pairs.Value;
        }

        private string GetImageFileEnding(string imageKey)
        {
            #if WINDOWS
            return imageKey + ".jpg";
            #else
            return imageKey;
            #endif
        }


        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            _isFavorite = !_isFavorite;

            if (_isFavorite)
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87d",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Red
                };
            }
            else
            {
                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = "\ue87e",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = Colors.Gray
                };
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
