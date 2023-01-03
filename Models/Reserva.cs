using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private List<Pessoa> _hospede = new List<Pessoa>();
        public List<Pessoa> Hospedes { get { return _hospede; } set { _hospede = value; } }
        public Suite SuiteReservada { get; set; }
        public int DiasReservados { get; set ; }

        public Reserva(){ }

        public Reserva(int diasRerservados){
           DiasReservados = diasRerservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes){
            if(hospedes.Count > SuiteReservada.Capacidade){
                throw new Exception("A quantidade de Hospédes não pode exceder a capacidade da suíte.");
            }
            Hospedes = new List<Pessoa>(hospedes);
        }
        public void CadastrarSuite(Suite suite){
            SuiteReservada = suite;
        }

        public int ObterQuantidadeHospedes(){
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria(){
            decimal desconto = 0;
            if (DiasReservados >= 10){
                desconto = SuiteReservada.ValorDiaria / 10;
                Console.WriteLine(desconto);
            }
            return DiasReservados * (SuiteReservada.ValorDiaria - desconto);
        }
    }
}