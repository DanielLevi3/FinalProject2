import React from 'react';
import { Link, NavLink, withRouter } from 'react-router-dom';

const Navbar = (props) => {
  console.log(props.history)
  /*
  setTimeout( () => { 
    props.history.push('/') }, 2000); 
    */
  return (
    <nav className="nav-wrapper red darken-3">
    <a className="brand-logo center">Flights</a>
      <div className="container">
        <ul className="right">
          <li><NavLink to="/">Home</NavLink></li>
          <li><NavLink to="/login">Login</NavLink></li>
          <li><NavLink to="/dashboard">Dashboard</NavLink></li>
        </ul>
      </div>
    </nav> 
  )
}
export default withRouter(Navbar)