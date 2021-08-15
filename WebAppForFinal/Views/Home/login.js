function signIn(e) {
    
    
    // create new customer object
    let userdetails = 
    {
            Name:$("#username").val(),
            password:$("#password").val()
    }
 
    //fire ajax request
    e.preventDefault();
 
    console.log(airline);
    console.log(JSON.stringify(airline));
    let userdetails =JSON.stringify(airline); 
 
    let jqXhr = $.ajax({
        url: "https://localhost:44395/api/Auth/GetToken",
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