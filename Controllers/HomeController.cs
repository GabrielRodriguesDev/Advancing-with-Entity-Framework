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
        /*  Categoria categoriaOne = new Categoria();
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
            this._database.SaveChanges(); */

            var listaCategorias = this._database.Categorias.Where(categoria => categoria.Id  >= 2 && !categoria.Nome.Equals("Keila")).ToList();//Como trabalhar com o WHERE, após carregar uma lista é necessário transformar em ToList para que possamos trabalhar ela.

            Console.WriteLine("======================");

            listaCategorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString());
            });
            return Content("Save Data");
        }

        public IActionResult Relacionamento() { // Criando registro com relacionamento.

                
                Produto produtoOne = new Produto();
                produtoOne.Nome = "Prd1";
                produtoOne.Categoria = this._database.Categorias.First(categoria => categoria.Id == 1); //Temos que recuperar os dados do objeto e setar jutamente ao registro.


                Produto produtoTwo = new Produto();
                produtoTwo.Nome = "Prd2";
                produtoTwo.Categoria = this._database.Categorias.First(categoria => categoria.Id == 1);


                Produto produtoThree = new Produto();
                produtoThree.Nome = "Prd3";
                produtoThree.Categoria = this._database.Categorias.First(categoria => categoria.Id == 2);

                this._database.Add(produtoOne);
                this._database.Add(produtoTwo);
                this._database.Add(produtoThree);

                this._database.SaveChanges();



                return Content("Relacionamento");
            }
    }
}
