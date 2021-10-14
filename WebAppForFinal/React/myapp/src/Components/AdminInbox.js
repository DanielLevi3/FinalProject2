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
       addAirline:
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
await axios.get('https://localhost:44395/api/Administrator/GetAllWaitingAirlines',
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
    'https://localhost:44395/api/Administrator/DeleteWaitingAirline',
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
addAirline= async (id)=>
{
  console.log(id);
  let airline = this.state.airlines.find(air =>
   air.Id===id
  )
  console.log(airline)
  let jwt = localStorage.getItem("token")
  await axios.post(
    'https://localhost:44395/api/Administrator/AddNewAirline',airline,
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
    addAirline:airline
  })
}
handleUserChange = (airline,user,name,value) => {
  airline[name]=value;
  user[name]=value;
  console.log(airline)
  this.setState({
    addAirline:airline
  })
  this.setState(prevState => ({
    addAirline: {
      ...prevState.addAirline,           // copy all other key-value pairs of food object    // copy all pizza key-value pairs
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
                  <td>{airline.CompanyName}</td>
                  <td>{airline.CountryName}</td>
                  <td>{airline.User.UserName}</td>
                  <td>{airline.UserId}</td>
                  <td>{airline.User.Email}</td>
                  <td>{airline.User.Password}</td>
                  <td>
                  <button
                  onClick={this.deleteAirline.bind(
                    this,
                    airline.Id
                  )} 
                >
                  Decline Airline
                </button>
                <button onClick={this.addAirline.bind(
                  this,airline.Id
                )}
    
                  >
                    Accept Airline
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




