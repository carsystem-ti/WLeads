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
    public class dadosPessoais
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
        public int CdCT
        {
            get { return _cdCT; }
            set { _cdCT = value; }
        }

        private string _dsCliente;
        public string DsCliente
        {
            get { return _dsCliente; }
            set { _dsCliente = value; }
        }

        private int _tpPessoa;
        public int TpPessoa
        {
            get { return _tpPessoa; }
            set { _tpPessoa = value; }
        }

        private string _dsDocumento;
        public string DsDocumento
        {
            get { return _dsDocumento; }
            set { _dsDocumento = value; }
        }

        private string _dsRG;
        public string DsRG
        {
            get { return _dsRG; }
            set { _dsRG = value; }
        }

        private string _dsOrgaoEmissor;
        public string DsOrgaoEmissor
        {
            get { return _dsOrgaoEmissor; }
            set { _dsOrgaoEmissor = value; }
        }

        private string _dtNascimento;
        public string DtNascimento
        {
            get { return _dtNascimento; }
            set { _dtNascimento = value; }
        }

        private string _dsSexo;
        public string DsSexo
        {
            get { return _dsSexo; }
            set { _dsSexo = value; }
        }

        private string _dsFoneRes;
        public string DsFoneRes
        {
            get { return _dsFoneRes; }
            set { _dsFoneRes = value; }
        }

        private string _dsFoneCel;
        public string DsFoneCel
        {
            get { return _dsFoneCel; }
            set { _dsFoneCel = value; }
        }

        private string _dsCEP;
        public string DsCEP
        {
            get { return _dsCEP; }
            set { _dsCEP = value; }
        }

        private string _dsEndereco;
        public string DsEndereco
        {
            get { return _dsEndereco; }
            set { _dsEndereco = value; }
        }

        private string _dsNumero;
        public string DsNumero
        {
            get { return _dsNumero; }
            set { _dsNumero = value; }
        }

        private string _dsComplemento;
        public string DsComplemento
        {
            get { return _dsComplemento; }
            set { _dsComplemento = value; }
        }

        private string _dsBairro;
        public string DsBairro
        {
            get { return _dsBairro; }
            set { _dsBairro = value; }
        }

        private string _dsCidade;
        public string DsCidade
        {
            get { return _dsCidade; }
            set { _dsCidade = value; }
        }

        private string _dsUF;
        public string DsUF
        {
            get { return _dsUF; }
            set { _dsUF = value; }
        }

        private string _dsRegiao;
        public string DsRegiao
        {
            get { return _dsRegiao; }
            set { _dsRegiao = value; }
        }

        private string _dsRefResidencial;
        public string DsRefResidencial
        {
            get { return _dsRefResidencial; }
            set { _dsRefResidencial = value; }
        }

        private string _dsEmail;
        public string DsEmail
        {
            get { return _dsEmail; }
            set { _dsEmail = value; }
        }

        private string _dsUsuarioCriacao;
        public string DsUsuarioCriacao
        {
            get { return _dsUsuarioCriacao; }
            set { _dsUsuarioCriacao = value; }
        }

        private string _dsVendedor;
        public string DsVendedor
        {
            get { return _dsVendedor; }
            set { _dsVendedor = value; }
        }

        private string _dsSupervisor;
        public string DsSupervisor
        {
            get { return _dsSupervisor; }
            set { _dsSupervisor = value; }
        }

        private string _dsMidia;
        public string DsMidia
        {
            get { return _dsMidia; }
            set { _dsMidia = value; }
        }

        #endregion

        public DataSet GravarDadosPessoais()
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosPessoais";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, _cdCT.ToString());
                dados.Comandos.adicionaParametro("@ds_Cliente", SqlDbType.VarChar, 50, _dsCliente.ToString());
                dados.Comandos.adicionaParametro("@tp_Pessoa", SqlDbType.Int, 6, _tpPessoa.ToString());
                dados.Comandos.adicionaParametro("@ds_Documento", SqlDbType.VarChar, 50, _dsDocumento.ToString());
                dados.Comandos.adicionaParametro("@ds_RG", SqlDbType.VarChar, 50, _dsRG.ToString());
                dados.Comandos.adicionaParametro("@ds_OrgaoEmissor", SqlDbType.VarChar, 50, _dsOrgaoEmissor.ToString());
                dados.Comandos.adicionaParametro("@dt_Nascimento", SqlDbType.DateTime, 8, Convert.ToDateTime(_dtNascimento).ToString("yyyy-MM-dd").ToString());
                dados.Comandos.adicionaParametro("@ds_Sexo", SqlDbType.Char, 1, _dsSexo.ToString());
                dados.Comandos.adicionaParametro("@ds_FoneRes", SqlDbType.VarChar, 15, _dsFoneRes.ToString());
                dados.Comandos.adicionaParametro("@ds_FoneCel", SqlDbType.VarChar, 15, _dsFoneCel.ToString());
                dados.Comandos.adicionaParametro("@ds_CEP", SqlDbType.VarChar, 9, _dsCEP.ToString());
                dados.Comandos.adicionaParametro("@ds_Endereco", SqlDbType.VarChar, 100, _dsEndereco.ToString());
                dados.Comandos.adicionaParametro("@ds_Numero", SqlDbType.VarChar, 10, _dsNumero.ToString());
                dados.Comandos.adicionaParametro("@ds_Complemento", SqlDbType.VarChar, 50, _dsComplemento.ToString());
                dados.Comandos.adicionaParametro("@ds_Bairro", SqlDbType.VarChar, 50, _dsBairro.ToString());
                dados.Comandos.adicionaParametro("@ds_Cidade", SqlDbType.VarChar, 50, _dsCidade.ToString());
                dados.Comandos.adicionaParametro("@ds_UF", SqlDbType.VarChar, 2, _dsUF.ToString());
                dados.Comandos.adicionaParametro("@ds_Regiao", SqlDbType.VarChar, 50, _dsRegiao.ToString());
                dados.Comandos.adicionaParametro("@ds_RefResidencial", SqlDbType.VarChar, 100, _dsRefResidencial.ToString());
                dados.Comandos.adicionaParametro("@ds_Email", SqlDbType.VarChar, 100, _dsEmail.ToString());
                dados.Comandos.adicionaParametro("@Operador_Inclusao", SqlDbType.VarChar, 30, _dsUsuarioCriacao.ToString());
                dados.Comandos.adicionaParametro("@Codigo_Vendedor", SqlDbType.VarChar, 6, _dsVendedor.ToString());
                dados.Comandos.adicionaParametro("@Codigo_Supervisor", SqlDbType.VarChar, 6, _dsSupervisor.ToString());
                dados.Comandos.adicionaParametro("@IdMidia", SqlDbType.VarChar, 3, _dsMidia.ToString());

                dados.Comandos.tempoLimite = 300;
                return dados.dsDados;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosPessoais'", ex);
            }
        }
    }
}
