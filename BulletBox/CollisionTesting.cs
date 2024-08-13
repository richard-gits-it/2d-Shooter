using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BulletBox
{
    public class CollisionTesting
    {
        BulletBox gameScreen;


        //constructor
        public CollisionTesting(BulletBox game)
        {
            gameScreen = game;
        }

        //methods
        public void DetectCollision()
        {
            foreach (Control x in gameScreen.Controls)
            {
                foreach (Control y in gameScreen.Controls)
                {
                    //detect enemy hitting by bullet, dies after 1 hit
                    if (y is PictureBox && (string)y.Tag == "bullet" && x is PictureBox && (string)x.Tag == "fEnemy")
                    {
                        EnemyHit(x,y, 3, 1);
                    }

                    //detect strong enemy hitting by bullet, dies after 3 health
                    if (y is PictureBox && (string)y.Tag == "bullet" && x is PictureBox && (string)x.Tag == "sEnemy")
                    {
                        EnemyHit(x, y, 7, 3);
                    }

                    //detect enemy hitting player
                    if (y is PictureBox && (string)y.Tag == "player" && x is PictureBox && ((string)x.Tag == "sEnemy" || (string)x.Tag == "fEnemy"))
                    {
                        PlayerHit(x, y);
                    }
                }

            }

        }

        private int hitCounter = 0;
        public void EnemyHit(Control x, Control y,int score, int health)
        {
            
            //removes controls when collision detected
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                hitCounter++;

                if (hitCounter >= health)
                {
                    //x is enemy
                    gameScreen.Controls.Remove(x);
                    ((PictureBox)x).Dispose();
                    gameScreen.Score += score;
                    hitCounter = 0;
                }
                //y is bullet
                gameScreen.Controls.Remove(y);
                ((PictureBox)y).Dispose();
            }
        }

        public void PlayerHit(Control x, Control y)
        {
            if (x.Bounds.IntersectsWith(y.Bounds))
            {
                gameScreen.PlayerHealth -= 1;
            }
        }

    }
}
