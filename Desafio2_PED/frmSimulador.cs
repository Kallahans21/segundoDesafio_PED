using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Desafio2_PED
{
    public partial class frmSimulador : Form
    {
        private CGrafo grafo;               //Instancia de clase CGrafo
        private CVertice NuevoNodo;         //Instancia de clase CVertice para crear el nodo "NuevoNodo"
        private CVertice NodoOrigen;        //Instancia de clase CVertice para crear el nodo "NuevoOrigen"
        private CVertice NodoDestino;       //Instancia de clase CVertice para crear el nodo "NodoDestino"
        private CVertice NodoEliminar;      //Instancia de clase CVertice para crear el nodo "NodoEliminar"
        private CVertice NodoArco;          //Instancia de clase CVertice para crear el nodo "NodoArco"
        private int var_control = 0;        //Se usará para determinar el estado de la pizarra: 0: Sin accion, 1: Dibujando arco, 2: Nuevo vertice
        private frmVertice ventanaVertice;  //Ventana para agregar los vertices
        private frmArco ventanaArco;        //Ventana para agregar los arcos

        public frmSimulador()
        {
            InitializeComponent();
            reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Cargamos la opciones de mapas predeterminados
            cmbSeleccionMapa.Items.Add("El Salvador");
            cmbSeleccionMapa.Items.Add("Guatemala");
            cmbSeleccionMapa.Items.Add("Honduras");
            cmbSeleccionMapa.Items.Add("Nicaragua");
            cmbSeleccionMapa.Items.Add("Costa Rica");
            cmbSeleccionMapa.Items.Add("Panamá");
            cmbSeleccionMapa.Items.Add("Belice");
        }

        private void cmbSeleccionMapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reiniciamos los valores al cambiar de mapa
            reset();
            DibujarMapa(cmbSeleccionMapa.SelectedIndex);
            getDepartamentos(cmbSeleccionMapa.SelectedIndex, cmbNodoIncial);
            cmbNodoIncial.SelectedIndex = 0;
        }

        private void pnl_pizaarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnl_pizaarra_MouseLeave(object sender, EventArgs e)
        {
            pnl_pizaarra.Refresh();

        }

        private void nuevoVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoNodo = new CVertice();
            var_control = 2;
            //0: Sin accion, 1: Dibujando arco, 2: Nuevo vertice


        }

        private void pnl_pizaarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1:                 //Dibujando arco

                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.Visible = false;
                        ventanaArco.control = false;
                        ventanaArco.ShowDialog();

                        int peso = 0;

                        if (ventanaArco.control)
                        {
                            //Se procede a crear la arista
                            peso = int.Parse(ventanaArco.txtArco.Text);
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino, peso))
                            {
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = int.Parse(ventanaArco.txtArco.Text); ;
                            }
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    pnl_pizaarra.Refresh();
                    break;
            }
        }

        private void pnl_pizaarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: //Dibujar arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    pnl_pizaarra.Refresh();
                    pnl_pizaarra.CreateGraphics().DrawLine(new Pen(Brushes.Blue, 2) { CustomEndCap = bigArrow }, NodoOrigen.Posicion, e.Location);
                    break;

                case 2:
                    if (NuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;

                        if (posX < NuevoNodo.Dimensiones.Width / 2)
                            posX = NuevoNodo.Dimensiones.Width / 2;
                        else if (posX > pnl_pizaarra.Size.Width - NuevoNodo.Dimensiones.Width / 2)
                            posX = pnl_pizaarra.Size.Width - NuevoNodo.Dimensiones.Width / 2;

                        if (posY < NuevoNodo.Dimensiones.Height / 2)
                            posY = NuevoNodo.Dimensiones.Height / 2;
                        else if (posY > pnl_pizaarra.Size.Height - NuevoNodo.Dimensiones.Width / 2)
                            posY = pnl_pizaarra.Size.Height - NuevoNodo.Dimensiones.Width / 2;

                        NuevoNodo.Posicion = new Point(posX, posY);
                        pnl_pizaarra.Refresh();
                        NuevoNodo.DibujarVertices(pnl_pizaarra.CreateGraphics());

                    }
                    break;

                case 3:
                    {
                        if (NodoOrigen == null)
                        {
                            NodoOrigen = grafo.DetectarPunto(e.Location);
                        }
                        else if (NodoDestino == null)
                        {
                            if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null)
                            {
                                if (NodoOrigen != NodoDestino)
                                {
                                    if (!grafo.EliminarArista(NodoOrigen, NodoDestino))
                                        grafo.EliminarArista(NodoOrigen, NodoDestino);
                                    pnl_pizaarra.Refresh();
                                }

                                var_control = 0;
                                NodoOrigen = null;
                                NodoDestino = null;
                            }
                        }
                        break;
                    }
            }
        }

        private void pnl_pizaarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) //Si se ha presionado el boton izq
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1;
                }

                if (NuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    grafo.AgregarVertice(NuevoNodo);
                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            NuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show("El nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "Error nuevo nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            grafo.EliminarVertice("");
                        }
                    }
                    else
                    {
                        grafo.EliminarVertice("");
                    }

                    NuevoNodo = null;
                    var_control = 0;
                    pnl_pizaarra.Refresh();
                }

                if (NodoEliminar != null)
                {
                    NodoEliminar = grafo.DetectarPunto(e.Location);
                    grafo.EliminarVertice(NodoEliminar);
                    grafo.EliminarArco(NodoEliminar);

                    NodoEliminar = null;
                    var_control = 0;
                    pnl_pizaarra.Refresh();
                }

                if (NodoArco != null)
                {
                    NodoArco = grafo.DetectarPunto(e.Location);
                    grafo.EliminarArco(NodoArco);

                    NodoEliminar = null;
                    var_control = 0;
                    pnl_pizaarra.Refresh();
                }

            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                    {
                        pnl_pizaarra.ContextMenuStrip = this.CMSCrearVertice;
                    }
                }
            }
        }


        public void DibujarMapa(int valor)
        {
            switch (valor)
            {
                case 0:
                    //El Salvador
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.El_Salvador;
                    break;
                case 1:
                    //Guatemala
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Guatemala;
                    break;
                case 2:
                    //Honduras
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Honduras;
                    break;
                case 3:
                    //Nicaragua
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Nicaragua;
                    break;
                case 4:
                    //Costa Rica
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Costa_Rica;
                    break;
                case 5:
                    //Panama
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Panamá;
                    break;
                case 6:
                    //Panama
                    pnl_pizaarra.BackgroundImage = Desafio2_PED.Properties.Resources.Belice;
                    break;
            }
        }

        private void nuevoNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoNodo = new CVertice();
            var_control = 2;
            //0: Sin accion, 1: Dibujando arco, 2: Nuevo vertice
        }

        public void reset()
        {
            grafo = new CGrafo();
            NuevoNodo = null;
            var_control = 0;
            ventanaVertice = new frmVertice();
            ventanaArco = new frmArco();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbNodoIncial.Text != "")
            {
                try
                {
                    List<CVertice> resultado = new List<CVertice>();
                    Refresh();
                    Queue<CVertice> miCola = new Queue<CVertice>();
                    ltbRecorrido.Items.Clear();
                    CVertice nodo = grafo.BuscarVertice(cmbNodoIncial.Text);
                    miCola.Enqueue(nodo);
                    while (miCola.Count != 0)
                    {
                        nodo = miCola.Dequeue();
                        if (!resultado.Contains(nodo))
                        {
                            resultado.Add(nodo);
                        }
                        foreach (CArco arco in nodo.ListaAdyacencia)
                        {
                            if (!resultado.Contains(arco.nDestino))
                            {
                                miCola.Enqueue(arco.nDestino);
                            }
                        }
                    }
                    int sumarcos = 0, o, d;
                    List<CVertice> listnodos = new List<CVertice>();
                    foreach (CVertice node in resultado)//indextar lista para dsps recorrer nodosadya(origen,destino)=peso
                    {
                        ltbRecorrido.Items.Add(node);
                        //*********
                        listnodos.Add(node);//creo una nueva lista con los nodos                       
                        //**********
                        grafo.ColorearNodo(node.Valor);
                        Refresh();
                        Thread.Sleep(500);
                        grafo.ReestablecerColorNodo(node.Valor);
                        Refresh();
                        Thread.Sleep(500);
                    }
                    ltbRecorrido.Items.Add("");
                    for (int i = 1; i < listnodos.Count; i++)
                    {
                        o = grafo.returnindice(listnodos[i - 1]);
                        d = grafo.returnindice(listnodos[i]);
                        sumarcos += grafo.nodos_Ady[o, d];
                    }
                    ltbRecorrido.Items.Add("Distancia: " + sumarcos);
                    Refresh();
                }
                catch
                {
                    MessageBox.Show("Error al realizar recorrido");
                }
            }
            else
                MessageBox.Show("Ingrese un valor de inicio");
        }

        private void buscarVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodoEliminar = new CVertice();
        }

        private void eliminarArcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var_control = 3;
        }

        private void btnProfundidad_Click(object sender, EventArgs e)
        {
            if (cmbNodoIncial.Text != "")
            {
                try
                {
                    List<CVertice> resultado = new List<CVertice>();
                    Refresh();
                    Stack<CVertice> miPila = new Stack<CVertice>();
                    ltbRecorrido.Items.Clear();
                    CVertice nodo = grafo.BuscarVertice(cmbNodoIncial.Text);
                    miPila.Push(nodo);
                    while (miPila.Count != 0)
                    {
                        nodo = miPila.Pop();
                        if (!resultado.Contains(nodo))
                        {
                            resultado.Add(nodo);
                        }
                        foreach (CArco arco in nodo.ListaAdyacencia)
                        {
                            if (!resultado.Contains(arco.nDestino))
                            {
                                miPila.Push(arco.nDestino);
                            }
                        }
                    }

                    foreach (CVertice node in resultado)
                    {
                        ltbRecorrido.Items.Add(node);
                        grafo.ColorearNodo(node.Valor);
                        Refresh();
                        Thread.Sleep(500);
                        grafo.ReestablecerColorNodo(node.Valor);
                        Refresh();
                        Thread.Sleep(500);
                    }

                    Refresh();
                }
                catch
                {
                    MessageBox.Show("Error al mostrar recorrido");
                }
            }
            else
                MessageBox.Show("Ingrese un valor de inicio");
        }


        private void getDepartamentos(int valor, ComboBox x)
        {
            switch (valor)
            {
                case 0:
                    //El Salvador

                    //Nombre de los departamentos
                    string[] SV = {"Ahuachapan","Cabañas","Chalatenango","Cuscatlan","La Libertad","La Paz", "La Union", "Morazan", "San Miguel",
                        "San Salvador", "San Vicente", "Santa Ana", "Sonsonate", "Usulutan"};
                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_SV = { { 169, 267 }, { 562, 266 }, { 423, 157 }, { 473, 318 }, { 349, 324 }, { 476, 381 }, { 819, 414 }, { 769, 337 },
                        { 706, 370 }, { 409, 287 }, { 555, 377 }, { 290, 190 }, { 248, 311 }, { 630, 460 } };

                    //Eliminamos todos los items para actualizarlos
                    x.Items.Clear();
                    foreach (String d in SV)
                    {
                        x.Items.Add(d);
                    }
                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_SV.GetLength(0) - 1); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_SV[i, 0], p_SV[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = SV[i];
                    }
                    break;
                case 1:
                    //Guatemala
                    string[] GT = {"Alta Verapaz","Baja Verapaz", "Chimaltenango", "Chiquimula", "El Progreso", "Escuintla", "Guatemala", "Huehuetenango", "Izabal",
                        "Jalapa","Jutiapa","Petén","Quezaltenango","Quiché","Retalhuleu","Sacatepéquez","San Marcos","Santa Rosa","Sololá","Suchitepéquez",
                        "Totonicapán","Zacapa" };

                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_GT = { { 513, 331 }, { 466, 384 }, { 414, 431 }, { 596, 430 }, { 518, 398 }, { 409, 487 }, { 472, 439 }, { 336, 313 }, { 620, 321 }, { 533, 438 }, { 536, 491 }, { 534, 187 }, { 331, 412 }, { 402, 355 }, { 310, 466 }, { 298, 385 }, { 484, 489 }, { 374, 422 }, { 376, 464 }, { 360, 398 }, { 567, 392 } };

                    x.Items.Clear();
                    foreach (String d in GT)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_GT.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_GT[i, 0], p_GT[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = GT[i];
                    }
                    break;
                case 2:
                    //Honduras
                    string[] HN = {"Atlántida","Choluteca","Colón","Comayagua","Copán","Cortés","El Paraíso","Francisco Morazán","Gracias a Dios",
                        "Intibucá","Islas de la Bahía",
                        "La Paz","Lempira","Ocotepeque","Olancho","Santa Bárbara","Valle","Yoro"};

                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_HN = { { 375, 177 }, { 385, 500 }, { 620, 180 }, { 322, 319 }, { 158, 292 }, { 277, 207 }, { 456, 376 }, { 367, 375 }, { 740, 266 }, { 285, 367 }, { 199, 374 }, { 139, 316 }, { 562, 311 }, { 221, 217 }, { 317, 440 }, { 365, 243 } };

                    x.Items.Clear();
                    foreach (String d in HN)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_HN.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_HN[i, 0], p_HN[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = HN[i];
                    }

                    break;
                case 3:
                    //Nicaragua
                    string[] NI = {"Atlántico Norte", "Atlántico Sur", "Boaco", "Carazo", "Chinandega", "Chontales", "Estelí", "Granada", "Jinotega",
                        "León", "Madriz","Managua","Masaya","Matagalpa","Nueva Segovia","Rio San Juan","Rivas"};

                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_NI = { { 619, 137 }, { 627, 307 }, { 431, 347 }, { 370, 445 }, { 268, 321 }, { 503, 413 }, { 369, 278 }, { 426, 407 }, { 454, 193 }, { 312, 358 }, { 320, 232 }, { 382, 347 }, { 391, 413 }, { 442, 309 }, { 399, 172 }, { 541, 465 }, { 462, 494 } };

                    x.Items.Clear();
                    foreach (String d in NI)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_NI.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_NI[i, 0], p_NI[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = NI[i];
                    }

                    break;
                case 4:
                    //Costa Rica
                    string[] CR = { "Alajuela", "Cartago", "Guanacaste", "Heredia", "Limon", "Puntarenas", "San Jose" };
                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_CR = { { 466, 177 }, { 600, 291 }, { 288, 188 }, { 538, 187 }, { 626, 201 }, { 657, 385 }, { 552, 317 } };

                    x.Items.Clear();
                    foreach (String d in CR)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_CR.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_CR[i, 0], p_CR[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = CR[i];
                    }
                    break;
                case 5:
                    //Panama
                    string[] PA = {"Bocas del Toro", "Chiriquí", "Coclé", "Colón", "Darién", "Emberá", "Herrera", "Kuna Yala", "Los Santos",
                        "Ngöbe_Buglé", "Panama", "Veraguas" };

                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_PA = { { 166, 214 }, { 171, 257 }, { 448, 295 }, { 512, 187 }, { 787, 299 }, { 840, 287 }, { 407, 387 }, { 737, 171 }, { 462, 392 }, { 275, 289 }, { 679, 213 }, { 346, 306 } };

                    x.Items.Clear();
                    foreach (String d in PA)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_PA.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_PA[i, 0], p_PA[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = PA[i];
                    }

                    break;
                case 6:
                    //Belice
                    string[] BZ = { "Belize", "Cayo", "Corozal", "Orange Walk", "Stann Creek", "Toledo" };

                    //Puntos para crear vertices | Mismo orden de los departamentos
                    int[,] p_BZ = { { 484, 256 }, { 387, 369 }, { 523, 120 }, { 408, 227 }, { 485, 343 }, { 424, 438 } };

                    x.Items.Clear();
                    foreach (String d in BZ)
                    {
                        x.Items.Add(d);
                    }

                    //Agregamos los nodos de acuerdo al pais
                    for (int i = 0; i < (p_BZ.GetLength(0)); i++)
                    {
                        NodoOrigen = new CVertice();
                        NodoOrigen.Posicion = new Point(p_BZ[i, 0], p_BZ[i, 1]);
                        grafo.AgregarVertice(NodoOrigen);
                        NodoOrigen.Valor = BZ[i];
                    }

                    break;
            }
        }

        private void pnl_pizaarra_MouseClick(object sender, MouseEventArgs e)
        {
            if (var_control != 1)
            {
                //MessageBox.Show(e.Location.X.ToString() + ", " + e.Location.Y.ToString());

                //richTextBox1.AppendText("{" + e.Location.X.ToString() + ", " + e.Location.Y.ToString()+ "}");
                //richTextBox1.AppendText(",");
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                try
                {
                    grafo.ColorearNodo(txtBusqueda.Text);
                    Refresh();
                    Thread.Sleep(1000);
                    grafo.ReestablecerColorNodo(txtBusqueda.Text);
                    Refresh();
                    Thread.Sleep(500);
                }
                catch
                {
                    MessageBox.Show("Nodo no encontrado");
                }
            }
            else
                MessageBox.Show("Ingrese un valor de busqueda");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void salirbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
