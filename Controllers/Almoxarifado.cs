using System.Collections.Generic;
using Models;
using MyProject.Data;

namespace Controllers
{
    public class AlmoxarifadoController
    {
        public void CriarAlmoxarifado(Models.Almoxarifado almoxarifado)
        {
            using (var context = new Context())
            {
                context.Almoxarifados.Add(almoxarifado);
                context.SaveChanges();
            }
        }

        public void AtualizarAlmoxarifado(Models.Almoxarifado almoxarifado)
        {
            using (var context = new Context())
            {
                context.Almoxarifados.Update(almoxarifado);
                context.SaveChanges();
            }
        }

        public void DeletarAlmoxarifado(Models.Almoxarifado almoxarifado)
        {
            using (var context = new Context())
            {
                context.Almoxarifados.Remove(almoxarifado);
                context.SaveChanges();
            }
        }

        public List<Models.Almoxarifado> ListarAlmoxarifados()
        {
            using (var context = new Context())
            {
                return context.Almoxarifados.ToList();
            }
        }

        public Models.Almoxarifado BuscarAlmoxarifado(int id)
        {
            using (var context = new Context())
            {
                return context.Almoxarifados.Find(id);
            }
        }
    }
}
