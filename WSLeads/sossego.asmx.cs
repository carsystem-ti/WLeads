using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace WSLeads
{
    /// <summary>
    /// Summary description for sossego
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class sossego : System.Web.Services.WebService
    {
        [WebMethod(Description = "Primeiro Contato CT")]
        public string Gravar_CT_Indicacao(WS_sossego.dadosCtBasica dct)
        {
            try
            {
                DataSet ds_dados;
                string strDados;

                ds_dados = dct.set_CT_dadosIncompletos();
                strDados = ds_dados.Tables[0].Rows[0]["cd_CT"].ToString();

                return strDados;
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na geração da CT.", ex);
            }
        }

        [WebMethod(Description = "Dados CT completa para análise")]
        public string Gravar_CT_Dados_Completos(WS_sossego.dadosPessoais dp, WS_sossego.dadosComercial dr, 
                                                WS_sossego.dadosCobranca dc, WS_sossego.dadosFormaPagto dfp, 
                                                WS_sossego.dadosAdicionais da, WS_sossego.dadosEntrega de, 
                                                WS_sossego.dadosFinanceira df, WS_sossego.dadosVeiculo dv, 
                                                WS_sossego.dadosVeiculoItem dvi)
        {
            try
            {
                DataSet ds_dadosPessoais;
                DataSet ds_dadosFormaPagtoTerceiro;

                // Etapa 1/5
                // 1    - Dados Pessoais
                ds_dadosPessoais = dp.GravarDadosPessoais();

                if (ds_dadosPessoais.Tables[0].Rows.Count > 0)
                {
                    // 1.1  - Dados Comercial
                    dr.GravarDadosComercial(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // Etapa 2/5
                    // 2    - Dados Cobranca
                    dc.GravarDadosCobranca(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // 2.1  - Dados Forma Pagamento
                    dfp.GravarDadosFormaPgto(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // 2.2 - Dados Forma Pagamento Terceiro
                    WS_sossego.dadosTerceiro dt = new WS_sossego.dadosTerceiro();
                    ds_dadosFormaPagtoTerceiro = dt.consultaSeChequeTerceiro();

                    if (ds_dadosFormaPagtoTerceiro.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt16(ds_dadosFormaPagtoTerceiro.Tables[0].Rows[0]["nr_resultado"].ToString()) == 1)
                        {
                            dt.GravarDadosTerceiro(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());
                        }
                    }

                    // Etapa 3/5
                    // Dados Adicionais
                    da.GravarDadosAdicionais(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // Etapa 4/5
                    // Dados Entrega
                    de.GravarDadosEntrega(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // Etapa 5/5
                    // Dados Financeira
                    df.GravaFinanceira(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // Etapa 5.1/5
                    // Dados Veiculo
                    dv.GravarDadosVeiculo(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    // Etapa 5.2/5
                    // Dados Veiculo Item
                    dvi.GravarDadosVeiculoItem(ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString());

                    return ds_dadosPessoais.Tables[0].Rows[0]["cd_CT"].ToString();
                }
                else
                {
                    return "Favor entrar com dados pessoais para gerar numero da CT, e dar continuidade nas outras etapas.";
                }
            }
            catch (Exception ex)
            {
                throw new global::System.Data.StrongTypingException("Problemas na geração da CT.", ex);
            }
        }
    }
}
