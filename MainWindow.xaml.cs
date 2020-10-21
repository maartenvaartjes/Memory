 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        public MainWindow()
        {
            InitializeComponent();


            InitializeGameGrid(NR_OF_ROWS, NR_OF_COLS);

            //AddLabel();

            //Image backgroundimage = new Image();
            //Uri path = new Uri("images", UriKind.Relative);
            //backgroundimage.Source = new BitmapImage(path);
            //Grid.SetColumn(backgroundimage, 0);
            //Grid.SetRow(backgroundimage, 0);
            //GameGrid.Children.Add(backgroundimage);

            AddImages(NR_OF_ROWS, NR_OF_COLS);

        }

        private void InitializeGameGrid(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < cols; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "Memory";
            title.FontFamily = new FontFamily("comic sans");
            title.FontSize = 40;
            title.HorizontalContentAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 1);
            GameGrid.Children.Add(title);
        }

        private void AddImages(int rows, int cols)
        {
            List<ImageSource> images = GetImageList();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Image backgroundimage = new Image();
                    Uri path = new Uri("images/9.png", UriKind.Relative);
                    backgroundimage.Source = new BitmapImage(path);
                    backgroundimage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundimage.MouseDown += new MouseButtonEventHandler(TurnCard); 
                    Grid.SetColumn(backgroundimage, c);
                    Grid.SetRow(backgroundimage, r);
                    GameGrid.Children.Add(backgroundimage);
                }
            }
        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }

        private List<ImageSource> GetImageList ()
        {
            List<ImageSource> result = new List<ImageSource>();

            for (int i = 0; i < (NR_OF_COLS * NR_OF_ROWS); i++)
            {
                int nr = i % 8 + 1;
                Uri path = new Uri("images/" + nr + ".png", UriKind.Relative);
                result.Add(new BitmapImage(path));
            }
            //TO DO: Maak Randomizer
            return result;
        }

        private void TurnCard(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.show("Test");
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }
    }


    
}
