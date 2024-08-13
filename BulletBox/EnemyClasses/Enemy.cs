using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletBox
{
    public abstract class Enemy
    {
        //variables
        PictureBox enemy;

        int enemyLeft;
        int enemyTop;

        //properties
        public PictureBox EnemySpawn { get => enemy; set => enemy = value; }
        public int EnemyLeft { get => enemyLeft; set => enemyLeft = value; }
        public int EnemyTop { get => enemyTop; set => enemyTop = value; }

        //methods
        public virtual void SpawnEnemy(Form form)
        {
            enemy = new PictureBox();
            EnemySpawn.SizeMode = PictureBoxSizeMode.StretchImage;
            EnemySpawn.Enabled = false;
        }
    }
}
