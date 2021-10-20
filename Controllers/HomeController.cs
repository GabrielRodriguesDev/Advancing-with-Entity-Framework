using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Advancing_with_Entity_Framework.Models;
using Advancing_with_Entity_Framework.Database;

namespace Advancing_with_Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _database;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDBContext database
            )
        {
            this._logger = logger;
            this._database = database;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test(){ // Action para gravar registros dentro do Banco para simular testes.
            Categoria categoriaOne = new Categoria();
            categoriaOne.Nome = "Gabriel";

            Categoria categoriaTwo = new Categoria();
            categoriaTwo.Nome = "André";

            Categoria categoriaThree = new Categoria();
            categoriaThree.Nome = "Keila";

            Categoria categoriaFour = new Categoria();
            categoriaFour.Nome = "Adrielly";

            List<Categoria> categoriaList = new List<Categoria>();

            categoriaList.Add(categoriaOne);
            categoriaList.Add(categoriaTwo);
            categoriaList.Add(categoriaThree);
            categoriaList.Add(categoriaFour);


            this._database.AddRange(categoriaList);
            this._database.SaveChanges();
            return Content("Save Data");
        }
    }
}
