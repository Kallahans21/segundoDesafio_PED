using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Desafio2_PED
{
    internal class CVertice
    {
        public string Valor;
        public List<CArco> ListaAdyacencia;
        static int size = 10;
        Size dimensiones;
        Color color_nodo;
        Color color_fuente;
        Point _posicion;
        int radio;

        public int grado = 0;

        public Color Color
        {
            get { return color_nodo; }
            set { color_nodo = value; }
        }
        public Color FontColor
        {
            get { return color_fuente; }
            set { color_fuente = value; }
        }
        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }
        public Size Dimensiones
        {
            get { return dimensiones; }
            set
            {
                radio = value.Width / 2;
                dimensiones = value;
            }
        }
        //************ Metodos ***************************
        public CVertice(string Valor)
        {
            this.Valor = Valor;
            this.ListaAdyacencia = new List<CArco>();
            this.Color = Color.Red;
            this.Dimensiones = new Size(size, size);
            this.FontColor = Color.Black;
        }
        //Contructor por defecto
        public CVertice () : this("") { }

        public void DibujarVertices (Graphics g)
        {
            SolidBrush b = new SolidBrush(this.color_nodo);
            Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio, this.dimensiones.Width, this.dimensiones.Height);
            g.FillEllipse(b, areaNodo);
            //g.DrawString(this.Valor, new Font("Century Gothic", 9), new SolidBrush(color_fuente), this._posicion.X, this._posicion.Y, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            g.DrawEllipse(new Pen(Brushes.Red, (float)1.0), areaNodo);
            b.Dispose();
        }

        public void DibujarArco(Graphics g)
        {
            float distancia;
            int difY, difX;
            foreach (CArco arco in ListaAdyacencia)
            {
                difX = this.Posicion.X - arco.nDestino.Posicion.X;
                difY = this.Posicion.Y - arco.nDestino.Posicion.Y;
                distancia = (float)Math.Sqrt(Math.Pow(difX, 2) + Math.Pow(difY, 2));
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;


                g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha) { CustomEndCap = bigArrow, Alignment = PenAlignment.Center }, _posicion, new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia), arco.nDestino.Posicion.Y + (int)(radio * difY / distancia)));
                g.DrawString(arco.peso.ToString(), new Font("Century Gothic", 11, FontStyle.Bold), new SolidBrush(Color.Black), this._posicion.X - (int)(difX / 3), this._posicion.Y - (int)(difY / 3), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
            }
        }
        
        //Metodo para detecta la posicion en el panel donde se dibujara el nodo
        public bool DetectarPunto(Point P)
        {
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(this._posicion.X - this.dimensiones.Width / 2, this._posicion.Y - this.dimensiones.Height / 2, this.dimensiones.Width, this.dimensiones.Height));
            bool retval = posicion.IsVisible(P);
            posicion.Dispose();
            return retval;
        }

        public override String ToString()
        {
            return this.Valor;
        }
    }
}
