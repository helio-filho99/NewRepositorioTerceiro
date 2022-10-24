using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modelo.Tabelas;
using Servico.Tabelas;
using System;

namespace Aula_0505.Controllers
{
    public class CategoriasController : Controller
    {
        //public EFContext context = new EFContext();
        //public ActionResult HtpNotFoundResult { get; private set; }

        private CategoriaServico categoriaServico = new CategoriaServico();

        private ActionResult ObterVisaoCategoriaId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria fabricante = categoriaServico.ObterCategoriaPorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        //private static IList<Categoria> categorias = new List<Categoria>()
        //{
        //    new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
        //    new Categoria() { CategoriaId = 2, Nome = "Monitores"},
        //    new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
        //    new Categoria() { CategoriaId = 4, Nome = "Mouses"},
        //    new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        //};

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // VOLTAR A PARTIR DAQUI AJKDSAD ASKABLFSBKLAFSAFSAFDSAFSAFSADVHFSADFJH

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            //categorias.Add(categoria);
            //categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;

            //context.Categorias.Add(categoria);
            //context.SaveChanges();
            //return RedirectToAction("Index");
            return GravarCategoria(categoria);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            //return View(categorias.Where(m => m.CategoriaId == id).First());

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Categoria categoria = context.Categorias.Find(id);
            //if (categoria == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(categoria);

            return ObterVisaoCategoriaId(id);
        }


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            //if (ModelState.IsValid)
            //{
            //    //categorias.Remove(
            //    //categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            //    //categorias.Add(categoria);

            //    context.Entry(categoria).State = EntityState.Modified;
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(categoria);

            return GravarCategoria(categoria);
        }


        // GET: Details
        public ActionResult Details(long? id)
        {
            ////return View(categorias.Where(m => m.CategoriaId == id).First());

            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Categoria categoria = context.Categorias.Where(f => f.CategoriaId == id).
            //    Include("Produtos.Fabricante").First();
            //if (categoria == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(categoria);

            return ObterVisaoCategoriaId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            ////return View(categorias.Where(m => m.CategoriaId == id).First());

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Categoria categoria = context.Categorias.Find(id);
            //if (categoria == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(categoria);

            return ObterVisaoCategoriaId(id);
        }


        // POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            ////categorias.Remove(
            ////categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());

            //Categoria categoria = context.Categorias.Find(id);
            //context.Categorias.Remove(categoria);
            //context.SaveChanges();
            //TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";

            //return RedirectToAction("Index");

            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}