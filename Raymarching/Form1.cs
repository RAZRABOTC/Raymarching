using Dimension;
using System.Diagnostics;

namespace Raymarching
{
    public partial class RayMarchingForm : Form
    {
        public RayMarchingForm()
        {
            InitializeComponent();
        }

        private void RayMarchingForm_Paint(object sender, PaintEventArgs e)
        {
            DrawObjectsAndRay(e , Cursor.Position);
        }

        private void RayMarchingForm_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void DrawObjectsAndRay(PaintEventArgs e , Point cursorPosition)
        {
            Vector2 circleScale = new Vector2(100, 100);
            float circleRadius = circleScale.X / 2;
            Vector2 circlePosition = new Vector2(400 + circleRadius, 200 + circleRadius);
            Vector2 camera = new Vector2(300, circlePosition.Y + circleRadius);
            //Vector2 cameraDirection = Vectors.GetDirection(camera, circlePosition-circleRadius-10);
            Vector2 cameraDirection = Vectors.GetDirection(camera, new Vector2(cursorPosition.X, cursorPosition.Y));
            Graphics graphics = e.Graphics;
            Brush brush = new SolidBrush(Color.FromArgb(255, 204, 0));
            Pen circlePen = new Pen(brush);
            Pen circlePen2 = new Pen(Color.FromArgb(255, 21, 0));

            graphics.DrawLine(circlePen2, 0, 0, 100, 0);
            graphics.DrawEllipse(circlePen2, 0, 0, 50, 50);

            graphics.DrawEllipse(circlePen2, camera.X, camera.Y, 2, 2);
            graphics.DrawEllipse(circlePen2, circlePosition.X - circleRadius, circlePosition.Y - circleRadius, circleScale.X, circleScale.Y);
            graphics.DrawEllipse(circlePen2, circlePosition.X, circlePosition.Y, 2, 2);
            PropertyText.Text = "Cam direction " + cameraDirection.ToString() + ", Circle Position:" + circlePosition.ToString() + "Cursor position"  + cursorPosition.ToString();
            // graphics.DrawLine(circlePen, camera.X, camera.Y, circlePosition.X + circlePosition.X * cameraDirection.X , circlePosition.Y + circlePosition.Y* cameraDirection.Y * 2);
            Vector2 rayPosition = camera;
            while (true)
            {
                float distance = Vectors.GetMagnitude(rayPosition, circlePosition) - circleRadius;
                Debug.WriteLine(distance);
                graphics.DrawEllipse(circlePen, rayPosition.X - distance, rayPosition.Y - distance, distance * 2, distance * 2);
                Vector2 lastRayPosition = rayPosition;
                var sinCosX = MathF.SinCos(MathF.PI / 180 * cameraDirection.X * 90);
                var sinCosY = MathF.SinCos(MathF.PI / 180 * cameraDirection.Y * 90);
                rayPosition = new(rayPosition.X + distance * sinCosX.Sin, rayPosition.Y + distance * sinCosY.Sin);
                graphics.DrawEllipse(circlePen2, rayPosition.X, rayPosition.Y, 2, 2);
                graphics.DrawLine(circlePen, lastRayPosition.X, lastRayPosition.Y, rayPosition.X, rayPosition.Y);
                if (distance > 1000 || distance <= 2) break;
            }
        }
    }
}
