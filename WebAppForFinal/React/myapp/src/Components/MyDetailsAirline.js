import React, { Component }  from 'react';
import $ from 'jquery';
import axios from 'axios';
import UserService from './UserService';
import Swal from "sweetalert2";  


class MyDetailsAirline extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      Id:undefined,
      CompanyName: undefined,
      CountryName: undefined,
      UserId: undefined,
      UserName: undefined,
      Password: undefined,
      Email: undefined,
      UserRole:2
    }
this.Auth = new UserService();
}
 
componentDidMount() {
  this.GetAirlineDetails()
}

handleChange = (e) => {
  this.setState({ 
      [e.target.name]: e.target.value 
  });
}

UpdateAirline= async ()=>
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

GetAirlineDetails = async ()=>
{
  let jwt = localStorage.getItem("token")
  await axios.get(
    'https://localhost:44395/api/Airline/GetAirlineDetails',
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
      console.log(res.data)
        this.setState({
          Id:res.data.Id,
          CompanyName: res.data.CompanyName,
          CountryName: res.data.CountryName,
          UserId: res.data.UserId,
          UserName:res.data.User.UserName,
          Password:res.data.User.Password,
          Email:res.data.User.Email,
          UserRole:2
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
    <span > Company Name: </span> <input type='text' name='CompanyName' defaultValue={this.state.CompanyName} onChange={this.handleChange}/> <br /> <br />
    <span > Country Name: </span> <input type='text' name='CountryName' defaultValue={this.state.CountryName} onChange={this.handleChange} /> <br /> <br />
    <span >UserName: </span> <input type='text' name='UserName' defaultValue={this.state.UserName} onChange={this.handleChange}/> <br /> <br />
    <span >Email: </span> <input type='text' name='email' defaultValue={this.state.Email} onChange={this.handleChange}/> <br /> <br />
    <span >Password: </span> <input type='text' name='password' defaultValue={this.state.Password} onChange={this.handleChange}/> <br /> <br />
    <button type="Button" onClick={this.UpdateCustomer} >Update
    </button>
    </div>
   ) }
}

export default MyDetailsAirline;
