namespace MinimalApiVeiculos.Models
{
    public class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
    }
}