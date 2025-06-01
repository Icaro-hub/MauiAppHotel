namespace MauiAppHotel.Models;

public class Evento
{
    public string Nome { get; set; }
    public string Local { get; set; }
    public int NumeroParticipantes { get; set; }
    public double CustoPorParticipante { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }

    public TimeSpan DuracaoEvento
    {
        get
        {
            if (DataTermino < DataInicio)
            {
                return TimeSpan.Zero;
            }
            return DataTermino.Subtract(DataInicio);
        }
    }

    public string DuracaoEventoFormada
    {
        get
        {
            if (DuracaoEvento.TotalDays == 0)
            {
                return "0 dias";
            }
            else if (DuracaoEvento.TotalDays == 1)
            {
                return "1 dia";
            }
            else
            {
                return $"{DuracaoEvento.Days} dias";
            }
        }
    }

    public double CustoTotalEvento
    {
        get
        {
            return NumeroParticipantes * CustoPorParticipante;
        }
    }

    public string CustoTotalEventoFormatado
    {
        get
        {
            return CustoTotalEvento.ToString("C2");
        }
    }
}