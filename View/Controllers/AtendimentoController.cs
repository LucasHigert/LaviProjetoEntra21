using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class AtendimentoController : Controller
    {
        private AtendimentoRepository repositoryAtendimento = new AtendimentoRepository();
        private PacienteRepository repositoryPaciente = new PacienteRepository();

        //Listagem de Atendimentos
        public ActionResult Index()
        {
            ViewBag.Atendimentos = repositoryAtendimento.ObterTodosPeloCargo(1);
            return View();
        }

        //Inserir
        #region
        public ActionResult Cadastro()
        {
            EncaminhamentoRepository encaminhamentoRepository = new EncaminhamentoRepository();
            ViewBag.Encaminhamentos = encaminhamentoRepository.ObterTodos();
            ViewBag.Pacientes = repositoryPaciente.ObterTodos();
            return View();
        }

        public ActionResult Inserir(Atendimento atendimento)
        {
            // atendimento.IdFuncionario = atendendente;
            // atendimento.IdMedico = medico;
            atendimento.IdFuncionario = 2;
            atendimento.Status = 1;
            atendimento.IdMedico = 2;

            var inseriu = repositoryAtendimento.Inserir(atendimento);
            if (inseriu == false)
            {
                return HttpNotFound();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        //Alterar
        #region
        public ActionResult Alterar(int id)
        {
            ViewBag.Atendimento = repositoryAtendimento.ObterPeloId(id);
            return View();
        }

        public ActionResult Update(Atendimento atendimento)
        {
            repositoryAtendimento.Alerar(atendimento);
            return RedirectToAction("index");
        }
        #endregion
    }
}