import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  

class Airline extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      flights :[],
      }
  }


componentDidMount(){
  this.getAllFlights();
}

getAllFlights = async ()=>{
let jwt = localStorage.getItem("token")
await axios.get('https://localhost:44395/api/Airline/GetAllFlightsByAirline',
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
                flights: res.data
              })
              console.log(this.state)
            }
            return Promise.resolve(res);
          }).catch((error)=>{
            console.log(error)
          })
}

deleteFlight =async (id)=>
{
  let jwt = localStorage.getItem("token")
  await axios.delete(
    'https://localhost:44395/api/Airline/CancelFlight',
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
      let newArr = this.state.flights.filter((flight)=>{
        return flight.id !=id;
      });
      this.setState({
        flights:newArr,
      });
      console.log(res.data)
      Swal.fire(
        'Flight was canceled succefully!',
        'success')
    }
  }).catch((error)=>{
    console.log(error)
    Swal.fire({
      icon: 'error',
      title: 'You can\'t cancel ticket purchase',
      text: `You are not allowed to cancel purchase`
  }) 
  })
}
UpdateAirline= async ()=>
{
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Airline/UpdateFlight',this.state,
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
            }   
        }
  )}
  
// else
// {
//   Swal.fire({
//     icon: 'error',
//     title: 'You can\'t cancel ticket purchase',
//     text: `The flight has already taken off`
// })
// }
//}
addFlight = async(newFlight) =>
{
  
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Airline/CancelFlight',
    {data:{}, headers: {
          // "Access-Control-Allow-Origin" : "*",
          "Content-type": "Application/json",
          "Authorization": `Bearer ${jwt}`
          }   
      })
    .then( res => 
    {
    if (res.status == 200) 
    {
      // let newArr = this.state.flights.filter((flight)=>{
      //   return flight.id !=id;
      // });
      // this.setState({
      //   flights:newArr,
      // });
      console.log(res.data)
      Swal.fire(
        'Flight was canceled succefully!',
        'success')
    }
  }).catch((error)=>{
    console.log(error)
    Swal.fire({
      icon: 'error',
      title: 'You can\'t cancel ticket purchase',
      text: `You are not allowed to cancel purchase`
  }) 
  })
}


handleChange = (e) => {
  this.setState({ 
      [e.target.name]: e.target.value 
  });
}
// <h2>Add flight</h2>

// <form>
// <input type="text" name="originCountry" required placeholder="Enter CountryName" >OriginCountry
// </input>
// <input type="text" name="destinationCountry" required placeholder="Enter CountryName" >DestinationCountry
// </input>
// <input type="date" name="departureTime" required placeholder="Enter DepartureTime" >DepartureTime
// </input>
// <input type="date" name="landingTime" required placeholder="Enter LandingTime" >LandingTime
// </input>
// <input type="number" name="remainingTickets" required placeholder="Enter RemainingTickets" >RemainingTickets
// </input>
// <button type="submit">Add</button>
// </form>

render() 
{
    if(this.state.flights.length !=0)
      {
      return (
      <div>
        <h3>My flights</h3>
        <table>
          <thead>
            <tr>
              <th>Airline Company</th>
              <th>Origin Country</th>
              <th>Destination Country</th>
              <th>Departure Time</th>
              <th>Landing Time</th>
              <th>Remaining Tickets</th>
              <th>Ticket ID</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.flights.map( (flight) => {
              return (
                <tr>
                  <td>{flight.AirlineCompanyName}</td>
                  <td><input type='text' name='OriginCountryName' defaultValue={flight.OriginCountryName} onChange={this.handleChange} /></td>
                  <td><input type='text' name='DestinationCountryName' defaultValue={flight.DestinationCountryName} onChange={this.handleChange} /></td>
                  <td><input type='date' name='DepartureTime' defaultValue={flight.DepartureTime} onChange={this.handleChange} /></td>
                  <td><input type='date' name='LandingTime' defaultValue={flight.LandingTime} onChange={this.handleChange} /></td>
                  <td><input type='number' name='RemainingTickets' defaultValue={flight.RemainingTickets} onChange={this.handleChange} /></td>
                  <td>
                      <button
                        onClick={this.deleteFlight.bind(
                          this,
                          flight.ID
                        )} 
                      >
                        Cancel Flight
                      </button>
                      <button
                      >
                        Update Flight
                      </button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <h4>Add flight</h4>

        <form>
         <span> OriginCountry :</span> <input type="text" name="originCountry" required placeholder="Enter CountryName" onChange={this.handleChange} />
         <span>DestinationCountry: </span> <input type="text" name="destinationCountry" required placeholder="Enter CountryName" onChange={this.handleChange} />
         <span> DepartureTime:</span> <input type="date" name="departureTime" required placeholder="Enter DepartureTime" onChange={this.handleChange} />
         <span>LandingTime :</span>  <input type="date" name="landingTime" required placeholder="Enter LandingTime"  onChange={this.handleChange} />
         <span>RemainingTickets: </span><input type="number" name="remainingTickets" required placeholder="Enter RemainingTickets" onChange={this.handleChange} />
         <span> </span> <button type="submit">Add</button>
        </form>
      </div>
    );
    }
    return null;
    }
  }
  
export default Airline;
