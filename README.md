# APP_II
.net MAUI

## 1ra Apps - Calculadora Simples con MVVM

Esta es un aplicaci�n de calculadora simple desarrollada en .NET MAUI. Permite realizar operaciones b�sicas como suma, resta, multiplicaci�n y divisi�n.

### Funcionalidades
- Suma
- Resta
- Multiplicaci�n
- Divisi�n

### Requisitos
- .NET MAUI instalado
- Visual Studio 2022 o superior
- SDK de .NET 6.0 o superior
- Dispositivo o emulador compatible con .NET MAUI

### Model MVVM
El proyecto sigue el patr�n de dise�o MVVM (Model-View-ViewModel) para separar la l�gica de la interfaz de usuario y facilitar el mantenimiento del c�digo.
- **Model**: Contiene el archivo `CalculadoraModel.cs` que define las operaciones matem�ticas y la l�gica de negocio.
- **View**: Contiene la Interfaz de la Calculadora en `MainPage.xaml`.
- **ViewModel**: Contiene `CalculadoraViewModel.cs` que maneja la interacci�n entre la vista y el modelo.