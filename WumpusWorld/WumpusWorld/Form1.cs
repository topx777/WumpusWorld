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
        PictureBox[,] cueva = new PictureBox[4, 4];
        bool[,] posJugador = new bool[4, 4];
        bool[,] posWumpus = new bool[4, 4];
        bool[,] posPuerta = new bool[4, 4];
        bool[,] posHoyos = new bool[4, 4];
        bool[,] posOro = new bool[4, 4];

        public Form1()
        {
            InitializeComponent();
        }

        private int NumeroRandomico()
        {
            Random genRandom = new Random();
            int numero = genRandom.Next(0, 3);
            return numero;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //generar jugador
            posJugador[0, 0] = true;
            
            //Generar Wumpus
            int posX_Wumpus;
            int posY_Wumpus; 
            do
            {
                posX_Wumpus = NumeroRandomico();
                posY_Wumpus = NumeroRandomico();
            }
            while ((posX_Wumpus == 0 && posY_Wumpus == 0) || (posX_Wumpus == 1 && posY_Wumpus == 0) || (posX_Wumpus == 0 && posY_Wumpus == 1));
            posWumpus[posX_Wumpus, posY_Wumpus] = true;

            //Generar Oro
            int posX_Oro;
            int posY_Oro;
            do
            {
                posX_Oro = NumeroRandomico();
                posY_Oro = NumeroRandomico();
            }
            while ((posX_Oro == 0 && posY_Oro == 0) || (posX_Oro == 1 && posY_Oro == 0) || (posX_Oro == 0 && posY_Oro == 1));
            posOro[posX_Oro, posY_Oro] = true;

            //Generar Hoyos
            int canHoyosGen = 0;
            while (canHoyosGen < 3)
            {
                int posX_Hoyo;
                int posY_Hoyo;
                do
                {
                    posX_Hoyo = NumeroRandomico();
                    posY_Hoyo = NumeroRandomico();
                }
                while ((posX_Hoyo == 0 && posY_Hoyo == 0) || (posX_Hoyo == 1 && posY_Hoyo == 0) || (posX_Hoyo == 0 && posY_Hoyo == 1));
                posOro[posX_Hoyo, posY_Hoyo] = true;
                canHoyosGen++;
            }

            for (int x = 0; x < cueva.GetLength(0); x++)
            {
                for (int y = 0; y < cueva.GetLength(1); y++)
                {
                    cueva[x, y] = new PictureBox();
                    cueva[x, y].Size = new Size(150, 150);
                    cueva[x, y].BorderStyle = BorderStyle.FixedSingle;
                    cueva[x, y].Location = new Point(50 + (x * 150), 50 + (y * 150));

                    if (posJugador[x, y])
                    {
                        cueva[x, y].BackColor = Color.BlueViolet;
                    }
                    else if (posWumpus[x, y])
                    {
                        cueva[x, y].BackColor = Color.Red;
                    }
                    else if (posOro[x, y])
                    {
                        cueva[x, y].BackColor = Color.Yellow;
                    }
                    else if (posHoyos[x, y])
                    {
                        cueva[x, y].BackColor = Color.Black;
                    }

                    this.Controls.Add(cueva[x, y]);
                }
            }
        }


    }
}
