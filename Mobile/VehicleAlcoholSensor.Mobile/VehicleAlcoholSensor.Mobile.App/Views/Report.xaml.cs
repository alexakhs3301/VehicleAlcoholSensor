using VehicleAlcoholSensor.Application.Commands.Report;
using VehicleAlcoholSensor.Mobile.App.Helpers;

namespace VehicleAlcoholSensor.Mobile.App.Views;

public partial class Report : ContentPage
{
    private readonly Handler _getReports;
    private const float  ppmToMgL = 0.9988590004f;

	public Report(Handler getReports)
	{
		InitializeComponent();
        _getReports = getReports;
        this.Appearing += Report_Appearing;
		this.Focused += Report_Focused;
    }

	private async void Report_Focused(object sender, FocusEventArgs e)
	{
		await GetTheReport();
	}

	private async void Report_Appearing(object sender, EventArgs e)
	{
		await GetTheReport();
	}

	private async Task GetTheReport()
	{
		var list = await _getReports.ExecuteAsync(new Application.Commands.Report.Command
		{
			DriverId = VehicleAlcoholSensorContext.Driver.Id,
			VehicleId = VehicleAlcoholSensorContext.Driver.Vehicle.Id,
			DeviceId = VehicleAlcoholSensorContext.Driver.Device.Id,
		});

		foreach (var value in list)
		{
			value.MgL = ((float)value.Concentration * ppmToMgL) / 1000.0f;
			value.MgL -= 0.15f;
		}

		this.ReportListView.ItemsSource = list.OrderByDescending(x => x.EventTimestamp);
	}
}