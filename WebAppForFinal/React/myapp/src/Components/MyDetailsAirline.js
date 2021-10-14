import React, { Component }  from 'react';
import axios from 'axios';
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
      User:{
      ID:undefined,
      UserName: undefined,
      Password: undefined,
      Email: undefined,
      UserRole:2
      }
    }
}
 
componentDidMount() {
  this.GetAirlineDetails()
}
// this.setState(prevState => ({
//   newFlight: {
//     ...prevState.newFlight,           // copy all other key-value pairs of food object    // copy all pizza key-value pairs
//       AirlineCompanyName: res.data.CompanyName          // update value of specific key
//   }
// }))
handleChange = (e) => {
  this.setState({ 
      [e.target.name]: e.target.value 
  });
}
handleUserChange = (e) => {
  let user = this.state.User
  user[e.target.name] = e.target.value
  this.setState({ 
    User:user
  });
}

UpdateAirline= async ()=>
{
  console.log(this.state)
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Airline/UpdateAirlineDetails',this.state,
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
          User:{
          ID:res.data.UserId,
          UserName:res.data.User.UserName,
          Password:res.data.User.Password,
          Email:res.data.User.Email,
          UserRole:2
          }
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
    <span >UserName: </span> <input type='text' name='UserName' defaultValue={this.state.User.UserName} onChange={this.handleUserChange}/> <br /> <br />
    <span >Email: </span> <input type='text' name='Email' defaultValue={this.state.User.Email} onChange={this.handleUserChange}/> <br /> <br />
    <span >Password: </span> <input type='text' name='Password' defaultValue={this.state.User.Password} onChange={this.handleUserChange}/> <br /> <br />
    <button type="Button" onClick={this.UpdateAirline} >Update
    </button>
    </div>
   ) }
}

export default MyDetailsAirline;
