using System;
using System.Drawing;

namespace LABA6
{
    public class ParticleCounter : IImpactPoint
    {
        public int Count { get; private set; } = 0;

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            if (distance < 20) // радиус, в пределах которого частицы будут уничтожаться
            {
                particle.Life = 0; // уничтожаем частицу
                Count++; // увеличиваем счетчик
            }
        }

        public override void Render(Graphics g)
        {
            // Ограничиваем насыщенность цвета для заливки
            int alpha = (int)Math.Min(255, Count * 0.5f);
            Color fillColor = Color.FromArgb(alpha, Color.Red);

            using (Pen pen = new Pen(Color.Red, 2))
            using (Brush brush = new SolidBrush(fillColor)) // Небольшая прозрачность для заливки
            {
                g.FillEllipse(brush, X - 18, Y - 18, 36, 36); // Рисуем внутренний залитый круг
                g.DrawEllipse(pen, X - 20, Y - 20, 40, 40); // Рисуем красную рамку

                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    var text = Count.ToString();
                    var font = new Font("Arial", 10);
                    var textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, textBrush, X - textSize.Width / 2, Y - textSize.Height / 2); // Рисуем текст по центру
                }
            }
        }
    }
}
