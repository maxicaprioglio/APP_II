using System.ComponentModel;
using System.Windows.Input;
using Actividad2.Models;
using System.Diagnostics; // Agrega este using


namespace Actividad2.ViewModels
{
    public class CalculadoraViewModel : INotifyPropertyChanged
    {
        private readonly CalculadoraModel model = new CalculadoraModel();
        private string valorEntrada = "";
        private bool isReturning = true;

        private string display = "0";
        public string Display
        {
            get => display;
            set
            {
                if (display != value)
                {
                    display = value;
                    OnPropertyChanged(nameof(Display));
                }
            }
        }

        public ICommand NumeroCommand { get; }
        public ICommand OperadorCommand { get; }
        public ICommand EnterCommand { get; }

        public CalculadoraViewModel()
        {
            NumeroCommand = new Command<string>(OnNumeroClicked);
            OperadorCommand = new Command<string>(OnOperadorClicked);
            EnterCommand = new Command(OnEnterClicked);
        }

        private void OnNumeroClicked(string numero)
        {
            if (isReturning)
            {
                if (Display == "0")
                {
                    Display = "";
                }
                valorEntrada += numero;
                Display += numero;
            }
            else
            {
                Display = "";
                valorEntrada = "";
                model.Operador = "";
                model.PrimerNumero = 0;
                isReturning = true;

                valorEntrada += numero;
                Display += numero;
            }
        }

        private void OnOperadorClicked(string operador)
        {
            if (model.Operador == "")
            {
                if (double.TryParse(valorEntrada, out double primerNumero))
                {
                    model.PrimerNumero = primerNumero;
                    model.Operador = operador;
                    valorEntrada = "";
                    Display += operador;
                }
            }
        }

        private void OnEnterClicked()
        {
            if (model.PrimerNumero != 0 || model.SegundoNumero != 0)
            {
                if (double.TryParse(valorEntrada, out double segundoNumero))
                {
                    model.SegundoNumero = segundoNumero;

                    try
                    {
                        double result = model.Calcular();
                        Display = result.ToString();

                    }
                    catch (Exception ex)
                    {
                        Display = "No se puede dividir por 0";
                    }

                    isReturning = false;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
