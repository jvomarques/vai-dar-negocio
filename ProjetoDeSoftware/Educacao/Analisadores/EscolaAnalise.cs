using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ProjetoDeSoftware.Alimentacao.Telas;
using ProjetoDeSoftware.Framework.Sidra.Entidades;
using ProjetoDeSoftware.Framework.Sidra.Analisadores;
using ProjetoDeSoftware.Alimentacao.Entidades;

namespace ProjetoDeSoftware.Alimentacao.Analisadores
{
    public class EscolaAnalise : Analise<Escola>
    {
        public int getNotaAlfabetizados(Escola e)
        {
            Alfabetizado alfa = (new Alfabetizado()).getAlfabetizadoPorBairro(e.getBairro().getId());
            Dictionary<string, double> map = alfa.getGrupoIdade();

            double numero_alunos_ponteciais = 0;
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

                if (inicio_grupo < 7)
                    numero_alunos_ponteciais += grupo.Value;
            }

            double proporcao = numero_alunos_ponteciais / e.getNumeroAlunos();

            if (proporcao <= 1)
            {
                addDicas("Quantidade de alfabetizados na região é pequena.");
                return 1;
            }
            else if (proporcao <= 3)
            {
                addDicas("Quantidade de alfabetizados na região é boa.");
                return 2;
            }
            else
            {
                addDicas("Quantidade de alfabetizados na região é ideal.");
                return 3;
            }
        }

        public double getNotaIdade(Escola e)
        {
            Idade idade = (new Idade()).getIdadePorBairro(e.getBairro().getId());
            Dictionary<string, double> map = idade.getGrupoIdade();

            double numero_alunos_ponteciais = 0.0;
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

                if (e.getIdadeMin() > inicio_grupo)
                    numero_alunos_ponteciais += grupo.Value;
            }
            numero_alunos_ponteciais = numero_alunos_ponteciais * 10;
            double proporcao = numero_alunos_ponteciais / e.getNumeroAlunos();
            if (e.getNumeroAlunos() < 27)
            {
                addDicas("A quantidade de alunos é baixa. A média de alunos por turma em Natal é de aproximadamente 27 pessoas.\nSeria interessante ampliar a expectativa de alunos.");
                return 1.0;
            }
            else if (proporcao <= 1)
            {
                addDicas("A faixa de idade não é boa na região. Seria interessante ampliar o público alvo e/ou diminuir a expectativa de \nalunos.");
                return 1.0;
            }
            else if (proporcao <= 3)
            {
                addDicas("A faixa de idade na região é boa. Boas chances de suprir a expectativas de alunos, mas talvez diminuí-la e/ou \nampliar o público alvo sejam boa alternativas.");
                return 2.0;
            }
            else
            {
                addDicas("A faixa de idade na região é ideal. Basta uma pequena parcela dos potenciais clientes fazerem matrícula para \natingir a expectativa.");
                return 2.5;
            }
        }

        public int getNotaMensalidade(Escola e)
        {
            Renda renda = (new Renda()).getRendaPorBairro(e.getBairro().getId());
            Dictionary<string, double> map = renda.getGrupoIdade();

            double renda_media_grupo = 0;
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

                if (inicio_grupo >= 30)
                {
                    renda_media_grupo += grupo.Value;
                    qnt_grupos++;
                }
            }

            renda_media_grupo /= qnt_grupos;
            double proporcao = e.getMensalidade() / renda_media_grupo;
            MainWindow.renda_bairro = renda_media_grupo;
            
            string aviso = "Lembre que, em geral, 15 % da renda é investida em educação. Nesse bairro, temos uma renda média de R$ " + renda_media_grupo;//

            if (proporcao <= 0.1)
            {
                addDicas("A mensalidade está baixa para a região. \n" + aviso);
                return 1;
            }
            else if (proporcao <= 0.2)
            {
                addDicas("A mensalidade está ideal.");
                return 3;
            }
            else if (proporcao <= 0.4)
            {
                addDicas("A mensalidade está alta para a região. \n" + aviso);
                return 2;
            }
            else
            {
                addDicas("A mensalidade está muito alta para a renda da região. \n" + aviso);
                return 1;
            }
        }

        public int getNotaReligiao(Escola e)
        {
            int nota3 = 0;
            if (nota3 == 0)
                addDicas("");
            else if (nota3 == 2)
                addDicas("A mesalidade está alta para a região");
            else if (nota3 == 3)
                addDicas("A mesalidade está baixa para a região");
            else
                addDicas("A mensalidade está ideal");

            return 0;
        }
        /*
        public override double getViabilidade(Escola e)
        {
            int nota1 = getNotaIdade(e);
            int nota2 = getNotaMensalidade(e);
            int nota3 = getNotaAlfabetizados(e);

            //if (nota1 == 1 || nota2 == 1)
               // return 0;
            Random random = new Random();
            int rd = random.Next(-10, 10);
            int resul = 100 * (nota1 + nota2 + nota3) / 9;

            if (nota1 == 1 || nota2 == 1)
                return (0 + Math.Abs(rd));

            if(rd + resul >=100){
                return resul - rd;
            } else if (resul - rd <= 0 )
                return resul + rd;

            return (100 * (nota1 + nota2 + nota3) / 9) + rd;
        }
         */
        public override double getViabilidade(Escola e)
        {
            Double nota1 = getNotaIdade(e);
            int nota2 = getNotaMensalidade(e);
            int nota3 = getNotaAlfabetizados(e);

            if (nota1 == 1 || nota2 == 1)
                return 0;

            return 100 * (nota1 + nota2 ) / 5.5;
        }
    }
}
