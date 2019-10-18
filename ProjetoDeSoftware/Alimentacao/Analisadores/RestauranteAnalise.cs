using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoDeSoftware.Framework.Sidra.Entidades;
using ProjetoDeSoftware.Framework.Sidra.Analisadores;
using ProjetoDeSoftware.Alimentacao.Entidades;

namespace ProjetoDeSoftware.Alimentacao.Analisadores
{
    //getNotaPrecoMedioPrato
    //getNotaCapacidade

    public class RestauranteAnalise : Analise<Restaurante>
    {
        List<Bairro> bairros = (new Bairro()).listAll();
        double renda_media_total = 0;

        public int getNotaPrecoMedioPrato(Restaurante r) 
        {
            string minha_zona = new Bairro(r.getBairro().getId()).getZona();
            if (r.ehDelivery)
            {
                if (r.abrangenciaApenasMinhaZona)
                {
                    int qtd_bairros = 0; ;
                    for (int i = 0; i < bairros.Count; i++)
                    {
                        if (minha_zona == bairros[i].getZona())
                        {
                            Renda renda = (new Renda()).getRendaPorBairro(bairros[i].getId());
                            Dictionary<string, double> map = renda.getGrupoIdade();

                            double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                            int qnt_grupos = 0;

                            foreach (KeyValuePair<string, double> grupo in map)
                            {
                                string num = "";

                                if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                                {
                                    num = grupo.Key.ToArray()[0].ToString();
                                    try
                                    {
                                        if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                            num += grupo.Key.ToArray()[1].ToString();
                                    }
                                    catch { }
                                }

                                int inicio_grupo = 1000000; ;
                                if (num != "")
                                    inicio_grupo = int.Parse(num);

                                if (inicio_grupo >= 20)
                                {
                                    renda_media_grupo += grupo.Value;
                                    qnt_grupos++;
                                }
                            }
                            qtd_bairros++;
                            renda_media_grupo /= qnt_grupos;
                            renda_media_total += renda_media_grupo;
                        }
                    }
                    renda_media_total /= qtd_bairros;
                }
                else
                {
                    for (int i = 0; i < bairros.Count; i++)
                    {
                        Renda renda = (new Renda()).getRendaPorBairro(bairros[i].getId());
                        Dictionary<string, double> map = renda.getGrupoIdade();

                        double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                        int qnt_grupos = 0;

                        foreach (KeyValuePair<string, double> grupo in map)
                        {
                            string num = "";

                            if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                            {
                                num = grupo.Key.ToArray()[0].ToString();
                                try
                                {
                                    if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                        num += grupo.Key.ToArray()[1].ToString();
                                }
                                catch { }
                            }

                            int inicio_grupo = 1000000; ;
                            if (num != "")
                                inicio_grupo = int.Parse(num);

                            if (inicio_grupo >= 20)
                            {
                                renda_media_grupo += grupo.Value;
                                qnt_grupos++;
                            }
                        }
                        renda_media_grupo /= qnt_grupos;
                        renda_media_total += renda_media_grupo;
                    }
                    renda_media_total /= bairros.Count;
                }
            }
            else 
            {
                Renda renda = (new Renda()).getRendaPorBairro(r.getBairro().getId());
                Dictionary<string, double> map = renda.getGrupoIdade();

                double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                int qnt_grupos = 0;
                foreach (KeyValuePair<string, double> grupo in map)
                {
                    string num = "";

                    if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                    {
                        num = grupo.Key.ToArray()[0].ToString();
                        try
                        {
                            if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                num += grupo.Key.ToArray()[1].ToString();
                        }
                        catch { }
                    }

                    int inicio_grupo = 1000000; ;
                    if (num != "")
                        inicio_grupo = int.Parse(num);

                    if (inicio_grupo >= 20)
                    {
                        renda_media_grupo += grupo.Value;
                        qnt_grupos++;
                    }
                }
                renda_media_grupo /= qnt_grupos;
                renda_media_total = renda_media_grupo;
            }

            double proporcao = (r.getPrecoMedioPrato() * 30) / renda_media_total;

            string aviso = "";//"Lembre que, em geral, 33% da renda é investida em alimentação fora de casa.Nessa zona/região de bairros, temos uma renda média de " + renda_media_total + "reais";
            if (proporcao <= 0.1) 
            {
                addDicas("O preço médio do prato está baixo para a região. " + aviso);
                return 30;
            }
            else if (proporcao <= 0.33)
            {
                addDicas("O preço médio do prato é o ideal para a região.");
                return 50;
            }
            else if (proporcao <= 0.45)
            {
                addDicas("O preço médio do prato está alto para a região. " + aviso);
                return 30;
            }
            else
            {
                addDicas("O preço médio do prato está muito alto para a renda da região. " + aviso);
                return 15;
            }
        }



