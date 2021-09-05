import React, { Component } from 'react';
// import axios from 'axios';
// import $, { event } from 'jquery';
import UserService from './UserService';
import {withRouter} from 'react-router-dom'


class Login extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      Name: "",
      Password: ""
    }
this.Auth = new UserService();

}
  
  ComponentDidmount = () => {
    
  }

  handleChange = (e) => {
    this.setState({ 
        [e.target.name]: e.target.value 
    });
  }

  tryLogin = async (e) => {
    
    e.preventDefault();

    if (this.state.Name == "" || this.state.Password == "") {
      alert("Must fill all fields");
      return;
    }

     await this.Auth.tryLogin(this.state.Name,this.state.Password).then(res => {
      //  console.log(this.Auth.decoded.user_role)
      if(this.Auth.decoded.user_role == "1") {
        this.props.history.push('/admin'); // send user to admin page
      }
      else if(this.Auth.decoded.user_role == "2") {
        this.props.history.push('/airline'); // send user to airline page
      }
      else if(this.Auth.decoded.user_role == "3") {
        this.props.history.push('/customer'); // send user to customer page
      }
      else
      {
        alert('Try login again, something went wrong...')
      }
  });

      console.log();
  }

  render() {
    return (
      <div className="Login">
        <form id="loginForm" className="loginForm">
          <div>
            <label>UserName</label>
            <input id="username" type="text" name="Name" placeholder="UserName" required onChange={this.handleChange} />
          </div>
          <div>
            <label>Password</label>
            <input id="password" type="password" name="Password" placeholder="Password" required onChange={this.handleChange} />
          </div>
          <div>
            <button type="submit" onClick={this.tryLogin} >Login
            </button>
          </div>
        </form>
        <a href="https://localhost:44395/home/customerregister"><button>RegisterForCustomer</button></a>
            <a href="https://localhost:44395/home/airlineregister"><button>RegisterForAirline</button></a>      
            <a href="https://localhost:44395/home/Adminregister"><button>RegisterForAdmin</button></a>
      </div>
    )
  }
}

export default withRouter(Login);
