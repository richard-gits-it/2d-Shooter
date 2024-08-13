using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Numerics;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Media;

namespace BulletBox
{
    public partial class BulletBox : Form
    {
        SpawnManager spawnManager;
        EnemyMovement enemyMovement;
        CollisionTesting collisionTesting;

        //fields
        Random rand = new Random();
        
        
        private int _angle; 
        private Stopwatch stopwatch = new Stopwatch();
        public TimeSpan elapsedTime;
        private string eT;
        SoundPlayer gunshot;
        SoundPlayer reload;


        //variables for bullet
        double _direction;
        double _bulletSpeed = 30;
        int _velocityX;
        int _velocityY;

        //movement variables
        enum KPress { none = 0, up = 1, right = 2, down = 4, left = 8 };
        KPress PlayerMove = KPress.none;

        //player variables
        int playerHealth = 100;
        int playerSpeed = 5;
        int score = 0;
        int ammo = 6;

        //properties
        public SpawnManager SpawnMan { get => spawnManager; }
        public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public int Score { get => score; set => score = value; }


        //constructor
        public BulletBox()
        {
            spawnManager = new SpawnManager(this);
            enemyMovement = new EnemyMovement(this);
            collisionTesting = new CollisionTesting(this);

            InitializeComponent();

            Changefont();
            gunshot = new SoundPlayer(Properties.Resources.gunshot);
            reload = new SoundPlayer(Properties.Resources.gunreload);


        }


        //METHODS

        private void gametimer_Tick(object sender, EventArgs e)
        {
            PointToCursor();
            MovePlayer();
            IsPlayerALive();

            enemyMovement.MoveZombie();
            collisionTesting.DetectCollision();

            try
            {
                lblScore.Text = "Score: " + score.ToString();
                lblAmmo.Text = ammo.ToString();
                lblHealth.Text = playerHealth.ToString() + "/100";
                elapsedTime = stopwatch.Elapsed;
                eT = String.Format(@"{0:D}.{1:00}s",elapsedTime.Seconds + (elapsedTime.Minutes * 60), elapsedTime.Milliseconds);
                lblTimer.Text = eT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ShootBullet(_velocityX, _velocityY, e.Location);
        }
        private void BulletBox_Load(object sender, EventArgs e)
        {
            gametimer.Start();
            StartTimer();

        }

        //movement
        private void MovePlayer()
        {
            //movement
            if ((PlayerMove & KPress.left) == KPress.left && gunBox.Left > 0)
            {
                gunBox.Left -= playerSpeed;
                reloadBar.Left -= playerSpeed;
                lblReload.Left -= playerSpeed;
            }

            if ((PlayerMove & KPress.right) == KPress.right && gunBox.Left + gunBox.Width < this.ClientSize.Width)
            {
                gunBox.Left += playerSpeed;
                reloadBar.Left += playerSpeed;
                lblReload.Left += playerSpeed;
            }

            if ((PlayerMove & KPress.up) == KPress.up && gunBox.Top > 40)
            {
                gunBox.Top -= playerSpeed;
                reloadBar.Top -= playerSpeed;
                lblReload.Top -= playerSpeed;
            }

            if ((PlayerMove & KPress.down) == KPress.down && gunBox.Top + gunBox.Height < this.ClientSize.Height)
            {
                gunBox.Top += playerSpeed;
                reloadBar.Top += playerSpeed;
                lblReload.Top += playerSpeed;
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    PlayerMove |= KPress.left;
                    break;
                case Keys.D:
                    PlayerMove |= KPress.right;
                    break;
                case Keys.W:
                    PlayerMove |= KPress.up;
                    break;
                case Keys.S:
                    PlayerMove |= KPress.down;
                    break;
            }
            System.Diagnostics.Debug.WriteLine("Direction: " + PlayerMove.ToString());
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    PlayerMove &= ~KPress.left;
                    break;
                case Keys.D:
                    PlayerMove &= ~KPress.right;
                    break;
                case Keys.W:
                    PlayerMove &= ~KPress.up;
                    break;
                case Keys.S:
                    PlayerMove &= ~KPress.down;
                    break;
            }
            System.Diagnostics.Debug.WriteLine("Direction: " + PlayerMove.ToString());
        }

