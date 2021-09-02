import React from 'react';
import { NavLink, withRouter } from 'react-router-dom';


const Navbar = (props) => {

  const logout =() =>
  {
    localStorage.clear();
    console.log(localStorage);
  }
  //console.log(props.history)
  /*
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
          <li><NavLink to="/" onClick={logout}>LogOut</NavLink></li>
        </ul>
      </div>
    </nav> 
  )
}
export default withRouter(Navbar)