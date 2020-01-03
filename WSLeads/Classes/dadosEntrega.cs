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
    public class dadosEntrega
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
        private string _dsContato;
        private string _dsTelefone;
        private string _dsCelular;
        private string _dtEntrega;
        private string _hrInicial;
        private string _hrFinal;
        private int _cdTipoEntrega;
        private string _dsKM;
        private int _cdTipoKM;
        private string _dsLocalizacao;        
        private string _dsCEP;
        private string _dsEndereco;
        private string _dsNumero;
        private string _dsComplemento;
        private string _dsBairro;
        private string _dsCidade;
        private string _dsUF;      
        private string _dsRefEntrega;
        private string _dsObservacoes;
        private int _cdInstalacao;

        public int CdCT
        {
            get { return _cdCT; }
            set { _cdCT = value; }
        }

        public string dsContato
        {
            get
            {
                return this._dsContato;
            }
            set
            {
                this._dsContato = value;
            }
        }

        public string dsTelefone
        {
            get
            {
                return this._dsTelefone;
            }
            set
            {
                this._dsTelefone = value;
            }
        }

        public string dsCelular
        {
            get
            {
                return this._dsCelular;
            }
            set
            {
                this._dsCelular = value;
            }
        }

        public string dtEntrega
        {
            get
            {
                return this._dtEntrega;
            }
            set
            {
                this._dtEntrega = value;
            }
        }

        public string hrInicial
        {
            get
            {
                return this._hrInicial;
            }
            set
            {
                this._hrInicial = value;
            }
        }

        public string hrFinal
        {
            get
            {
                return this._hrFinal;
            }
            set
            {
                this._hrFinal = value;
            }
        }

        public int cdTipoEntrega
        {
            get
            {
                return this._cdTipoEntrega;
            }
            set
            {
                this._cdTipoEntrega = value;
            }
        }

        public string dsKM
        {
            get
            {
                return this._dsKM;
            }
            set
            {
                this._dsKM = value;
            }
        }

        public int cdTipoKM
        {
            get
            {
                return this._cdTipoKM;
            }
            set
            {
                this._cdTipoKM = value;
            }
        }

        public string dsLocalizacao
        {
            get
            {
                return this._dsLocalizacao;
            }
            set
            {
                this._dsLocalizacao = value;
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

        public string dsRefEntrega
        {
            get
            {
                return this._dsRefEntrega;
            }
            set
            {
                this._dsRefEntrega = value;
            }
        }

        public string dsObservacoes
        {
            get
            {
                return this._dsObservacoes;
            }
            set
            {
                this._dsObservacoes = value;
            }
        }

        public int CdInstalacao
        {
            get { return _cdInstalacao; }
            set { _cdInstalacao = value; }
        }

        #endregion

        public void GravarDadosEntrega(string cd_ct)
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosEntrega";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@ds_Contato", SqlDbType.Int, 100, _dsContato.ToString());
                dados.Comandos.adicionaParametro("@ds_Telefone", SqlDbType.VarChar, 15, _dsTelefone.ToString());
                dados.Comandos.adicionaParametro("@ds_Celular", SqlDbType.VarChar, 15, _dsCelular.ToString());
                dados.Comandos.adicionaParametro("@dt_Entrega", SqlDbType.DateTime, 8, Convert.ToDateTime(_dtEntrega).ToString("yyyy-MM-dd").ToString());
                dados.Comandos.adicionaParametro("@hr_Inicial", SqlDbType.DateTime, 8, Convert.ToDateTime(_hrInicial).ToString("yyyy-MM-dd").ToString()); 
                dados.Comandos.adicionaParametro("@hr_Final", SqlDbType.DateTime, 8, Convert.ToDateTime(_hrFinal).ToString("yyyy-MM-dd").ToString());
                dados.Comandos.adicionaParametro("@cd_TipoEntrega", SqlDbType.Int, 1, _cdTipoEntrega.ToString());
                dados.Comandos.adicionaParametro("@ds_KM", SqlDbType.Char, 1, _dsKM.ToString());
                dados.Comandos.adicionaParametro("@cd_TipoKM", SqlDbType.Int, 1, _cdTipoKM.ToString());
                dados.Comandos.adicionaParametro("@cd_Localizacao", SqlDbType.VarChar, 20, _dsLocalizacao.ToString());
                dados.Comandos.adicionaParametro("@ds_CEP", SqlDbType.VarChar, 9, _dsCEP.ToString());
                dados.Comandos.adicionaParametro("@ds_Endereco", SqlDbType.VarChar, 100, _dsEndereco.ToString());
                dados.Comandos.adicionaParametro("@ds_Complemento", SqlDbType.VarChar, 20, _dsComplemento.ToString());
                dados.Comandos.adicionaParametro("@ds_Numero", SqlDbType.VarChar, 10, _dsNumero.ToString());
                dados.Comandos.adicionaParametro("@ds_Bairro", SqlDbType.VarChar, 50, _dsBairro.ToString());
                dados.Comandos.adicionaParametro("@ds_Cidade", SqlDbType.VarChar, 50, _dsCidade.ToString());
                dados.Comandos.adicionaParametro("@ds_UF", SqlDbType.VarChar, 2, _dsUF.ToString());
                dados.Comandos.adicionaParametro("@ds_Referencia", SqlDbType.VarChar, 100, _dsRefEntrega.ToString());
                dados.Comandos.adicionaParametro("@ds_Obsevacoes", SqlDbType.VarChar, 8000, _dsObservacoes.ToString());
                dados.Comandos.adicionaParametro("@cd_Instalacao", SqlDbType.Int, 1, _cdInstalacao.ToString());

                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosEntrega'", ex);
            }
        }
    }
}
