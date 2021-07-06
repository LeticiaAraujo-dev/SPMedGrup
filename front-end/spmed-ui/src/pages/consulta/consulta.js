import { Component } from 'react';
// import { Link } from 'react-router-dom';

class Consultas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
        }
    }

    buscarConsulta = () => {
        fetch('http://localhost:5000/api/Consulta',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ listaConsultas: data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.listaConsultas);
    }

    componentDidMount(){
        this.buscarConsulta();
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
                                this.state.listaConsultas.map( (consulta) => {
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

export default Consultas;
