using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IConsultaRepository
    {
        List<ConsultaDomain> ListarTodos();

        ConsultaDomain BuscarPorId(int id);

        void Cadastrar(ConsultaDomain novaConsulta);

        void Atualizar(int id, ConsultaDomain consultaAtualizada);

        void Deletar(int id);
    }
}
