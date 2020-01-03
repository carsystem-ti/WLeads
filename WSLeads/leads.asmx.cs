using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace WS_sossego
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod(Description = "Cadastro Leads")]
        public string cadastro_Leads(WSLeads.cadastroLeads cd)
        {
           // DataSet ds_dados;
           // string strDados;
            int retorno = 0;
            //ds_dados = cd.pro_setLeadsCadastro();

            retorno = cd.pro_setLeadsCadastro();
            ///strDados = ds_dados.Tables[0].Rows[0]["ds_retorno"].ToString();

            return retorno.ToString();
        }
        [WebMethod(Description = "teste")]
        public string teste()
        {
            // DataSet ds_dados;
            // string strDados;
            int retorno = 0;
            //ds_dados = cd.pro_setLeadsCadastro();

            //retorno = cd.pro_setLeadsCadastro();
            ///strDados = ds_dados.Tables[0].Rows[0]["ds_retorno"].ToString();

            return retorno.ToString();
        }
    }
}
