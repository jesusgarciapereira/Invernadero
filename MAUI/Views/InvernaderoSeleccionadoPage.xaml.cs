using DTO;
using MAUI.VM;

namespace MAUI.Views;

public partial class InvernaderoSeleccionadoPage : ContentPage
{
	public InvernaderoSeleccionadoPage()
	{
		InitializeComponent();
	}
    public InvernaderoSeleccionadoPage(clsTemperaturaConNombreInvernadero temperaturasConNombreInvernadero)
    {
        InitializeComponent();
        BindingContext = new InvernaderoSeleccionadoVM(temperaturasConNombreInvernadero);

    }
}