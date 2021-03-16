using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                    cmd.Parameters.Add(new SqlParameter("@imageBase64", user.imageBase64));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }

        }

    }
}
