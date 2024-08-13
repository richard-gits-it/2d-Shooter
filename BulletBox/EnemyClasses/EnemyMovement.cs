using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace BulletBox
{
    public class EnemyMovement
    {
        BulletBox gameScreen;

        Timer _timer = new Timer();

        int speed = (int)1;
        int speed2 = (int)2;

        public EnemyMovement(BulletBox game)
        {
            gameScreen = game;
        }


        public void MoveZombie() //follows player
        {
            foreach (Control x in gameScreen.Controls)
            {

                    if (x is PictureBox && (string)x.Tag == "fEnemy")
                    {
                        //weakenemy is faster
                        if (x.Left > gameScreen.gunBox.Left)
                        {
                            x.Left -= speed2;
                        }
                        if (x.Left < gameScreen.gunBox.Left)
                        {
                            x.Left += speed2;
                        }
                        if (x.Top > gameScreen.gunBox.Top)
                        {
                            x.Top -= speed2;
                        }
                        if (x.Top < gameScreen.gunBox.Top)
                        {
                            x.Top += speed2;
                        }
                    }
            }

            foreach (Control x in gameScreen.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "sEnemy")
                {
                    //strong enemy is slower
                    if (x.Left > gameScreen.gunBox.Left)
                    {
                        x.Left -= speed;
                    }
                    if (x.Left < gameScreen.gunBox.Left)
                    {
                        x.Left += speed;
                    }
                    if (x.Top > gameScreen.gunBox.Top)
                    {
                        x.Top -= speed;
                    }
                    if (x.Top < gameScreen.gunBox.Top)
                    {
                        x.Top += speed;
                    }
                }
            }
        }

        
    }
}
