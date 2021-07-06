import React, { Component } from 'react';
// import { Link } from 'react-router-dom';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';



class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
        }
    }

    efetuaLogin = (event) => {
        // Ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
        event.preventDefault();

        axios.post('http://localhost:5000/api/Usuarios/Login', {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(resposta => {
            // Caso o status code seja 200,
            if (resposta.status === 200) {
                // salva o token no localStorage,
                localStorage.setItem('usuario-login', resposta.data.token);
                // exibe o token no console do navegador
                console.log('Meu token é: ' + resposta.data.token);

                // Define a variável base64 que vai receber o payload do token
                let base64 = localStorage.getItem('usuario-login').split('.')[1];
                // Exibe no console o valor presente na variável base64
                console.log(base64);
                // Exibe no console o valor convertido de base64 para string
                console.log(window.atob(base64));
                // Exibe no console o valor convertido da string para JSON
                console.log(JSON.parse(window.atob(base64)));

                // Exibe no console apenas o tipo de usuário logado
                console.log(parseJwt().role);

                // Verifica se o tipo de usuário logado é Administrador
                // Se for, redireciona para a página de Tipos Eventos
                if (parseJwt().role === '1') {
                    this.props.history.push('/Cadastro');
                    console.log('estou logado: ' + usuarioAutenticado());
                }

                // Se não for, redireciona para a página home
                else {
                    this.props.history.push('/consultasMinhas')
                }
            }
        })

        // Caso haja um erro,
        .catch(() => {
            // define o state erroMensagem com uma mensagem personalizada e que a requisição terminou
            this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.'});
        })
    }

    // atualizaStateCampo = (campo) => {
    //     this.setState({ [campo.target.name] : campo.target.value })
    //     console.log(this.state.campo.target.value)

    // };

    atualizaEstadoEmail = async (event) => {
        await this.setState({ email : event.target.value })
        console.log(this.state.email)
    };

    atualizaEstadoSenha = async (event) => {
        await this.setState({ senha : event.target.value })
        console.log(this.state.senha)
    };


    render(){
        return(
            <div>
                <main>
                    <section>
                        <p>
                            Realize seu Login
                        </p>

                        <form onSubmit={this.efetuaLogin}>
                            <div>
                                <input 
                                type="text"
                                name="email"
                                
                                value={this.state.email}
                                onChange={this.atualizaEstadoEmail}
                                placeholder="username"
                                />
                            </div>

                            <div>
                                <input 
                                type="text"
                                name="senha"
                                
                                value={this.state.senha}
                                onChange={this.atualizaEstadoSenha}
                                placeholder="password"
                                />
                            </div>

                            <button type="submit">Login</button>

                        </form>
                    </section>
                </main>
            </div>
        )
    }

}

export default Login;