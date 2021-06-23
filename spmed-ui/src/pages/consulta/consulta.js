import {Component} from 'react';
import { Link } from 'react-router-dom';

class Consultas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [{idCosulta: 1,Medico: 'Julio da Silva', especialidade: 'olho cuidador', Paciente: 'Janaina dos SANTOS', Data: '10/2/2021'}],
        }
    }

    componentDidMount(){
        this.buscarConsultas();
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
                                        <tr key={consulta.idCosulta}>
                                            <td>{consulta.Medico}</td>
                                            <td>{consulta.especialidade}</td>
                                            <td>{consulta.Paciente}</td>
                                            <td>{consulta.Data}</td>

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
