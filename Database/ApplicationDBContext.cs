using Microsoft.EntityFrameworkCore;
using Starting_with_the_entity_framework.Models;

namespace Starting_with_the_entity_framework.Database
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

    } 
}