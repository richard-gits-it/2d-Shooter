using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletBox
{
    class StrongEnemy : Enemy
    {
        Form gameScreen;
        Random rand = new Random();
        private Pen pen;
        private Color color = Color.DarkOrange;

        public override void SpawnEnemy(Form form)
        {
            base.SpawnEnemy(form);

            //spawns randomly outside screen
            if (rand.Next(2) == 0)
            {
                EnemySpawn.Left = -EnemySpawn.Width;
            }
            else
            {
                EnemySpawn.Left = form.ClientSize.Width;
            }
            if (rand.Next(2) == 0)
            {
                EnemySpawn.Top = -EnemySpawn.Height;
            }
            else
            {
                EnemySpawn.Top = form.ClientSize.Height;
            }
            EnemySpawn.Size = new Size(50, 50);

            gameScreen = form;

            EnemySpawn.Paint += ZombieSpawn_Paint;
            gameScreen.Controls.Add(EnemySpawn);
            EnemySpawn.BringToFront();
            EnemySpawn.Tag = "sEnemy";

        }

        private void ZombieSpawn_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pen = new Pen(color);
            g.FillRectangle(pen.Brush, EnemyLeft, EnemyTop, 50, 50);
        }
    }
}
