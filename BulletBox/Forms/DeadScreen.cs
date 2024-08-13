using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulletBox
{
    public partial class DeadScreen : Form
    {
        int finalScore;
        string totalTime;
        SoundPlayer menu = new SoundPlayer(Properties.Resources.menuselect);
        public DeadScreen(int score, string time)
        {
            finalScore = score;
            totalTime = time;
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
            foreach (Control y in panel1.Controls)
            {
                y.Font = new Font(pfc.Families[0], y.Font.Size, FontStyle.Regular);
            }
        }

        private void lblMain_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu main = new MainMenu();
            main.ShowDialog();
            this.Close();
        }

        private void DeadScreen_Load(object sender, EventArgs e)
        {
            lblTime.Text = totalTime;
            lblScore.Text = finalScore.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter name.");
            }
            else
            {
                Save();
                panel1.Dispose();
            }
        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Please enter name.");
                }
                else
                {
                    Save();
                    panel1.Dispose();
                }
            }
        }

        private void Save()
        {
            StreamWriter outputFile;
            outputFile = File.AppendText("scoreData.csv");//creates csv file if it does not exist

            //writes data into csv with delimiter comma
            outputFile.WriteLine($"{txtName.Text},{finalScore.ToString()}");

            outputFile.Close();
        }
    }
}
