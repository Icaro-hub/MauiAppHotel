namespace MauiAppHotel.Views;
using MauiAppHotel.Models;

public partial class ResumoEvento : ContentPage
{
	public ResumoEvento(Evento evento)
	{
		InitializeComponent();
		this.BindingContext = evento;
	}
}