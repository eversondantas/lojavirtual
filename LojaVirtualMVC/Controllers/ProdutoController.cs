using LojaVirtualMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtualMVC.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            IEnumerable<ProdutoModel> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Produtos").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<ProdutoModel>>().Result;
            return View(prodList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ProdutoModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Produtos/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProdutoModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProdutoModel prod)
        {
            // É inserção
            if (prod.ProdutoID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Produtos", prod).Result;
                TempData["SuccessMessage"] = "Registro inserido com sucesso";
            } //É edição
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Produtos/" + prod.ProdutoID.ToString(), prod).Result;
                TempData["SuccessMessage"] = "Registro alterado com sucesso";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Produtos/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Registro deletado com sucesso";

            return RedirectToAction("Index");
        }
    }
}