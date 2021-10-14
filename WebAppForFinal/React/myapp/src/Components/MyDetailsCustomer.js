import React, { Component }  from 'react';
import axios from 'axios';
import UserService from './UserService';
import Swal from "sweetalert2";  


class MyDetailsCustomer extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      Id:undefined,
      FirstName: undefined,
      LastName: undefined,
      Address: undefined,
      PhoneNumber: undefined,
      CreditNumber: undefined,
      UserId: undefined,
      UserName: undefined,
      Password: undefined,
      Email: undefined,
      UserRole:3
    }
}
 
componentDidMount() {
  this.GetCustomerDetails()
}

handleChange = (e) => {
  this.setState({ 
      [e.target.name]: e.target.value 
  });
}

UpdateCustomer = async ()=>
{
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Customer/UpdateCustomerDetails',this.state,
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
            }   
        }
  )
  
}

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
    if (res.status == 200) 
    {
        this.setState({
          Id:res.data.id,
          FirstName: res.data.firstName,
          LastName: res.data.lastName,
          Address: res.data.address,
          PhoneNumber: res.data.phoneNumber,
          CreditNumber: res.data.creditNumber,
          UserId: res.data.user.id,
          UserName:res.data.user.userName,
          Password:res.data.user.password,
          Email:res.data.user.email,
          UserRole:3
        })
        console.log(res.data)
    }

return Promise.resolve(res);
})
.catch(function (error) {
  Swal.fire({
    icon: 'error',
    title: 'Oops...',
    text: `${error}`
})
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
    <span > First Name: </span> <input type='text' name='firstname' defaultValue={this.state.FirstName} onChange={this.handleChange}/> <br /> <br />
    <span > Last Name: </span> <input type='text' name='lastname' defaultValue={this.state.LastName} onChange={this.handleChange} /> <br /> <br />
    <span > Address: </span> <input type='text' name='address' defaultValue={this.state.Address} onChange={this.handleChange}/> <br /> <br />
    <span > Phone Number: </span> <input type='text' name='phonenumber' defaultValue={this.state.PhoneNumber} onChange={this.handleChange}/> <br /> <br />
    <span > Credit Number: </span> <input type='text' name='creditnumber' defaultValue={this.state.CreditNumber} onChange={this.handleChange}/> <br /> <br />
    <span >UserName: </span> <input type='text' name='username' defaultValue={this.state.UserName} onChange={this.handleChange}/> <br /> <br />
    <span >Email: </span> <input type='text' name='email' defaultValue={this.state.Email} onChange={this.handleChange}/> <br /> <br />
    <span >Password: </span> <input type='text' name='password' defaultValue={this.state.Password} onChange={this.handleChange}/> <br /> <br />
    <button type="Button" onClick={this.UpdateCustomer} >Update
    </button>
    </div>
   ) }
}

export default MyDetailsCustomer;
