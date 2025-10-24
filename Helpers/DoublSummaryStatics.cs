using Microsoft.VisualBasic;
using Desafio_Itau_backend_C_.Models;

namespace Desafio_Itau_backend_C_.Helpers
{
    public class DoubleSummaryStatics 
    {
        private int _count = 0;
        private double _sum;
        private double _avg;
        private double _min = double.MaxValue;
        private double _max = double.MinValue;


        public void Add(double valor) 
        {
            this._count++;
            this._sum += valor;
            if (valor < _min) _min = valor;
            if(valor > _max) _max = valor;
        }

        public int Count => _count;
        public double Sum => _sum;
        public double Min => _count > 0 ? _min :0;
        public double Max => _count > 0 ? _max : 0;
        public double Avg => _count > 0 ? _sum/_count : 0;


    }
}
