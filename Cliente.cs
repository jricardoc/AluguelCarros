namespace Atividade_Fran
{
    public class Cliente
    {
        public string CPF { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CNH { get; set; }
        public string Telefone { get; set; }

        public Cliente(string cpf, string nome, string endereco, string cnh, string telefone)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.Endereco = endereco;
            this.CNH = cnh;
            this.Telefone = telefone;
        }
    }
}