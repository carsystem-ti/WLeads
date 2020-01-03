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
    public class dadosVeiculo
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
	    private string _dsPlaca;
	    private string _dsContrato;
	    private string _dsTipoVeiculo;
	    private string _dsFabricante;
	    private string _dsModelo;
	    private string _dsCor;
	    private string _dsCombustivel;
	    private string _dsAno;
	    private string _dsRenavan;
	    private string _dsChassi;
        private string _dsProduto;
	    private string _dsTipoOperacao;
        private string _dsTitularidade;
        private string _dsBancoDebitoMonitoramento;
        private string _dsAgenciaDebitoMonitoramento;
        private string _dsContaCorrenteDebitoMonitoramento;
        private string _dsRgDebitoMonitoramento;
        private Int64 _dsCpfCnpjDebitoMonitoramento;
        private string _dsNomeDebitoMonitoramento;

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

        public string dsPlaca
        {
            get
            {
                return this._dsPlaca;
            }
            set
            {
                this._dsPlaca = value;
            }
        }

        public string dsContrato
        {
            get
            {
                return this._dsContrato;
            }
            set
            {
                this._dsContrato = value;
            }
        }

        public string dsTipoVeiculo
        {
            get
            {
                return this._dsTipoVeiculo;
            }
            set
            {
                this._dsTipoVeiculo = value;
            }
        }

        public string dsFabricante
        {
            get
            {
                return this._dsFabricante;
            }
            set
            {
                this._dsFabricante = value;
            }
        }

        public string dsModelo
        {
            get
            {
                return this._dsModelo;
            }
            set
            {
                this._dsModelo = value;
            }
        }

        public string dsCor
        {
            get
            {
                return this._dsCor;
            }
            set
            {
                this._dsCor = value;
            }
        }

        public string dsCombustivel
        {
            get
            {
                return this._dsCombustivel;
            }
            set
            {
                this._dsCombustivel = value;
            }
        }

        public string dsAno
        {
            get
            {
                return this._dsAno;
            }
            set
            {
                this._dsAno = value;
            }
        }

        public string dsRenavan
        {
            get
            {
                return this._dsRenavan;
            }
            set
            {
                this._dsRenavan = value;
            }
        }

        public string dsChassi
        {
            get
            {
                return this._dsChassi;
            }
            set
            {
                this._dsChassi = value;
            }
        }

        public string dsProduto
        {
            get
            {
                return this._dsProduto;
            }
            set
            {
                this._dsProduto = value;
            }
        }

        public string dsTipoOperacao
        {
            get
            {
                return this._dsTipoOperacao;
            }
            set
            {
                this._dsTipoOperacao = value;
            }
        }

        public string dsTitularidade
        {
            get
            {
                return this._dsTitularidade;
            }
            set
            {
                this._dsTitularidade = value;
            }
        }

        public String dsBancoDebitoMonitoramento
        {
            get
            {
                return this._dsBancoDebitoMonitoramento;
            }
            set
            {
                this._dsBancoDebitoMonitoramento = value;
            }
        }

        public String dsAgenciaDebitoMonitoramento
        {
            get
            {
                return this._dsAgenciaDebitoMonitoramento;
            }
            set
            {
                this._dsAgenciaDebitoMonitoramento = value;
            }
        }

        public String dsContaCorrenteDebitoMonitoramento
        {
            get
            {
                return this._dsContaCorrenteDebitoMonitoramento;
            }
            set
            {
                this._dsContaCorrenteDebitoMonitoramento = value;
            }
        }

        public string DsRgDebitoMonitoramento
        {
            get 
            { 
                return this._dsRgDebitoMonitoramento; 
            }
            set 
            { 
                this._dsRgDebitoMonitoramento = value; 
            }
        }

        public Int64 DsCpfCnpjDebitoMonitoramento
        {
            get 
            { 
                return this._dsCpfCnpjDebitoMonitoramento; 
            }
            set 
            { 
                this._dsCpfCnpjDebitoMonitoramento = value; 
            }
        }

        public string DsNomeDebitoMonitoramento
        {
            get 
            { 
                return this._dsNomeDebitoMonitoramento; 
            }
            set 
            { 
                this._dsNomeDebitoMonitoramento = value; 
            }
        }

        #endregion

        public void GravarDadosVeiculo(string cd_ct)
        {

            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosVeiculo";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@ds_Placa", SqlDbType.VarChar, 7,_dsPlaca.ToString());    
                dados.Comandos.adicionaParametro("@ds_Contrato", SqlDbType.VarChar,6 ,_dsContrato.ToString());
                dados.Comandos.adicionaParametro("@ds_TipoVeiculo", SqlDbType.VarChar,50,_dsTipoVeiculo.ToString());
                dados.Comandos.adicionaParametro("@ds_Fabricante", SqlDbType.VarChar,50,_dsFabricante.ToString());
                dados.Comandos.adicionaParametro("@ds_Modelo", SqlDbType.VarChar,50,_dsModelo.ToString());
                dados.Comandos.adicionaParametro("@ds_Cor", SqlDbType.VarChar,50,_dsCor.ToString());
                dados.Comandos.adicionaParametro("@ds_Combustivel", SqlDbType.VarChar,50,_dsCombustivel.ToString());
                dados.Comandos.adicionaParametro("@ds_Ano", SqlDbType.VarChar,50,_dsAno.ToString());
                dados.Comandos.adicionaParametro("@ds_Renavan", SqlDbType.VarChar,50,_dsRenavan.ToString());
                dados.Comandos.adicionaParametro("@ds_Chassi", SqlDbType.VarChar,50,_dsChassi.ToString());
                dados.Comandos.adicionaParametro("@ds_Produto", SqlDbType.VarChar,100,_dsProduto.ToString());
                dados.Comandos.adicionaParametro("@ds_TipoOperacao", SqlDbType.Char,1,_dsTipoOperacao.ToString());
                dados.Comandos.adicionaParametro("@ds_Titularidade", SqlDbType.Char,1,_dsTitularidade.ToString());



                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosVeiculo'", ex);
            }
        }
    }
}
