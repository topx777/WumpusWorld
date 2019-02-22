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
        //Timer
        Timer timer = new Timer();

        //Cueva de Picture Box Generada
        PictureBox[,] cueva = new PictureBox[4, 4];
        //Generar Posicion
        bool[,] posJugador = new bool[4, 4];
        bool[,] posWumpus = new bool[4, 4];
        bool[,] posSalida = new bool[4, 4];
        bool[,] posHoyos = new bool[4, 4];
        bool[,] posOro = new bool[4, 4];
        //Generar Sensores
        bool[,] sensor_hedor = new bool[4, 4];
        bool[,] sensor_brisa = new bool[4, 4];
        bool[,] sensor_resplandor = new bool[4, 4];
        bool[,] sensor_luz = new bool[4, 4];
        bool[,] sensor_grito = new bool[4, 4];

        int PosX_Actual_Jugador = 0;
        int PosY_Actual_Jugador = 0;

        int cantFlechas = 1;
        PictureBox[] flechas;

        public Form1()
        {
            InitializeComponent();
        }

        private int NumeroRandomico()
        {
            Random genRandom = new Random();
            int numero = genRandom.Next(0, 4);
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
            while ((posX_Oro == 0 && posY_Oro == 0) || (posX_Oro == 1 && posY_Oro == 0) || (posX_Oro == 0 && posY_Oro == 1) || (posX_Oro == posX_Wumpus && posY_Oro == posY_Wumpus));
            posOro[posX_Oro, posY_Oro] = true;

            //Generar Oro
            int posX_Salida;
            int posY_Salida;
            do
            {
                posX_Salida = NumeroRandomico();
                posY_Salida = NumeroRandomico();
            }
            while ((posX_Salida == 0 && posY_Salida == 0) || (posX_Salida == 1 && posY_Salida == 0) || (posX_Salida == 0 && posY_Salida == 1) || (posX_Salida == posX_Wumpus && posY_Salida == posY_Wumpus) || (posX_Salida == posX_Oro && posY_Salida == posY_Oro) || (posX_Salida < 2 || posY_Salida < 2) || (posX_Salida == 2 && posY_Salida == 2));
            posSalida[posX_Salida, posY_Salida] = true;

            //Generar Hoyos
            int posX_Hoyo_def = 0;
            int posY_Hoyo_def = 0;
            for (int cantHoyosGen = 0; cantHoyosGen < 2; cantHoyosGen++)
            {
                int posX_Hoyo;
                int posY_Hoyo;
                do
                {
                    posX_Hoyo = NumeroRandomico();
                    posY_Hoyo = NumeroRandomico();
                }
                while ((posX_Hoyo == 0 && posY_Hoyo == 0) || (posX_Hoyo == 1 && posY_Hoyo == 0) || (posX_Hoyo == 0 && posY_Hoyo == 1) || (posX_Hoyo == posX_Oro && posY_Hoyo == posY_Oro) || (posX_Hoyo == posX_Wumpus && posY_Hoyo == posY_Wumpus) || (posX_Hoyo == posX_Salida && posY_Hoyo == posY_Salida) || (posX_Hoyo == posX_Hoyo_def && posY_Hoyo == posY_Hoyo_def) || (posX_Hoyo > 2 || posY_Hoyo > 2) || ((posX_Hoyo == posX_Hoyo_def + 1 || posX_Hoyo == posX_Hoyo_def - 1) || (posY_Hoyo == posY_Hoyo_def + 1 || posY_Hoyo == posY_Hoyo_def - 1)));
                posHoyos[posX_Hoyo, posY_Hoyo] = true;
                posX_Hoyo_def = posX_Hoyo;
                posY_Hoyo_def = posY_Hoyo;
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
                        if (x + 1 <= 3)
                            sensor_hedor[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_hedor[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_hedor[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_hedor[x, y - 1] = true;
                    }
                    else if (posOro[x, y])
                    {
                        cueva[x, y].BackColor = Color.Yellow;
                        if (x + 1 <= 3)
                            sensor_resplandor[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_resplandor[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_resplandor[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_resplandor[x, y - 1] = true;
                    }
                    else if (posSalida[x, y])
                    {
                        cueva[x, y].BackColor = Color.Brown;
                        if (x + 1 <= 3)
                            sensor_luz[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_luz[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_luz[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_luz[x, y - 1] = true;
                    }
                    else if (posHoyos[x, y])
                    {
                        cueva[x, y].BackColor = Color.Black;
                        if (x + 1 <= 3)
                            sensor_brisa[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_brisa[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_brisa[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_brisa[x, y - 1] = true;
                    }

                    this.Controls.Add(cueva[x, y]);
                }
            }

            flechas = new PictureBox[2];
            flechas[0] = new PictureBox();
            flechas[0].Size = new Size(150, 150);
            flechas[0].Location = new Point(50, 50);
            flechas[0].BackColor = Color.ForestGreen;
            flechasGroup.Controls.Add(flechas[0]);

            definirMovimiento();
        }


        private void definirMovimiento()
        {
            btnIzquierda.Visible = PosX_Actual_Jugador - 1 >= 0 ? true : false;
            btnDerecha.Visible = PosX_Actual_Jugador + 1 <= 3 ? true : false;
            btnArriba.Visible = PosY_Actual_Jugador - 1 >= 0 ? true : false;
            btnAbajo.Visible = PosY_Actual_Jugador + 1 <= 3 ? true : false;
        }

        private void redefinirCueva()
        {
            for (int x = 0; x < cueva.GetLength(0); x++)
            {
                for (int y = 0; y < cueva.GetLength(1); y++)
                {
                    cueva[x, y].Dispose();
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
                        if (x + 1 <= 3)
                            sensor_hedor[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_hedor[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_hedor[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_hedor[x, y - 1] = true;
                    }
                    else if (posOro[x, y])
                    {
                        cueva[x, y].BackColor = Color.Yellow;
                        if (x + 1 <= 3)
                            sensor_resplandor[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_resplandor[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_resplandor[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_resplandor[x, y - 1] = true;
                    }
                    else if (posSalida[x, y])
                    {
                        cueva[x, y].BackColor = Color.Brown;
                        if (x + 1 <= 3)
                            sensor_luz[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_luz[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_luz[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_luz[x, y - 1] = true;
                    }
                    else if (posHoyos[x, y])
                    {
                        cueva[x, y].BackColor = Color.Black;
                        if (x + 1 <= 3)
                            sensor_brisa[x + 1, y] = true;
                        if (x - 1 >= 0)
                            sensor_brisa[x - 1, y] = true;
                        if (y + 1 <= 3)
                            sensor_brisa[x, y + 1] = true;
                        if (y - 1 >= 0)
                            sensor_brisa[x, y - 1] = true;
                    }

                    this.Controls.Add(cueva[x, y]);
                }
            }
        }

        private void ActivarSensores()
        {
            brisaDetector.BackColor = sensor_brisa[PosX_Actual_Jugador, PosY_Actual_Jugador] ? Color.Red : Control.DefaultBackColor;
            hedorDetector.BackColor = sensor_hedor[PosX_Actual_Jugador, PosY_Actual_Jugador] ? Color.Red : Control.DefaultBackColor;
            resplandorDetector.BackColor = sensor_resplandor[PosX_Actual_Jugador, PosY_Actual_Jugador] ? Color.Yellow : Control.DefaultBackColor;
            gritoDetector.BackColor = sensor_grito[PosX_Actual_Jugador, PosY_Actual_Jugador] ? Color.Green : Control.DefaultBackColor;
            luzDetector.BackColor = sensor_luz[PosX_Actual_Jugador, PosY_Actual_Jugador] ? Color.SkyBlue : Control.DefaultBackColor;
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosX_Actual_Jugador = PosX_Actual_Jugador + 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosX_Actual_Jugador = PosX_Actual_Jugador - 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosY_Actual_Jugador = PosY_Actual_Jugador - 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosY_Actual_Jugador = PosY_Actual_Jugador + 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }
    }
}
