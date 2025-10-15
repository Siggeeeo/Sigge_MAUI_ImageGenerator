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

        private ImageItem _currentImage;


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
            int randomIndex =random.Next(_images.Count);
            _currentImage = _images[randomIndex];

            string imageName = GetImageFileEnding(_currentImage.ImageName);

            ShowGallery.Source = imageName;
            ImageText.Text = _currentImage.ImageDescription;

            UpdateFavoriteButtonVisuals();

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
            if (_currentImage == null) return;

            _currentImage.IsFavorite = !_currentImage.IsFavorite;

            UpdateFavoriteButtonVisuals();


            }

        private void UpdateFavoriteButtonVisuals()
        {
            if (_currentImage ==null )

                if (_currentImage.IsFavorite)
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

    }
}
