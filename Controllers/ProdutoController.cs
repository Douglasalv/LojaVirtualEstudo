using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController: Controller
    {

        public ActionResult Visualizar()
        {
            return new ContentResult() { Content = "<h3>Produto - Visualizar</h3>", ContentType = "text/html" };
        }
    }
}
