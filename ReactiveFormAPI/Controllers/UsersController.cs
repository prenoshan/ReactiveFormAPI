using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ReactiveFormAPI.Common;
using ReactiveFormAPI.Models;

namespace ReactiveFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        public async Task Insert(User user)
        {
            using (SqlConnection sql = new SqlConnection(Global.ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("insert_UserDetails", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@email", user.email));
                    cmd.Parameters.Add(new SqlParameter("@password", user.password));
                    cmd.Parameters.Add(new SqlParameter("@imageBase64", user.image));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }

    }
}
