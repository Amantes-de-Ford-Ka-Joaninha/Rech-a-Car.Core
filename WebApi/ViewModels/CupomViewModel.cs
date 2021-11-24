using Dominio.ParceiroModule;
using System;

namespace WebApi.ViewModels
{
    public class CupomViewModel
    {
        public class CupomListViewModel
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string ParceiroNome { get; set; }

            public DateTime DataValidade { get; set; }

            public int ValorPercentual { get; set; }

            public double ValorFixo { get; set; }

            public double ValorMinimo { get; set; }
        }

        public class CupomDetailsViewModel
        {
            public int Id { get; set; }

            public int ParceiroId { get; set; }

            public string Nome { get; set; }

            public DateTime DataValidade { get; set; }

            public int ValorPercentual { get; set; }

            public double ValorFixo { get; set; }

            public double ValorMinimo { get; set; }

            public int Usos { get; set; }
        }

        public class CupomCreateViewModel
        {
            public int ParceiroId { get; set; }

            public string Nome { get; set; }

            public DateTime DataValidade { get; set; }

            public int ValorPercentual { get; set; }

            public double ValorFixo { get; set; }

            public double ValorMinimo { get; set; }

            public int Usos { get; set; }
        }

        public class CupomEditViewModel
        {
            public int Id { get; set; }

            public int ParceiroId { get; set; }

            public string Nome { get; set; }

            public decimal Valor { get; set; }

            public DateTime DataValidade { get; set; }

            public decimal ValorMinimo { get; set; }

            public int Usos { get; set; }
        }

    }
}
