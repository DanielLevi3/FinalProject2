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
      newFlight: {
        AirlineCompanyName:"",
        OriginCountryName:"",
        DestinationCountryName:"",
        DepartureTime:"",
        LandingTime:"",
        RemainingTickets:0,
      },
       updateFlight:
       {
        FlightID:null,
        AirlineCompanyName:null,
        OriginCountryName:null,
        DestinationCountryName:null,
        DepartureTime:null,
        LandingTime:null,
        RemainingTickets:null
      }
    }
  }


componentDidMount(){
  this.getAllFlights();
  this.initNewFlightDetails();
  
  // this.newArrayFunc();
  // this.initNewFlightDetails();
  // call initNewFlightDetails
}
// Func=()=>
// {
//     this.setState({
//       updateFlight: this.state.flights
//     })
//     console.log(this.state.updateFlight)

// }

// newArrayFunc=()=>
// {
//   for (let index = 0; index < this.state.flights.length; index++) {
//     const element = this.state.flights[index];
//     this.state.updateFlight.push(element);
//   }
//   console.log(this.state.updateFlight);
// }

initNewFlightDetails = async ()=>
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
      this.setState(prevState => ({
        newFlight: {
          ...prevState.newFlight,           // copy all other key-value pairs of food object    // copy all pizza key-value pairs
            AirlineCompanyName: res.data.CompanyName          // update value of specific key
        }
      }))
    }
    console.log(this.state.newFlight)

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
UpdateFlight= async (id)=>
{
// let flight =this.state.flights.find((f)=>{
// return f.ID=id
// })
// let flight={
//   id,
//   AirlineCompanyName,
//   OriginCountryName,
//   DestinationCountryName,
//   departureTime,
//   landingTime,
//   remainingTickets
// }

// console.log(flight);
// let fflight=this.state.flights.find((f)=>
// {
//  return f.ID=id
// })
// this.setState({
//   updateFlight: fflight
// })
console.log(this.state.updateFlight)
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Airline/UpdateFlight',this.state.updateFlight,
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
               }
     }   
  )
  console.log(this.state)

}
  
// else
// {
//   Swal.fire({
//     icon: 'error',
//     title: 'You can\'t cancel ticket purchase',
//     text: `The flight has already taken off`
// })
// }
//}
addFlight = async(e) =>
{
  e.preventDefault();
  let new_flight= this.state.newFlight
  console.log(new_flight)
  let jwt = localStorage.getItem("token")
  await axios.post(
    'https://localhost:44395/api/Airline/CreateFlight',
    this.state.newFlight, {headers: {
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
        'Flight was added succefully!',
        'success')
    }
  }).catch((error)=>{
    console.log(error)
    Swal.fire({
      icon: 'error',
      title: '',
      text: `error`
  }) 
  })
}
// handleChangeDefaultValue = (e) => {
//   let flight = this.state.updateFlight
//   flight[e.target.name] = e.target.value
//   console.log(flight)
//   this.setState({ 
//     updateFlight: flight

//   });

// savedetails = () => {
//   this.setState({ isEditDisabled: true });

//   this.state.flights.forEach((f) => {
//     f.remaining_Tickets = parseInt(f.remaining_Tickets);
//   });

// }
valueChange =(flight,name,value)=>
{
  
  flight[name]=value;
  console.log(flight)
  this.setState({
    updateFlight:flight
  })
}
handleChange = (e,flight) => {
  let f = flight
  console.log(f);
  f[e.target.name] = e.target.value
  this.setState({ 
    updateFlight: f
  });
}

handleChangeNewFlight = (e) => {
  let flight = this.state.newFlight
  flight[e.target.name] = e.target.value
  this.setState({ 
      newFlight: flight
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
                  <td><input type='text' name='OriginCountryName' onChange defaultValue={flight.OriginCountryName} onChange={(e) =>
                  this.valueChange(
                    flight,
                    "OriginCountryName",
                    e.target.value
                  )} /></td>
                  <td><input type='text' name='DestinationCountryName' defaultValue={flight.DestinationCountryName} onChange={(e) =>
                    this.valueChange(
                      flight,
                      "DestinationCountryName",
                      e.target.value
                    )} /></td>
                  <td><input type='datetime-local' name='DepartureTime' defaultValue={flight.DepartureTime} onChange={(e) =>
                    this.valueChange(
                      flight,
                      "DepartureTime",
                      e.target.value
                    )} /></td>
                  <td><input type='datetime-local' name='LandingTime' defaultValue={flight.LandingTime} onChange={(e) =>
                    this.valueChange(
                      flight,
                      "LandingTime",
                      e.target.value
                    )} /></td>
                  <td><input type='number' name='RemainingTickets' defaultValue={flight.RemainingTickets} onChange={(e) =>
                    this.valueChange(
                      flight,
                      "RemainingTickets",
                      e.target.value
                    )} /></td>
                  <td>
                      <button
                        onClick={this.deleteFlight.bind(
                          this,
                          flight.ID
                        )} 
                      >
                        Cancel Flight
                      </button>
                      <button onClick={this.UpdateFlight.bind(
                        this,flight.ID
                      )}
          
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
         <span> OriginCountry :</span> <input type="text" name="OriginCountryName" required placeholder="Enter CountryName" onChange={this.handleChangeNewFlight} />
         <span>DestinationCountry: </span> <input type="text" name="DestinationCountryName" required placeholder="Enter CountryName" onChange={this.handleChangeNewFlight} />
         <span> DepartureTime:</span> <input type='datetime-local' name="DepartureTime" required placeholder="Enter DepartureTime" onChange={this.handleChangeNewFlight} />
         <span>LandingTime :</span>  <input type='datetime-local' name="LandingTime" required placeholder="Enter LandingTime"  onChange={this.handleChangeNewFlight} />
         <span>RemainingTickets: </span><input type="number" name="RemainingTickets" required placeholder="Enter RemainingTickets" onChange={this.handleChangeNewFlight} />
         <span> </span> <button type="submit" onClick={this.addFlight}>Add</button>
        </form>
      </div>
    );
    }
    return null;
    }
  }
  
export default Airline;
