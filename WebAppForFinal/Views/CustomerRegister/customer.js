$(document).ready(function() {
    /*
    $('#contact_form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            first_name: {
                validators: {
                        stringLength: {
                        min: 2,
                    },
                        notEmpty: {
                        message: 'Please enter your First Name'
                    }
                }
            },
             last_name: {
                validators: {
                     stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please enter your Last Name'
                    }
                }
            },
			 user_name: {
                validators: {
                     stringLength: {
                        min: 8,
                    },
                    notEmpty: {
                        message: 'Please enter your Username'
                    }
                }
            },
			 user_password: {
                validators: {
                     stringLength: {
                        min: 8,
                    },
                    notEmpty: {
                        message: 'Please enter your Password'
                    }
                }
            },
            credit: {
                validators: {
                     stringLength: {
                        min: 16,
                    },
                    notEmpty: {
                        message: 'Please enter your Credit Card number'
                    }
                }
            },
			// confirm_password: {
            //     validators: {
            //          stringLength: {
            //             min: 8,
            //         },
            //         notEmpty: {
            //             message: 'Please confirm your Password'
            //         }
            //     }
            // },
            email: {
                validators: {
                    notEmpty: {
                        message: 'Please enter your Email Address'
                    },
                    emailAddress: {
                        message: 'Please enter a valid Email Address'
                    }
                }
            },
            contact_no: {
                validators: {
                  stringLength: {
                        min: 10, 
                        max: 12,
                    notEmpty: {
                        message: 'Please enter your Contact No.'
                     }
                }
            },
			 address: {
                validators: {
                    notEmpty: {
                        message: 'Please enter your Address'
                    }
                }
            },
                }
            }
            
 });
*/

 

//             // Prevent form submission
//             e.preventDefault();

//             // Get the form instance
//             var $form = $(e.target);

//             // Get the BootstrapValidator instance
//             var bv = $form.data('bootstrapValidator');

//              //Use Ajax to submit form data
//             $.post($form.attr('action'), $form.serialize(), function(result) {
//                 console.log(result);
//             }, 'json/*');
//             var url = "Annonymous/SignUp";

//             var data = {};
//             var json = JSON.stringify(data);

//             var xhr = new XMLHttpRequest();
//             xhr.open("POST", url, true);
//             xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
//             xhr.onload = function () {
//                 var users = JSON.parse(xhr.responseText);
//                 if (xhr.readyState == 4 && xhr.status == "201") {
//                     console.table(users);
//                 } else {
//                     console.error(users);
//                 }
//             }
//             xhr.send(json);
//                 .on('success.form.bv', function (e) {
//                 $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
//                 $('#contact_form').data('bootstrapValidator').resetForm();
//                 });
//    // $("#contact_form").submit(function (event) {

//     //    // Stop form from submitting normally
//     //    //event.preventDefault();

//     //    // Get some values from elements on the page:
//     //    //var $form = $(this),
//     //    //    term = $form.find("input[name='first_name']", "input[name='last_name']", "input[name='credit']", "input[name='address']", "input[name='user_name']", "input[name='user_password']", "input[name='email']", "input[name='contact_no']").val(),
//     //    //    url = $form.attr("action");

//     //    // Send the data using post
//     //    //var posting = $.post(url, { s: term });

//     //    // Put the results in a div
//     //    posting.done(function (data) {
//     //        var content = $(data).find("#content");
//     //        $("#result").empty().append(content);
//    //    });
//    // });
// });

// // ($"#firstname").val() document.getitembyid('firtname').value let customer = {firstname : ($"#firstname").val()}
// // JSON.stringify(customer)
// //let jqXhr = $.ajax({
// //     url: "/api/Anonymous/CreateNewCustomer",
// //     type: "POST",
// //     data: customer,
// //     contentType: 'application/json'
// // }).done(() => {
// //     Swal.fire(
// //         'New Customer was created succefully!',
// //         'You can login to the system now!',
// //         'success'
// //     )
// // }).fail(() => {
// //     let text = (jqXhr.responseText.split("\"")[2]).split("_")[1];
// //     Swal.fire({
// //         icon: 'error',
// //         title: 'Oops...',
// //         text: `${text} is allready taken`
// //     })
// // })


//
// }
})

function validate() {
    if ($('#first_name').val() === "") {
        alert("no name!");
    }
}

function signUp(e) {
   console.log('!');
   validate();

   // create new customer object
   let customer = 
   {
       firstName: $('#first_name').val(), 
       lastName: $('#last_name').val(),
       address: $('#address').val(),
       PhoneNumber: $('#contact_no').val(),
       CreditNumber: $("#credit").val(),
       user:
       {
           userName:$("#user_name").val(),
           password:$("#user_password").val(),
           email:$("#email").val(),

       }
   }

   //fire ajax request
   e.preventDefault();

   console.log(customer);
   console.log(JSON.stringify(customer));
   let customerJson =JSON.stringify(customer); 

   let jqXhr = $.ajax({
       url: "https://localhost:44395/api/Anonymous/SignUp",
       type: "POST",
       data: customerJson,
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





//        contentType: "application/json; charset=utf-8",  
//        dataType: "json",  
//        success: function(response) {  
//            if (response != null) {  
//                alert("Name : " + response.Name + ", Designation : " + response.Designation + ", Location :" + response.Location);  
//            } else {  
//                alert("Something went wrong");  
//            }  
//        },  
//        failure: function(response) {  
//            alert(response.responseText);  
//        },  
//        error: function(response) {  
//            alert(response.responseText);  
//        }  
//    });  
//    //})//.done(() => {
//        alert('congratz')
    //    Swal.fire(
    //        'New Customer was created succefully!',
    //        'You can login to the system now!',
    //        'success'
   //)
  // }).fail(() => {alert('oh oh we got problems')
     //  let text = (jqXhr.responseText.split("\"")[2]).split("_")[1];
    //    Swal.fire({
    //        icon: 'error',
    //        title: 'Oops...',
    //        text: `${text} is allready taken`
    //   })
   
   
}
