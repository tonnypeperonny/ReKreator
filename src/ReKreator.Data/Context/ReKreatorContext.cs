using Microsoft.AspNet.Identity.EntityFramework;
using ReKreator.Data.Models;

namespace ReKreator.Data.Context
{
    public class ReKreatorContext : IdentityDbContext<User>
    {
        public static ReKreatorContext Create()
        {
            return new ReKreatorContext();
        }

        public ReKreatorContext()
            : base("ReKreatorDb")
        {

        }
    }
}