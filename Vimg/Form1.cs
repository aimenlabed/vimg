using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vimg
{
   
    public partial class Form1 : Form
    { 
        Bitmap b;
        Bitmap bo;
        string su;
        bool w;
        float tw;
        float th;
        bool N;
        
        public Form1()
        {
            
            this.SizeChanged += Form1_SizeChanged;
            
            InitializeComponent();
            
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left) {
                if (flowLayoutPanel1.Visible == false) pictur();
                 else flowLayoutPanel1.Visible = false;
            }
            else if (e.Button == MouseButtons.Right)m(); 
        }

        private void m()
        {
            Point p = Cursor.Position;
            
            p.X -= Location.X+10;
            p.Y -= Location.Y + 35;
            if (p.X > Width - 230) p.X -= 219;
            if (p.Y > Height - 100) p.Y -= 75;
            flowLayoutPanel1.Location = p;
            flowLayoutPanel1.Visible = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            
            if (bo != null) {
            float cc = (float)bo.Width / (float)bo.Height;
            float c2 = (float)pictureBox1.Width / (float)pictureBox1.Height;
            if (pictureBox1.Width >= pictureBox1.Height)
            {
                if (bo.Width >= bo.Height)
                {
                    if (cc < c2)
                    {
                        b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
                    }
                    else
                    {
                        b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
                    }
                }
                else
                    b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
            }
            else
            {

                if (bo.Width < bo.Height)
                {
                    if (cc > c2)
                        b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
                    else
                        b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
                }
                else
                    b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
            }
                pictureBox1.Image = b;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { }
        private void pictur()
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png;*.jpeg;*.gif;*.bmp;*.jpg)|*.png;*.jpeg;*.gif;*.bmp;*.jpg";
            if (open.ShowDialog() == DialogResult.OK) {
                su = open.FileName;
             bo =  new Bitmap(open.FileName);
                float cc = (float)bo.Width / (float)bo.Height;
                float c2 = (float)pictureBox1.Width / (float)pictureBox1.Height;
                if (pictureBox1.Width >= pictureBox1.Height)
                {
                    if (bo.Width >= bo.Height)
                    {
                        if (cc < c2)
                        {
                            b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
                        }
                        else
                        {
                            b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
                        }
                    }
                    else
                        b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
                }
                else
                {

                    if (b.Width < b.Height)
                    {
                        if (cc > c2)
                            b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
                        else
                            b = new Bitmap(bo, new Size((pictureBox1.Height * bo.Width / bo.Height), pictureBox1.Height));
                    }
                    else
                        b = new Bitmap(bo, new Size(pictureBox1.Width, (pictureBox1.Width * bo.Height / bo.Width)));
                }


                pictureBox1.Image = b;
            }
            pictureBox1.BackColor = Color.Black;
                //this.Width = this.Width / 2;
            }

        private void Form1_Load(object sender, EventArgs e)
        {   if(N==false)
            if(Program.U.Length>0)
            {
                    su = Program.U[0];
                b = new Bitmap(Program.U[0]);
                    b = new Bitmap(b, new Size(pictureBox1.Width, pictureBox1.Height));
                    pictureBox1.Image = b;

            }
            N = true;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            pictur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            if (bo == null) MessageBox.Show("no Image");
            else MessageBox.Show("Image Url : "+su+ "\n\nHeight    : " + bo.Height.ToString()+ "\nWidth     : "+bo.Width.ToString());
        }
    }
}
