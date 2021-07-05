import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
//import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';
import App from './pages/home/App';
import Consultas from './pages/consulta/consulta'
// import ConsultasMinhas from './pages/consultasMinhas/consultaminha'
import Cadastro from './pages/cadastros/cadastros'
// import Login from './pages/login/login'
import NotFound from './pages/notFound/notFound'

import reportWebVitals from './reportWebVitals';

// const PermissaoAdm = ({ component : Component  }) => (
//   <Route 
//     render = { props =>
//       usuarioAutenticado() && parseJwt().role === "1" ? 
//       <Component {...props} /> : 
//       <Redirect to = 'login' />
//     }
//   />
// );

// const PermissaoUsu = ({ component : Component  }) => (
//   <Route 
//     render = { props =>
//       usuarioAutenticado() ? 
//       <Component {...props} /> : 
//       <Redirect to = 'login' />
//     }
//   />
// );

const routing = (
  <Router>  
    <div>
      <Switch>
        <Route exact path="/" component={App}/>
        <Route exact path="/consulta" component={Consultas}/>
        {/* <Route exact path="/consultasMinhas" component={ConsultasMinhas}/> */}
        <Route exact path="/Cadastro" component={Cadastro}/>
        {/* <Route exact path="/login" component={ Login }/> */}
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
