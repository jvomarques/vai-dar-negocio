using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoDeSoftware.Framework.Sidra.Entidades;

namespace ProjetoDeSoftware.Alimentacao.Entidades
{
    public class Restaurante
    {
        double preco_medio_prato;
        int capacidade;
        Bairro bairro;
        public bool ehDelivery;
        public bool abrangenciaApenasMinhaZona;

        public Restaurante(double _preco_medio_prato, int _capacidade, bool _ehDelivery, bool _abrangenciaApenasMinhaZona, Bairro _bairro) 
        {
            preco_medio_prato = _preco_medio_prato;
            capacidade = _capacidade;
            ehDelivery = _ehDelivery;
            abrangenciaApenasMinhaZona = _abrangenciaApenasMinhaZona;
            bairro = _bairro;
        }

        public Restaurante(double _preco_medio_prato, int _capacidade, bool _ehDelivery, bool _abrangenciaApenasMinhaZona)
        {
            preco_medio_prato = _preco_medio_prato;
            capacidade = _capacidade;
            ehDelivery = _ehDelivery;
            abrangenciaApenasMinhaZona = _abrangenciaApenasMinhaZona;
        }

        public double getPrecoMedioPrato() 
        {
            return preco_medio_prato;
        }

        public int getCapacidade() 
        {
            return capacidade;
        }

        public Bairro getBairro() 
        {
            return bairro;
        }
    }
}
