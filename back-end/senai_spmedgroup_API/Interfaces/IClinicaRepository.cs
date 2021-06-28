using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IClinicaRepository
    {
        List<ClinicaDomain> ListarTodos();

        ClinicaDomain BuscarPorId(int id);

        void Cadastrar(ClinicaDomain novaClinica);

        void Atualizar(int id, ClinicaDomain clinicaAtualizada);

        void Deletar(int id);
    }
}
