using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusWorld
{
    public partial class Form1 : Form
    {
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

        //Matriz de Recorrido
        bool[,] recorrido = new bool[4, 4];

        int PosX_Actual_Jugador = 0;
        int PosY_Actual_Jugador = 0;

        int cantFlechas = 1;
        PictureBox[] flechas;
        bool flecha_cargada = false;


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
            recorrido[0, 0] = true;

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
                    cueva[x, y].Tag = x + "," + y;
                    cueva[x, y].Click += IntentarMatar;

                    if (posJugador[x, y])
                    {
                        cueva[x, y].BackgroundImage = WumpusWorld.ImagenesRes.jugador;
                        cueva[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (posWumpus[x, y])
                    {
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
            flechas[0].Location = new Point(40, 50);
            flechas[0].BackgroundImage = WumpusWorld.ImagenesRes.flecha;
            flechas[0].BackgroundImageLayout = ImageLayout.Stretch;

            flechas[0].Click += CargarArco;

            flechasGroup.Controls.Add(flechas[0]);

            definirMovimiento();
        }

        private void IntentarMatar(object sender, EventArgs e)
        {
            if(flecha_cargada)
            {
                string posicion = ((PictureBox)sender).Tag.ToString();
                int posXmatar = Convert.ToInt32(posicion[0].ToString());
                int posYmatar = Convert.ToInt32(posicion[2].ToString());
                if((posXmatar == PosX_Actual_Jugador + 1 && posYmatar == PosY_Actual_Jugador) || (posXmatar == PosX_Actual_Jugador + - 1 && posYmatar == PosY_Actual_Jugador) || (posYmatar == PosY_Actual_Jugador + 1 && posXmatar == PosX_Actual_Jugador) || (posYmatar == PosY_Actual_Jugador - 1 && posXmatar == PosX_Actual_Jugador))
                {
                    if(posWumpus[posXmatar, posYmatar])
                    {
                        MessageBox.Show("Wumpus asesinado");
                        posWumpus[posXmatar, posYmatar] = false;
                        if (posXmatar + 1 <= 3)
                        {
                            sensor_hedor[posXmatar + 1, posYmatar] = false;
                            sensor_grito[posXmatar + 1, posYmatar] = true;
                        }
                        if (posXmatar - 1 >= 0)
                        {
                            sensor_hedor[posXmatar - 1, posYmatar] = false;
                            sensor_grito[posXmatar - 1, posYmatar] = true;
                        }
                        if (posYmatar + 1 <= 3)
                        {
                            sensor_hedor[posXmatar, posYmatar + 1] = false;
                            sensor_grito[posXmatar, posYmatar + 1] = true;
                        }
                        if (posYmatar - 1 >= 0)
                        {
                            sensor_hedor[posXmatar, posYmatar - 1] = false;
                            sensor_grito[posXmatar, posYmatar - 1] = true;
                        }
                        gritoDetector.BackColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("Parece, que no habia nada en ese cuarto, flecha malgastada");
                    }
                    flecha_cargada = false;
                }
                else
                {
                    MessageBox.Show("Estas muy lejos para dispara ahi");
                }
            }
        }

        private void CargarArco(object sender, EventArgs e)
        {
            if (cantFlechas > 0 && !flecha_cargada) {
                flecha_cargada = true;
                cantFlechas--;
                flechasGroup.Controls.RemoveAt(cantFlechas);
            }
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
                    cueva[x, y].Tag = x + "," + y;
                    cueva[x, y].Click += IntentarMatar;


                    if (posJugador[x, y])
                    {
                        cueva[x, y].BackgroundImage = WumpusWorld.ImagenesRes.jugador;
                        cueva[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if(recorrido[x, y] && !posJugador[x, y])
                    {
                        int cantSensores = 0;
                        string sensor_query = "";
                        if (sensor_brisa[x, y])
                        {
                            cantSensores++;
                            sensor_query = sensor_query + "_Brisa";
                        }
                        if (sensor_hedor[x, y])
                        {
                            cantSensores++;
                            sensor_query = sensor_query + "_Hedor";
                        }
                        if (sensor_resplandor[x, y])
                        {
                            cantSensores++;
                            sensor_query = sensor_query + "_Brillo";
                        }
                        if (sensor_luz[x, y])
                        {
                            cantSensores++;
                            sensor_query = sensor_query + "_Luz";
                        }

                        sensor_query = cantSensores + sensor_query;

                        ResourceManager rm = new ResourceManager("WumpusWorld.ImagenesRes", Assembly.GetExecutingAssembly());
                        cueva[x, y].BackgroundImage = rm.GetObject("_" + sensor_query) as Image;
                        cueva[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                        rm.ReleaseAllResources();
                    }


                    this.Controls.Add(cueva[x, y]);
                }
            }
        }

        private void ActivarSensores()
        {
            int cantSensores = 1;
            string sensor_query = "_J";
            if(sensor_brisa[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cantSensores++;
                brisaDetector.BackColor = Color.Red;
                sensor_query = sensor_query + "_Brisa";
            }
            else
            {
                brisaDetector.BackColor = Control.DefaultBackColor;
            }
            if (sensor_hedor[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cantSensores++;
                hedorDetector.BackColor = Color.Red;
                sensor_query = sensor_query + "_Hedor";
            }
            else
            {
                hedorDetector.BackColor = Control.DefaultBackColor;
            }
            if (sensor_resplandor[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cantSensores++;
                resplandorDetector.BackColor = Color.Green;
                sensor_query = sensor_query + "_Brillo";
            }
            else
            {

                resplandorDetector.BackColor = Control.DefaultBackColor;
            }
            if (sensor_luz[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cantSensores++;
                luzDetector.BackColor = Color.Green;
                sensor_query = sensor_query + "_Luz";
            }
            else
            {
                luzDetector.BackColor = Control.DefaultBackColor;
            }

            sensor_query = cantSensores + sensor_query;

            ResourceManager rm = new ResourceManager("WumpusWorld.ImagenesRes", Assembly.GetExecutingAssembly());
            cueva[PosX_Actual_Jugador, PosY_Actual_Jugador].BackgroundImage = rm.GetObject("_" + sensor_query) as Image;
            rm.ReleaseAllResources();

            if (posWumpus[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cueva[PosX_Actual_Jugador, PosY_Actual_Jugador].BackgroundImage = WumpusWorld.ImagenesRes.wumpus;
                MessageBox.Show("Fuite comido por el wumpus.... Perdiste");
            }

            if (posHoyos[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cueva[PosX_Actual_Jugador, PosY_Actual_Jugador].BackgroundImage = WumpusWorld.ImagenesRes.hoyo;
                MessageBox.Show("Caiste en un hoyo.... Perdiste");
            }

            if (posSalida[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cueva[PosX_Actual_Jugador, PosY_Actual_Jugador].BackgroundImage = WumpusWorld.ImagenesRes.puerta;
                MessageBox.Show("Encontraste la salida.... Ganaste");
            }

            if (posOro[PosX_Actual_Jugador, PosY_Actual_Jugador])
            {
                cueva[PosX_Actual_Jugador, PosY_Actual_Jugador].BackgroundImage = WumpusWorld.ImagenesRes.oro;
                flechas[cantFlechas] = new PictureBox();
                flechas[cantFlechas].Size = new Size(150, 150);
                flechas[cantFlechas].Location = new Point((cantFlechas) * 150 + 40, 50);
                flechas[cantFlechas].BackgroundImage = WumpusWorld.ImagenesRes.flecha;
                flechas[cantFlechas].BackgroundImageLayout = ImageLayout.Stretch;
                flechas[cantFlechas].Click += CargarArco;
                flechasGroup.Controls.Add(flechas[cantFlechas]);
                cantFlechas++;
                MessageBox.Show("Encontraste el ORO... + 1 flecha, que suerte!");
                posOro[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
                if (PosX_Actual_Jugador + 1 <= 3)
                    sensor_resplandor[PosX_Actual_Jugador + 1, PosY_Actual_Jugador] = false;
                if (PosX_Actual_Jugador - 1 >= 0)
                    sensor_resplandor[PosX_Actual_Jugador - 1, PosY_Actual_Jugador] = false;
                if (PosY_Actual_Jugador + 1 <= 3)
                    sensor_resplandor[PosX_Actual_Jugador, PosY_Actual_Jugador + 1] = false;
                if (PosY_Actual_Jugador - 1 >= 0)
                    sensor_resplandor[PosX_Actual_Jugador, PosY_Actual_Jugador - 1] = false;

            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosX_Actual_Jugador = PosX_Actual_Jugador + 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            recorrido[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosX_Actual_Jugador = PosX_Actual_Jugador - 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            recorrido[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosY_Actual_Jugador = PosY_Actual_Jugador - 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            recorrido[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = false;
            PosY_Actual_Jugador = PosY_Actual_Jugador + 1;
            posJugador[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            recorrido[PosX_Actual_Jugador, PosY_Actual_Jugador] = true;
            redefinirCueva();
            definirMovimiento();
            ActivarSensores();
        }


    }
}
