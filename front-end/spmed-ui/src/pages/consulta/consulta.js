import {Component} from 'react';
import { Link } from 'react-router-dom';

class Consultas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
        }
    }

    buscarConsulta = () => {

        fetch('http://localhost:5000/api/Consulta')

        .then(resposta => resposta.json())

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
                                <th>Data</th>
                                <th>Hora</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.listaConsultas.map( (consulta) => {
                                    return(
                                        <tr key={consulta.idConsulta }>
                                            <td>{consulta.NomeMedico }</td>
                                            <td>{consulta.NomeEspecialidade }</td>
                                            <td>{consulta.NomePaciente }</td>
                                            <td>{consulta.TipoSituacao }</td>
                                            <td>{consulta.DataRealizacao }</td>

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
