﻿using Model;
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
            ViewBag.Pacientes = repositoryPaciente.ObterPacientesPeloIdCidade(1);
            return View();
        }

        public ActionResult Inserir(int atendendente,int medico,int paciente,DateTime data,int prioridate,string observacao)
        {
            Atendimento atendimento = new Atendimento();
            atendimento.IdFuncionario = atendendente;
            atendimento.IdMedico = medico;
            atendimento.IdPaciente = paciente;
            atendimento.DataAtendimento = data;
            atendimento.Prioridade = prioridate;
            atendimento.Observacao = observacao;

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