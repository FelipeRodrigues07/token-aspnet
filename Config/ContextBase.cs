using api_app.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api_app.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>//criando um campo customizado   para configurar um contexto de banco de dados
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)  //construtor: Recebe as opções de configuração do contexto e passa para a classe base (IdentityDbContext).
        {
        }

        public DbSet<ProductModel> Product { get; set; } //Cria um conjunto de dados (DbSet) para a entidade ProductModel, permitindo operações CRUD no banco de dados.

        protected override void OnModelCreating(ModelBuilder builder)  //Define que a entidade ApplicationUser será mapeada para a tabela AspNetUsers e especifica Id como chave primária. Chama OnModelCreating da classe base para garantir que outras configurações padrão sejam aplicadas.
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Configuração do banco de dados: Configura o provedor de banco de dados (SQL Server) usando a string de conexão, caso o optionsBuilder ainda não tenha sido configurado.
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string ObterStringConexao()  //Essa configuração completa permite que o seu contexto ContextBase gerencie a persistência de dados, incluindo a identidade dos usuários, e se conecte ao banco de dados SQL Server configurado.
        {
            return "Data Source=NBQSP-FC693;Initial Catalog=API_CANAL_DEV_NET_CORE;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            //return "Data Source=NBQSP-FC693;Initial Catalog=API_CANAL_DEV_NET_CORE;Integrated Security=True"; // Evitar
        }

    }
}
