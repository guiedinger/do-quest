﻿using Do.Quest.Infra.Data.Conventions;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Do.Quest.Domain.Entities;

namespace Do.Quest.Infra.Data.Context
{
    public class QuestionarioContext
    {
        private readonly IMongoDatabase _mongoDataBase;

        internal IMongoCollection<Usuario> Usuarios => _mongoDataBase.GetCollection<Usuario>("Usuarios");
        internal IMongoCollection<GrupoUsuario> GruposUsuarios => _mongoDataBase.GetCollection<GrupoUsuario>("GruposUsuarios");

        public QuestionarioContext(IConfiguration configuration)
        {
            RegisterConventions();
            _mongoDataBase = new MongoClient(configuration["NoSqlDatabaseSettings:ConnectionString"])
                    .GetDatabase(configuration["NoSqlDatabaseSettings:DatabaseName"]);
        }

        private static void RegisterConventions()
        {
            ConventionRegistry.Register(nameof(IgnoreValidationResultConvention), new ConventionPack { new IgnoreValidationResultConvention() }, t => true);

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);
        }
    }
}