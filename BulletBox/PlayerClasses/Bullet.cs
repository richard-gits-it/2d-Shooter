using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace BulletBox
{
    internal class Bullet
    {
        //fields
        private int _x;
        private int _y;
        private int _velocityX;
        private int _velocityY;
        private Point _target;
        //private int _diameter = 10;
        //private int _radius = 200;
        private Timer _bulletTimer = new Timer();
        private PictureBox bullet = new PictureBox();
        private Color _color = Color.LightGoldenrodYellow;

        //methods
        public void MakeBullet(Form form)
        {
            CurrentBullet.BackColor = _color;
            CurrentBullet.Size = new Size(10, 10);
            CurrentBullet.Left = _x;
            CurrentBullet.Top = _y;
            CurrentBullet.BringToFront();
            CurrentBullet.Tag = "bullet";

            form.Controls.Add(CurrentBullet);

            _bulletTimer.Interval = 5;
            _bulletTimer.Tick += new EventHandler(BulletTick);
            _bulletTimer.Start();
        }

        private void BulletTick(object sender, EventArgs e)
        {
            CurrentBullet.Left += _velocityX;
            CurrentBullet.Top += _velocityY;

            if (IsOffscreen())
            {
                _bulletTimer.Stop();
                _bulletTimer.Dispose();
                CurrentBullet.Dispose();

                _bulletTimer = null;
                CurrentBullet = null;
            }
        }

        private bool IsOffscreen()
        {
            return CurrentBullet.Right < 0 || CurrentBullet.Left > 1280 || CurrentBullet.Bottom < 0 || CurrentBullet.Top > 720;
        }



        //properties
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int VelocityX { get => _velocityX; set => _velocityX = value; }
        public int VelocityY { get => _velocityY; set => _velocityY = value; }
        public Timer BulletTimer { get => _bulletTimer; set => _bulletTimer = value; }
        public PictureBox CurrentBullet { get => bullet; set => bullet = value; }
        public Point Target { get => _target; set => _target = value; }
    }
}
