using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Syncfusion.EJ2.Maps;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoMapSf.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(
            IHttpClientFactory httpClientFactory,
            ILogger<IndexModel> logger,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public string BingKey => _configuration.GetValue<string>("BingKey");

        public object MapsMarkerData;

        public MapsCenterPosition CenterPosition => new MapsCenterPosition
        {
            Latitude = -2.8,
            Longitude = 118
        };

        public MapsMarkerClusterSettings ClusterSettings => new MapsMarkerClusterSettings
        {
            AllowClusterExpand = true,
            AllowClustering = true,
            Shape = MarkerType.Image,
            Height = 40,
            Width = 40,
            ImageUrl = Url.Content("~/cluster.svg"),
            LabelStyle = new MapsFont
            {
                Color = "White"
            }
        };

        public List<MapsMarker> MarkerSettings => new List<MapsMarker>
        {
            new MapsMarker
            {
                AnimationDuration = 0,
                DataSource = MapsMarkerData,
                Fill = "#ff0000",
                Height = 10,
                Shape = MarkerType.Circle,
                TooltipSettings = _tooltipSettings,
                Visible = true,
                Width = 10
            }
        };

        public MapsZoomSettings ZoomSettings => new MapsZoomSettings
        {
            Enable = true,
            MouseWheelZoom = false,
            HorizontalAlignment = Alignment.Near,
            PinchZooming = true,
            ShouldZoomInitially = false,
            Toolbars = _toolbars,
            ToolBarOrientation = Orientation.Vertical,
            ZoomFactor = 5
        };

        public async Task OnGet()
        {
            var x = ReadMarkerFromFile();
            MapsMarkerData = await ReadMarkerFromApi();

            Maps maps = new Maps
            {
                TooltipDisplayMode = TooltipGesture.DoubleClick,
            };

            // MapsLayer mapsLayer = new MapsLayer
            // {
            //     LayerType = ShapeLayerType.Bing,
            //     BingMapType = BingMapType.AerialWithLabel,
            //     ShapeSettings = new MapsShapeSettings
            //     {
            //         Autofill = true
            //     }
            // };
        }

        // public object WorldMap()
        // {
        //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        //     return JsonConvert.DeserializeObject(allText);
        // }

        private async Task<object> ReadMarkerFromApi()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.SendAsync(new HttpRequestMessage(
                HttpMethod.Get,
                "https://atr.wordpress-theme.bid/protaru/api/Progress/DaerahMap"));
            return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
        }

        private object ReadMarkerFromFile()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/markercluster.js");
            return JsonConvert.DeserializeObject(allText);
        }

        private readonly string[] _toolbars = new string[]
        {
            "Zoom",
            "ZoomIn",
            "ZoomOut",
            "Pan",
            "Reset"
        };
        private readonly MapsTooltipSettings _tooltipSettings = new MapsTooltipSettings
        {
            Template = "#tooltip-template",
            Visible = true,
            ValuePath = "nama"
        };
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
    }
}
