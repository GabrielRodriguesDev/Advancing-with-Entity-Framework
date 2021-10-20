using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Starting_with_the_entity_framework.Database;
using Starting_with_the_entity_framework.Models;

namespace Starting_with_the_entity_framework.Controllers
{
    public class FuncionariosController: Controller
    {
        private readonly ApplicationDBContext _database;
        public FuncionariosController(ApplicationDBContext database)
        {
            this._database = database; //Injetando a DI do EF (Classe de configuração do EntityFramework) para que possamos manipular o bd nesse caso fazer um insert
        }


        public IActionResult Index(){
            var funcionarios = this._database.Funcionarios.ToList(); // Recebendo uma coleção de Funcionarios, tranformando em uma lista e armazenando na variavel
            return View(funcionarios);
        }
        public IActionResult Cadastrar() { // Método que retorna uma view, no caso a mesma com o nome do método View - Cadastrar
            return View();
        }

        public IActionResult Editar(int id) {
            Funcionario funcionario = this._database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        public IActionResult Deletar(int id) {
            Funcionario funcionario = this._database.Funcionarios.First(registro => registro.Id == id);
            this._database.Remove(funcionario);
            this._database.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost] // Método POST que será chamado pela view Cadastrar, e receberá um formulario (Objeto Funcionario já está sendo tipado direto na view)
        public IActionResult Salvar(Funcionario funcionario) {
            if(funcionario.Id == 0){ // == 0 Pois um valor do tipo int nunca é igual a null e sim a 0
                // Caso não tenha o id ele salva um novo registro.
                this._database.Funcionarios.Add(funcionario); //Chamando o método add() que simula o insert, e como a classe é funcionarios como a Entidade no qual a tabela foi baseada passamos ela como data.
                
            
            } else {
                // Caso tenha o id, ele atualiza o registro
                Funcionario FuncionarioCadastrado = this._database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                // Atualizando registro que retornou do banco pela linha acima e atualizando as informações, pelas informações que foram obtidas pela view.
                // Após realizar a mudança do objeto que foi retornado pelo banco (função First acima) ao aplicar o SaveChanges() ele já realiza o Update dentro do Banco de Dados
                FuncionarioCadastrado.Nome = funcionario.Nome; 
                FuncionarioCadastrado.Salario = funcionario.Salario;
                FuncionarioCadastrado.Cpf = funcionario.Cpf;
            }
            this._database.SaveChanges(); //Salvando as mudanças, simulando o commit
            return RedirectToAction("Index");
        }
    }
}