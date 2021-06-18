namespace Atividade_Fran
{
    public class Aluguel
    {
        public Carro carro { get; set; }
        public string cpfCliente { get; set; }


        public Aluguel(Carro carro, string cpfCliente){
            this.carro = carro;
            this.cpfCliente = cpfCliente;
        }
    }
}