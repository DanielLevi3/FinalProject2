import React, { Component }  from 'react';
import axios from 'axios';
import Swal from "sweetalert2";  

class AdminCustomers extends Component
{
  constructor(props){
    super(props);
     this.state =
    {
      customers :[],
       updateCustomer:
       {
            ID:undefined,
            FirstName: undefined,
            LastName: undefined,
            Address: undefined,
            PhoneNumber: undefined,
            CreditNumber: undefined,
              User:{
              ID:undefined,
              UserName: undefined,
              Password: undefined,
              Email: undefined,
              UserRole:2
        }
      }
    }
  }


componentDidMount(){
  this.getAllCustomers();
}

getAllCustomers = async ()=>{
let jwt = localStorage.getItem("token")
await axios.get('https://localhost:44395/api/Administrator/GetAllCustomers',
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
                customers: res.data
              })
              console.log(this.state)
            }
            return Promise.resolve(res);
          }).catch((error)=>{
            console.log(error)
          })
}

deleteCustomer =async (id)=>
{
  let jwt = localStorage.getItem("token")
  await axios.delete(
    'https://localhost:44395/api/Administrator/DeleteCustomer',
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
      let newArr = this.state.customers.filter((c)=>{
        return c.id !=id;
      });
      this.setState({
        customers:newArr,
      });
      console.log(res.data)
      Swal.fire(
        'Customer was deleted succefully!',
        'success')
    }
  }).catch((error)=>{
    console.log(error)
    Swal.fire({
      icon: 'error',
      title: 'You can\'t delete this customer',
      text: `something went wrong`
  }) 
  })
}
updateCustomer= async ()=>
{
console.log(this.state.updateCustomer)
  let jwt = localStorage.getItem("token")
  await axios.put(
    'https://localhost:44395/api/Administrator/UpdateCustomer',this.state.updateCustomer,
    {headers: {
            // "Access-Control-Allow-Origin" : "*",
            "Content-type": "Application/json",
            "Authorization": `Bearer ${jwt}`
               }
     }   
  )
  console.log(this.state)

}
  


valueChange =(customer,name,value)=>
{
  
  customer[name]=value;
  console.log(customer)
  this.setState({
    updateCustomer:customer
  })
}
handleUserChange = (customer,user,name,value) => {
  customer[name]=value;
  user[name]=value;
  console.log(customer)
  this.setState({
    updateCustomer:customer
  })
  this.setState(prevState => ({
    updateCustomer: {
      ...prevState.updateCustomer,           // copy all other key-value pairs of food object    // copy all pizza key-value pairs
        User: user
  }}))
}

render() 
{
    if(this.state.customers.length !=0)
      {
      return (
      <div>
        <h3>Customers</h3>
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Address</th>
              <th>PhoneNumber</th>
              <th>CreditNumber</th>
              <th>UserId</th>
              <th>UserName</th>
              <th>Password</th>
              <th>Email</th>
            </tr>
          </thead>
          <tbody>
            {this.state.customers.map( (customer) => {
             
              return (
                <tr>
                <td>{customer.ID}</td>
                  <td><input type='text' name='FirstName' defaultValue={customer.FirstName} onChange={(e) =>
                    this.valueChange(
                      customer,
                      "FirstName",
                      e.target.value
                    )} /></td>
                  <td><input type='text' name='LastName' defaultValue={customer.LastName} onChange={(e) =>
                  this.valueChange(
                    customer,
                    "LastName",
                    e.target.value
                  )} /></td>
                  <td><input type='text' name='Address' defaultValue={customer.Address} onChange={(e) =>
                    this.valueChange(
                      customer,
                      "Address",
                      e.target.value
                    )} /></td>
                    <td><input type='text' name='PhoneNumber' defaultValue={customer.PhoneNumber} onChange={(e) =>
                      this.valueChange(
                        customer,
                        "PhoneNumber",
                        e.target.value
                      )} /></td>
                      <td><input type='text' name='CreditNumber' defaultValue={customer.CreditNumber} onChange={(e) =>
                        this.valueChange(
                          customer,
                          "CreditNumber",
                          e.target.value
                        )} /></td>
                 
                  <td><input type='number' name='UserId' defaultValue={customer.UserId} onChange={(e) =>
                    this.valueChange(
                      customer,
                      "UserId",
                      e.target.value
                    )} /></td>
                    <td><input type='text' name='Username' defaultValue={customer.User.UserName} onChange={(e) =>
                      this.handleUserChange(
                        customer,
                        customer.User,
                        "Username",
                        e.target.value
                      )} /></td>
                  
                  <td><input type='text' name='Password' defaultValue={customer.User.Password} onChange={(e) =>
                    this.handleUserChange(
                      customer,
                      customer.User,
                      "Password",
                      e.target.value
                    )} /></td>
                    <td><input type='text' name='Email' defaultValue={customer.User.Email} onChange={(e) =>
                      this.handleUserChange(
                        customer,
                        customer.User,
                        "Email",
                        e.target.value
                      )} /></td>
                  <td>
                  <button
                  onClick={this.deleteCustomer.bind(
                    this,
                    customer.ID
                  )} 
                >
                  Delete Customer
                </button>
                <button onClick={this.updateCustomer.bind(
                  this
                )}
    
                  >
                    Update Customer
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
  
export default AdminCustomers;
