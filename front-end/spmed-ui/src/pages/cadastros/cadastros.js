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
        event.preventDefault();

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

    // Recebe um tipo de evento da lista
    buscarConsultaPorId = (consulta) => {
        this.setState({
            // Atualiza o state idTipoEventoAlterado com o valor do ID do Tipo de Evento recebido
            idConsultaAlterada : consulta.idConsulta,
            // e o state titulo com o valor do titulo do Tipo de Evento recebido
auisfhdgsifhdgiksdhfughsdfuhg

            titulo : tipoEvento.tituloTipoEvento
        }, () => {
            console.log(
                // Exibe no console do navegador o valor do ID do Tipo de Evento recebido
                'O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado, ',
                // o valor do state idTipoEventoAlterado
                'agora o valor do state idTipoEventoAlterado é: ' + this.state.idTipoEventoAlterado,
                // e o valor do state titulo
                'e o valor do state titulo é: ' + this.state.titulo
            );
        });
    };

    // Função responsável por excluir um Tipo de Evento
    excluirTipoEvento = (tipoEvento) => {
        // Exibe no console do navegador o ID do Tipo de Evento recebido
        console.log('O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado')

        // Faz a chamada para a API usando fetch passando o ID do Tipo de Evento recebido na URL da requisição
        fetch('http://localhost:5000/api/tiposeventos/' + tipoEvento.idTipoEvento,
        {
            // Define o método da requisição ( DELETE )
            method : 'DELETE',

            // Define o cabeçalho da requisição
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Caso a requisição retorne um status code 204,
        .then(resposta => {
            if (resposta.status === 204) {
                // Exibe no console do navegador a mensagem 'Tipo de Evento x excluído!' onde x é o ID do Tipo de Evento excluído
                console.log('Tipo de Evento ' + tipoEvento.idTipoEvento + ' excluído!')
            };
        })

        // Caso ocorra alguma erro, exibe este erro no console do navegador
        .catch(erro => console.log(erro))

        // Então, atualiza a lista de Tipos de Eventos
        // sem o usuário precisar executar outra ação
        .then(this.buscarTiposEventos)
    }

    // Reseta os states titulo e idTipoEventoAlterado
    limparCampos = () => {
        this.setState({
            titulo : '',
            idTipoEventoAlterado : 0
        })
        // Exibe no console do navegador a mensagem 'Os states foram resetados!'
        console.log('Os states foram resetados!')
    }

    componentDidMount(){

    }

    
}