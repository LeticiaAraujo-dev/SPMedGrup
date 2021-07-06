import React, { Component } from 'react';
// import { Link } from 'react-router-dom';
import axios from 'axios';

class ConsultasMinhas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaMinhasConsultas : [],
        }
    }

    buscarMinhasConsultas = () => {
        // Faz a chamada para a API usando axios
        axios('http://localhost:5000/api/consulta/minhas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200,
            if (resposta.status === 200) {
                // atualiza o state listaTiposEventos com os dados obtidos 
                this.setState({ listaMinhasConsultas : resposta.data })
                // e exibe no console do navegador a lista de tipos eventos
                console.log(this.state.listaMinhasConsultas)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro))
    };

    componentDidMount(){
        this.buscarMinhasConsultas();
    }

    render(){
        return(
            <div>
                <main>
                    <h1>Consultas</h1>
                    <table>
                        <thead>
                            <tr>
                                <th>Medico</th>
                                <th>especialidade</th>
                                <th>Paciente</th>
                                <th>Data e Hora</th>
                                <th>Situação</th>
                            </tr>
                        </thead>
                        <tbody className="card-consulta">
                            {
                                this.state.listaMinhasConsultas.map( (consulta) => {
                                    return(
                                        <tr key={consulta.idConsulta }>
                                            <td>{consulta.idMedicoNavigation.nomeMedico }</td>
                                            <td>{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade }</td>
                                            <td>{consulta.idPacienteNavigation.nomePaciente }</td>
                                            <td>{consulta.dataRealizacao }</td>
                                            <td>{consulta.idSituacaoNavigation.tipoSituacao }</td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                </main>
            </div>
        );
    }
}

export default ConsultasMinhas;
