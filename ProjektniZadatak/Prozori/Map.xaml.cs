using ProjektniZadatak.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ProjektniZadatak
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Dictionary<Animal, BitmapImage> animalImageMap = new Dictionary<Animal, BitmapImage>();
        public Dictionary<Tip, BitmapImage> tipImageMap = new Dictionary<Tip, BitmapImage>();
        private Image draggedImage;
        private Animal tempAnimal;
        private Point startPoint = new Point();
        private Point mousePosition;
        private ObservableCollection<Animal> animalsMap = new ObservableCollection<Animal>();
        private ObservableCollection<Animal> animalsMap2 = new ObservableCollection<Animal>();
        private Window1 win1;

        public Map(ObservableCollection<Animal> a,Window1 w)
        {
            InitializeComponent();
            this.animalsMap = a;
            zivotinje.ItemsSource = a;
            this.win1 = w;
        }

        public void refreshCollections()
        {
            animalsMap = new ObservableCollection<Animal>();
            animalsMap2 = new ObservableCollection<Animal>();
            animalImageMap = new Dictionary<Animal, BitmapImage>();
        }

        public void updateImageDictionaries(Dictionary<Tip, BitmapImage> tb, Dictionary<Animal, BitmapImage> ab)
        {
            tipImageMap = tb;
            animalImageMap = ab;
        }

        public void loadMap()
        {
            foreach (Animal a in animalsMap)
            {
                if (!String.Equals(a.locationX, "-") && !String.Equals(a.locationY, "-"))
                {
                    Image i = new Image();
                    i.Source = animalImageMap[a];
                    i.Width = 64;
                    i.Height = 64;
                    i.Stretch = Stretch.None;
                    canvasMap.Children.Add(i);
                    Canvas.SetLeft(i, Convert.ToDouble(a.locationX) - 32);
                    Canvas.SetTop(i, Convert.ToDouble(a.locationY) - 32);
                    Console.WriteLine(a.Ime);
                }
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Animal animal = null;

                if (listViewItem != null)
                {
                    animal = (Animal)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", animal);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }


            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            Point p = e.GetPosition(canvasMap);

            // && p.X < canvasMap.Width && p.Y < canvasMap.Height
            if (e.Data.GetDataPresent("myFormat"))
            {
                Animal animal = e.Data.GetData("myFormat") as Animal;

                //if (String.Equals(animal.locationX, "-") && String.Equals(animal.locationY, "-"))
                //{
                    Image i = new Image();
                    i.Source = animal.Image;
                    i.Width = 64;
                    i.Height = 64;
                    i.Stretch = Stretch.Uniform;
                    canvasMap.Children.Add(i);
                    Canvas.SetLeft(i, p.X - 32);
                    Canvas.SetTop(i, p.Y - 32);
                    Console.WriteLine(animal.Ime);
                    animal.locationX = p.X.ToString();
                    animal.locationY = p.Y.ToString();
                //}
                
            }

            Console.WriteLine("Dodato");
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = e.Source as Image;

            if (image != null && canvasMap.CaptureMouse())
            {
                mousePosition = e.GetPosition(canvasMap);
                draggedImage = image;

                string imageloc = (Canvas.GetLeft(draggedImage) + 32).ToString() + (Canvas.GetTop(draggedImage) + 32).ToString();
                foreach (Animal s in animalsMap)
                {
                    if (String.Equals(imageloc, s.locationX + s.locationY))
                    {
                        tempAnimal = s;
                        break;
                    }
                }

                Panel.SetZIndex(draggedImage, 1); // in case of multiple images
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedImage != null)
            {
                if (mousePosition.X < 50)
                {
                    return;
                }

                canvasMap.ReleaseMouseCapture();
                Panel.SetZIndex(draggedImage, 0);
                draggedImage = null;
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            { 
                var position = e.GetPosition(canvasMap);
                var offset = position - mousePosition;


                mousePosition = position;
                
                if (Math.Abs(offset.X) <= 64 && Math.Abs(offset.Y) <= 64)
                {
                    //return;
                }

                Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
                Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);

                tempAnimal.locationX = (Canvas.GetLeft(draggedImage) + 32).ToString();
                tempAnimal.locationY = (Canvas.GetTop(draggedImage) + 32).ToString();

            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            win1.updateCursors();
        }
    }
}
