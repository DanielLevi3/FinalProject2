import React from 'react';
import axios from 'axios';
import $ from 'jquery';

const user ={
  Name:$("#username"),
  Password:$("#password")
};
const onLogin = () =>
{  
  axios.post('https://localhost:44395/api/Auth/token',user)
  .then(function (response) {
    console.log(response);
  })
  .catch(function (error) {
    console.log(error);
  });
}

const Login = () => {
  return (
    <div className="Login">
    <form id="loginForm" className="loginForm">
    <div>
    <label>UserName</label>
    <input id="username" type="text" name="UserName" placeholder="UserName" required />
    </div>
    <div>
    <label>Password</label>
    <input id="password" type="password" name="Password" placeholder="Password" required />
    </div>
    <div>
    <button type="submit" onClick={onLogin} >Submit
    </button> 
    </div>
    </form>
    </div>
  );
}

export default Login;
