using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web_api_simpsons.Modules;
using web_api_simpsons.Dependencies;
using Microsoft.AspNetCore.Cors;
using System.Data.SqlClient;


namespace web_api_simpsons.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : ICharacter
    {
        List<Character> listOfCharacters => new List<Character>
        {
            new Character
            {
                FirstName = "Homero",
                SecondName = "Jay",
                LastName = "Simpsons",
                Age = 34
            },
            new Character
            {
                FirstName = "Bart",
                SecondName = " ",
                LastName = "Simpsons",
                Age = 10
            }
            new character
            {
                FirstName = "Margory",
                SecondName = "",
                LastName = "Simpson"
                Age = 36
            }
            new character
            {
                FirstName = "Lisa"
                SecondName = "",
                LastName = "Simpson"
                Age = 9
            }
            new character
            {
                firstName = "Maggie",
                SecondName = "",
                LastName = "Simpson"
                Age = 2
            }
        };
        
        string connectionString = @"data source=LAPTOP-AMOBBGOB\SQLEXPRESS; initial catalog=db_simpsons; user id=simpsons; password=1234";


        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacters[id];
        }

        [HttpGet]
        public List<Character> GetCharacterList()
        {
            List<Character> characters = new List<Character>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from tbl_character", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Character character = new Character
                {
                    Id = reader.GetInt64(reader.GetOrdinal("id")),
                    FirstName = reader.GetString(reader.GetOrdinal("firstName"))
                };
                characters.Add(character);
            }
            conn.Close();
            return characters;
        }
    }
}