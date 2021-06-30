import { Component } from 'react';

class Cadastro extends Component{
    constructor(props){
        super(props);
        this.state = {
            idConsulta: 0,
            idMedico : 0,
            idPaciente : 0,
            dataRealizacao: new Date,
            idSituacao: 0
        }
    }

    // Função responsável por cadastrar um Tipo de Evento
    cadastrarConsulta = (event) => {
        // Ignora o comportamento padrão do navegador
        //event.preventDefault();

        if (this.state.idConsulta !== 0) {

            fetch('http://localhost:5000/api/Consulta/' + this.state.idConsulta,
            {
                method : 'PUT',

                body : JSON.stringify({
                    idConsulta : this.state.idConsultaAlterada,
                    idMedico : this.state.idMedicoAlterada,
                    idPaciente : this.state.idPacienteAlterada,
                    dataRealizacao : this.state.dataRealizacaoAlterada,
                    idSituacao : this.state.idSituacaoAlterada
                }),

                headers : {
                    "Content-Type" : "application/json",
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log(
                        'Consulta ' + this.state.idConsultaAlterada + ' atualizada!',

                        'Seu medico agora é: ' + this.state.idMedicoAlterada,
                        'Seu paciente agora é: ' + this.state.idPacienteAlterada,
                        'Sua data agora é: ' + this.state.dataRealizacaoAlterada,
                        'Sua situação agora é: ' + this.state.idSituacaoAlterada
                    );
                };
            })

            .then(this.buscarConsulta)

            .then(this.limparCampos)
        }

        else {

            fetch('http://localhost:5000/api/Consulta',
            {

                method : 'POST',

 
                body : JSON.stringify({ idConsulta : this.state.idConsultaNova, 
                                        idMedico : this.state.idMedicoNovo,
                                        idPaciente : this.state.idPacienteNovo,
                                        dataRealizacao : this.state.dataRealizacaoNovo,
                                        idSituacao : this.state.idSituacaoNovo
                }),

                // Define o cabeçalho da requisição
                headers : {
                    "Content-Type" : "application/json",
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })


            .then(console.log('Consulta cadastrado!'))

            .catch(erro => console.log(erro))


            .then(this.buscarConsulta)

            .then(this.limparCampos)
        }
    };

    buscarConsultaPorId = (consulta) => {
        this.setState({
            idConsultaAlterada : consulta.idConsulta,

            idMedico : consulta.idMedicoNovo,
            idPaciente : consulta.idPacienteNovo,
            dataRealizacao : consulta.dataRealizacaoNovo,
            idSituacao : consulta.idSituacaoNovo
        }, () => {
            console.log(
                'A consulta ' + consulta.idConsulta + ' foi selecionada, ',
                'agora o valor do state idMedico é: ' + this.state.idMedicoNovo,
                'e o valor do state idPaciente é: ' + this.state.idPacienteNovo,
                'e o valor do state dataRealizacao é: ' + this.state.dataRealizacaoNovo,
                'e o valor do state idSituacao é: ' + this.state.idSituacaoNovo,

            );
        });
    };

    excluirTipoEvento = (consulta) => {
        console.log('A consulta ' + consulta.idConsulta + ' foi selecionada')


        fetch('http://localhost:5000/api/Consulta/' + consulta.idConsulta,
        {
            method : 'DELETE',

            // Define o cabeçalho da requisição
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 204) {
                console.log('Consulta ' + consulta.idConsulta + ' excluída!')
            };
        })

        .catch(erro => console.log(erro))

        .then(this.buscarConsulta)
    }

    limparCampos = () => {
        this.setState({
            idConsulta: 0,
            idMedico : 0,
            idPaciente : 0,
            dataRealizacao: new Date,
            idSituacao: 0
        })
        console.log('Os states foram resetados!')
    }

    buscarIdPaciente = () => {
        fetch('http://localhost:5000/api/Paciente'
            //headers : { 'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login') 
        //}
        )

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ idPaciente : data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.idPaciente);
    }

    buscarIdMedico = () => {
        fetch('http://localhost:5000/api/Medico'
            //headers : { 'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login') 
        //}
        )

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ idPaciente : data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.idPaciente);
    }

    buscarIdSituacao = () => {
        fetch('http://localhost:5000/api/Situacao'
            //headers : { 'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login') 
        //}
        )

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ idPaciente : data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.idPaciente);
    }

    componentDidMount(){
       
    }

    render(){
        return(
            <div>
                <section className="cadastro-consulta">
                    <h1 className="titulo-secao">Cadastro de Consultas</h1>
                    <form onSubmit={this.cadastrarConsulta}>
                        <input list="idMedico" name="idMedico"/>
                            <datalist>
                                
                                <option value={this.buscarIdPaciente}/>
                            </datalist>
                        <input list="idPaciente" name="idPaciente"/>
                            <datalist>
                                <option value={this.buscarIdMedico}/>
                            </datalist>
                        <input list="idSituacao" name="idSituacao"/>
                            <datalist>
                                <option value={this.buscarIdSituacao}/>
                            </datalist>
                        <input type="submit"/>
                    </form>
                </section>
            </div>

        )}
    
}

export default Cadastro;
