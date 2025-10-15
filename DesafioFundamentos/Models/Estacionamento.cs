namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            // Se a placa não foi informada, solicita ao usuário
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.Write("Digite a placa do veículo para estacionar: ");
                placa = Console.ReadLine();
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa '{placa}' adicionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            string placa = string.Empty;
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();
            
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = int.Parse(Console.ReadLine());
                valorTotal = precoInicial + precoPorHora * horas;
                
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int i = 0;
                foreach (var veiculo in veiculos)
                {
                    ++i;
                    Console.WriteLine($"{i} - {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
