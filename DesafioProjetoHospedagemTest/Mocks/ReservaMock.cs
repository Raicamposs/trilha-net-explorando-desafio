using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagemTest.Mocks
{
    public class ReservaMock
    {
        private Reserva reserva;
        public ReservaMock()
        {
            this.reserva = new Reserva(diasReservados: 11);
            this.reserva.CadastrarSuite(new Suite(tipoSuite: "any", capacidade: 2, valorDiaria: 30));
            this.reserva.CadastrarHospedes(new List<Pessoa>() { new Pessoa(nome: "any 1"), new Pessoa(nome: "any 2") });
        }

        public ReservaMock WithHospedes(int pessoas)
        {
            List<Pessoa> hospedes = new List<Pessoa>();
            for (int i = 0; i < pessoas; i++)
            {
                hospedes.Add(new Pessoa(nome: "any " + (i + 2)));
            }
            this.reserva.CadastrarHospedes(hospedes);
            return this;
        }

        public ReservaMock WithCapacidade(int capacidade)
        {
            Suite suite = new Suite(tipoSuite: "any", capacidade: capacidade, valorDiaria: this.reserva.Suite.ValorDiaria);
            this.reserva.CadastrarSuite(suite);
            return this;
        }

        public ReservaMock WithValorDiaria(decimal valorDiaria)
        {
            Suite suite = new Suite(tipoSuite: "any", capacidade: this.reserva.Suite.Capacidade, valorDiaria: valorDiaria);
            this.reserva.CadastrarSuite(suite);
            return this;
        }

        public ReservaMock WithValorDiasReservados(int diasReservados)
        {
            reserva.DiasReservados = diasReservados;
            return this;
        }

        public Reserva Build()
        {
            return this.reserva;
        }

    }


}

