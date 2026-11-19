public class GerenciadorAtendimento
{
    private FilaVetor filaPrioritaria;
    private FilaVetor filaNormal;

    private int contadorPrioritario;
    private int seqPrioritaria;
    private int seqNormal;

    public GerenciadorAtendimento(int capacidadePorFila)
    {
        filaPrioritaria = new FilaVetor(capacidadePorFila);
        filaNormal = new FilaVetor(capacidadePorFila);

        contadorPrioritario = 0;
        seqPrioritaria = 1;
        seqNormal = 1;
    }

    public void GerarSenhaPrioritaria()
    {
        string senha = $"P{seqPrioritaria:D2}";
        if (filaPrioritaria.Enfileirar(senha))
        {
            seqPrioritaria++;
            Console.WriteLine($"-> Senha PRIORITÁRIA gerada: {senha}");
        }
        else
        {
            Console.WriteLine("-> ERRO: A fila prioritária está cheia!");
        }
    }

    public void GerarSenhaNormal()
    {
        string senha = $"N{seqNormal:D2}";
        if (filaNormal.Enfileirar(senha))
        {
            seqNormal++;
            Console.WriteLine($"-> Senha NORMAL gerada: {senha}");
        }
        else
        {
            Console.WriteLine("-> ERRO: A fila normal está cheia!");
        }
    }

    public void ChamarProximoPaciente()
    {
        if (filaPrioritaria.EstaVazia() && filaNormal.EstaVazia())
        {
            Console.WriteLine("-> Nenhuma senha aguardando atendimento.");
            return;
        }

        // Regra: Chama prioritário se tiver gente E (chamou menos de 2 OU a normal está vazia)
        if (!filaPrioritaria.EstaVazia() && (contadorPrioritario < 2 || filaNormal.EstaVazia()))
        {
            string chamado = filaPrioritaria.Desenfileirar();
            contadorPrioritario++;
            Console.WriteLine($"*** CHAMANDO PRIORITÁRIO: {chamado} ***");
        }
        else if (!filaNormal.EstaVazia())
        {
            string chamado = filaNormal.Desenfileirar();
            contadorPrioritario = 0; // Reinicia a contagem para os próximos 2 prioritários
            Console.WriteLine($"*** CHAMANDO NORMAL: {chamado} ***");
        }
    }

    public void MostrarStatusFilas()
    {
        Console.WriteLine("\n--- SITUAÇÃO ATUAL DOS VETORES ---");
        Console.WriteLine("Fila Prioritária: " + filaPrioritaria.ExibirFila());
        Console.WriteLine("Fila Normal:      " + filaNormal.ExibirFila());
    }
}