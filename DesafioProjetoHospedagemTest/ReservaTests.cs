using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagemTest.Mocks;

namespace DesafioProjetoHospedagemTest;

public class ReservaTests
{
    [Fact]
    public void DeveRejeitarNumeroDeHospedesMaiorQueCapacidade()
    {
        Exception ex = Assert.Throws<Exception>(() => new ReservaMock().WithCapacidade(5).WithHospedes(10).Build());
        Assert.Equal("Numero de hospedes maior que a capacidade da suite", ex.Message);
    }

    [Fact]
    public void DeveValidarNumeroDeHospedes()
    {
        Reserva reserva = new ReservaMock().WithCapacidade(20).WithHospedes(10).Build();
        Assert.Equal(10, reserva.ObterQuantidadeHospedes());
    }

    [Fact]
    public void DeveCalcularReservaSemDesconto()
    {
        Reserva reserva = new ReservaMock().WithValorDiasReservados(5).WithValorDiaria(10).Build();
        Assert.Equal(50, reserva.CalcularValorDiaria());
    }


    [Fact]
    public void DeveCalcularReservaComDescontoQuandoDiaReservadosIgual10()
    {
        Reserva reserva = new ReservaMock().WithValorDiasReservados(10).WithValorDiaria(30).Build();
        Assert.Equal(270, reserva.CalcularValorDiaria());
    }

    [Fact]
    public void DeveCalcularReservaComDescontoQuandoDiaReservadosMaior10()
    {
        Reserva reserva = new ReservaMock().WithValorDiasReservados(11).WithValorDiaria(30).Build();
        Assert.Equal(297, reserva.CalcularValorDiaria());
    }
}