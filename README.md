# APP_II
.net MAUI

## 1ra Apps - Calculadora Simples con MVVM

Esta es un aplicación de calculadora simple desarrollada en .NET MAUI. Permite realizar operaciones básicas como suma, resta, multiplicación y división.

### Funcionalidades
- Suma
- Resta
- Multiplicación
- División

### Requisitos
- .NET MAUI instalado
- Visual Studio 2022 o superior
- SDK de .NET 6.0 o superior
- Dispositivo o emulador compatible con .NET MAUI

### Model MVVM
El proyecto sigue el patrón de diseño MVVM (Model-View-ViewModel) para separar la lógica de la interfaz de usuario y facilitar el mantenimiento del código.
- **Model**: Contiene el archivo `CalculadoraModel.cs` que define las operaciones matemáticas y la lógica de negocio.
- **View**: Contiene la Interfaz de la Calculadora en `MainPage.xaml`.
- **ViewModel**: Contiene `CalculadoraViewModel.cs` que maneja la interacción entre la vista y el modelo.