using VehicleAlcoholSensor.Application.Commands.Report;

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
        var list = await _getReports.HandleAsync(new Application.Commands.Report.Command
        {
            DriverId = 1,
            VehicleId = 1,
        });

        this.ReportListView.ItemsSource = list;
    }
}