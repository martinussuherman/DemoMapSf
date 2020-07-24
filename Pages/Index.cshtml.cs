using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        
        public void OnGet()
        {
            var marker = new List<MapsMarker>
            {
                new MapsMarker()
                {
                    Height= 60
                }
            };
            var tooltip = new MapsTooltipSettings
            {
                Visible = true,
                ValuePath = "city"
            };
        }

        // public IActionResult MarkerCluster()
        // {
        //     ViewBag.world = WorldMap();
        //     ViewBag.marker =  Clustersettings();
        //     return View();
        // }
        // public object WorldMap()
        // {
        //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        //     return JsonConvert.DeserializeObject(allText);
        // }
        // public object Clustersettings()
        // {
        //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/markercluster.js");
        //     return JsonConvert.DeserializeObject(allText);
        // }

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

    }
}
