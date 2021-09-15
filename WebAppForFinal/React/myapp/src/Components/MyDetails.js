import React, { Component }  from 'react';
import $ from 'jquery';
import axios from 'axios';
import UserService from './UserService';

class MyDetails extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      FirstName: "",
      LastName: "",
      Address: "",
      PhoneNumber: "",
      CreditNumber: "",
      UserId: "",
      User:
      {
        UserName:"",
        Password:"",
        Email:"",
        UserRole:3
      }
    }
this.Auth = new UserService();
}
 
componentDidMount() {
  this.GetCustomerDetails()
}

//  customer = 
// {
//     firstName: thit.state., 
//     lastName: $('#last_name').val(),
//     address: $('#address').val(),
//     PhoneNumber: $('#contact_no').val(),
//     CreditNumber: $("#credit").val(),
//     user:
//     {
//         userName:$("#user_name").val(),
//         password:$("#user_password").val(),
//         email:$("#email").val(),

//     }
// }

GetCustomerDetails = async ()=>
{
  let jwt = localStorage.getItem("token")
  await axios.get(
    'https://localhost:44395/api/Customer/GetCustomerDetails',
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
            }   
        }
  )
  .then( res => 
    {
    if (res.status == 200) {

        // this.setState.FirstName(res.data.FirstName)
        // this.setState.LastName(res.data.LastName)
        // this.setState.Address(res.data.Address)
        // this.setState.PhoneNumber(res.data.PhoneNumber)
        // this.setState.CreditNumber(res.data.CreditNumber)
        // this.setState.UserId(res.data.UserId)
        // this.setState.User(res.data.User)
        this.setState({
          FirstName: res.data.firstName
        })
        console.log(res.data.firstName)
    }

return Promise.resolve(res);
})
.catch(function (error) {
    alert('Error')
    console.log(error);
});
// }
//     console.log(response)
//     this.setState.FirstName(response.data.FirstName)
//     this.setState.LastName(response.data.LastName)
//     this.setState.Address(response.data.Address)
//     this.setState.PhoneNumber(response.data.PhoneNumber)
//     this.setState.CreditNumber(response.data.CreditNumber)
//     this.setState.UserId(response.data.UserId)
//     this.setState.User(response.data.User)

//     },
//     (error) => {
//   return error.response.status
//     }
//   );
// }
  
}

render() {
  return (
    <div > 
    <h1>Personal Details</h1> <br />
    <span > First Name: </span> <input type='text' defaultValue={this.state.FirstName}/> <br /> <br />
    <span > Last Name: </span> <input type='text' defaultValue={this.state.LastName} /> <br /> <br />
    <span > Address: </span> <input type='text' defaultValue={this.state.Address}/> <br /> <br />
    <span > Phone Number: </span> <input type='text' defaultValue={this.state.PhoneNumber}/> <br /> <br />
    <span > Credit Number: </span> <input type='text' defaultValue={this.state.CreditNumber}/> <br /> <br />
    <span > UserId: </span> <input type='text' defaultValue={this.state.UserId}/> <br /> <br />
    <span >User: </span> <input type='text' defaultValue={this.state.User}/> <br /> <br />
    </div>
   ) }
}

export default MyDetails;
