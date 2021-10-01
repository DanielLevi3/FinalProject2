import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  


class Tickets extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      tickets :[],
    };
}
 
componentDidMount() {
  this.getAlltickets();
}

getAlltickets = async ()=>{
let jwt = localStorage.getItem("token")
await axios.get('https://localhost:44395/api/Customer/GetAllFlight',
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
                tickets: res.data
              })
              console.log(this.state)
            }
            return Promise.resolve(res);
          }).catch((error)=>{
            console.log(error)
          })
}

deleteTicket =async (id)=>
{
  // let currentDate = new Date();
  //       let detpartureDate = new Date(this.state.flight.Departure_Time)
  //       // if (detpartureDate.getTime() > currentDate.getTime()) {
  // let ticketSending = JSON.stringify({
  //   ID:this.state.tickets.TicketId,
  //   FlightID: this.state.tickets.Id
  // })

  //console.log(ticket);
  let jwt = localStorage.getItem("token")
  await axios.delete(
    'https://localhost:44395/api/Customer/CancelTicket',
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
      let newArr = this.state.tickets.filter((ticket)=>{
        return ticket.id !=id;
      });
      this.setState({
        tickets:newArr,
      });
      console.log(res.data)
      Swal.fire(
        'Ticket purchase was canceled succefully!',
        'You can purchase tickets to another tickets',
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
    if(this.state.tickets.length !=0)
      {
      return (
      <div>
        <h3>My tickets</h3>
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
            {this.state.tickets.map( (ticket) => {
              return (
                <tr>
                  <td>{ticket.AirlineCompanyName}</td>
                  <td>{ticket.OriginCountryName}</td>
                  <td>{ticket.DestinationCountryName}</td>
                  <td>{ticket.DepartureTime}</td>
                  <td>{ticket.LandingTime}</td>
                  <td>{ticket.RemainingTickets}</td>
                  <td>
                      <button
                        onClick={this.deleteTicket.bind(
                          this,
                          ticket.TicketId
                        )} 
                      >
                        Cancel Ticket
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
  

export default Tickets;


// return (
//   <div > 
//   <h1>Personal Details</h1> <br />
//   <div style={{ border: '1px solid black' }} >
//       <span style={{ fontWeight: 'bold' }}> Company: </span>  {flight.AirlineCompanyName} {' '}
//       <span style={{ fontWeight: 'bold' }}> Departure date: </span> {flight.Departure_Time.split('T')[0]} {' '}
//       <span style={{ fontWeight: 'bold' }}> Origion Country: </span>  {flight.OrigionCountry} {' '}
//       <span style={{ fontWeight: 'bold' }}> Departure Time: </span>  {flight.Departure_Time.split('T')[1]} {' '} <br /> <br />
//       <span style={{ fontWeight: 'bold' }}> Destination Country: </span>  {flight.DestinationCountry} {' '}
//       <span style={{ fontWeight: 'bold' }}> Landing date: </span>  {flight.Landing_Time.split('T')[0]} {' '}
//       <span style={{ fontWeight: 'bold' }}> Landing Time: </span>  {flight.Landing_Time.split('T')[1]} {' '} <br /> <br />
//       <input type="button" style={{ backgroundColor: 'salmon' }} value="Cancel Ticket" onClick={deleteTicket} />
//   </div>)
//   </div>
// )}
//   }
// }
//if(this.state.tickets.length !=0)
//   {
//   return (
//   <div>
//     <h3>My tickets</h3>
//     <table>
//       <thead>
//         <tr>
//           <th>Id</th>
//           <th>Airline Company</th>
//           <th>Origin Country</th>
//           <th>Destination Country</th>
//           <th>Departure Time</th>
//           <th>Landing Time</th>
//           <th>Remaining Tickets</th>
//           <th>Ticket ID</th>
//           <th></th>
//         </tr>
//       </thead>
//       <tbody>
//         {map(this.state.tickets, (ticket) => {
//           return (
//             <tr>
//               <td>{ticket.flight.id}</td>
//               <td>{ticket.flight.airline_Company_Id}</td>
//               <td>{ticket.flight.origin_Country_Id}</td>
//               <td>{ticket.flight.destination_Country_Id}</td>
//               <td>{ticket.flight.departure_Time}</td>
//               <td>{ticket.flight.landing_Time}</td>
//               <td>{ticket.flight.remaining_Tickets}</td>
//               <td>{ticket.flight.ticket_Id}</td>
//               <td>
//                 {ticket.isCancellable && (
//                   <button
//                     onClick={this.deleteTicket.bind(
//                       this,
//                       ticket.flight.ticket_Id
//                     )}
//                   >
//                     Cancel Ticket
//                   </button>
//                 )}
//               </td>
//             </tr>
//           );
//         })}
//       </tbody>
//     </table>
//   </div>
// );
// }
// return null;
// }
// }