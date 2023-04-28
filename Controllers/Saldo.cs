using System.Collections.Generic;
using Models;
using MyProject.Data;

namespace Controllers
{
    public class SaldoController
    {
        public void CriarSaldo(Models.Saldo saldo)
        {
            using (var context = new Context())
            {
                context.Saldos.Add(saldo);
                context.SaveChanges();
            }
        }

        public void AtualizarSaldo(Models.Saldo saldo)
        {
            using (var context = new Context())
            {
                context.Saldos.Update(saldo);
                context.SaveChanges();
            }
        }

        public void DeletarSaldo(Models.Saldo saldo)
        {
            using (var context = new Context())
            {
                context.Saldos.Remove(saldo);
                context.SaveChanges();
            }
        }

        public List<Models.Saldo> ListarSaldos()
        {
            using (var context = new Context())
            {
                return context.Saldos.ToList();
            }
        }

        public Models.Saldo BuscarSaldo(int id)
        {
            using (var context = new Context())
            {
                return context.Saldos.Find(id);
            }
        }
    }
}
