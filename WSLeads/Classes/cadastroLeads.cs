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
using System.Web.Configuration;
using System.Data.SqlClient;

namespace WSLeads
{
    public class cadastroLeads
    {
        private string strBanco = "Principal";
        private string strUser = "usr_web";
        private string strSenha = "premium";

        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;


        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados();

        #region Atributos e Propriedades da Classe

        private int _tpStatus;
        public int TpStatus
        {
            get { return _tpStatus; }
            set { _tpStatus = value; }
        }

        private int _tpEvento;
        public int TpEvento
        {
            get { return _tpEvento; }
            set { _tpEvento = value; }
        }

        private string _dsNome;
        public string DsNome
        {
            get { return _dsNome; }
            set { _dsNome = value; }
        }

        private string _dsEmail;
        public string DsEmail
        {
            get { return _dsEmail; }
            set { _dsEmail = value; }
        }

        private string _nrdddTelFixo;
        public string NrdddTelFixo
        {
            get { return _nrdddTelFixo; }
            set { _nrdddTelFixo = value; }
        }

        private string _nrTelefoneFixo;
        public string NrTelefoneFixo
        {
            get { return _nrTelefoneFixo; }
            set { _nrTelefoneFixo = value; }
        }

        private string _nrdddCelular;
        public string NrdddCelular
        {
            get { return _nrdddCelular; }
            set { _nrdddCelular = value; }
        }

        private string _nrCelular;
        public string NrCelular
        {
            get { return _nrCelular; }
            set { _nrCelular = value; }
        }

        private int _nrTipoVeiculo;
        public int NrTipoVeiculo
        {
            get { return _nrTipoVeiculo; }
            set { _nrTipoVeiculo = value; }
        }

        private string _dsVeiculo;
        public string DsVeiculo
        {
            get { return _dsVeiculo; }
            set { _dsVeiculo = value; }
        }

        private string _dsModeloVeiculo;
        public string DsModeloVeiculo
        {
            get { return _dsModeloVeiculo; }
            set { _dsModeloVeiculo = value; }
        }

        private int _nrAnoVeiculo;
        public int NrAnoVeiculo
        {
            get { return _nrAnoVeiculo; }
            set { _nrAnoVeiculo = value; }
        }

        private string _dsMensagem;
        public string DsMensagem
        {
            get { return _dsMensagem; }
            set { _dsMensagem = value; }
        }

        private string _nrLoja;
        public string NrLoja
        {
            get { return _nrLoja; }
            set { _nrLoja = value; }
        }

        private string _nrdddComercial;
        public string NrdddComercial
        {
            get { return _nrdddComercial; }
            set { _nrdddComercial = value; }
        }

        private string _nrComercial;
        public string NrComercial
        {
            get { return _nrComercial; }
            set { _nrComercial = value; }
        }

        private string _dsComplemento;
        public string DsComplemento
        {
            get { return _dsComplemento; }
            set { _dsComplemento = value; }
        }

        private string _idMidia;
        public string IdMidia
        {
            get { return _idMidia; }
            set { _idMidia = value; }
        }

        private int _idMotivo;
        public int IdMotivo
        {
            get { return _idMotivo; }
            set { _idMotivo = value; }
        }

        private string _dsVendedor;
        public string Dsvendedor
        {
            get { return _dsVendedor; }
            set { _dsVendedor = value; }
        }

        private int _idEmpresa;
        public int IdEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        private string _dsLoja;
        public string DsLoja
        {
            get { return _dsLoja; }
            set { _dsLoja = value; }
        }

        private int _nrAno;
        public int NrAno
        {
            get { return _nrAno; }
            set { _nrAno = value; }
        }

        #endregion

