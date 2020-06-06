using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OxyPlotView : ContentPage
    {
        public OxyPlotInfo oxyPlotInfo;
        public OxyPlotView()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            this.Title = "OxyPlot";
            oxyPlotInfo = new OxyPlotInfo();
            oxyPlotInfo.info = "Xamarin Pie-Chart";
            List<OxyPlotItem> items = new List<OxyPlotItem>
            {
                new OxyPlotItem { Label = "slice 1", value = 25, color = OxyColor.FromRgb(122, 122, 122) },
                new OxyPlotItem { Label = "slice 2", value = 50, color = OxyColor.FromRgb(20, 22, 22) },
                new OxyPlotItem { Label = "slice 3", value = 100, color = OxyColor.FromRgb(222, 222, 222) }
            };
            oxyPlotInfo.Items = items;
            this.BindingContext = this.oxyPlotInfo;
            this.MakePlot();
        }
        public void MakePlot()
        {
            PlotModel plotModel = new PlotModel
            {
                Title = "OxyPlot Example",
                TextColor = OxyColor.FromRgb(122, 122, 122)
            };
            var ps = new PieSeries
            {
                StrokeThickness=.25,
                InsideLabelPosition=.25,
                AngleSpan = 360,
                StartAngle = 0,
                TextColor = OxyColor.FromRgb(100, 100, 100)
            };
            foreach (var oxyitem in oxyPlotInfo.Items)
            {
                ps.Slices.Add(new PieSlice(oxyitem.Label, oxyitem.value) { IsExploded = false, Fill = oxyitem.color });
            };

            plotModel.Series.Add(ps);
            this.plotmodel.Model = plotModel;
        }

        private async void ProgressBotton_Clicked(object sender, EventArgs e)
        {
            await this.Processbar.ProgressTo(.8, 500, Easing.Linear);
        }
    }
}