

$(document).ready(function () {
  
    $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/MenuItem", 
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name",          "width": "25%" },
            { "data": "price",         "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "foodType.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div>
                                <a href="/Admin/MenuItems/Upsert?id=${data}" class="btn btn-success text-white"
                                style="cursor:pointer; width:100px;"> <i class="bi bi-pencil-square"></i> Edit </a>
                                <a href="/Admin/MenuItems/Upsert?id=${data}" class="btn btn-danger text-white"
                                style="cursor:pointer; width:100px;"> <i class="bi bi-trash-fill"></i> Delete </a>

                            </div`
                },

                "width": "15%"
            }

        ],
        "width": "100%"
    });
    
});