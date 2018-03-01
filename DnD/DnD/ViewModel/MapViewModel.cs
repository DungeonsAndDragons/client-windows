using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DnD.ViewModel
{
    public class MapViewModel : ObservableObject
    {
        public Canvas Canvas
        {
            get
            {
                if (canvas == null)
                {
                    CreateCanvas();
                    FillField(canvas, 10, 10);
                }
                return canvas;
            }
        }

        private Canvas canvas;

        private void FillField(Canvas canvas, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var button = CreatePolygon(GetPixelPosition(i, j), 0);
                    button.Click += (_, __) => button.Background = Brushes.Red;
                    if (i == 60 && j == 40)
                    {
                        button.Background = Brushes.Red;
                        button.Background.Freeze();
                    }
                    canvas.Children.Add(button);
                }
            }
        }

        private Point GetPixelPosition(int x, int y)
        {
            float xOffset = x * 39;
            float yOffset = (x % 2 == 1 ? 21 : 0) + y * 42;
            return new Point(xOffset, yOffset);
        }

        private Button CreatePolygon(Point point, int fillData)
        {
            Button button = new Button
            {
                Tag = point,
                Style = Application.Current.TryFindResource("TileStyle") as Style
            };
            button.Background = Brushes.Transparent;
            button.Background.Freeze();
            Canvas.SetTop(button, point.Y);
            Canvas.SetLeft(button, point.X);
            return button;
        }

        private void CreateCanvas()
        {
            canvas = new Canvas();
        }
    }
}