using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Durak
{
    public partial class Durak : Form
    {
        public Durak()
        {
            InitializeComponent();
        }
        private bool mouse = true;
        private void No_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы не дурак. Поздравляю!");
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я в это не верю. Попробуйте еще раз.");
        }

        private void Durak_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse)
            {
                int x = MousePosition.X - this.Location.X;
                int y = MousePosition.Y - this.Location.Y;

                if (No.Location.X - x > 0 && No.Location.Y - y > 0)
                {
                    if (No.Location.X - x < 35 && No.Location.Y - y < 0)
                    {
                        No.Location = new Point(No.Location.X + 35, No.Location.Y);
                        No.Location = new Point(No.Location.X, No.Location.Y + 35);
                    }
                }
                if (No.Location.X - x < 0 && No.Location.Y - y < 0)
                {
                    if (x - No.Location.X - No.Width < 35 && y - No.Location.Y - No.Height < 35)
                    {
                        if (x - No.Location.X > No.Width / 2)
                        {
                            No.Location = new Point(No.Location.X - 35, No.Location.Y);
                        }
                        if (y - No.Location.Y > No.Height / 2)
                        {
                            No.Location = new Point(No.Location.X, No.Location.Y - 35);
                        }
                    }
                }
                if (No.Location.X - x < 0 && No.Location.Y - y > 0)
                {
                    if (x - No.Location.X - No.Width < 35 && No.Location.Y - y < 35)
                    {
                        if (x - No.Location.X < No.Width / 2)
                        {
                            No.Location = new Point(No.Location.X - 35, No.Location.Y);
                        }
                        No.Location = new Point(No.Location.X, No.Location.Y + 35);
                    }
                }
                if (No.Location.X - x > 0 && No.Location.Y - y < 0)
                {
                    if (No.Location.X - x < 35 && y - No.Location.Y - No.Height < 35)
                    {
                        No.Location = new Point(No.Location.X + 35, No.Location.Y);
                        if (y - No.Location.Y < No.Height / 2)
                        {
                            No.Location = new Point(No.Location.X, No.Location.Y - 35);
                        }
                    }
                }
               
                //
                if (No.Top > ClientSize.Height - No.Height)
                {
                    No.Location = new Point(No.Location.X, No.Height);
                }

                if (No.Top < 0)
                {
                    No.Location = new Point(No.Location.X, ClientSize.Height - No.Height);
                }
                if (No.Left < 0)
                {
                    No.Location = new Point(ClientSize.Width - No.Width, No.Location.Y);
                }

                if (No.Left > ClientSize.Width - No.Width)
                {
                    No.Location = new Point(No.Width, No.Location.Y);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "42")
            {
                mouse = false;
                MessageBox.Show("Чит-код активирован");
            }
        }

        private void No_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }


    }


}

