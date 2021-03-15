// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function hideTooltip()
{
    $("#maps_mapsTooltip").remove();
}

function markerClicked(args) 
{
    x = args.x;
    y = args.y;
    $(".protaru-tooltip").html(
        '<h5 class="text-center">' + args.data.location + '</h5>' +
        '<h6 class="text-center">' + args.data.rtr + '</h6>' +
        '<p class="mb-0">Progress: ' + args.data.progress + '</p>' +
        '<p class="mb-0">Surat Rekom Gub: ' + args.data.rekomGub + '</p>' +
        '<p class="mb-0">Rapat Lintas Sektor: ' + args.data.linSek + '</p>' +
        '<p class="mb-0">Surat Persetujuan Substansi: ' + args.data.perSub + '</p>' +
        '<p class="mb-0">No. Perda: ' + args.data.perda + '</p>' +
        '<button onclick="linkClicked()" class="btn btn-primary btn-block p-0">Detail</a>'
    );
}
