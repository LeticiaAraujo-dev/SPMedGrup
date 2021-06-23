import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

import './index.css';
import App from './pages/home/App';
import Consultas from './pages/consulta/consulta'
import NotFound from './pages/notFound/notFound'

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>  
    <div>
      <Switch>
        <Route exact path="/" component={App}/>
        <Route path="/consulta" component={Consultas}/>
        <Route exact path="/notFound" component={NotFound}/>
        <Redirect to = "/notFound"/>
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