        //checks
        private void IsPlayerALive()
        {
            if (playerHealth > 1)
            {

            }
            else
            {
                gametimer.Stop();
                StopTimer();

                Hide();
                DeadScreen gameOver = new DeadScreen(score, eT);
                gameOver.ShowDialog();
                this.Close();
            }
        }

        //shooting
        private async void ShootBullet(int velocityX, int velocityY, Point target)
        {
            if (ammo > 0)
            {
                Bullet newBullet = new Bullet();
                newBullet.Target = target;
                newBullet.VelocityX = velocityX;
                newBullet.VelocityY = velocityY;
                newBullet.X = gunBox.Left + (gunBox.Width / 2);
                newBullet.Y = gunBox.Top + (gunBox.Height / 2);
                newBullet.MakeBullet(this);
                ammo--;
                ScreenShake();
                gunshot.Play();
            }
            if (ammo == 0)
            {
                reloadBar.Visible = true;
                lblReload.Visible = true;
                reloadBar.Value = 0;

                //delays shooting for 1 seconds to reload
                int progress = 0;
                while (progress < 100)
                {
                    await Task.Delay(100);
                    progress += 10;
                    reloadBar.Value = progress;
                }
                reload.Play();
                ammo = 6;
            }
            reloadBar.Visible = false;
            lblReload.Visible = false;
        }



        //StopWatch methods
        private void StartTimer()
        {
            stopwatch.Start();
        }
        private void StopTimer()
        {
            stopwatch.Stop();
        }
        private void ResetTimer()
        {
            stopwatch.Reset();
        }




        //FORM CHANGES
        private void ScreenShake()
        {
            //shakes screen when mouse clicked
            const int shakeAmount = 4;
            const int shakeDuration = 200; // in milliseconds
            Point originalLocation = Location;
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalMilliseconds < shakeDuration)
            {
                int dx = rand.Next(-shakeAmount, shakeAmount + 1);
                int dy = rand.Next(-shakeAmount, shakeAmount + 1);
                Location = new Point(originalLocation.X + dx, originalLocation.Y + dy);
                Application.DoEvents();
                //System.Threading.Thread.Sleep(10);
            }
            Location = originalLocation;
        }
        private void Changefont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("upheavtt.ttf");
            foreach (Control x in this.Controls)
            {
                x.Font = new Font(pfc.Families[0], x.Font.Size, FontStyle.Regular);
            }
        }

        //change cursor to crosshair
        private void BulletBox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = new Cursor(Properties.Resources.crosshair.GetHicon());
        }

        private void BulletBox_MouseLeave(object sender, EventArgs e)
        {
            //Cursor = Cursors.Default;
        }

        //creates rectangle
        private void gunBox_Paint(object sender, PaintEventArgs e)
        {
            var gradientBrush = new LinearGradientBrush(new Point(-20, -10), new Point(50, 0), Color.Blue, Color.DarkBlue);
            var pen = new Pen(gradientBrush, 1);

            Graphics g = e.Graphics;

            g.TranslateTransform(gunBox.Width / 2, gunBox.Height / 2);
            g.RotateTransform(_angle); //rotates to calculated angle
            g.FillRectangle(pen.Brush, -20, -10, 50, 20);
        }

        private void PointToCursor()
        {
            //finds angle for gunBox to rotate
            int dx = Cursor.Position.X - Location.X - (gunBox.Location.X + gunBox.Width / 2);
            int dy = Cursor.Position.Y - Location.Y - (gunBox.Location.Y + gunBox.Height / 2);
            int newAngle = (int)(Math.Atan2(dy, dx) * 180.0 / Math.PI); //trig function to find angle
            if (newAngle != _angle)
            {
                _angle = newAngle;
                gunBox.Invalidate(); //redraws picture box to update the rotation angle
            }

            //finds direction and velocities for bullet
            _direction = Math.Atan2(dy, dx);
            _velocityX = (int)(Math.Cos(_direction) * _bulletSpeed);
            _velocityY = (int)(Math.Sin(_direction) * _bulletSpeed);
            lblX.Text = _velocityX.ToString("F2");
            lblY.Text = _velocityY.ToString("F2");
            lblD.Text = newAngle.ToString("F2");
        }

    }
}