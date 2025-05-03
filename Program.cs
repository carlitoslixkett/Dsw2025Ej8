using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>();

            
            var caja1 = new CajaDeAhorro("CA001", 1000, TipoCuenta.CajaDeAhorro, new string[] { "Carlos" });
            caja1.tasaDeInteres = 0.05m;
            caja1._estado = Estado.Suspendida;

            var caja2 = new CajaDeAhorro("CA002", 200, TipoCuenta.CajaDeAhorro, new string[] { "Victor" });
            caja2.tasaDeInteres = 0.03m;

            
            var corriente1 = new CuentaCorriente("CC001", 500, TipoCuenta.CuentaCorriente, new string[] { "Juan" });
            corriente1.limiteDeDescubierto = 300;
            corriente1.comision = 0.02m;

            var corriente2 = new CuentaCorriente("CC002", 50, TipoCuenta.CuentaCorriente, new string[] { "Mariano" });
            corriente2.limiteDeDescubierto = 100;
            corriente2.comision = 0.03m;

            cuentas.Add(caja1);
            cuentas.Add(caja2);
            cuentas.Add(corriente1);
            cuentas.Add(corriente2);

           
            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(100);
                    cuenta.Retirar(150);
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
            }

            
            caja1.AplicarInteres(caja1.tasaDeInteres);
            caja2.AplicarInteres(caja2.tasaDeInteres);

            
            Console.WriteLine("\n--- RESUMEN DE CUENTAS ---");
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta._numero,
                    Tipo = cuenta._tipo,
                    Saldo = cuenta._saldo
                };

                Console.WriteLine($"Cuenta: {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: {resumen.Saldo:C}");
            }
        }


    }
}
