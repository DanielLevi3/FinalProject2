import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  

class AdminAirlines extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      airlines :[],
       updateAirline:
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
  }


componentDidMount(){
  this.getAllAirlines();
}

getAllAirlines = async ()=>{
let jwt = localStorage.getItem("token")
await axios.get('https://localhost:44395/api/Administrator/GetAllAirlines',
{headers: {
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
            }   
        }).then( res => 
            {
            if (res.status == 200) 
            {
              console.log(res.data)
              this.setState({
                airlines: res.data
              })
              console.log(this.state)
            }
            return Promise.resolve(res);
          }).catch((error)=>{
            console.log(error)
          })
}

deleteAirline =async (id)=>
{
  let jwt = localStorage.getItem("token")
  await axios.delete(
    'https://localhost:44395/api/Administrator/DeleteAirline',
    {data:{id}, headers: {
          // "Access-Control-Allow-Origin" : "*",
          "Content-type": "Application/json",
          "Authorization": `Bearer ${jwt}`
          }   
      })
    .then( res => 
    {
    if (res.status == 200) 
    {
      let newArr = this.state.airlines.filter((air)=>{
        return air.id !=id;
      });
      this.setState({
        airlines:newArr,
      });
      console.log(res.data)
      Swal.fire(
        'airline was deleted succefully!',
        'success')
    }
  }).catch((error)=>{
    console.log(error)
    Swal.fire({
      icon: 'error',
      title: 'You can\'t delete this airline',
      text: `something went wrong`
  }) 
  })
}
updateAirline= async ()=>
{
console.log(this.state.updateAirline)
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Administrator/UpadateAirline',this.state.updateAirline,
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
               }
     }   
  )
  console.log(this.state)

}
  


valueChange =(airline,name,value)=>
{
  
  airline[name]=value;
  console.log(airline)
  this.setState({
    updateAirline:airline
  })
}
handleUserChange = (airline,user,name,value) => {
  airline[name]=value;
  user[name]=value;
  console.log(airline)
  this.setState({
    updateAirline:airline
  })
  this.setState(prevState => ({
    updateAirline: {
      ...prevState.updateAirline,           // copy all other key-value pairs of food object    // copy all pizza key-value pairs
        User: user
  }}))
}

render() 
{
    if(this.state.airlines.length !=0)
      {
      return (
      <div>
        <h3>AirlinesCompany</h3>
        <table>
          <thead>
            <tr>
              <th>Id</th>
              <th>CompanyName</th>
              <th>CountryName</th>
              <th>Username</th>
              <th>UserId</th>
              <th>Email</th>
              <th>Password</th>
            </tr>
          </thead>
          <tbody>
            {this.state.airlines.map( (airline) => {
             
              return (
                <tr>
                <td>{airline.Id}</td>
                  <td><input type='text' name='CompanyName' defaultValue={airline.CompanyName} onChange={(e) =>
                    this.valueChange(
                      airline,
                      "CompanyName",
                      e.target.value
                    )} /></td>
                  <td><input type='text' name='CountryName' defaultValue={airline.CountryName} onChange={(e) =>
                  this.valueChange(
                    airline,
                    "CountryName",
                    e.target.value
                  )} /></td>
                  <td><input type='text' name='Username' defaultValue={airline.User.UserName} onChange={(e) =>
                    this.handleUserChange(
                      airline,
                      airline.User,
                      "Username",
                      e.target.value
                    )} /></td>
                  <td><input type='number' name='UserId' defaultValue={airline.UserId} onChange={(e) =>
                    this.valueChange(
                      airline,
                      "UserId",
                      e.target.value
                    )} /></td>
                  <td><input type='text' name='Email' defaultValue={airline.User.Email} onChange={(e) =>
                    this.handleUserChange(
                      airline,
                      airline.User,
                      "Email",
                      e.target.value
                    )} /></td>
                  <td><input type='text' name='Password' defaultValue={airline.User.Password} onChange={(e) =>
                    this.handleUserChange(
                      airline,
                      airline.User,
                      "Password",
                      e.target.value
                    )} /></td>
                  <td>
                  <button
                  onClick={this.deleteAirline.bind(
                    this,
                    airline.Id
                  )} 
                >
                  Delete Airline
                </button>
                <button onClick={this.updateAirline.bind(
                  this
                )}
    
                  >
                    Update Airline
                  </button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    );
    }
    return null;
    }
  }
  
export default AdminAirlines;
