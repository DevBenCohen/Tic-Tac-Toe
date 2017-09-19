using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (turn)
                btn.Text = "X";
            else
                btn.Text = "O";
            btn.Enabled = false;
            this.turn = !this.turn;
            this.turn_count++;
            check_Winner();
        }


        private void check_Winner()
        {
            bool winner = false;
            if ((T1.Text == T2.Text) && (T2.Text == T3.Text) && (!T1.Enabled)) 
                winner = true;
            if ((M1.Text == M2.Text) && (M2.Text == T3.Text) && (!M1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((T1.Text == M1.Text) && (M1.Text == B1.Text) && (!T1.Enabled))
                winner = true;
            if ((T2.Text == M2.Text) && (M2.Text == B2.Text) && (!T2.Enabled))
                winner = true;
            if ((T3.Text == M3.Text) && (M3.Text == B3.Text) && (!T3.Enabled))
                winner = true;
            if ((T1.Text == M2.Text) && (M2.Text == B3.Text) && (!T1.Enabled))
                winner = true;
            if ((T3.Text == M2.Text) && (M2.Text == B1.Text) && (!T3.Enabled))
                winner = true;
            if (winner)
            {
                disable_buttons();
                string win = "";
                if (turn)
                    win = "O";
                else
                    win = "X";
                MessageBox.Show(win + " Won!", "Score");
            }
            else if (this.turn_count == 9)
            {
                disable_buttons();
                MessageBox.Show("It's a Tie!", "Score");
            }
                    
        }

        private void disable_buttons()
        {
            foreach (Control c in Controls)
            {
                Button btn = c as Button;
                btn.Enabled = false;
            }
        }
    }
}
