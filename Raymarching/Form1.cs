using Dimension;
using System.Diagnostics;
using System.Drawing;

namespace Raymarching
{
    public partial class RayMarchingForm : Form
    {
        private GameObject[] objects;
        private Vector2 origin = new(100, 500);

        public RayMarchingForm()
        {
            InitializeComponent();
            objects = [new (new Rectangle(new Point(300, 300) ,new Size(100,200)) , ShapeType.Rectangle) , new(new Rectangle(new Point(100, 500), new Size(100, 100)), ShapeType.Circle)];
        }

        private void DrawObjects(Graphics graphics, Pen pen)
        {
            pen ??= new Pen(Color.FromArgb(100, 231, 233));
            foreach(var obj in objects)
            {
                if (obj.ShapeType == ShapeType.Circle)
                {
                    graphics.DrawEllipse(pen, obj.Shape);
                }
                else if (obj.ShapeType == ShapeType.Rectangle)
                {
                    graphics.DrawRectangle(pen, obj.Shape);
                }
            }
        }

        private void RayMarchingForm_Paint(object sender, PaintEventArgs e)
        {
            DrawObjects(e.Graphics , new Pen(Color.FromArgb(52,52,52)));
            ConductRay(e.Graphics , new Pen(Color.FromArgb(252, 186, 3)) , Cursor.Position);
        }

        private void RayMarchingForm_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private bool ConductRay(Graphics graphics , Pen circlePen , Point cursorPosition)
        {
            Vector2 direction = Vectors.GetDirection(origin, new (cursorPosition.X , cursorPosition.Y));
            if (direction == default) return false;
            const float oneDegree = MathF.PI / 180;
            const float hitDistance = 1;
            const float maxDistance = 2000;
            PrintProperties(direction, cursorPosition);
            Vector2 rayPosition = origin;
            while (true)
            {
                float distance = GetShortestDistance(rayPosition);
                Debug.WriteLine("L " + objects[1].Shape.Location);
                graphics.DrawEllipse(circlePen, rayPosition.X - distance, rayPosition.Y - distance, distance * 2, distance * 2);
                Vector2 lastRayPosition = rayPosition;
                float sinX = MathF.Sin(oneDegree * direction.X * 90);
                float sinY = MathF.Sin(oneDegree * direction.Y * 90);
                rayPosition = new(rayPosition.X + distance * sinX, rayPosition.Y + distance * sinY);
                graphics.DrawEllipse(circlePen, rayPosition.X, rayPosition.Y, 2, 2);
                graphics.DrawLine(circlePen, lastRayPosition.X, lastRayPosition.Y, rayPosition.X, rayPosition.Y);
                if (distance > maxDistance) return false;
                if (distance < hitDistance) return true;
            }
        }

        private float GetShortestDistance(Vector2 origin)
        {
            float currentShortestDistance = float.MaxValue;
            foreach (GameObject obj in objects)
            {
                Debug.WriteLine(currentShortestDistance);
                float currentDistance;
                if (obj.ShapeType == ShapeType.Circle)
                {
                    currentDistance = GetDistanceFromCircle(obj , origin);
                }
                else
                {
                    currentDistance = GetDistanceFromRectangle(obj , origin);
                }
                currentShortestDistance = Math.Min(currentShortestDistance, currentDistance);
            }
            return currentShortestDistance;
        }

        private float GetDistanceFromCircle(GameObject circle, Vector2 origin)
        {
            return Vectors.GetMagnitude(origin, new(circle.Shape.Location.X + circle.Shape.Width/2, circle.Shape.Location.Y + circle.Shape.Width/2)) - circle.Shape.Width/2;
        }
        private float GetDistanceFromRectangle(GameObject rectangle, Vector2 origin)
        {
            return Vectors.GetMagnitude(origin, origin.Clamp(new Vector2(rectangle.Shape.Left, rectangle.Shape.Top), new(rectangle.Shape.Right, rectangle.Shape.Bottom)));
        }


        private void PrintProperties(Vector2 cameraDirection , Point cursorPosition)
        {
            PropertyText.Text = "Origin direction :" + cameraDirection.ToString() + "Cursor position" + cursorPosition.ToString() + "\n";
        }


        private void PrintResult(bool result)
        {
            if (result)
            {
                ResultText.Text = "Successefully ray hit the target";
                ResultText.ForeColor = Color.DarkGreen;
            }
            else
            {
                ResultText.Text = "Failed, ray didn't reach the target";
                ResultText.ForeColor = Color.DarkRed;
            }
        }
    }
    public class GameObject
    {
        public Rectangle Shape { get; private set; }
        public ShapeType ShapeType { get; private set; }
        public GameObject(Rectangle shape , ShapeType shapeType)
        {
            Shape = shape;
            ShapeType = shapeType;
        }
        public Point GetCenter()
        {
            return new(Shape.X + Shape.Width / 2 + Shape.Y + Shape.Height / 2);
        }
    }

    public enum ShapeType
    {
        Circle, Rectangle
    }
    
}
