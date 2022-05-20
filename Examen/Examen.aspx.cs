using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using System.Linq;
using System.Web.Services;

namespace Examen
{
    public partial class Examen : System.Web.UI.Page
    {
        private string srtParameters;
        private string url = "https://apitestcotizamatico.azurewebsites.net/api/catalogos";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                llenaComboInicial();
        }

        private void llenaComboInicial()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ddlSubmarca.Items.Clear();
            ddlModelo.Items.Clear();
            ddlDesc.Items.Clear();

            var obj = new
            {
                NombreCatalogo = "Marca",
                Filtro = "1",
                IdAplication = "2"
            };

            srtParameters = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(srtParameters, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var response = client.PostAsync(url, content).Result;
            dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
            var list = JsonConvert.DeserializeObject<List<Marcas>>(data["CatalogoJsonString"].ToString());
            ListItem i = null;
            i = new ListItem("Selecciona una Marca", "0");
            ddlMarca.Items.Add(i);

            foreach (var item in list)
            {
                i = new ListItem(item.sMarca, Convert.ToString(item.iIdMarca));
                ddlMarca.Items.Add(i);
            }
        }

        public void ddlMarca_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlMarca.SelectedValue.ToString() != null)
            {
                ddlSubmarca.Items.Clear();
                ddlModelo.Items.Clear();
                ddlDesc.Items.Clear();

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    NombreCatalogo = "Submarca",
                    Filtro = ddlMarca.SelectedValue,
                    IdAplication = "2"
                };

                srtParameters = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(srtParameters, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(url, content).Result;
                dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
                var list = JsonConvert.DeserializeObject<List<SubMarcas>>(data["CatalogoJsonString"].ToString());
                ListItem i = null;
                i = new ListItem("Selecciona una Submarca", "0");
                ddlSubmarca.Items.Add(i);

                foreach (var item in list)
                {
                    i = new ListItem(item.sSubMarca, Convert.ToString(item.iIdSubMarca));
                    ddlSubmarca.Items.Add(i);
                }
            }
        }

        public void ddlSubmarca_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlSubmarca.SelectedValue.ToString() != null)
            {
                ddlModelo.Items.Clear();
                ddlDesc.Items.Clear();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    NombreCatalogo = "Modelo",
                    Filtro = ddlSubmarca.SelectedValue,
                    IdAplication = "2"
                };

                srtParameters = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(srtParameters, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(url, content).Result;
                dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
                var list = JsonConvert.DeserializeObject<List<Modelo>>(data["CatalogoJsonString"].ToString());
                ListItem i = null;
                i = new ListItem("Selecciona un Modelo", "0");
                ddlModelo.Items.Add(i);

                foreach (var item in list)
                {
                    i = new ListItem(item.sModelo, Convert.ToString(item.iIdModelo));
                    ddlModelo.Items.Add(i);
                }
            }
        }

        public void ddlModelo_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlModelo.SelectedValue.ToString() != null)
            {
                ddlDesc.Items.Clear();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    NombreCatalogo = "DescripcionModelo",
                    Filtro = ddlModelo.SelectedValue,
                    IdAplication = "2"
                };

                srtParameters = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(srtParameters, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(url, content).Result;
                dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
                var list = JsonConvert.DeserializeObject<List<DescModelo>>(data["CatalogoJsonString"].ToString());
                ListItem i = null;
                i = new ListItem("Selecciona un Modelo", "0");
                ddlDesc.Items.Add(i);

                foreach (var item in list)
                {
                    i = new ListItem(item.sDescripcion, Convert.ToString(item.iIdDescripcionModelo));
                    ddlDesc.Items.Add(i);
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            txtEstado.Text = "";
            txtMunicipio.Text = "";
            txtColonia.Text = "";

            var obj = new
            {
                NombreCatalogo = "Sepomex",
                Filtro = txtCP.Text,
                IdAplication = "2"
            };

            srtParameters = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(srtParameters, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.PostAsync(url, content).Result;
            dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
            dynamic data2 = JsonConvert.DeserializeObject(data["CatalogoJsonString"].Value);

            txtEstado.Text = data2[0]["Municipio"]["Estado"]["sEstado"];
            txtMunicipio.Text = data2[0]["Municipio"]["sMunicipio"];
            txtColonia.Text = data2[0]["Ubicacion"][0]["sUbicacion"];
        }
    }

    public class Marcas
    {
        public int iIdMarca { get; set; }
        public string sMarca { get; set; }
    }

    public class SubMarcas
    {
        public int iIdSubMarca { get; set; }
        public string sSubMarca { get; set; }
    }

    public class Modelo
    {
        public int iIdModelo { get; set; }
        public string sModelo{ get; set; }
    }

    public class DescModelo
    {
        public int iIdDescripcionModelo { get; set; }
        public string sDescripcion { get; set; }
    }
    
}