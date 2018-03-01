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

namespace DnD.View
{
    /// <summary>
    /// Interaktionslogik für MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();

            ContentView.PreviewMouseWheel += CanvasMouseWheel;
            ContentView.PreviewMouseRightButtonDown += CanvasMouseLeftButtonDown;
            ContentView.PreviewMouseRightButtonUp += CanvasMouseLeftButtonUp;
            ContentView.PreviewMouseMove += CanvasMouseMove;
        }

        private bool dragging;
        private bool wasDragged;
        private Point dragStart;
        private Canvas Canv => ContentView.Content as Canvas;

        private void CanvasMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!dragging)
            {
                var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1);
                var position = e.GetPosition(ContentView);

                var child = Canv.Children[0] as FrameworkElement;
                var bounds = matrixTransform.TransformBounds(new Rect(child.RenderSize));
                if ((bounds.Width > 25 || scale > 1.0) && (bounds.Width < 90 || scale < 1.0))
                {
                    var matrix = matrixTransform.Matrix;
                    matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
                    matrixTransform.Matrix = matrix;
                }
            }
        }

        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragging = true;
            wasDragged = false;
            dragStart = e.GetPosition(ContentView);
            ContentView.CaptureMouse();
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
            
            ContentView.ReleaseMouseCapture();
            if (!wasDragged)
            {
                e.Handled = true;
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var delta = e.GetPosition(ContentView) - dragStart;
                if (delta.Length > 0)
                {
                    var matrix = matrixTransform.Matrix;
                    matrix.TranslatePrepend(delta.X, delta.Y);
                    matrixTransform.Matrix = matrix;
                    wasDragged = true;
                }
            }
        }
    }
}
        