        public DataSet set_cadastro()
        {
            dados.Conexoes.bancoDados = strBanco;
            dados.Conexoes.usuario = strUser;
            dados.Conexoes.senha = strSenha;

            dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
            dados.Comandos.limpaParametros();

            verificaDados();

            try
            {
                dados.Comandos.textoComando = "[CRM].[pro_setGravaLeads]";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro("@id_status", SqlDbType.Int, 3, _tpStatus.ToString());
                dados.Comandos.adicionaParametro("@id_tipoEvento", SqlDbType.Int, 3, _tpEvento.ToString());
                dados.Comandos.adicionaParametro("@ds_nome", SqlDbType.VarChar, 40, _dsNome.ToString());
                dados.Comandos.adicionaParametro("@nr_dddTelefone", SqlDbType.Char, 2, _nrdddTelFixo.ToString());
                dados.Comandos.adicionaParametro("@nr_telefone", SqlDbType.VarChar, 13, _nrTelefoneFixo.ToString());
                dados.Comandos.adicionaParametro("@nr_dddCelular", SqlDbType.Char, 2, _nrdddCelular.ToString());
                dados.Comandos.adicionaParametro("@id_midia", SqlDbType.Char, 3, _idMidia.ToString());
                dados.Comandos.adicionaParametro("@id_empresa", SqlDbType.Int, 3, _idEmpresa.ToString());
                dados.Comandos.adicionaParametro("@id_motivo", SqlDbType.Int, 3, _idMotivo.ToString());
                dados.Comandos.adicionaParametro("@nr_tipoVeiculo", SqlDbType.Int, 2, _nrTipoVeiculo);
                dados.Comandos.adicionaParametro("@nr_celular", SqlDbType.VarChar, 13, _nrCelular);
                dados.Comandos.adicionaParametro("@nr_dddComercial", SqlDbType.Char, 2, _nrdddComercial);

                dados.Comandos.adicionaParametro("@nr_comercial", SqlDbType.VarChar, 13, _nrComercial);
                dados.Comandos.adicionaParametro("@ds_email", SqlDbType.VarChar, 60, _dsEmail);
                dados.Comandos.adicionaParametro("@ds_complemento", SqlDbType.VarChar, 60, _dsComplemento);
                dados.Comandos.adicionaParametro("@modelo", SqlDbType.VarChar, 40, _dsModeloVeiculo);
                dados.Comandos.adicionaParametro("@ano", SqlDbType.Int, 4, _nrAno);
                dados.Comandos.adicionaParametro("@vendedorExterno", SqlDbType.VarChar, 30, _dsVendedor);
                dados.Comandos.adicionaParametro("@loja", SqlDbType.VarChar, 35, _dsLoja);
                dados.Comandos.adicionaParametro("@dsmensagem", SqlDbType.VarChar, 8000, _dsMensagem);

                dados.Comandos.tempoLimite = 300;
                dados.retornaDados = true;
                return dados.execute();
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na proc 'CRM.pro_setCadastroLeads'", ex);
            }
        }
        public int pro_setLeadsCadastro()
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[CRM].[pro_setGravaLeads]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_status", _tpStatus.ToString());
                        cmd.Parameters.AddWithValue("@id_tipoEvento", _tpEvento.ToString());
                        cmd.Parameters.AddWithValue("@ds_nome", _dsNome.ToString());
                        cmd.Parameters.AddWithValue("@nr_dddTelefone", _nrdddTelFixo.ToString());
                        cmd.Parameters.AddWithValue("@nr_telefone", _nrTelefoneFixo.ToString());
                        cmd.Parameters.AddWithValue("@nr_dddCelular", _nrdddCelular.ToString());
                        cmd.Parameters.AddWithValue("@id_midia", _idMidia.ToString());
                        cmd.Parameters.AddWithValue("@id_empresa", _idEmpresa.ToString());
                        cmd.Parameters.AddWithValue("@id_motivo", _idMotivo.ToString());
                        cmd.Parameters.AddWithValue("@nr_tipoVeiculo", _nrTipoVeiculo);
                        cmd.Parameters.AddWithValue("@nr_celular", _nrCelular);
                        cmd.Parameters.AddWithValue("@nr_dddComercial", _nrdddComercial);
                        cmd.Parameters.AddWithValue("@nr_comercial", _nrComercial);
                        cmd.Parameters.AddWithValue("@ds_email", _dsEmail);
                        cmd.Parameters.AddWithValue("@ds_complemento", _dsComplemento);
                        cmd.Parameters.AddWithValue("@modelo", _dsModeloVeiculo);
                        cmd.Parameters.AddWithValue("@ano", _nrAno);
                        cmd.Parameters.AddWithValue("@vendedorExterno", _dsVendedor);
                        cmd.Parameters.AddWithValue("@loja", _dsLoja);
                        cmd.Parameters.AddWithValue("@dsmensagem", _dsMensagem.ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        private void verificaDados()
        {
            WSLeads.cadastroLeads cd = new WSLeads.cadastroLeads();

            if (cd.NrCelular == null)
            {
                cd.NrCelular = DBNull.Value.ToString();
            }

            if (cd.NrdddComercial == null)
            {
                cd.NrdddComercial = DBNull.Value.ToString();
            }

            if (cd.DsEmail == null)
            {
                cd.DsEmail = DBNull.Value.ToString();
            }

            if (cd.NrComercial == null)
            {
                cd.NrComercial = DBNull.Value.ToString();
            }

            if (cd.DsComplemento == null)
            {
                cd.DsComplemento = DBNull.Value.ToString();
            }

            if (cd.DsModeloVeiculo == null)
            {
                cd.DsModeloVeiculo = DBNull.Value.ToString();
            }

            if (cd.NrAno == null)
            {
                cd.NrAno = 0;
            }

            if (cd.Dsvendedor == null)
            {
                cd.Dsvendedor = DBNull.Value.ToString();
            }

            if (cd.DsLoja == null)
            {
                cd.DsLoja = DBNull.Value.ToString();
            }

            if (cd.DsMensagem == null)
            {
                cd.DsMensagem = DBNull.Value.ToString();
            }
        }
    }
}
