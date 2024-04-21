using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using PruebaREST.Clases.cs;

namespace PruebaREST.CSU
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("https://randomuser.me/api/");
            string Respuesta;

            RestRequest request = new RestRequest();
            var response = client.Get(request);

            Respuesta = response.Content;

            Resultados oResultado = JsonConvert.DeserializeObject<Resultados>(Respuesta);

            Usuario oUsuario = oResultado.results[0];

            imgUsuario.ImageUrl = oUsuario.picture.large;
            txtTitulo.Text = oUsuario.name.title;
            txtNombres.Text = oUsuario.name.first;
            txtApellidos.Text = oUsuario.name.last;
            txtUsuario.Text = oUsuario.login.username;
            txtPass.Text = oUsuario.login.password;


        }
    }
}