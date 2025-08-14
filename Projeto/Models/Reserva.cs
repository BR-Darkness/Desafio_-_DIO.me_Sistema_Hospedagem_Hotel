namespace DesafioProjetoHospedagem.Models
{
    public class Reserva(int diasReservados)
    {
        public int DiasReservados { get; set; } = diasReservados;
        private List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Erro: Limite de hospedes cadastrados da suite selecionada ultrapassado");   
            }
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
            decimal valorDiaria = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10) valorDiaria = (valorDiaria / 100) * 90;

            return valorDiaria;
        }
    }
}