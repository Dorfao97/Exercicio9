GerenciadorAtendimento hospital = new GerenciadorAtendimento(20);
int opcao = 0;

while (opcao != 5)
{
    Console.WriteLine("\n=== HOSPITAL SÓFALTAVOCÊ ===");
    Console.WriteLine("1 - Gerar senha PRIORITÁRIA");
    Console.WriteLine("2 - Gerar senha NORMAL");
    Console.WriteLine("3 - Chamar próximo paciente");
    Console.WriteLine("4 - Exibir filas");
    Console.WriteLine("5 - Sair");
    Console.Write("Escolha uma opção: ");

    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Digite apenas números válidos!");
        continue;
    }

    switch (opcao)
    {
        case 1:
            hospital.GerarSenhaPrioritaria();
            break;
        case 2:
            hospital.GerarSenhaNormal();
            break;
        case 3:
            hospital.ChamarProximoPaciente();
            break;
        case 4:
            hospital.MostrarStatusFilas();
            break;
        case 5:
            Console.WriteLine("Sistema encerrado.");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}