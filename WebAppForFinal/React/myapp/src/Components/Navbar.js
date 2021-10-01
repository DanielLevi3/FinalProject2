import React from 'react';
import { NavLink, withRouter } from 'react-router-dom';
import MyDetails from './MyDetailsCustomer';
import UserService from './UserService';
import jwtDecode from 'jwt-decode';


const Navbar = (props) => {

  const logout =() =>
  {
    localStorage.clear();
    console.log(localStorage);
  }
  const MyDets =()=>
  {
    <div>
    {MyDetails}
    </div>
  }
  //console.log(props.history)
  /*
  {
             AuthService(localStorage.getItem('token')).role == '1' && how to nav between user components
          //   <div>
          //     <li><NavLink to="/" >My Details</NavLink></li>
          //     <li><NavLink to="/" >My Tickets</NavLink></li>
          //   </div>
          // }
  setTimeout( () => { 
    props.history.push('/') }, 2000); 
    */
  return (
    <nav className="nav-wrapper red darken-3">
      <div className="container">
        <ul className="right">
          <li><NavLink to="/">Home</NavLink></li>
          <li><NavLink to="/login">Login</NavLink></li>
          <li><NavLink to="/dashboard">Dashboard</NavLink></li>

          { localStorage.getItem('token') != null &&
            <li><NavLink to="/" onClick={logout}>Logout</NavLink></li>
          }
          { localStorage.getItem('token') != null && jwtDecode(localStorage.getItem('token')).user_role == "3" &&
            <li><NavLink to="/customer/Mydetails"> My Details</NavLink></li>
          }
          { localStorage.getItem('token') != null && jwtDecode(localStorage.getItem('token')).user_role == "3" &&
          <li><NavLink to="/customer/Tickets"> Tickets </NavLink></li>
          }
          { localStorage.getItem('token') != null && jwtDecode(localStorage.getItem('token')).user_role == "2" &&
          <li><NavLink to="/Airline/Flights"> Flights </NavLink></li>
          }
          { localStorage.getItem('token') != null && jwtDecode(localStorage.getItem('token')).user_role == "2" &&
          <li><NavLink to="/Airline/Mydetails"> My Details </NavLink></li>
          }
        </ul>
      </div>
    </nav> 
  )
}
export default withRouter(Navbar)