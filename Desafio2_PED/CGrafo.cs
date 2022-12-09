using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Desafio2_PED
{
    internal class CGrafo
    {
        public List<CVertice> nodos; //Lista de nodos del grafo
        public int[,] nodos_Ady = new int[50, 50];
        int indice;
        int i, j;
        public CGrafo()             //Constructor
        {
            nodos = new List<CVertice>();
        }

        //************************************************************************************
        //************************ Operaciones Basica ****************************************
        //************************************************************************************

        //Contruye un nodo a partir de su valor y lo agrega a la lista de nodos
        public CVertice AgregarVertice(string valor)
        {
            CVertice nodo = new CVertice(valor);
            nodos.Add(nodo);
            return nodo;
        }

        //Agregar un nodo a la lista de nodos del grafo
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo);
        }

        //Busca un nodo en la lista de nodos del grafo

        public CVertice BuscarVertice (string valor)
        {
            return nodos.Find(v => v.Valor == valor);
        }

        //Crear la arista a partir de los nodos de origen y de destino

        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso)
        {
            i = returnindice(origen);
            j = returnindice(nDestino);

            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
            {
                origen.ListaAdyacencia.Add(new CArco(nDestino, peso));
                nodos_Ady[i, j] = peso; 
                return true;
            }
            return false;
        }

        //Metodo para dibujar el grafo
        public void DibujarGrafo(Graphics g)
        {
            //Dibujando arcos
            foreach (CVertice nodo in nodos)
                nodo.DibujarArco(g);

            //Dibujando los vertices
            foreach (CVertice nodo in nodos)
                nodo.DibujarVertices(g);
        }
        //Metodos para detectar si se ha posicionado sobre algun nodo y lo devuelve

        public CVertice DetectarPunto(Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
                if (nodoActual.DetectarPunto(posicionMouse))
                    return nodoActual;
            return null;
        }
        //Metodo para regresar al estado original

        public void ReestablecerGrafo(Graphics g)
        {
            foreach(CVertice nodo in nodos)
            {
                nodo.Color = Color.White;
                nodo.FontColor = Color.Black;
                foreach(CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.Black;
                }
            }
            DibujarGrafo(g);
        }

        public void EliminarVertice(CVertice vertice)
        {
            nodos.Remove(vertice);
            EliminarArco(vertice);
        }

        public void EliminarArco(CVertice nBorrar)
        {
            foreach (CVertice nodo in nodos)
                EliminarArista(nodo, nBorrar);
        }

        public bool EliminarArista(CVertice origen, CVertice nDestino)
        {
            CArco arista = origen.ListaAdyacencia.Find(v => v.nDestino == nDestino);
            return origen.ListaAdyacencia.Remove(arista);
        }

        public void EliminarVertice(string sEvalor)
        {
            if (this.BuscarVertice(sEvalor) != null)
                nodos.Remove(this.BuscarVertice(sEvalor));
        }
        public void EliminarArco(CVertice nOrigen, CVertice nDestino)
        {
            i = returnindice(nOrigen);
            j = returnindice(nDestino);
            nodos_Ady[i, j] = 0;
        }

        public int returnindice(CVertice n1)
        {
            indice = 0;
            int x = 0;
            foreach (CVertice nodo in nodos)
            {
                if (n1 == nodo)
                {
                    indice = x;
                }
                x++;
            }
            return indice;
        }


        public void ColorearNodo(string valorEscogido)
        {
            try
            {
                CVertice nodoEscogido = this.BuscarVertice(valorEscogido);
                nodoEscogido.Color = Color.DeepSkyBlue;
            }
            catch
            {
                MessageBox.Show("No se encontro ningun nodo");
            }
        }
        public void ReestablecerColorNodo(string valorEscogido)
        {
            CVertice nodoEscogido = this.BuscarVertice(valorEscogido);
            nodoEscogido.Color = Color.Red;
        }

    }



}
