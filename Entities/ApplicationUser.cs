using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_app.Entities
{
    public class ApplicationUser : IdentityUser //usando a tabela propria do aspanet
    {
        [Column("USR_RG")]
        public string RG { get; set; }
    }  
}


//Essa classe ApplicationUser estende o modelo de usuário padrão do ASP.NET Core Identity para incluir uma propriedade adicional (RG) que é mapeada para uma coluna específica na tabela de usuários do banco de dados. Isso permite que você armazene informações adicionais sobre o usuário além das propriedades padrão fornecidas pela IdentityUser