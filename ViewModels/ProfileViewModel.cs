using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Actividad2.Models;


namespace Actividad2.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private UserProfile _alumno;

        private ErrorsProfile _errores;

        public ProfileViewModel()
        {
            _alumno = new UserProfile();
            _errores = new ErrorsProfile();

            GuardarCommand = new Command(Guardar);
        }

        public string Nombre
        {
            get => _alumno.Nombre;
            set
            {
                if (_alumno.Nombre != value)
                {
                    _alumno.Nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string Edad
        {
            get => _alumno.Edad;
            set
            {
                if (_alumno.Edad != value)
                {
                    _alumno.Edad = value;
                    OnPropertyChanged(nameof(Edad));
                }
            }
        }

        public string Descripcion
        {
            get => _alumno.Descripcion;
            set
            {
                if (_alumno.Descripcion != value)
                {
                    _alumno.Descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }
        public string ErrorNombre
        {
            get => _errores.errorNombre;
            set
            {
                if (_errores.errorNombre != value)
                {
                    _errores.errorNombre = value;
                    OnPropertyChanged(nameof(ErrorNombre));
                }
            }
        }

        public string ErrorEdad
        {
            get => _errores.errorEdad;
            set
            {
                _errores.errorEdad = value;
                OnPropertyChanged(nameof(ErrorEdad));
            }
        }

        public string ErrorDescripcion
        {
            get => _errores.errorDescripcion;
            set
            {
                _errores.errorDescripcion = value;
                OnPropertyChanged(nameof(ErrorDescripcion));
            }
        }

        public string ImagenUrl { 
            get => _alumno.ImagenUrl; 
            set { 
                if (_alumno.ImagenUrl != value) { 
                    _alumno.ImagenUrl = value; 
                    OnPropertyChanged(nameof(ImagenUrl));
                } 
            } 
        }
        // validar
        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(_alumno.Nombre))
            {
                ErrorNombre = "El nombre es obligatorio";
            }
            else if (!Regex.IsMatch(_alumno.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                ErrorNombre = "El nombre solo puede contener letras y espacios";
            }
            else
            {
                ErrorNombre = string.Empty;
            }
        }
        private void ValidarEdad()
        {
            if (string.IsNullOrWhiteSpace(_alumno.Edad))
                ErrorEdad = "La edad es obligatoria";
            else if (!int.TryParse(_alumno.Edad, out int edadNum) || edadNum <= 0)
                ErrorEdad = "Debe ser un número válido mayor que 0";
            else
                ErrorEdad = string.Empty;
        }

        private void ValidarDescripcion()
        {
            ErrorDescripcion = string.IsNullOrWhiteSpace(Descripcion) ? "La descripción es obligatoria" : string.Empty;
        }
        public ICommand GuardarCommand { get; }
        private void Guardar()
        {
            ValidarNombre();
            ValidarEdad();
            ValidarDescripcion();

            if (!string.IsNullOrEmpty(ErrorNombre) ||
                !string.IsNullOrEmpty(ErrorEdad) ||
                !string.IsNullOrEmpty(ErrorDescripcion))
            {
                return;
            }

            // Aquí podrías guardar en base de datos, mostrar mensaje, etc.
            Application.Current.MainPage.DisplayAlert("Guardado", "Datos actualizados", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nombrePropiedad) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
    }
}

