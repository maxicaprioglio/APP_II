
namespace Calculadora.Models
{
    public class CalculadoraModel
    {
        public double PrimerNumero { get; set; }
        public double SegundoNumero { get; set; }
        public string Operador { get; set; } = string.Empty;

        public double Calcular()
        {
            return Operador switch
            {
                "+" => PrimerNumero + SegundoNumero,
                "-" => PrimerNumero - SegundoNumero,
                "*" => PrimerNumero * SegundoNumero,
                "/" => SegundoNumero != 0 ? PrimerNumero / SegundoNumero : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException("Operador inválido")
            };
        }
    }
}