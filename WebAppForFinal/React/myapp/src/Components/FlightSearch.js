import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  

class FlightSearch extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      FlightsGetAll:[],
      Flights :[],
      Change:{
        DestinationCountryName:"",
      OriginCountryName:"",
      LandingTime:"",
      DepartureTime:"",
      }
    };
}
 
componentDidMount() {
  this.getAllFlights();
}

getAllFlights = async ()=>{
 
  await axios.get('https://localhost:44395/api/Anonymous/getallflights').then( res => 
              {
              if (res.status == 200) 
              {
                console.log(res.data)
                this.setState({
                  FlightsGetAll: res.data
                })
                console.log(this.state)
              }
              return Promise.resolve(res);
            }).catch((error)=>{
              console.log(error)
            })
  }

getAllFlightsByParams = async (e)=>{
  e.preventDefault();
  console.log(this.state.Change)
 
  const C_hange =this.state.Change
  console.log(this.state.Change)
await axios.post('https://localhost:44395/api/Anonymous/getflightbyparameters',this.state.Change).then( res => 
            {
            if (res.status == 200) 
            {
              console.log(res.data)
              this.setState({
                Flights: res.data
              })
              console.log(this.state)
            }
            return Promise.resolve(res);
          }).catch((error)=>{
            console.log(error)
          })
}

handleDestCountryChange = (change,name,value) => {
  change[name]=value;
  console.log(change)
  this.setState({ 
    Change:change
  });
}
// handleOriginCountryChange = (change,name,value) => {
//   this.setState({ 
//     originCountry:origin
//   });
// }
// handleLandingDateChange =(change,name,value) => {
//   let landing = this.state.Change.landingDate
//   landing[name] = value
//   this.setState({ 
//     landingDate:landing
//   });
// }
// handleDepartureDateChange = (change,name,value) => {
//   change[name] =value
//   this.setState({ 
//     Change:change
//   });
// }

render() {
  if(this.state.Flights.length !=0)
  {
      return (
      <div>

    
      <span > Destination Country: </span> <input type='text' name='DestinationCountryName' required onChange={(e) =>
        this.handleDestCountryChange(
          this.state.Change,
          "DestinationCountryName",
          e.target.value
        )}/>
      <span > Origin Country: </span> <input type='text' name='OriginCountryName' required onChange={(e) =>
        this.handleDestCountryChange(
          this.state.Change,
          "OriginCountryName",
          e.target.value
        )}/>
      <span > Landing Date: </span> <input type='datetime-local' name='LandingTime' required onChange={(e) =>
        this.handleDestCountryChange(
          this.state.Change,
          "LandingTime",
          e.target.value
        )}/>
      <span > Departure Date: </span> <input type='datetime-local' name='DepartureTime' required onChange={(e) =>
        this.handleDestCountryChange(
          this.state.Change,
          "DepartureTime",
          e.target.value
        )}/>
      <button  onClick={this.getAllFlightsByParams}>Search</button>

      <h3>Flights</h3>
        <table>
          <thead>
            <tr>
              <th>Airline Company</th>
              <th>Origin Country</th>
              <th>Destination Country</th>
              <th>Departure Time</th>
              <th>Landing Time</th>
              <th>Remaining Tickets</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.Flights.map( (flight) => {
              return (
                <tr>
                  <td>{flight.AirlineCompanyName}</td>
                  <td>{flight.OriginCountryName}</td>
                  <td>{flight.DestinationCountryName}</td>
                  <td>{flight.DepartureTime}</td>
                  <td>{flight.LandingTime}</td>
                  <td>{flight.RemainingTickets}</td>
                  <td>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    );
          }
          return(
            <div>
          
            <span > Destination Country: </span> <input type='text' name='DestinationCountryName' required onChange={(e) =>
              this.handleDestCountryChange(
                this.state.Change,
                "DestinationCountryName",
                e.target.value
              )}/>
            <span > Origin Country: </span> <input type='text' name='OriginCountryName' required onChange={(e) =>
              this.handleDestCountryChange(
                this.state.Change,
                "OriginCountryName",
                e.target.value
              )}/>
            <span > Landing Date: </span> <input type='datetime-local' name='LandingTime' required onChange={(e) =>
              this.handleDestCountryChange(
                this.state.Change,
                "LandingTime",
                e.target.value
              )}/>
            <span > Departure Date: </span> <input type='datetime-local' name='DepartureTime' required onChange={(e) =>
              this.handleDestCountryChange(
                this.state.Change,
                "DepartureTime",
                e.target.value
              )}/>
            <button  onClick={this.getAllFlightsByParams}>Search</button>

            <h3>Flights</h3>
        <table>
          <thead>
            <tr>
              <th>Airline Company</th>
              <th>Origin Country</th>
              <th>Destination Country</th>
              <th>Departure Time</th>
              <th>Landing Time</th>
              <th>Remaining Tickets</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.FlightsGetAll.map( (flight) => {
              return (
                <tr>
                  <td>{flight.AirlineCompanyName}</td>
                  <td>{flight.OriginCountryName}</td>
                  <td>{flight.DestinationCountryName}</td>
                  <td>{flight.DepartureTime}</td>
                  <td>{flight.LandingTime}</td>
                  <td>{flight.RemainingTickets}</td>
                  <td>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
            </div>
          )
    }
  }
  

  
export default FlightSearch;
