public class FilaVetor
{
    private string[] vetor;
    private int fim; // Marca o índice da última posição ocupada
    private int capacidade;

    public FilaVetor(int tamanhoMaximo)
    {
        capacidade = tamanhoMaximo;
        vetor = new string[capacidade];
        fim = -1; // -1 indica que a fila está vazia
    }

    public bool EstaVazia()
    {
        return fim == -1;
    }

    public bool EstaCheia()
    {
        return fim == capacidade - 1;
    }

    // Insere a senha na próxima posição livre do vetor
    public bool Enfileirar(string senha)
    {
        if (EstaCheia())
        {
            return false;
        }

        fim++;
        vetor[fim] = senha;
        return true;
    }

    // Remove quem está na posição 0 e puxa todo mundo para a esquerda
    public string Desenfileirar()
    {
        if (EstaVazia())
        {
            return null;
        }

        // Guarda a senha do primeiro da fila (sempre no índice 0)
        string senhaChamada = vetor[0];

        // Desloca os elementos: o índice 1 vai para o 0, o 2 vai para o 1, etc.
        for (int i = 0; i < fim; i++)
        {
            vetor[i] = vetor[i + 1];
        }

        // Limpa a última posição que ficou duplicada e diminui o tamanho
        vetor[fim] = null;
        fim--;

        return senhaChamada;
    }

    // Mostra os itens do vetor um ao lado do outro
    public string ExibirFila()
    {
        if (EstaVazia())
        {
            return "[ Vazia ]";
        }

        string resultado = "[ ";
        for (int i = 0; i <= fim; i++)
        {
            resultado += vetor[i];
            if (i < fim)
            {
                resultado += " | ";
            }
        }
        resultado += " ]";

        return resultado;
    }
}