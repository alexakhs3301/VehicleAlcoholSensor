using VehicleAlcoholSensor.Application.Commands.Report;
using VehicleAlcoholSensor.Mobile.App.Helpers;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Report : ContentPage
{
    private readonly Handler _getReports;

    public Report(Handler getReports)
	{
		InitializeComponent();
        _getReports = getReports;
        this.Appearing += Report_Appearing;
    }

    private async void Report_Appearing(object sender, EventArgs e)
    {
        var list = await _getReports.ExecuteAsync(new Application.Commands.Report.Command
        {
            DriverId = VehicleAlcoholSensorContext.Driver.Id,
            VehicleId = VehicleAlcoholSensorContext.Driver.Vehicle.Id,
            DeviceId = VehicleAlcoholSensorContext.Driver.Device.Id,
        });

        this.ReportListView.ItemsSource = list.OrderByDescending(x=>x.EventTimestamp);
    }
}