using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TIC_TAC_TOE
{
    public partial class Form1 : Form
    {
        private int player = 0;
        private int x = 12, y = 12;
        private int size = 3;
        private Button[,] buttons;        
        public Form1()
        {
            InitializeComponent();
            this.Height = 850;
            this.Width = 850;
            player = 0;
            label1.Text = $"Ход {player + 1} игрока";
            setbuttons();

        }
        private void setbuttons()
        {
            buttons = new Button[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                }
            }
            for (int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    buttons[i,j].Text = "";
                    buttons[i, j].Enabled = true;
                    buttons[i,j].Location = new Point(150+x+206*j, y+206*i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font("Microsoft Sans Sefif", 60);
                    this.Controls.Add(buttons[i,j]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            switch (player)
            {
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");
                    checkwin();
                    player = 1;
                    break;
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");
                    checkwin();
                    player = 0;
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            label1.Text = $"Ход {player + 1} игрока";
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    buttons[i,j].Enabled = true;
                    buttons[i, j].Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0; i<size; i++) for(int j=0; j<size; j++) this.Controls.Remove(buttons[i, j]);
            string m = sender.GetType().GetProperty("Text").GetValue(sender).ToString();
            size = (int)m[0]-48;
            setbuttons();
        }

        private void checkwin()
        {

            bool stop = false;
            for(int i=0; i < size; i++)
            {
                stop = false;
                for(int j=0; (j + 2) < size; j++)
                {
                    if (buttons[i,j].Text == buttons[i, j+1].Text && buttons[i, j+1].Text == buttons[i,j+2].Text && buttons[i, j].Text !="")
                    {
                        MessageBox.Show($"Победа ирока {player+1}");
                        stop = true;
                        break;
                    }
                    if (buttons[j, i].Text == buttons[j+1, i].Text && buttons[j+1, i].Text == buttons[j + 2, i].Text && buttons[j, i].Text != "")
                    {
                        MessageBox.Show($"Победа ирока {player + 1}");
                        stop = true;
                        break;
                        
                    }
                }
                if (stop) break;
            }
            for(int i=0; (i + 2)<size; i++)
            {
                for(int j=0; (j + 2)<size; j++)
                {
                    if (buttons[i, j].Text != "" && buttons[i, j].Text == buttons[i + 1, j + 1].Text && buttons[i + 2, j +  2].Text == buttons[i + 1, j + 1].Text)
                    {
                        MessageBox.Show($"Победа ирока {player + 1}");
                        stop = true;
                        break;
                    }
                }
                if (stop) break;
            }
            for(int i = (size - 1); (i-2)>=0; i--)
            {
                for(int j=0; (j+2)<size; j++)
                {
                    if (buttons[i, j].Text != "" && buttons[i-1, j+1].Text == buttons[i, j].Text && buttons[i - 1, j + 1].Text == buttons[i-2, j + 2].Text)
                    {
                        MessageBox.Show($"Победа ирока {player + 1}");
                        stop = true;
                        break;
                    }
                }
                if (stop) break;
            }
        }
    }
}