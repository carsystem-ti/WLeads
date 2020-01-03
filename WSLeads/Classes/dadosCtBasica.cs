using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WS_sossego
{
    public class dadosCtBasica
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private string _ds_nomeCliente;
        public string Ds_nomeCliente
        {
            get { return _ds_nomeCliente; }
            set { _ds_nomeCliente = value; }
        }
        private string _ds_telResidencial;
        public string Ds_telResidencial
        {
            get { return _ds_telResidencial; }
            set { _ds_telResidencial = value; }
        }
        private string _ds_telCelular;
        public string Ds_telCelular
        {
            get { return _ds_telCelular; }
            set { _ds_telCelular = value; }
        }
        private string _cd_codigoMidia;
        public string Cd_codigoMidia
        {
            get { return _cd_codigoMidia; }
            set { _cd_codigoMidia = value; }
        }

        private string _ds_vendedor;
        public string Ds_vendedor
        {
            get { return _ds_vendedor; }
            set { _ds_vendedor = value; }
        }

        private string _cd_vendedor;
        public string Cd_vendedor
        {
            get { return _cd_vendedor; }
            set { _cd_vendedor = value; }
        }

        private string _cd_supervisor;
        public string Cd_supervisor
        {
            get { return _cd_supervisor; }
            set { _cd_supervisor = value; }
        }

        #endregion

        public DataSet set_CT_dadosIncompletos()
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            verificaDados();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_CT_Leads";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@ds_nomeCliente", SqlDbType.VarChar, 106, _ds_nomeCliente.ToString());
                dados.Comandos.adicionaParametro("@ds_telResidencial", SqlDbType.VarChar, 50, _ds_telResidencial.ToString());
                dados.Comandos.adicionaParametro("@ds_telCelular", SqlDbType.VarChar, 50, _ds_telCelular).ToString();
                dados.Comandos.adicionaParametro("@cd_codigoMidia", SqlDbType.VarChar, 3, _cd_codigoMidia.ToString());
                dados.Comandos.adicionaParametro("@ds_vendedor", SqlDbType.VarChar, 20, _ds_vendedor);
                dados.Comandos.adicionaParametro("@cd_vendedor", SqlDbType.VarChar, 6, _cd_vendedor);
                dados.Comandos.adicionaParametro("@cd_supervisor", SqlDbType.VarChar, 6, _cd_supervisor);

                dados.Comandos.tempoLimite = 300;
                dados.retornaDados = true;

                return dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_CT_Leads'", ex);
            }
        }

        private void verificaDados()
        {
            WS_sossego.dadosCtBasica dct = new dadosCtBasica();

            if (dct.Ds_vendedor == null)
            {
                dct.Ds_vendedor = DBNull.Value.ToString();
            }

            if (dct.Cd_vendedor == null)
            {
                dct.Cd_vendedor = DBNull.Value.ToString();
            }

            if (dct.Cd_supervisor == null)
            {
                dct.Cd_supervisor = DBNull.Value.ToString();
            }
        }
    }
}
