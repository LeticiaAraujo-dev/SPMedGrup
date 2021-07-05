// import React, { Component } from 'react';
// import { Link } from 'react-router-dom';
// import axios from 'axios';
// import { parseJwt, usuarioAutenticado } from '../../services/auth';

// class Login extends Component{
//     constructor(props){
//         super(props);
//         this.state = {
//             email : '',
//             senha : '',
//             erroMensagem : '',
//             isLoading : false
//         }
//     }

//     efetuaLogin = (event) => {
//         event.preventDefault();

//         this.setState({ erroMensagem : '', isLoading : true });

//         axios.post('http://localhost:5000/api/Usuarios/Login', {
//             email : this.state.email,
//             senha : this.state.senha
//         })

//         .then(resposta => {
//             if (resposta.status === 200) {
//                 localStorage.setItem('usuario-login', resposta.data.token);

//                 console.log('Meu token é: ' + resposta.data.token);

//                 this.setState({ isLoading : false })

//                 let base64 = localStorage.getItem('usuario-login').split('.')[1];

//                 console.log(base64);

//                 console.log(window.atob(base64));

//                 console.log(JSON.parse(window.atob(base64)));

//                 console.log(parseJwt().role);

//                 if (parseJwt().role === '1') {
//                     this.props.history.push('/cadastros');
//                     console.log('estou logado: ' + usuarioAutenticado());
//                 } 
//                 else {
//                     this.props.history.push('/consultasMinhas')
//                 }
//             }
//         })

//         .catch(() => {
//             this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false });
//         })

//     }

//     atualizaStateCampo = (campo) => {
//         this.setState({ [campo.target.name] : campo.target.value })
//     };

//     render(){
//         return(
//             <div>
//                 <main>
//                     <section className="container-login flex">
//                         <div className="img__login"><div className="img__overlay"></div></div>

//                         <div className="item__login">
//                             <div className="row">
//                                 <div className="item">
//                                     <Link to="/"><img src={logo} className="icone__login" alt="logo da Gufi" /></Link>
//                                 </div>
//                                 <div className="item" id="item__title">
//                                     <p className="text__login" id="item__description">Bem-vindo(a)! Faça login para acessar sua conta.</p>
//                                 </div>

//                                 {/* Faz a chamada para a função de login quando o botão é pressionado */}
//                                 <form onSubmit={this.efetuaLogin}>
//                                     <div className="item">
//                                         <input
//                                             id="login__email"
//                                             className="input__login"
//                                             // E-mail
//                                             type="text"
//                                             name="email"
//                                             // Define que o input email recebe o valor do state email
//                                             value={this.state.email}
//                                             // Faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
//                                             onChange={this.atualizaStateCampo}
//                                             placeholder="username"
//                                         />
//                                     </div>

//                                     <div className="item">
//                                         <input 
//                                             id="login__password"
//                                             className="input__login"
//                                             // Senha
//                                             type="password"
//                                             name="senha"
//                                             // Define que o input senha recebe o valor do state senha
//                                             value={this.state.senha}
//                                             // Faz a chamada para a função que atualiza o state, conforme
//                                             // o usuário altera o valor do input
//                                             onChange={this.atualizaStateCampo}
//                                             placeholder="password"
//                                         />
//                                     </div>

//                                     {/* Exibe a mensagem de erro ao tentar logar com credenciais inválidas */}
//                                     <p style={{ color : 'red', textAlign : 'center' }}>{this.state.erroMensagem}</p>

//                                     {/* 
//                                         Verifica se a requisição está em andamento
//                                         Se estiver, desabilita o click do botão
//                                     */}

//                                     {
//                                         // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
//                                         this.state.isLoading === true &&
//                                         <div className="item">
//                                             <button className="btn btn__login" id="btn__login" type="submit" disabled>Loading...</button>
//                                         </div>
//                                     }

//                                     {
//                                         // Caso seja false, renderiza o botão habilitado com o texto 'Login'
//                                         this.state.isLoading === false &&
//                                         <div className="item">
//                                             <button
//                                                 className="btn btn__login" id="btn__login"
//                                                 type="submit"
//                                                 disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
//                                                 Login
//                                             </button>
//                                         </div>
//                                     }
//                                 </form>
//                             </div>
//                         </div>
//                     </section>
//                 </main>
//             </div>
//         )
//     }
// }

// export default Login;
