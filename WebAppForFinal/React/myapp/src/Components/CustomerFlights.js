import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  
import { get } from 'jquery';
import Tickets from './Tickets';

class CustomerFlights extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      flight :
      {
        id:undefined,
        AirlineCompanyName:undefined,
        Departure_Time:undefined,
        OrigionCountry:undefined,
        DestinationCountry:undefined,
        Landing_Time:undefined,
        Ticket_Id:undefined
      }
    };
    this.tickets= new this.Tickets();
}
 
componentDidMount() {
 // this.deleteTicket();
}

// deleteTicket =async (id)=>
// {
//   let currentDate = new Date();
//         let detpartureDate = new Date(this.state.flight.Departure_Time)
//         // if (detpartureDate.getTime() > currentDate.getTime()) {
//   let ticket = JSON.stringify({
//     Id:this.state.flight.Ticket_Id,
//     Flight_Id: this.state.flight.Id,
//     AirlineCompanyName: this.state.flight.AirlineCompanyName,
//     OrigionCountry: this.state.flight.OrigionCountry,
//     DestinationCountry: this.state.flight.DestinationCountry,
//     Departure_Time: this.state.flight.Departure_Time,
//     Landing_Time: this.state.flight.Landing_Time})

//   let jwt = localStorage.getItem("token")
//   await axios.delete(
//     'https://localhost:44395/api/Customer/CancelTicket',
//     {data:ticket},
//     {headers: {
//           // "Access-Control-Allow-Origin" : "*",
//           "Content-type": "Application/json",
//           "Authorization": `Bearer ${jwt}`
//           }   
//       } 
//   ).then( res => 
//     {
//     if (res.status == 200) 
//     {
//       console.log(res.data)
//       Swal.fire(
//         'Ticket purchase was canceled succefully!',
//         'You can purchase tickets to another flights',
//         'success')
//     }
//     return Promise.resolve(res);
//   }).catch((error)=>{
//     console.log(error)
//     Swal.fire({
//       icon: 'error',
//       title: 'You can\'t cancel ticket purchase',
//       text: `You are not allowed to cancel purchase`
//   }) 
//   })
// }
// else
// {
//   Swal.fire({
//     icon: 'error',
//     title: 'You can\'t cancel ticket purchase',
//     text: `The flight has already taken off`
// })
// }
//}


render() {
  return (
    <div > 
    <h1>Personal Details</h1> <br />
    <div >
        <span > Company: </span>  {this.state.flight.AirlineCompanyName} {' '}
        <span > Departure date: </span> {this.state.flight.Departure_Time.split('T')[0]} {' '}
        <span > Origion Country: </span>  {this.state.flight.OrigionCountry} {' '}
        <span > Departure Time: </span>  {this.state.flight.Departure_Time.split('T')[1]} {' '} <br /> <br />
        <span > Destination Country: </span>  {this.state.flight.DestinationCountry} {' '}
        <span > Landing date: </span>  {this.state.flight.Landing_Time.split('T')[0]} {' '}
        <span > Landing Time: </span>  {this.state.flight.Landing_Time.split('T')[1]} {' '} <br /> <br />
        <button ><input type="button"  value="Cancel Ticket" onClick={this.deleteTicket()} /> Cancel Ticket</button>
    </div>)
    </div>
  )}
    }

export default CustomerFlights;
