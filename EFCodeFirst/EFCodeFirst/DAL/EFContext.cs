using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EFCodeFirst.DAL
{
	//CHAMAMOS A DB CONTEXT DA WEB.CONFIG PARA TERMOS ACESSO A CONNECTIONSTRING
	public class EFContext : DbContext
	{
		public EFContext() : base("EFConnectionString")	{}

		// O METODO OVERRIDE FAZ COM QUE AS CLASSES NÃO PLURALIZE NA HORA DA CRIAÇÃO DO BD USANDO COMO REFERENCIA O METODO OnModelCreating
		//Ele vai executar esse metodo ao invez do metodo original(DbContext)
		//Tem que ser PROTECTED pra sem a mesma assinatuda que está no DbContext
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}

		//ESTAMOS CRIANDO O BANCO DE DADOS NA DB CONTEXT
		public DbSet <Universidade> Universidades { get; set; }
		public DbSet<Curso> Cursos { get; set; }
		public DbSet<Aluno> Alunos { get; set; }
	}
}