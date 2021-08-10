$(document).ready(function() {
})

    function validate() {
        if ($('#first_name').val() === "") {
            alert("no name!");
        }
    }
  
    function signUp(e) {
    
    
       // create new customer object
       let airline = 
       {
        companyName: $('#company_name').val(), 
        countryName: $('#country').val(), 
           user:
           {
               userName:$("#user_name").val(),
               password:$("#user_password").val(),
               email:$("#email").val(),
           }
       }
    
       //fire ajax request
       e.preventDefault();
    
       console.log(airline);
       console.log(JSON.stringify(airline));
       let airlineJson =JSON.stringify(airline); 
    
       let jqXhr = $.ajax({
           url: "https://localhost:44395/api/Anonymous/SignUpAirline",
           type: "POST",
           data: airlineJson,
           dataType: "json",
           contentType: "application/json",
        }).done(function (result) {
            console.log("action taken: " + result.success);
            return result;
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
    
        });
    }

    