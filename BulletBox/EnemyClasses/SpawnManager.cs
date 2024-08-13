using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace BulletBox
{
    public class SpawnManager
    {
        //variables
        BulletBox gameScreen;
        Random randSpawn = new Random();
        Timer spawnTimer = new Timer();


        //properties


        //constructor
        public SpawnManager(BulletBox game)
        {
            gameScreen = game;
            spawnTimer.Interval = 1000;
            spawnTimer.Tick += new EventHandler(SpawnTick);
            spawnTimer.Start();
        }

        //methods
        private void SpawnTick(object sender, EventArgs e)
        {
            int time;
            int spawnOdds;
            try
            {
                time = (int)gameScreen.elapsedTime.TotalSeconds;
                spawnOdds = 50;

            }
            catch (Exception)
            {

                throw;
            }

            spawnOdds += time*8;

            if (randSpawn.Next(0, 200) < spawnOdds)
            {
                SpawnWeakEnemy();
            }
            if (randSpawn.Next(0, 2000) < spawnOdds)
            {
                SpawnStrongEnemy();
            }
        }

        private void SpawnWeakEnemy()
        {
            Enemy enemy = new WeakEnemy();
            enemy.SpawnEnemy(gameScreen);
        }

        private void SpawnStrongEnemy()
        {
            Enemy enemy = new StrongEnemy();
            enemy.SpawnEnemy(gameScreen);
        }


    }
}
