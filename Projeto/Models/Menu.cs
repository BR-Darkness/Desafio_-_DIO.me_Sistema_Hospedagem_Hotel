namespace DesafioProjetoHospedagem.Models;

public class Menu
{
    static readonly List<Suite> listaSuites = [];
    static readonly List<Reserva> listaReservas = [];

    public static void MenuPrincipal()
    {
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("== Digite a sua opção: ==");
            Console.WriteLine("1. Suítes");
            Console.WriteLine("2. Reservas");
            Console.WriteLine("3. Encerrar");
            Console.WriteLine();
            Console.Write("Selecione uma opção: ");

            switch (Console.ReadLine())
            {
                case "1": MenuSuites();                         break;
                case "2": MenuReservas();                       break;
                case "3": exibirMenu = false;                   break;
                
                default: Console.WriteLine("Opção inválida");   break;
            }
        }

        Console.Write("\nPressione qualquer tecla para continuar...");
        Console.ReadLine();
        
        Console.WriteLine("O programa se encerrou");
    }

    #region "Menu Suítes"
    public static void MenuSuites()
    {
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("== MENU SUÍTES ==");
            Console.WriteLine("1. Cadastrar suíte");
            Console.WriteLine("2. Remover suíte");
            Console.WriteLine("3. Listar suítes");
            Console.WriteLine("4. Voltar");
            Console.WriteLine();
            Console.Write("Selecione uma opção: ");

            switch (Console.ReadLine())
            {
                case "1": CadastrarSuite();     break;
                case "2": RemoverSuite();       break;
                case "3": ListarSuites();       break;
                case "4": exibirMenu = false;   break;
                
                default: Console.WriteLine("Opção inválida");   break;
            }

            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }
    }

    public static void CadastrarSuite()
    {
        Console.WriteLine();
        Console.Write("Tipo da suíte: ");
        string tipoSuite = Console.ReadLine().Trim().ToUpper();

        if (!listaSuites.Any(suite => suite.TipoSuite == tipoSuite))
        {
            Console.Write("Capacidade da suíte: ");
            int capacidadeSuite = Convert.ToInt32(Console.ReadLine());

            Console.Write("Valor da diária da suíte: ");
            decimal valorDiariaSuite = Convert.ToDecimal(Console.ReadLine());

            listaSuites.Add
            (
                new Suite
                (
                    tipoSuite: tipoSuite, 
                    capacidade: capacidadeSuite, 
                    valorDiaria: valorDiariaSuite
                )
            );
        }
        else
        {
            Console.WriteLine("Suite já cadastrada");
        }
    }
    
    public static void RemoverSuite()
    {
        Console.WriteLine();
        Console.Write("Tipo da suíte: ");
        string tipoSuite = Console.ReadLine().Trim().ToUpper();

        if (listaSuites.Any(suite => suite.TipoSuite == tipoSuite))
        {
            Suite suiteQueSeraDeletada = listaSuites.FirstOrDefault(
                suite => suite.TipoSuite.Equals(tipoSuite, StringComparison.OrdinalIgnoreCase)
            );

            if (listaReservas.Any(reserva => reserva.Suite == suiteQueSeraDeletada))
            {
                Console.WriteLine("Suíte encontra-se sob reserva no momento");
                return;
            }

            listaSuites.Remove(suiteQueSeraDeletada);
        }
        else
        {
            Console.WriteLine("Suite não encontrada");
        }
    }

    public static void ListarSuites()
    {
        // Verifica se há veículos no estacionamento
        if (listaSuites.Count != 0)
        {
            Console.WriteLine();
            Console.WriteLine("== As suítes cadastradas são: ==");

            Console.WriteLine($"• {"Nº",-10} | {"Tipo da Suíte",-20} | {"Valor Diária",-15} | {"Capacidade",-10}");
            Console.WriteLine("---------------------------------------------------------------------");

            for (int i = 0; i < listaSuites.Count; i++)
            {
                Suite s = listaSuites[i];
                Console.WriteLine($"• {i + 1,-10:00} | {s.TipoSuite,-20} | {s.ValorDiaria,-15:C} | {s.Capacidade,-10}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total de suítes cadastradas: {listaSuites.Count}");
        }
        else
        {
            Console.WriteLine("Não há suítes cadastradas.");
        }
    }
    #endregion

    #region "Menu Reservas"
    public static void MenuReservas()
    {
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("== MENU RESERVAS ==");
            Console.WriteLine("1. Cadastrar reserva");
            Console.WriteLine("2. Remover reserva");
            Console.WriteLine("3. Listar reservas");
            Console.WriteLine("4. Voltar");
            Console.WriteLine();
            Console.Write("Selecione uma opção: ");

            switch (Console.ReadLine())
            {
                case "1": CadastrarReserva();   break;
                case "2": RemoverReserva();     break;
                case "3": ListarReservas();     break;
                case "4": exibirMenu = false;   break;
                
                default: Console.WriteLine("Opção inválida");   break;
            }

            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }
    }

    public static void CadastrarReserva()
    {
        Console.WriteLine();
        Console.Write("Suíte da reserva: ");
        string tipoDaSuiteDaReserva = Console.ReadLine().Trim().ToUpper();

        Suite suiteDaReserva = listaSuites.FirstOrDefault(
            suite => suite.TipoSuite.Equals(tipoDaSuiteDaReserva, StringComparison.OrdinalIgnoreCase)
        );

        if (suiteDaReserva is null)
        {
            Console.WriteLine("Suíte não encontrada");
            return;
        }

        if (!listaReservas.Any(reserva => reserva.Suite == suiteDaReserva))
        {
            Console.Write("Dias da reserva: ");
            int diasDaReserva = Convert.ToInt32(Console.ReadLine());

            List<Pessoa> lista = GerarListaHospedesReserva();

            Reserva reserva = new Reserva(diasDaReserva);
            reserva.CadastrarSuite(suiteDaReserva);
            reserva.CadastrarHospedes(lista);

            listaReservas.Add(reserva);
        }
        else
        {
            Console.WriteLine("Suite já reservada");
        }
    }
    
    public static void RemoverReserva()
    {
        Console.WriteLine();
        Console.Write("Suíte da reserva: ");
        string nomeDaSuiteDaReserva = Console.ReadLine().Trim().ToUpper();

        Reserva reservaQueSeraRemovida = listaReservas.FirstOrDefault(
            reserva => reserva.Suite.TipoSuite.Equals(nomeDaSuiteDaReserva, StringComparison.OrdinalIgnoreCase)
        );

        if (reservaQueSeraRemovida is null)
        {
            Console.WriteLine("Reserva não encontrada");
            return;
        }

        if (listaReservas.Any(reserva => reserva == reservaQueSeraRemovida))
        {
            listaReservas.Remove(reservaQueSeraRemovida);
        }
        else
        {
            Console.WriteLine("Suite não encontrada");
        }
    }

    public static void ListarReservas()
    {
        // Verifica se há veículos no estacionamento
        if (listaReservas.Count != 0)
        {
            Console.WriteLine();
            Console.WriteLine("== As reservas cadastradas são: ==");

            Console.WriteLine($"• {"Nº",-10} | {"Tipo da Suíte",-20} | {"Dias Reservados",-15} | {"Valor Total",-15} | {"Hospedes",-10}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            for (int i = 0; i < listaReservas.Count; i++)
            {
                Reserva r = listaReservas[i];
                Console.WriteLine($"• {i + 1,-10:00} | {r.Suite.TipoSuite,-20} | {r.DiasReservados,-15} | {r.CalcularValorDiaria(),-15:C} | {r.ObterQuantidadeHospedes(),-10}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total de reservas cadastradas: {listaReservas.Count}");
        }
        else
        {
            Console.WriteLine("Não há reservas cadastradas.");
        }
    }
    #endregion

    #region "Hóspedes"
    public static List<Pessoa> GerarListaHospedesReserva()
    {
        List<Pessoa> listaHospedesReserva = new List<Pessoa>();
        bool adicionando = true;

        // Realiza o loop do menu
        while (adicionando)
        {
            Console.WriteLine();
            Console.Write("Digite o nome do hóspede: ");
            string nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                listaHospedesReserva.Add(new Pessoa(nome));
            }
            else
            {
                Console.WriteLine("Nome não pode ser vazio");
                continue;
            }

            Console.Write("\nAdicionar mais hóspedes? (N para parar): ");
            string resposta = Console.ReadLine();

            if (resposta != null && resposta.Equals("N", StringComparison.OrdinalIgnoreCase)) adicionando = false;
        }

        return listaHospedesReserva;
    }
    #endregion
}
