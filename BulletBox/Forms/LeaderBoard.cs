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

namespace BulletBox
{
    public partial class LeaderBoard : Form
    {
        List<Player> players = new List<Player>();
        SoundPlayer menu = new SoundPlayer(Properties.Resources.menuselect);
        public LeaderBoard()
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
                x.Font = new Font(pfc.Families[0], x.Font.Size, x.Font.Style);
            }
        }

        private void LoadScore()
        {

            if (!File.Exists("scoreData.csv"))
            {
                Console.WriteLine("File not found");
                return;
            }

            players.Clear();

            StreamReader inputFile = new StreamReader("scoreData.csv");
            while (!inputFile.EndOfStream)
            {
                string line = inputFile.ReadLine();
                var tmpArr = line.Split(',');

                Player tmp = new Player(tmpArr[0], int.Parse(tmpArr[1]));

                players.Add(tmp);

            }
            inputFile.Close();

        }

        private void LeaderUpdate()
        {
            List<Player> playerScoresSorted = players.OrderByDescending(o => o.Score).ToList();

            try
            {
                player1.Text = playerScoresSorted[0].Username;
                score1.Text = playerScoresSorted[0].Score.ToString();

                player2.Text = playerScoresSorted[1].Username;
                score2.Text = playerScoresSorted[1].Score.ToString();

                player3.Text = playerScoresSorted[2].Username;
                score3.Text = playerScoresSorted[2].Score.ToString();

                player4.Text = playerScoresSorted[3].Username;
                score4.Text = playerScoresSorted[3].Score.ToString();

                player5.Text = playerScoresSorted[4].Username;
                score5.Text = playerScoresSorted[4].Score.ToString();

                player6.Text = playerScoresSorted[5].Username;
                score6.Text = playerScoresSorted[5].Score.ToString();

                player7.Text = playerScoresSorted[6].Username;
                score7.Text = playerScoresSorted[6].Score.ToString();

                player8.Text = playerScoresSorted[7].Username;
                score8.Text = playerScoresSorted[7].Score.ToString();

                player9.Text = playerScoresSorted[8].Username;
                score9.Text = playerScoresSorted[8].Score.ToString();

                player10.Text = playerScoresSorted[9].Username;
                score10.Text = playerScoresSorted[9].Score.ToString();
            }
            catch (Exception)
            {

            }

        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            LoadScore();
            LeaderUpdate();
        }

        private void MouseEntered(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size + 4);
                label.ForeColor = Color.Red;
            }
            menu.Play();
        }

        private void MouseLeft(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - 4);
                label.ForeColor = Color.White;
            }
        }

        private void lblMain_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu main = new MainMenu();
            main.ShowDialog();
            this.Close();
        }
    }
}
