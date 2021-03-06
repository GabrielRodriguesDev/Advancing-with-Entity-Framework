using Microsoft.EntityFrameworkCore;
using Advancing_with_Entity_Framework.Models;

namespace Advancing_with_Entity_Framework.Database
{
    public class ApplicationDBContext: DbContext  // Ao herdar de DbContext eu deixo indico ao ASP.NET que essa é a minha classe de configuração do Entity FrameWork
    { 
        
        
        /*O EF Core precisa que ao criar essa classe em que estamos seja carregado as opções de conexão.
            E após carregarmos essas opções de conexão temos que passar elas para a classe Pai.
            Que é DbContext no qual estamos herdando.
            Essa operação está sendo feito através do : base(options) que passa o parametro do construtor.
            Para a classe pai que no caso é DbContext
        */
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
            
        }

         // Todas as propriedades da classe que por fim irão virar campos da tabela e o DbSet, ambos tem que ser public para que o EF possa ter acesso a eles.
        //Para cada entidade que queremos mapear precisamos do atributo DbSet<>
        public DbSet<Funcionario> Funcionarios {get; set;} //Com isso o EF já sabe que deve criar uma tabela com base nessa classe.
        //O nome dela será o nome do atributo que nesse caso é Funcionarios;

        public DbSet<Categoria> Categorias {get; set;}


        public DbSet<Produto> Produtos {get; set;}


        //Usando a Fluent API para poder fazer configurações refenrete ao BD, essas configs são renderizadas no momento do migration
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Produto>().ToTable("GabrielProdutos")
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100); //Deixando o campo nome da tabela produto com o maximo de 100 caracteres.   
        }


    } 
}   