

$(document).ready(function () {
  
    $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/MenuItem", 
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "25%" }

        ],
        "width": "100%"
    });
    
});