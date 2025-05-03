using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal limiteDeDescubierto {  private get; set; }
        public decimal comision { private get; set; }

        public CuentaCorriente(string numero, decimal saldo, TipoCuenta tipo , string[] titulares)
        : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
        {
            this.comision = comision;
        }


        public override void Depositar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new CuentaNoActivaException(_estado);
            }
            if (monto <= 0)
                throw new MontoNoValidoException();
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo += monto;
            }
            else if (_tipo == TipoCuenta.CuentaCorriente)
            {
                monto -= monto * comision;
                _saldo += monto;
            }
            
            
        }
        public override void Retirar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new CuentaNoActivaException(_estado);
            }
                if (_saldo - monto < -limiteDeDescubierto)
                {
                    _estado = Estado.Suspendida;
                    throw new SaldoInsuficienteException();
                }
                if (monto <= 0)
                    throw new MontoNoValidoException();
                if (_tipo == TipoCuenta.CajaDeAhorro)
                {
                    _saldo -= monto;
                }
                else if (_tipo == TipoCuenta.CuentaCorriente)
                {
                    if (_saldo - monto >= -limiteDeDescubierto)
                    {
                        _saldo -= monto;
                    }
                    if (_saldo < 0)
                    {
                        _estado = Estado.Suspendida;
                    }
                }
            
            
        }

        public void indicarLimite(decimal limiteDeDescubierto)
        { 
        this.limiteDeDescubierto = limiteDeDescubierto;
        }
    }
}
