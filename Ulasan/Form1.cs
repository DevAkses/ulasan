using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Ulasan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class User
        {
            public int id_user { get; set; }
            public string username { get; set; }
            public string role { get; set; }

        }

        private static RSA GenerateRsaKey(int keySizeInBits)
        {
            var rsa = RSA.Create();
            rsa.KeySize = keySizeInBits;
            return rsa;
        }

        public class TokenManager
        {
            private const string SecretKey = "mysecretkey";

            public static string GenerateToken(User user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var rsaKey = GenerateRsaKey(2048);

                var rsaParameters = rsaKey.ExportParameters(includePrivateParameters: false);
                var rsaSecurityKey = new RsaSecurityKey(rsaParameters);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.NameIdentifier, user.id_user.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, user.role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsaKey), SecurityAlgorithms.RsaSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            public static User ValidateToken(string token)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var rsaKey = GenerateRsaKey(2048);

                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new RsaSecurityKey(rsaKey),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                    var username = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                    var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value;

                    return new User { id_user = userId, username = username, role = role };
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=ternyatabeda;Database=token"))
            {
                connection.Open();
                string query = "select * from users where username = @username and password = @password";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Jika login berhasil, buat objek User dan token
                            User user = new User
                            {
                                id_user = (int)reader["id_user"],
                                username = (string)reader["username"],
                                role = (string)reader["role"]
                            };

                            string token = TokenManager.GenerateToken(user);

                            // Simpan token di session atau tempat penyimpanan yang sesuai
                            MessageBox.Show("Berhasil");
                            if (user.role == "admin")
                            {
                                // Tampilkan form admin
                                Form3 adminForm = new Form3(user);
                                adminForm.Show();
                            }
                            else if (user.role == "user")
                            {
                                // Tampilkan form user
                                Form2 userForm = new Form2(user);
                                userForm.Show();
                            }
                            this.Hide();
                        }
                        else
                        {
                            // Jika login gagal, tampilkan pesan kesalahan
                            MessageBox.Show("Username atau password salah.");
                        }
                    }
                }
            }
        }
    }
}