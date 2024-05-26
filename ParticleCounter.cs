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

        public virtual void Render(Graphics g)
        {
            base.Render(g);

            int alpha = Math.Min(255, Count); // максимальная насыщенность 255
            Color color = Color.FromArgb(alpha, Color.Red);

            using (Brush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, X - 20, Y - 20, 40, 40);
                
            }

            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.DrawString(
                    Count.ToString(),
                    new Font("Arial", 10),
                    brush,
                    X - 10,
                    Y - 10
                );
            }
        }
    }
}
