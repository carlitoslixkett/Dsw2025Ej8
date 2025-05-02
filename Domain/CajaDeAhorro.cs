using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, TipoCuenta tipo, string[] titulares) : base(numero, saldo, tipo, titulares)
        {
        }

        public decimal tasaDeInteres { private get; set; }

        public override void Depositar(decimal monto)
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo += monto;
            }

        }

        public override void Retirar(decimal monto)
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo -= monto;
            }
        }
        public  void AplicarInteres(decimal tasaDeInteres)
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {

                if (_estado != Estado.Activa)
                {
                    Console.WriteLine($"Error: No se puede operar con la cuenta en estado {_estado}. No se aplica el interés."); ;
                }
                else
                {
                    _saldo += _saldo * tasaDeInteres;
                }
            }
        }
    }
}
