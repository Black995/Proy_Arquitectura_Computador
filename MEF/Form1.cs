using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MEF
{
    
    public class Form1 : Form
    {
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem mnuSalir;
        private MenuItem menuItem3;
        private MenuItem mnuInicio;
        private MenuItem mnuParo;
        private MenuItem mnuReset;
        private Timer timer1;
        private IContainer components;


        // Creamos un objeto para la maquina de estados finitos
        private CMaquina maquina = new CMaquina();
        private CMaquina maquina2 = new CMaquina();
        

        // Objetos necesarios
        public S_objeto[] ListaObjetos = new S_objeto[10];
        public S_objeto[] ListaObjetos2 = new S_objeto[10];
        public S_objeto MiBateria;
        
        public Form1()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            
            //
            // TODO: agregar código de constructor después de llamar a InitializeComponent
            //

            // Inicializamos los objetos

            // Cremos un objeto para tener valores aleatorios
            Random random = new Random();

            // Recorremos todos los objetos
            for (int n = 0; n < 10; n++)
            {
                // Colocamos las coordenadas
                ListaObjetos[n].x = random.Next(0, 639);
                ListaObjetos[n].y = random.Next(0, 479);
                ListaObjetos2[n].x = random.Next(0, 639);
                ListaObjetos2[n].y = random.Next(0, 479);

                // Lo indicamos activo
                ListaObjetos[n].activo = true;
                ListaObjetos2[n].activo = true;
            }

            // Colocamos la bateria
            MiBateria.x = random.Next(0, 639);
            MiBateria.y = random.Next(0, 479);
            MiBateria.activo = true;

            maquina.Inicializa(ref ListaObjetos, MiBateria);
            maquina2.Inicializa(ref ListaObjetos2, MiBateria);

        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {   
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuInicio = new System.Windows.Forms.MenuItem();
            this.mnuParo = new System.Windows.Forms.MenuItem();
            this.mnuReset = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSalir});
            this.menuItem1.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Index = 0;
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInicio,
            this.mnuParo,
            this.mnuReset});
            this.menuItem3.Text = "Aplicacion";
            // 
            // mnuInicio
            // 
            this.mnuInicio.Index = 0;
            this.mnuInicio.Text = "Inicio";
            this.mnuInicio.Click += new System.EventHandler(this.mnuInicio_Click);
            // 
            // mnuParo
            // 
            this.mnuParo.Index = 1;
            this.mnuParo.Text = "Pausa";
            this.mnuParo.Click += new System.EventHandler(this.mnuParo_Click);
            // 
            // mnuReset
            // 
            this.mnuReset.Index = 2;
            this.mnuReset.Text = "Reiniciar";
            this.mnuReset.Click += new System.EventHandler(this.mnuReset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::MEF.Properties.Resources.map;
            this.ClientSize = new System.Drawing.Size(692, 500);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Mario vs Luigi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.Run(new Form1());
        }

        private void mnuSalir_Click(object sender, System.EventArgs e)
        {
            // Cerramos la ventana y finalizamos la aplicacion
            this.Close();
        }

        private void mnuInicio_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void mnuParo_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Esta funcion es el handler del timer
            // Aqui tendremos la logica para actualizar nuestra maquina de estados

            // Actualizamos a la maquina
            maquina.Control();
            maquina2.Control();


            // Mandamos a redibujar la pantalla
            this.Invalidate();
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Creamos la fuente y la brocha para el texto
            Font fuente = new Font("Arial", 16);
            Font fuente2 = new Font("Arial", 24);

            SolidBrush brocha = new SolidBrush(Color.White);
            SolidBrush brochaVerde = new SolidBrush(Color.Green);
            SolidBrush brochaRoja = new SolidBrush(Color.Red);

            Rectangle rect;
            Image coin = Image.FromFile("coin.png");
            Image mush = Image.FromFile("mushroom.png");
            Image luigi = Image.FromFile("luigi.png");
            Image mario = Image.FromFile("mario2.png");
            Image star = Image.FromFile("estrella.gif");


                //Luigi
                 rect = new Rectangle(maquina.CoordX - 4, maquina.CoordY - 4, 40, 40);
                 e.Graphics.DrawImage(luigi, rect);
                //Mario
                rect = new Rectangle(maquina2.CoordX - 4, maquina2.CoordY - 4, 40, 40);
                e.Graphics.DrawImage(mario, rect);

            // Dibujamos los objetos
            for (int n = 0; n < 10; n++)
                if (ListaObjetos[n].activo == true)
                {
                    rect = new Rectangle(ListaObjetos[n].x - 4, ListaObjetos[n].y - 4, 20, 20);
                    e.Graphics.DrawImage(mush,rect);
                }

            for (int n = 0; n < 10; n++)
                if (ListaObjetos2[n].activo == true)
                {
                    rect = new Rectangle(ListaObjetos2[n].x - 4, ListaObjetos2[n].y - 4, 20, 20);
                    e.Graphics.DrawImage(coin, rect);
                }

            // Dibujamos la bateria
            rect = new Rectangle(MiBateria.x - 4, MiBateria.y - 4, 30, 30);
            e.Graphics.DrawImage(star, rect);

            // Indicamos el estado en que se encuentra la maquina
            e.Graphics.DrawString("LUIGI -> " + maquina.EstadoM.ToString(), fuente, brocha, 10, 10);
            e.Graphics.DrawString("MARIO -> " + maquina2.EstadoM.ToString(), fuente, brocha, 10, 40);

            if(maquina.EstadoM == 4)
            {
                timer1.Enabled = false;
                e.Graphics.DrawString("GANÓ LUIGI" , fuente2, brocha, 250, 200);
            }
            if (maquina2.EstadoM == 4)
            {
                timer1.Enabled = false;
                e.Graphics.DrawString("GANÓ MARIO" , fuente2, brocha, 250, 200);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
