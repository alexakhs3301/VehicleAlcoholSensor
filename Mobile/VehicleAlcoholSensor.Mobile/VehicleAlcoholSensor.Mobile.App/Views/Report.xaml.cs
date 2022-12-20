using VehicleAlcoholSensor.Application.Commands.Report;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Report : ContentPage
{
    private readonly Handler _getReports;

    public Report(Handler getReports)
	{
		InitializeComponent();
        _getReports = getReports;

        InitializeList();
    }

    private void InitializeList()
    {
        var list = _getReports.HandleAsync(new Application.Commands.Report.Command
        {
            DriverId = 1,
            VehicleId = 1,
        }).Result;

        foreach(var entity in list)
        {
            Console.WriteLine(entity.ToString());
        }
    }
}