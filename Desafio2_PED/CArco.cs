using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Desafio2_PED
{
    internal class CArco
    {
        //Attributos

        public CVertice nDestino;
        public int peso;            //Peso (valor) de cada arco (Arista)

        public float grosor_flecha;
        public Color color;

        //Metodos

        public CArco (CVertice destino): this (destino, 1)
        {
            this.nDestino = destino;
        }

        public CArco (CVertice destino, int peso)
        {
            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 3;
            this.color = Color.Blue;
        }

    }
}
