﻿using System;
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
        bool winner = false;
        bool turn = true;
        int turn_count = 0;
        private Button[] btnArr = new Button[9];
        public Form1()
        {
            InitializeComponent();
            this.btnArr[0] = T1;
            this.btnArr[1] = T2;
            this.btnArr[2] = T3;
            this.btnArr[3] = M1;
            this.btnArr[4] = M2;
            this.btnArr[5] = M3;
            this.btnArr[6] = B1;
            this.btnArr[7] = B2;
            this.btnArr[8] = B3;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = "X";
            btn.Enabled = false;
            this.turn_count++;
            this.turn = !this.turn;
            check_Winner();
            computer_Move();
        }

        private void preforme_Click(Button btn)
        {
            if (!this.winner)
            {
                btn.Text = "O";
                btn.Enabled = false;
                this.turn_count++;
                this.turn = !this.turn;
                check_Winner();
            }
        }


        private void computer_Move()
        {
            ///prioreties:
            ///1. Winning
            ///2. Blocking
            ///3. Going For A Corner 
            ///4. Picking An Open Space
            Button move = null;
            move = win_or_block("O");
            if (move == null)
            {
                move = win_or_block("X");
                if (move == null)
                {
                    move = find_Corner();
                    if (move == null)
                    {
                        move = open_Space();
                    }
                }
            }
            if ((T1.Text == "X") && (M2.Enabled) || (T3.Text == "X") && (M2.Enabled) || (B1.Text == "X") && (M2.Enabled) || (B3.Text == "X") && (M2.Enabled))
                move = M2;
            preforme_Click(move);
        }

        private Button win_or_block(string sign)
        {
            Console.WriteLine("Checking");
            //Horizontal Check
            if ((T1.Text == sign) && (T2.Text == sign) && (T3.Text == ""))
                return T3;
            if ((T2.Text == sign) && (T3.Text == sign) && (T1.Text == ""))
                return T1;
            if ((T1.Text == sign) && (T3.Text == sign) && (T2.Text == ""))
                return T2;
            if ((M1.Text == sign) && (M2.Text == sign) && (M3.Text == ""))
                return M3;
            if ((M2.Text == sign) && (M3.Text == sign) && (M1.Text == ""))
                return M1;
            if ((M1.Text == sign) && (M3.Text == sign) && (M2.Text == ""))
                return M2;
            if ((B1.Text == sign) && (B2.Text == sign) && (B3.Text == ""))
                return B3;
            if ((B2.Text == sign) && (B3.Text == sign) && (B1.Text == ""))
                return B1;
            if ((B1.Text == sign) && (B3.Text == sign) && (B2.Text == ""))
                return B2;
            //Vertical Check
            if ((T1.Text == sign) && (M1.Text == sign) && (B1.Text == ""))
                return B1;
            if ((M1.Text == sign) && (B1.Text == sign) && (T1.Text == ""))
                return T1;
            if ((T1.Text == sign) && (B1.Text == sign) && (M1.Text == ""))
                return M1;
            if ((T2.Text == sign) && (M2.Text == sign) && (B2.Text == ""))
                return B2;
            if ((M2.Text == sign) && (B2.Text == sign) && (T2.Text == ""))
                return T2;
            if ((T2.Text == sign) && (B2.Text == sign) && (M2.Text == ""))
                return M2;
            if ((T3.Text == sign) && (M3.Text == sign) && (B3.Text == ""))
                return B3;
            if ((M3.Text == sign) && (B3.Text == sign) && (T3.Text == ""))
                return T3;
            if ((T3.Text == sign) && (B3.Text == sign) && (M3.Text == ""))
                return M3;
            //Diagonal Check
            if ((T1.Text == sign) && (M2.Text == sign) && (B3.Text == ""))
                return B3;
            if ((M2.Text == sign) && (B3.Text == sign) && (T1.Text == ""))
                return T1;
            if ((T1.Text == sign) && (B3.Text == sign) && (M2.Text == ""))
                return M2;
            if ((T3.Text == sign) && (M2.Text == sign) && (B1.Text == ""))
                return B1;
            if ((M2.Text == sign) && (B1.Text == sign) && (T3.Text == ""))
                return T3;
            if ((T3.Text == sign) && (B1.Text == sign) && (M2.Text == ""))
                return M2;

            return null;
        }

        private Button find_Corner()
        {
            Console.WriteLine("In corner");
            if (T1.Text == "O")
            {
                if (T3.Text == "")
                    return T3;
                if (B3.Text == "")
                    return B3;
                if (B1.Text == "")
                    return B1;
            }
            if (T3.Text == "O")
            {
                if (T1.Text == "")
                    return T1;
                if (B3.Text == "")
                    return B3;
                if (B1.Text == "")
                    return B1;
            }
            if (B3.Text == "O")
            {
                if (T1.Text == "")
                    return T1;
                if (T3.Text == "")
                    return T3;
                if (B1.Text == "")
                    return B1;
            }
            if (B1.Text == "O")
            {
                if (T1.Text == "")
                    return T1;
                if (T3.Text == "")
                    return T3;
                if (B3.Text == "")
                    return B3;
            }
            if (T1.Text == "")
                return T1;
            if (T3.Text == "")
                return T3;
            if (B1.Text == "")
                return B1;
            if (B3.Text == "")
                return B3;
            return null;
        }

        private Button open_Space()
        {
            Console.WriteLine("In open space");
            Button btn = null;
            foreach (Control c in Controls)
            {
                btn = c as Button;
                if (btn != null)
                {
                    if (btn.Text == "")
                        return btn;
                }
            }
            return null;
        }
     


        private void check_Winner()
        {
            if ((T1.Text == T2.Text) && (T2.Text == T3.Text) && (!T1.Enabled)) 
                this.winner = true;
            if ((M1.Text == M2.Text) && (M2.Text == M3.Text) && (!M1.Enabled))
                this.winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                this.winner = true;
            if ((T1.Text == M1.Text) && (M1.Text == B1.Text) && (!T1.Enabled))
                this.winner = true;
            if ((T2.Text == M2.Text) && (M2.Text == B2.Text) && (!T2.Enabled))
                this.winner = true;
            if ((T3.Text == M3.Text) && (M3.Text == B3.Text) && (!T3.Enabled))
                this.winner = true;
            if ((T1.Text == M2.Text) && (M2.Text == B3.Text) && (!T1.Enabled))
                this.winner = true;
            if ((T3.Text == M2.Text) && (M2.Text == B1.Text) && (!T3.Enabled))
                this.winner = true;
            if (this.winner)
            {
                disable_buttons();
                string win = "";
                if (turn)
                    win = "O";
                else
                    win = "X";
                MessageBox.Show(win + " Won!", "Score");
                this.winner = false;
            }
            else if (this.turn_count == 9)
            {
                disable_buttons();
                MessageBox.Show("It's a Tie!", "Score");
            }
                    
        }

        private void disable_buttons()
        {
            for (int i = 0; i < this.btnArr.Length; i++)
            {
                this.btnArr[i].Enabled = false;
            }
        }

        private void PC_Click(object sender, EventArgs e)
        {
            this.turn_count = 0;
            this.turn = false;
            for (int i =0; i < this.btnArr.Length; i++)
            {
                this.btnArr[i].Text = "";
                this.btnArr[i].Enabled = true;
            }
            computer_Move();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            this.turn_count = 0;
            this.turn = true;
            for (int i = 0; i < this.btnArr.Length; i++)
            {
                this.btnArr[i].Text = "";
                this.btnArr[i].Enabled = true;
            }

        }
    }
}
