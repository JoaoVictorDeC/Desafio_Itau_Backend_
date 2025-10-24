using Desafio_Itau_backend_C_.Helpers;

namespace Desafio_Itau_backend_C_.DTO
{

    public class EstatisticaDTO
    {

        public int Count { get; set; }
        public double Sum { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }

        public EstatisticaDTO(){ }



        public EstatisticaDTO(DoubleSummaryStatics estastistica)
        {
            Sum = estastistica.Sum;
            Min = estastistica.Min;
            Max = estastistica.Max;
            Average = estastistica.Avg;
            Count = estastistica.Count;

        }
    }
}
