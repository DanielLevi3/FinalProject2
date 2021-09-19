import React, { Component } from 'react';
  import Navbar from './Components/Navbar';
  import { BrowserRouter, Route, Switch } from 'react-router-dom';
  import Home from './Components/Home';
  import Login from './Components/Login';
  import Dashboard from './Components/Dashboard';
  import Admin from './Components/Admin';
  import Airline from './Components/Airline';
  import MyDetails from './Components/MyDetails';
  import Tickets from './Components/Tickets';
  
  class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="App">
          <header className="App">
            <Navbar />
            <Switch>
              <Route exact path='/' component={Home} />
              <Route path='/login' component={Login} />
              <Route path='/dashboard' component={Dashboard} />
              <Route path='/admin' component={Admin} />
              <Route path='/airline' component={Airline} />
              <Route path='/customer/Mydetails' component={MyDetails} />
              <Route path='/customer/Tickets' component={Tickets} />
            </Switch>
          </header>
        </div>
      </BrowserRouter>
    );
  }
  }
export default App;

// function Home() {
//   return <h2>Home</h2>;
// }

// function Login() {
//   return <h2>Login</h2>;
// }

// function Topics() {
//   let match = useRouteMatch();

//   return (
//     <div>
//       <h2>Topics</h2>

//       <ul>
//         <li>
//           <Link to={`${match.url}/components`}>Components</Link>
//         </li>
//         <li>
//           <Link to={`${match.url}/props-v-state`}>
//             Props v. State
//           </Link>
//         </li>
//       </ul>

//       {/* The Topics page has its own <Switch> with more routes
//           that build on the /topics URL path. You can think of the
//           2nd <Route> here as an "index" page for all topics, or
//           the page that is shown when no topic is selected */}
//       <Switch>
//         <Route path={`${match.path}/:topicId`}>
//           <Topic />
//         </Route>
//         <Route path={match.path}>
//           <h3>Please select a topic.</h3>
//         </Route>
//       </Switch>
//     </div>
//   );
// }

// function Topic() {
//   let { topicId } = useParams();
//   return <h3>Requested topic ID: {topicId}</h3>;
//}