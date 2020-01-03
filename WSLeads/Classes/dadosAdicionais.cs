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
    public class dadosAdicionais
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

        private int _cdNacionalidade;
        public int CdNacionalidade
        {
            get { return _cdNacionalidade; }
            set { _cdNacionalidade = value; }
        }

        private int _cdEstadoCivil;
        public int CdEstadoCivil
        {
            get { return _cdEstadoCivil; }
            set { _cdEstadoCivil = value; }
        }

        private int _cdResidencia;
        public int CdResidencia
        {
            get { return _cdResidencia; }
            set { _cdResidencia = value; }
        }

        private string _dsTempoResidencia;
        public string DsTempoResidencia
        {
            get { return _dsTempoResidencia; }
            set { _dsTempoResidencia = value; }
        }

        private string _dsNomeMae;
        public string DsNomeMae
        {
            get { return _dsNomeMae; }
            set { _dsNomeMae = value; }
        }

        private string _dsDependentes;
        public string DsDependentes
        {
            get { return _dsDependentes; }
            set { _dsDependentes = value; }
        }

        private int _cdOcupacao;
        public int CdOcupacao
        {
            get { return _cdOcupacao; }
            set { _cdOcupacao = value; }
        }

        private string _dsFuncao;
        public string DsFuncao
        {
            get { return _dsFuncao; }
            set { _dsFuncao = value; }
        }

        private string _dsAdmissao;
        public string DsAdmissao
        {
            get { return _dsAdmissao; }
            set { _dsAdmissao = value; }
        }

        private double _dsSalario;
        public double DsSalario
        {
            get { return _dsSalario; }
            set { _dsSalario = value; }
        }

        private string _dsEmpregador;
        public string DsEmpregador
        {
            get { return _dsEmpregador; }
            set { _dsEmpregador = value; }
        }

        private int _cdTipoEmpresa;
        public int CdTipoEmpresa
        {
            get { return _cdTipoEmpresa; }
            set { _cdTipoEmpresa = value; }
        }

        private string _dsRefPessoal1;
        public string DsRefPessoal1
        {
            get { return _dsRefPessoal1; }
            set { _dsRefPessoal1 = value; }
        }

        private string _dsRefPessoal2;
        public string DsRefPessoal2
        {
            get { return _dsRefPessoal2; }
            set { _dsRefPessoal2 = value; }
        }

        private int _cdRelacao1;
        public int CdRelacao1
        {
            get { return _cdRelacao1; }
            set { _cdRelacao1 = value; }
        }

        private int _cdRelacao2;
        public int CdRelacao2
        {
            get { return _cdRelacao2; }
            set { _cdRelacao2 = value; }
        }

        private string _dsContato1;
        public string DsContato1
        {
            get { return _dsContato1; }
            set { _dsContato1 = value; }
        }

        private string _dsContato2;
        public string DsContato2
        {
            get { return _dsContato2; }
            set { _dsContato2 = value; }
        }

        private string _dsOutrosTelefones;
        public string DsOutrosTelefones
        {
            get { return _dsOutrosTelefones; }
            set { _dsOutrosTelefones = value; }
        }

        private string _dsSocio;
        public string DsSocio
        {
            get { return _dsSocio; }
            set { _dsSocio = value; }
        }

        private string _dsCNPJ;
        public string DsCNPJ
        {
            get { return _dsCNPJ; }
            set { _dsCNPJ = value; }
        }

        private string _dsContador;
        public string DsContador
        {
            get { return _dsContador; }
            set { _dsContador = value; }
        }

        private string _dsTelContador;
        public string DsTelContador
        {
            get { return _dsTelContador; }
            set { _dsTelContador = value; }
        }

        private string _dsCartao;
        public string DsCartao
        {
            get { return _dsCartao; }
            set { _dsCartao = value; }
        }

        private string _dsBanco;
        public string DsBanco
        {
            get { return _dsBanco; }
            set { _dsBanco = value; }
        }

        private string _dsAgencia;
        public string DsAgencia
        {
            get { return _dsAgencia; }
            set { _dsAgencia = value; }
        }

        private string _dsAgenciaDig;
        public string DsAgenciaDig
        {
            get { return _dsAgenciaDig; }
            set { _dsAgenciaDig = value; }
        }

        private string _dsConta;
        public string DsConta
        {
            get { return _dsConta; }
            set { _dsConta = value; }
        }

        private string _dsContaDig;
        public string DsContaDig
        {
            get { return _dsContaDig; }
            set { _dsContaDig = value; }
        }

        private string _dsClienteDesde;
        public string DsClienteDesde
        {
            get { return _dsClienteDesde; }
            set { _dsClienteDesde = value; }
        }

        #endregion

        public void GravarDadosAdicionais(string cd_ct)
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosAdicionais";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@cd_Nacionalidade", SqlDbType.Int, 6,_cdNacionalidade.ToString());
                dados.Comandos.adicionaParametro("@cd_EstadoCivil", SqlDbType.Int, 6,_cdEstadoCivil.ToString());
                dados.Comandos.adicionaParametro("@cd_Residencia", SqlDbType.Int, 6,_cdResidencia.ToString());
                dados.Comandos.adicionaParametro("@ds_TempoResidencia", SqlDbType.VarChar, 6,_dsTempoResidencia.ToString());
                dados.Comandos.adicionaParametro("@ds_NomeMae", SqlDbType.VarChar, 100,_dsNomeMae.ToString());
                dados.Comandos.adicionaParametro("@ds_Dependentes", SqlDbType.VarChar, 2,_dsDependentes.ToString());
                dados.Comandos.adicionaParametro("@cd_Ocupacao", SqlDbType.Int, 6,_cdOcupacao.ToString());
                dados.Comandos.adicionaParametro("@ds_Funcao", SqlDbType.VarChar, 50,_dsFuncao.ToString());
                dados.Comandos.adicionaParametro("@ds_Admissao", SqlDbType.VarChar, 4,_dsAdmissao.ToString());
                dados.Comandos.adicionaParametro("@ds_Salario", SqlDbType.Float, 15,_dsSalario.ToString().Replace(".", "").ToString().Replace(",", ".").ToString());
                dados.Comandos.adicionaParametro("@ds_Empregadora", SqlDbType.VarChar, 100,_dsEmpregador.ToString());
                dados.Comandos.adicionaParametro("@cd_TipoEmpresa", SqlDbType.Int, 6,_cdTipoEmpresa.ToString());
                dados.Comandos.adicionaParametro("@ds_RefPessoal1", SqlDbType.VarChar, 100,_dsRefPessoal1.ToString());
                dados.Comandos.adicionaParametro("@ds_RefPessoal2", SqlDbType.VarChar, 100,_dsRefPessoal2.ToString());
                dados.Comandos.adicionaParametro("@cd_Relacao1", SqlDbType.Int, 6,_cdRelacao1.ToString());
                dados.Comandos.adicionaParametro("@cd_Relacao2", SqlDbType.Int, 6,_cdRelacao2.ToString());
                dados.Comandos.adicionaParametro("@ds_Contato1", SqlDbType.VarChar, 15,_dsContato1.ToString());
                dados.Comandos.adicionaParametro("@ds_Contato2", SqlDbType.VarChar, 15,_dsContato2.ToString());
                dados.Comandos.adicionaParametro("@ds_OutrosTelefones", SqlDbType.VarChar, 50,_dsOutrosTelefones.ToString());
                dados.Comandos.adicionaParametro("@ds_Socio", SqlDbType.Char, 1,_dsSocio.ToString());
                dados.Comandos.adicionaParametro("@ds_Documento", SqlDbType.VarChar, 18,_dsCNPJ.ToString());
                dados.Comandos.adicionaParametro("@ds_Contador", SqlDbType.VarChar, 100,_dsContador.ToString());
                dados.Comandos.adicionaParametro("@ds_TelContador", SqlDbType.VarChar, 15,_dsTelContador.ToString());
                dados.Comandos.adicionaParametro("@ds_Cartao", SqlDbType.Char, 1,_dsCartao.ToString());
                dados.Comandos.adicionaParametro("@cd_Banco", SqlDbType.Int, 6,_dsBanco.ToString());
                dados.Comandos.adicionaParametro("@ds_Agencia", SqlDbType.VarChar, 10,_dsAgencia.ToString());
                dados.Comandos.adicionaParametro("@ds_AgenciaDig", SqlDbType.VarChar, 2,_dsAgenciaDig.ToString());
                dados.Comandos.adicionaParametro("@ds_Conta", SqlDbType.VarChar, 20,_dsConta.ToString());
                dados.Comandos.adicionaParametro("@ds_ContaDig", SqlDbType.VarChar, 2,_dsContaDig.ToString());
                dados.Comandos.adicionaParametro("@ds_DataConta", SqlDbType.VarChar, 7,_dsClienteDesde.ToString());

                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosAdicionais'", ex);
            }
        }
    }
}
