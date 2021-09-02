import axios from 'axios';
// import $, { event } from 'jquery';
// import Login from './Login';
import jwtDecode from 'jwt-decode';
import { Component } from 'react';

class UserService extends Component
{
 
  // Create function that decodes JWT to object // JwtDecode

  constructor(props) {
    super(props);
    this.decoded = null;
  }

    getToken = () => {
        return this.decoded;
    }

    // add logout  -  localStorage.clear()
   

    tryLogin = async (Name,Password) => {
        await axios.post('https://localhost:44395/api/Auth/token',{Name,Password})
        .then( res => 
            {
            if (res.status == 200) {
                let token = res.data;
                localStorage.setItem("token", token)
                this.decoded = jwtDecode(token)
                console.log(this.decoded)
            }

        return Promise.resolve(res);
        })
        .catch(function (error) {
            alert('Error while trying to log in')
            console.log(error);
        });
      }

   loggedIn ()
    {
        const token = this.getToken()
        return !!token && !this.isTokenExpired(token)
    }

    // isTokenExpired (token)
    // {
    //     try {
    //         const decoded = jwtDecode(token);
    //         if (decoded.exp < Date.now() / 1000) {
    //             return true;
    //         }
    //         else
    //             return false;
    //     }
    //     catch (err) {
    //         return false;
    //     }
    // }


    // getToken ()
    // {
    //     return JSON.parse(localStorage.getItem('id_token'));
    // }

    // logout () 
    // {
    //     localStorage.removeItem('id_token');
    // }

    // getProfile ()
    // {
    //     return jwtDecode(this.getToken());
    // }


    // async fetch (url, options) {
    //     const headers = {
    //         'Accept': 'application/json',
    //         'Content-Type': 'application/json'
    //     }
    //     if (this.loggedIn()) {
    //         headers['Authorization'] = 'Bearer ' + this.getToken()
    //     }

    //     const response = await fetch(url, {
    //         headers,
    //         ...options
    //     });
    //     const response_1 = await this._checkStatus(response);
    //     return response_1.json();
    // }

    // _checkStatus (response) {

    //     if (response.status >= 200 && response.status < 300) {
    //         return response
    //     } else {
    //         var error = new Error(response.statusText)
    //         error.response = response
    //         throw error
    //     }
    // }

  render() {
    return (
        null
    )
  }
}

export default UserService;
