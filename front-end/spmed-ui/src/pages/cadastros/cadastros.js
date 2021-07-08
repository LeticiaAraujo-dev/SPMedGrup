import { Component } from 'react';



class Cadastro extends Component{
    constructor(props){
        super(props);
        this.state = {
            idConsulta: 0,
            idMedico : 0,
            idPaciente : 0,
            dataRealizacao: new Date(),
            idSituacao: 0,
            listaMedicos: [],
            listaPacientes: [],
        }
    }



    buscarMedicos = () => {
        fetch('http://localhost:5000/api/Medico',
        {
            // headers : {
            //     'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            // }
        })

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ listaMedicos: data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.listaMedicos);
    }

    buscarPacientes = () => {
        fetch('http://localhost:5000/api/Paciente',
        {
            // headers : {
            //     'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            // }
        })

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })

        .then(data => this.setState({ listaPacientes: data }))

        .catch((erro) => console.log(erro))

        console.log(this.state.listaPacientes);
    }

    // Função responsável por cadastrar um Tipo de Evento
    cadastrarConsulta = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();
        this.setState({ isLoading : true });
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

                // headers : {
                //     "Content-Type" : "application/json",
                //     'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                // }
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

            .then(this.limparCampos)
        }

        else {
            console.log('Cadastrando...')

            fetch('http://localhost:5000/api/Consulta',
            {

                method : 'POST',

 
                body : JSON.stringify({ 
                                        idMedico : this.state.idMedico,
                                        idPaciente : this.state.idPaciente,
                                        dataRealizacao : this.state.dataRealizacao,
                                        idSituacao : this.state.idSituacao
                }),

                // Define o cabeçalho da requisição
                headers : {
                    "Content-Type" : "application/json",
                    // 'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }


            })


            .then(console.log('Consulta cadastrado!'))

            .catch(erro => console.log(erro))


            .then(this.limparCampos)
        }
    };

    buscarConsultaPorId = (consulta) => {
        this.setState({
            idConsulta : consulta.idConsulta,

            idMedico : consulta.idMedico,
            idPaciente : consulta.idPaciente,
            dataRealizacao : consulta.dataRealizacao,
            idSituacao : consulta.idSituacao
        }, () => {
            console.log(
                'A consulta ' + consulta.idConsultaNova + ' foi selecionada, ',
                'agora o valor do state idMedico é: ' + this.state.idMedico,
                'e o valor do state idPaciente é: ' + this.state.idPaciente,
                'e o valor do state dataRealizacao é: ' + this.state.dataRealizacao,
                'e o valor do state idSituacao é: ' + this.state.idSituacao,

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

    }

    limparCampos = () => {
        this.setState({
            idMedico : 0,
            idPaciente : 0,
            dataRealizacao: new Date(),
            idSituacao: 0
        })
        console.log('Os states foram resetados!')
    }

    // atualizaStateCampo = (campo) => {
    //      this.setState({ [campo.target.name] : campo.target.value }) 
    // };

    atualizaEstadoMedico = async (event) => {
        await this.setState({ idMedico : event.target.value })
        console.log(this.state.idMedico)
    };

    atualizaEstadoPaciente = async (event) => {
        await this.setState({ idPaciente : event.target.value })
        console.log(this.state.idPaciente)
    };

    atualizaEstadoSitacao = async (event) => {
        await this.setState({ idSituacao : event.target.value })
        console.log(this.state.idSituacao)
    };

    atualizaEstadoData = async (event) => {
        await this.setState({ dataRealizacao : event.target.value })
        console.log(this.state.dataRealizacao)
    };

    componentDidMount(){
       
    }

    render(){
        return(
            <div>
                <section className="cadastro-consulta">
                    <h1 className="titulo-secao">Cadastro de Consultas</h1>
                    <form onSubmit={this.cadastrarConsulta}>
                        <div className="container">
                                
                                <input 
                                    type="text"
                                    id="idMedico"
                                    value={this.state.idMedico}
                                    onChange={this.atualizaEstadoMedico}
                                    placeholder="idMedico"
                                />

                                {/* <select
                                    name="idMedico"
                                    value={this.state.idMedico}
                                    onChange={this.atualizaEstadoMedico}

                                >
                                    <option value="">Selecione o Medico</option>

                                    {
                                        // Percorre a lista de Tipos Eventos e retorna uma opção para cada tema
                                        // definindo o valor como seu próprio ID
                                        this.state.listaMedicos.map( medico => {
                                            return(
                                                <option key={medico.idMedico} value={medico.idMedico}>
                                                    {medico.idMedicoNavigation.nomeMedico}
                                                </option>
                                            );
                                        } )
                                    }

                                </select> */}
                                
                                <input 
                                    type="text"
                                    id="idPaciente"
                                    value={this.state.idPaciente}
                                    onChange={this.atualizaEstadoPaciente}
                                    placeholder="idPaciente"
                                />
                                <input 
                                    type="text"
                                    id="idSituacao"
                                    value={this.state.idSituacao}
                                    onChange={this.atualizaEstadoSitacao}
                                    placeholder="idSituacao"
                                />
                                <input 
                                    type="text"
                                    id="dataRealizacao"
                                    value={this.state.dataRealizacao}
                                    onChange={this.atualizaEstadoData}
                                    placeholder="dataRealizacao"
                                />
                                <button type="submit" >Cadastrar</button> 
                        </div>
                    </form>
                </section>
            </div>

        )}
    
}

export default Cadastro;
