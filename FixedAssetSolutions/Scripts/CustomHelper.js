
// AJAX Function to get data

function AJAX() {

    $.ajax({
        type: "GET",
        url: "http://localhost:49889/API/Company",
        success: function (data) {
            console.log(data);
        }
    });
}
    
    
   
    
