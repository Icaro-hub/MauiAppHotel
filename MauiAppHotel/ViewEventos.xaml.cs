namespace MauiAppHotel;
using MauiAppHotel.Views;
using MauiAppHotel.Models;


public partial class ViewEventos : ContentPage
{
    public ViewEventos()
    {
        InitializeComponent();
    }

    private async void OnCadastrarEventosClicked(object sender, EventArgs e)
    {
        var novoEvento = new Evento();

        if (string.IsNullOrWhiteSpace(txt_nome_do_evento.Text))
        {
            await DisplayAlert("Valida��o", "Por favor, inserir nome do evento!", "OK");
            return;
        }
        novoEvento.Nome = txt_nome_do_evento.Text;

        if (string.IsNullOrWhiteSpace(txtLocal.Text))
        {
            await DisplayAlert("Valida��o", "Por favor, inserir local do evento!", "OK");
            return;
        }
        novoEvento.Local = txtLocal.Text;

        if (!int.TryParse(txtNumeroParticipantes.Text, out int numParticipantes) || numParticipantes <= 0)
        {
            await DisplayAlert("Valida��o", "O n�mero de participantes deve ser um valor num�rico maior que zero.", "OK");
            return;
        }
        novoEvento.NumeroParticipantes = numParticipantes;

        if (!double.TryParse(txtCusto.Text, out double custoPorParticipante) || custoPorParticipante < 0)
        {
            await DisplayAlert("Valida��o", "O custo por participante deve ser um valor num�rico n�o negativo.", "OK");
            return;
        }
        novoEvento.CustoPorParticipante = custoPorParticipante;

        novoEvento.DataInicio = dtpck_inicio.Date;
        novoEvento.DataTermino = dtpck_termino.Date;

        if (novoEvento.DataTermino < novoEvento.DataInicio)
        {
            await DisplayAlert("Valida��o", "A Data de t�rmino n�o pode ser anterior � DataInicio", "OK");
            return;
        }

        

        await Navigation.PushAsync(new ResumoEvento(novoEvento));
    }
}