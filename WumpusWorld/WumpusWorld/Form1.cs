using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusWorld
{
    public partial class Form1 : Form
    {
        //Cueva de Picture Box Generada
        PictureBox[,] cueva = new PictureBox[4,4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < cueva.GetLength(0); x++)
            {
                for (int y = 0; y < cueva.GetLength(1); y++)
                {
                    cueva[x, y] = new PictureBox();
                    cueva[x, y].Size = new Size(150, 150);
                    cueva[x, y].BorderStyle = BorderStyle.FixedSingle;
                    cueva[x, y].Location = new Point(250 + (x * 150), 150 + (y * 150));

                    this.Controls.Add(cueva[x, y]);
                }
            }
        }
    }
}
