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
            await DisplayAlert("Validação", "Por favor, inserir nome do evento!", "OK");
            return;
        }
        novoEvento.Nome = txt_nome_do_evento.Text;

        if (string.IsNullOrWhiteSpace(txtLocal.Text))
        {
            await DisplayAlert("Validação", "Por favor, inserir local do evento!", "OK");
            return;
        }
        novoEvento.Local = txtLocal.Text;

        if (!int.TryParse(txtNumeroParticipantes.Text, out int numParticipantes) || numParticipantes <= 0)
        {
            await DisplayAlert("Validação", "O número de participantes deve ser um valor numérico maior que zero.", "OK");
            return;
        }
        novoEvento.NumeroParticipantes = numParticipantes;

        if (!double.TryParse(txtCusto.Text, out double custoPorParticipante) || custoPorParticipante < 0)
        {
            await DisplayAlert("Validação", "O custo por participante deve ser um valor numérico não negativo.", "OK");
            return;
        }
        novoEvento.CustoPorParticipante = custoPorParticipante;

        novoEvento.DataInicio = dtpck_inicio.Date;
        novoEvento.DataTermino = dtpck_termino.Date;

        if (novoEvento.DataTermino < novoEvento.DataInicio)
        {
            await DisplayAlert("Validação", "A Data de término não pode ser anterior à DataInicio", "OK");
            return;
        }

        

        await Navigation.PushAsync(new ResumoEvento(novoEvento));
    }
}