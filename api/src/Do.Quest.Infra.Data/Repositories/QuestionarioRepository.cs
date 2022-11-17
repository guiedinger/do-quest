﻿using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Infra.Data.Context;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace Do.Quest.Infra.Data.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private readonly QuestionarioContext _questionarioContext;

        public QuestionarioRepository(QuestionarioContext questionarioContext)
        {
            _questionarioContext = questionarioContext;
        }

        public async Task AdicionarGrupoUsuariosAsync(GrupoUsuario grupoUsuario)
        {
            await _questionarioContext.GruposUsuarios.InsertOneAsync(grupoUsuario);
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
           await _questionarioContext.Usuarios.InsertOneAsync(usuario);
        }

        public async Task AdicionarUsuariosAsync(IEnumerable<Usuario> usuarios)
        {
            await _questionarioContext.Usuarios.InsertManyAsync(usuarios);
        }

        public List<Questionario> GetQuestionario(GrupoUsuario grupoUsuario)
        {
            List<Questionario> quest = null;

            foreach (var item in _questionarioContext.Questionario.AsQueryable())
            {
                foreach (var item2 in item.GruposUsuarios)
                {
                    if (item2.Id == grupoUsuario.Id)
                    {
                        quest.Add(item);
                        break;
                    } 
                }
            }

            return quest;
        }

		public async Task Cadastrar(Questionario questionario) {
         throw new NotImplementedException();
            //await _questionarioContext.Questionario.InsertManyAsync(questionario);
		}

        Task IQuestionarioRepository.GetQuestionario(GrupoUsuario grupoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
