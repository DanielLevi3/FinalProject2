        function signUp(e) {
    
    
            // create new customer object
            let admin = 
            {
                firstName: $('#first_name').val(), 
                lastName: $('#last_name').val(),
                level: $('#level').val(),
                user:
                {
                    userName:$("#user_name").val(),
                    password:$("#user_password").val(),
                    email:$("#email").val(),
                }
            }
         
            //fire ajax request
            e.preventDefault();
         
            console.log(admin);
            console.log(JSON.stringify(admin));
            let adminJson =JSON.stringify(admin); 
         
            let jqXhr = $.ajax({
                url: "https://localhost:44395/api/Anonymous/SignUpAdmin",
                type: "POST",
                data: adminJson,
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
     