namespace SistemaDeHospedagem.Models
{
  public class Reserva
  {
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
      DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
      if (Suite.Capacidade >= hospedes.Count) Hospedes = hospedes;
      else throw new Exception($"Capacidade da suite {Suite.TipoSuite} é menor"
                                + " que a quantidade de hóspedes.");
    }

    public void CadastrarSuite(Suite suite)
    {
      Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
      return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
      decimal valor = DiasReservados * Suite.ValorDiaria;
      if (DiasReservados >= 10) valor *= .90M;
      return valor;
    }
  }
}