        public int getNotaCapacidade(Restaurante r) 
        {
            string minha_zona = new Bairro(r.getBairro().getId()).getZona();
            
            if (r.ehDelivery)
            {
                if (r.abrangenciaApenasMinhaZona)
                {
                    int qtd_bairros = 0; ;
                    for (int i = 0; i < bairros.Count; i++)
                    {
                        if (minha_zona == bairros[i].getZona())
                        {
                            Idade idade = (new Idade()).getIdadePorBairro(bairros[i].getId());
                            Dictionary<string, double> map = idade.getGrupoIdade();

                            double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                            int qnt_grupos = 0;

                            foreach (KeyValuePair<string, double> grupo in map)
                            {
                                string num = "";

                                if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                                {
                                    num = grupo.Key.ToArray()[0].ToString();
                                    try
                                    {
                                        if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                            num += grupo.Key.ToArray()[1].ToString();
                                    }
                                    catch { }
                                }

                                int inicio_grupo = 1000000; ;
                                if (num != "")
                                    inicio_grupo = int.Parse(num);

                                if (inicio_grupo >= 20)
                                {
                                    renda_media_grupo += grupo.Value;
                                    qnt_grupos++;
                                }
                            }
                            qtd_bairros++;
                            renda_media_grupo /= qnt_grupos;
                            renda_media_total += renda_media_grupo;
                        }
                    }
                    renda_media_total /= qtd_bairros;
                }
                else
                {
                    for (int i = 0; i < bairros.Count; i++)
                    {
                        Idade idade = (new Idade()).getIdadePorBairro(bairros[i].getId());
                        Dictionary<string, double> map = idade.getGrupoIdade();

                        double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                        int qnt_grupos = 0;

                        foreach (KeyValuePair<string, double> grupo in map)
                        {
                            string num = "";

                            if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                            {
                                num = grupo.Key.ToArray()[0].ToString();
                                try
                                {
                                    if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                        num += grupo.Key.ToArray()[1].ToString();
                                }
                                catch { }
                            }

                            int inicio_grupo = 1000000; ;
                            if (num != "")
                                inicio_grupo = int.Parse(num);

                            if (inicio_grupo >= 20)
                            {
                                renda_media_grupo += grupo.Value;
                                qnt_grupos++;
                            }
                        }
                        renda_media_grupo /= qnt_grupos;
                        renda_media_total += renda_media_grupo;
                    }
                    renda_media_total /= bairros.Count;
                }
            }
            else
            {
                Idade idade = (new Idade()).getIdadePorBairro(r.getBairro().getId());
                Dictionary<string, double> map = idade.getGrupoIdade(); ;

                double renda_media_grupo = 0; //MAIOR QUE 20 ANOS
                int qnt_grupos = 0;
                foreach (KeyValuePair<string, double> grupo in map)
                {
                    string num = "";

                    if (grupo.Key.ToArray()[0] >= '0' && grupo.Key.ToArray()[0] <= '9')
                    {
                        num = grupo.Key.ToArray()[0].ToString();
                        try
                        {
                            if (grupo.Key.ToArray()[1] >= '0' && grupo.Key.ToArray()[1] <= '9')
                                num += grupo.Key.ToArray()[1].ToString();
                        }
                        catch { }
                    }

                    int inicio_grupo = 1000000; ;
                    if (num != "")
                        inicio_grupo = int.Parse(num);

                    if (inicio_grupo >= 20)
                    {
                        renda_media_grupo += grupo.Value;
                        qnt_grupos++;
                    }
                }
                renda_media_grupo /= qnt_grupos;
                renda_media_total = renda_media_grupo;
            }

            double proporcao = Convert.ToDouble(r.getCapacidade() / renda_media_total);

            if (proporcao >= 0 && proporcao < 0.01)
            {
                addDicas("Estabelecimento com pouca capacidade para região.");
                return 30;
            }
            else if (proporcao > 0.01 && proporcao <= 0.05)
            {
                addDicas("Estabelecimento com capacidade ideal para a região.");
                return 50;
            }
            else
            {
                addDicas("Estabelecimento com capacidade ruim para a região.");
                return 15;
            }
        }

        public override double getViabilidade(Restaurante r)
        {
            return getNotaCapacidade(r) + getNotaPrecoMedioPrato(r);
        }
    }
}
