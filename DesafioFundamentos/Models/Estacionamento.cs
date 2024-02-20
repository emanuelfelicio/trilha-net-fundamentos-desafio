using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{

    public class Estacionamento
    {
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
        }
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> _veiculos = new List<string>();


        public static bool Validador(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var regex = new Regex("^[A-Z]{3}[0-9][A-Z][0-9]{2}");
            return regex.IsMatch(value);
        }
        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = "";
            placa = Console.ReadLine().ToUpper();


            if (Validador(placa))
            {
                if (!_veiculos.Contains(placa))
                {
                    _veiculos.Add(placa);
                }
                else
                {
                    Console.WriteLine("a placa já foi cadastrada!");
                }

            }
            else
            {
                Console.WriteLine("A placa está com formato incorreto ou já foi cadastrada, por favor tente novamente");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = "";
            placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (_veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = 0;
                valorTotal = _precoInicial + _precoPorHora * horas;

                _veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {

            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
