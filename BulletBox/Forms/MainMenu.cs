using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace BulletBox
{
    public partial class MainMenu : Form
    {
        Random rand = new Random();
        SoundPlayer menu = new SoundPlayer(Properties.Resources.menuselect);
        public MainMenu()
        {
            InitializeComponent();
            Changefont();
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

        private void lblPlay_Click(object sender, EventArgs e)
        {
            Hide();
            BulletBox game = new BulletBox();
            game.ShowDialog();
            this.Close();
        }

        private void lblLead_Click(object sender, EventArgs e)
        {
            Hide();
            LeaderBoard board = new LeaderBoard();
            board.ShowDialog();
            this.Close();
        }


        private void lblQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MouseEntered(object sender, EventArgs e)
        {
            label = sender as Label;
            if (label != null)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size + 4);
                label.ForeColor = Color.Red;
            }
            menu.Play();
        }
        private void MouseLeft(object sender, EventArgs e)
        {
            label = sender as Label;
            if (label != null)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - 4);
                label.ForeColor = Color.White;
            }
        }

        //shake text effects

        private bool _isShaking = false;
        private Timer _shakeTimer = new Timer();
        private int _shakeCount = 0;
        private const int _shakeAmount = 10;
        private Label label;

        //private void MouseMoving(object sender, MouseEventArgs e)
        //{
        //    label = sender as Label;
        //    if (label != null)
        //    {
        //        if (_isShaking)
        //        {
        //            //shakes text when mouse is in container
        //            const int shakeAmount = 4;
        //            Point originalLocation = label.Location;
        //            while (_isShaking)
        //            {
        //                int dx = rand.Next(-shakeAmount, shakeAmount + 1);
        //                int dy = rand.Next(-shakeAmount, shakeAmount + 1);
        //                label.Location = new Point(originalLocation.X + dx, originalLocation.Y + dy);
        //            }
        //            label.Location = originalLocation;
        //        }
        //    }
        //}

        private void _shakeTimer_Tick(object sender, EventArgs e)
        {

            if (label != null)
            {
                if (_isShaking)
                {
                    //shakes text when mouse is in container
                    const int shakeAmount = 4;
                    Point originalLocation = label.Location;
                    while (_isShaking)
                    {
                        int dx = rand.Next(-shakeAmount, shakeAmount + 1);
                        int dy = rand.Next(-shakeAmount, shakeAmount + 1);
                        label.Location = new Point(originalLocation.X + dx, originalLocation.Y + dy);
                        Application.DoEvents();
                    }
                    label.Location = originalLocation;
                }
                else
                {
                    _shakeTimer.Stop();
                }
            }
        }

        private void TextShake(Label x)
        {
            //shakes text when mouse is in container
            const int shakeAmount = 4;
            Point originalLocation = x.Location;
            while (_isShaking)
            {
                int dx = rand.Next(-shakeAmount, shakeAmount + 1);
                int dy = rand.Next(-shakeAmount, shakeAmount + 1);
                x.Location = new Point(originalLocation.X + dx, originalLocation.Y + dy);
                Application.DoEvents();
            }
            x.Location = originalLocation;
        }
    }
}
