using Dimension;
using System.Diagnostics;
using System.Drawing;

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
            Vector2 cameraPosition = new Vector2(300, circlePosition.Y + circleRadius);
            Vector2 cameraDirection = Vectors.GetDirection(cameraPosition, new Vector2(cursorPosition.X, cursorPosition.Y));
            Graphics graphics = e.Graphics;
            Pen circlePen = new Pen(Color.FromArgb(255, 204, 0));
            Pen circlePen2 = new Pen(Color.FromArgb(255, 21, 0));

            PrintProperties(graphics, circlePen, circlePen2, cameraPosition, circlePosition, circleRadius, circleScale, cameraDirection, cursorPosition);
            PrintResult(ConductRay(graphics, circlePen, circlePen2, cameraPosition, circlePosition, circleRadius, cameraDirection));
        }

        private bool ConductRay(Graphics graphics , Pen circlePen , Pen circlePen2, Vector2 cameraPosition , Vector2 circlePosition , float circleRadius , Vector2 cameraDirection)
        {
            const float oneDegree = MathF.PI / 180;
            const float hitDistance = 2;
            const float maxDistance = 2000;
            Vector2 rayPosition = cameraPosition;
            while (true)
            {
                float distance = Vectors.GetMagnitude(rayPosition, circlePosition) - circleRadius;
                graphics.DrawEllipse(circlePen, rayPosition.X - distance, rayPosition.Y - distance, distance * 2, distance * 2);
                Vector2 lastRayPosition = rayPosition;
                var sinCosX = MathF.SinCos(oneDegree * cameraDirection.X * 90);
                var sinCosY = MathF.SinCos(oneDegree * cameraDirection.Y * 90);
                rayPosition = new(rayPosition.X + distance * sinCosX.Sin, rayPosition.Y + distance * sinCosY.Sin);
                graphics.DrawEllipse(circlePen2, rayPosition.X, rayPosition.Y, 2, 2);
                graphics.DrawLine(circlePen, lastRayPosition.X, lastRayPosition.Y, rayPosition.X, rayPosition.Y);
                if (distance > maxDistance) return false;
                if (distance < hitDistance) return true;
            }
        }

        private void PrintProperties(Graphics graphics , Pen circlePen , Pen circlePen2 , Vector2 cameraPosition , Vector2 circlePosition , float circleRadius, Vector2 circleScale , Vector2 cameraDirection , Point cursorPosition)
        {
            graphics.DrawEllipse(circlePen2, cameraPosition.X, cameraPosition.Y, 2, 2);
            graphics.DrawEllipse(circlePen2, circlePosition.X - circleRadius, circlePosition.Y - circleRadius, circleScale.X, circleScale.Y);
            graphics.DrawEllipse(circlePen2, circlePosition.X, circlePosition.Y, 2, 2);
            PropertyText.Text = "Camera direction :" + cameraDirection.ToString() + ", Circle Position:" + circlePosition.ToString() + "Cursor position" + cursorPosition.ToString() + "\n Circle scale : " 
                + circleScale.ToString();
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
}
