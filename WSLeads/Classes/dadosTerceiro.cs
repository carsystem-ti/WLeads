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
    public class dadosTerceiro
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
        private string _dsCliente;
        private int _tpPessoa;
        private string _dsDocumento;
        private string _dsRG;
        private string _dsOrgaoEmissor;
        private string _dtNascimento;
        private string _dsCEP;
        private string _dsEndereco;
        private string _dsNumero;
        private string _dsComplemento;
        private string _dsBairro;
        private string _dsCidade;
        private string _dsUF;
        private string _dsFoneRes;
        private string _dsFoneCel;
        private string _dsRefTerceiro;
        private string _dsEmail;

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

        public string dsCliente
        {
            get
            {
                return this._dsCliente;
            }
            set
            {
                this._dsCliente = value;
            }
        }

        public int tpPessoa
        {
            get
            {
                return this._tpPessoa;
            }
            set
            {
                this._tpPessoa = value;
            }
        }

        public string dsDocumento
        {
            get
            {
                return this._dsDocumento;
            }
            set
            {
                this._dsDocumento = value;
            }
        }

        public string dsRG
        {
            get
            {
                return this._dsRG;
            }
            set
            {
                this._dsRG = value;
            }
        }

        public string dsOrgaoEmissor
        {
            get
            {
                return this._dsOrgaoEmissor;
            }
            set
            {
                this._dsOrgaoEmissor = value;
            }
        }

        public string dtNascimento
        {
            get
            {
                return this._dtNascimento;
            }
            set
            {
                this._dtNascimento = value;
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


        public string dsRefTerceiro
        {
            get
            {
                return this._dsRefTerceiro;
            }
            set
            {
                this._dsRefTerceiro = value;
            }
        }

        public string dsEmail
        {
            get
            {
                return this._dsEmail;
            }
            set
            {
                this._dsEmail = value;
            }
        }

        #endregion

        public DataSet consultaSeChequeTerceiro()
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_GetPgtoTerceiro";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cdCT.ToString());

                dados.Comandos.tempoLimite = 300;
                return dados.dsDados;

                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_GetPgtoTerceiro'", ex);
            }
        }

        public void GravarDadosTerceiro(string cd_ct)
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosTerceiro";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@ds_Cliente", SqlDbType.VarChar, 50, _dsCliente.ToString());
                dados.Comandos.adicionaParametro("@tp_Pessoa", SqlDbType.Int, 1, _tpPessoa.ToString());
                dados.Comandos.adicionaParametro("@ds_Documento", SqlDbType.VarChar, 50, _dsDocumento.ToString()); 
                dados.Comandos.adicionaParametro("@ds_RG", SqlDbType.VarChar, 50, _dsRG.ToString());  
                dados.Comandos.adicionaParametro("@ds_OrgaoEmissor", SqlDbType.VarChar, 50, _dsOrgaoEmissor.ToString());  
                dados.Comandos.adicionaParametro("@dt_Nascimento", SqlDbType.DateTime, 8, _dtNascimento.ToString()); 
                dados.Comandos.adicionaParametro("@ds_FoneRes", SqlDbType.VarChar, 15, _dsFoneRes.ToString());
                dados.Comandos.adicionaParametro("@ds_FoneCel", SqlDbType.VarChar,15, _dsFoneCel.ToString());  
                dados.Comandos.adicionaParametro("@ds_CEP", SqlDbType.VarChar, 9, _dsCEP.ToString());  
                dados.Comandos.adicionaParametro("@ds_Endereco", SqlDbType.VarChar,100, _dsEndereco.ToString());
                dados.Comandos.adicionaParametro("@ds_Numero", SqlDbType.VarChar,10,_dsNumero.ToString());
                dados.Comandos.adicionaParametro("@ds_Complemento", SqlDbType.VarChar,50,_dsComplemento.ToString());  
                dados.Comandos.adicionaParametro("@ds_Bairro", SqlDbType.VarChar,50, _dsBairro.ToString());
                dados.Comandos.adicionaParametro("@ds_Cidade", SqlDbType.VarChar,50, _dsCidade.ToString());
                dados.Comandos.adicionaParametro("@ds_UF", SqlDbType.VarChar,2, _dsUF.ToString());
                dados.Comandos.adicionaParametro("@ds_RefTerceiro", SqlDbType.VarChar,100, _dsRefTerceiro.ToString());
                dados.Comandos.adicionaParametro("@ds_EMail", SqlDbType.VarChar,100, _dsEmail.ToString());

                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosTerceiro'", ex);
            }
        }
    }
}
