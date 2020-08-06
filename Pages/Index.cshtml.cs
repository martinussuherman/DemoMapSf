using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Syncfusion.EJ2.Maps;

namespace DemoMapSf.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(
            ILogger<IndexModel> logger,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string[] Toolbars => new string[]
        {
            "Zoom",
            "ZoomIn",
            "ZoomOut",
            "Pan",
            "Reset"
        };

        public string BingKey => _configuration.GetValue<string>("BingKey");

        public object MapsMarker => ReadMarkerFromFile();

        public MapsMarkerClusterSettings MapsMarkerClusterSettings => new MapsMarkerClusterSettings
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

        public MapsTooltipSettings MapsTooltipSettings => new MapsTooltipSettings
        {
            // Template = "#tooltip-template",
            Visible = true,
            ValuePath = "city"
        };

        public void OnGet()
        {
            // MapsZoomSettings mapsZoomSettings = new MapsZoomSettings
            // {
            //     ToolBarOrientation = Orientation.Vertical
            // };

            // Maps maps = new Maps
            // {
            //     CenterPosition = new MapsCenterPosition
            //     {
            //         Latitude = -2.15,
            //         Longitude = 118
            //     },
            //     ZoomSettings = new MapsZoomSettings
            //     {
            //         ZoomFactor = 3
            //     }
            // };

            // MapsLayer mapsLayer = new MapsLayer
            // {
            //     LayerType = ShapeLayerType.Bing,
            //     BingMapType = BingMapType.AerialWithLabel
            // };

            // MapsMarker marker = new MapsMarker
            // {
            //     Shape = MarkerType.Circle,
            //     Fill = "#ff0000"
            // };
        }

        // public object WorldMap()
        // {
        //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        //     return JsonConvert.DeserializeObject(allText);
        // }

        private object ReadMarkerFromFile()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/markercluster.js");
            return JsonConvert.DeserializeObject(allText);
        }

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

    }
}
