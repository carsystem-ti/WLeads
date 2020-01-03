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
    public class dadosCobranca
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
        private string _dsCEP;
        private string _dsEndereco;
        private string _dsNumero;
        private string _dsComplemento;
        private string _dsBairro;
        private string _dsCidade;
        private string _dsUF;
        private string _dsFoneRes;
        private string _dsFoneCel;
        private string _dsRefCobranca;
        private string _dsContratoEscolhido;
        private string _dsFolhaPromocional;

        public string DsFolhaPromocional
        {
            get 
            { 
                return _dsFolhaPromocional; 
            }
            set 
            { 
                _dsFolhaPromocional = value; 
            }
        }

        public string DsContratoEscolhido
        {
            get
            { 
                return _dsContratoEscolhido; 
            }
            set 
            { 
                _dsContratoEscolhido = value; 
            }
        }

        public int cdCT
        {
            get
            {
                return this._cdCT;
            }
            set
            {
                this._cdCT = value;
            }
        }

        public string dsFoneRes
        {
            get
            {
                return this._dsFoneRes;
            }
            set
            {
                this._dsFoneRes = value;
            }
        }

        public string dsFoneCel
        {
            get
            {
                return this._dsFoneCel;
            }
            set
            {
                this._dsFoneCel = value;
            }
        }

        public string dsCEP
        {
            get
            {
                return this._dsCEP;
            }
            set
            {
                this._dsCEP = value;
            }
        }

        public string dsEndereco
        {
            get
            {
                return this._dsEndereco;
            }
            set
            {
                this._dsEndereco = value;
            }
        }

        public string dsNumero
        {
            get
            {
                return this._dsNumero;
            }
            set
            {
                this._dsNumero = value;
            }
        }

        public string dsComplemento
        {
            get
            {
                return this._dsComplemento;
            }
            set
            {
                this._dsComplemento = value;
            }
        }

        public string dsBairro
        {
            get
            {
                return this._dsBairro;
            }
            set
            {
                this._dsBairro = value;
            }
        }

        public string dsCidade
        {
            get
            {
                return this._dsCidade;
            }
            set
            {
                this._dsCidade = value;
            }
        }

        public string dsUF
        {
            get
            {
                return this._dsUF;
            }
            set
            {
                this._dsUF = value;
            }
        }

        public string dsRefCobranca
        {
            get
            {
                return this._dsRefCobranca;
            }
            set
            {
                this._dsRefCobranca = value;
            }
        }

        #endregion

        public void GravarDadosCobranca(string cd_ct)
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosCobranca";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@ds_FoneRes", SqlDbType.VarChar, 15, _dsFoneRes.ToString());
                dados.Comandos.adicionaParametro("@ds_FoneCel", SqlDbType.VarChar,15, _dsFoneCel.ToString());
                dados.Comandos.adicionaParametro("@ds_CEP", SqlDbType.VarChar, 9, _dsCEP.ToString());
                dados.Comandos.adicionaParametro("@ds_Endereco", SqlDbType.VarChar, 100, _dsEndereco);
                dados.Comandos.adicionaParametro("@ds_Numero", SqlDbType.VarChar, 10, _dsNumero.ToString());
                dados.Comandos.adicionaParametro("@ds_Complemento", SqlDbType.VarChar, 50, _dsComplemento.ToString());
                dados.Comandos.adicionaParametro("@ds_Bairro", SqlDbType.VarChar, 50, _dsBairro.ToString());
                dados.Comandos.adicionaParametro("@ds_Cidade", SqlDbType.VarChar, 50, _dsCidade.ToString());
                dados.Comandos.adicionaParametro("@ds_UF", SqlDbType.VarChar, 2, _dsUF.ToString());
                dados.Comandos.adicionaParametro("@ds_RefCobranca", SqlDbType.VarChar, 100, _dsRefCobranca.ToString());
                dados.Comandos.adicionaParametro("@ds_Contrato", SqlDbType.VarChar, 15, _dsContratoEscolhido.ToString());
                dados.Comandos.adicionaParametro("@ds_Folha", SqlDbType.VarChar, 15, _dsFolhaPromocional.ToString());

                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosCobranca'", ex);
            }
        }
    }
}
