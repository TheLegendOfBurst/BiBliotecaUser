﻿using BiBliotecaUser.ORM;
using BiBliotecaUser.Model;
using BiBliotecaUser.Repositorio;

namespace BiBliotecaUser.Repositorio
{
    public class UsuarioR
    {
        private readonly BibliotecaContext _context;

        public UsuarioR(BibliotecaContext context)
        {
            _context = context;
        }



        public TbUsuario GetByCredentials(string usuario, string senha)
        {
            // Aqui você deve usar a lógica de hash para comparar a senha
            return _context.TbUsuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }

        // Você pode adicionar métodos adicionais para gerenciar usuários
    }
}
