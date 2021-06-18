namespace Atividade_Fran
{
    public class Carro
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Chassi { get; set; }

        public double Preco { get; set; }

        public bool Status { get; set; }

        public Carro(string _marca, string _modelo, int _ano, string _chassi, double _preco, bool _status)
        {
            this.Marca = _marca;
            this.Modelo = _modelo;
            this.Ano = _ano;
            this.Chassi = _chassi;
            this.Preco = _preco;
            this.Status = _status;
        }

        public double calcularPreco(int horas)
        {
            return Preco * (double)horas;
        }
    }
}