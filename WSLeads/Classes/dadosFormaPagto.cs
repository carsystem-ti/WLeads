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
    public class dadosFormaPagto
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _cdCT;
        private string _dsFormaPgto;
        private int _intParcela;
        private double _dblValor;
        private string _dsDescricao;
        private int _flTerceiro;

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

        public string dsFormaPgto
        {
            get
            {
                return this._dsFormaPgto;
            }
            set
            {
                this._dsFormaPgto = value;
            }
        }

        public int intParcela
        {
            get
            {
                return this._intParcela;
            }
            set
            {
                this._intParcela = value;
            }
        }

        public double dblValor
        {
            get
            {
                return this._dblValor;
            }
            set
            {
                this._dblValor = value;
            }
        }

        public string dsDescricao
        {
            get
            {
                return this._dsDescricao;
            }
            set
            {
                this._dsDescricao = value;
            }
        }

        public int flTerceiro
        {
            get
            {
                return this._flTerceiro;
            }
            set
            {
                this._flTerceiro = value;
            }
        }

        #endregion

        public void GravarDadosFormaPgto(string cd_ct)
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            try
            {
                dados.Comandos.textoComando = "Proc_REP_CT_Grava_DadosFormaPgto";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@cd_CT", SqlDbType.Int, 6, cd_ct.ToString());
                dados.Comandos.adicionaParametro("@ds_FormaPgto", SqlDbType.VarChar, 50, _dsFormaPgto.ToString());
                dados.Comandos.adicionaParametro("@qt_Parcelas", SqlDbType.Int, 6,_intParcela.ToString());
                dados.Comandos.adicionaParametro("@vl_parcelas", SqlDbType.Float,10, _dblValor.ToString().Replace(".", "").ToString().Replace(",", "."));
                dados.Comandos.adicionaParametro("@ds_Pagamento", SqlDbType.VarChar, 50, _dsDescricao.ToString());
                dados.Comandos.adicionaParametro("@fl_Terceiro", SqlDbType.Bit, 1, _flTerceiro.ToString());   

                dados.Comandos.tempoLimite = 300;
                dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'Proc_REP_CT_Grava_DadosFormaPgto'", ex);
            }
        }
    }
}
