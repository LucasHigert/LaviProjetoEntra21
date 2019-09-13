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
        #region Verificação login
        private bool VerificaLogado()
        {
            if (Session["usuarioLogadoId"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private AtendimentoRepository repositoryAtendimento = new AtendimentoRepository();

        private PacienteRepository repositoryPaciente = new PacienteRepository();

        //Listagem de Atendimentos
        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {


                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    ViewBag.Cargo = "Administrador";
                    ViewBag.Atendimentos = repositoryAtendimento.ObterTodosPosto(funcionario.IdPosto);
                    return View();
                }
                else if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    ViewBag.Cargo = funcionario.Cargo.Nome;
                    ViewBag.Atendimentos = repositoryAtendimento.ObterTodosPeloCargoPosto(1, funcionario.IdPosto);
                    return View();
                }
                else
                {

                    ViewBag.Cargo = funcionario.Cargo.Nome;

                    ViewBag.Atendimentos = repositoryAtendimento.ObterTodosPeloCargoPosto(Convert.ToInt32(Session["usuarioLogadoPermissao"]) - 1, funcionario.IdPosto);
                    return View();
                }
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Inserir
        #region
        public ActionResult Cadastro()
        {
            if (VerificaLogado() == true)
            {

                EncaminhamentoRepository encaminhamentoRepository = new EncaminhamentoRepository();
                ViewBag.Encaminhamentos = encaminhamentoRepository.ObterTodos();
                ViewBag.Pacientes = repositoryPaciente.ObterTodos();
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        public ActionResult Inserir(Atendimento atendimento)
        {
            if (VerificaLogado() == true)
            {

                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                atendimento.IdFuncionario = funcionario.Id;
                atendimento.IdPosto = funcionario.IdPosto;

                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    atendimento.Status = 1;
                }
                else
                {
                    atendimento.Status = Convert.ToInt32(Session["usuarioLogadoPermissao"]);
                }

                var inseriu = repositoryAtendimento.Inserir(atendimento);
                if (inseriu == false)
                {
                    return RedirectToAction("Cadastro");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion

        //Alterar
        #region
        public ActionResult Alterar(int id)
        {
            if (VerificaLogado() == true)
            {

                ViewBag.Atendimento = repositoryAtendimento.ObterPeloId(id);
                ViewBag.Pacientes = repositoryPaciente.ObterTodos();
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        public ActionResult Update(Atendimento atendimento)
        {
            if (VerificaLogado() == true)
            {
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                Atendimento atendimentoOriginal = repositoryAtendimento.ObterPeloId(atendimento.Id);
                atendimentoOriginal.IdFuncionario = funcionario.Id;
                atendimentoOriginal.IdPosto = funcionario.IdPosto;
                if (Session["usuarioLogadoPermissao"].ToString() == "3")
                {
                    atendimento.Status = 3;
                    atendimento.IdMedico = funcionario.Id;
                }
                else
                {
                    atendimento.Status = (Convert.ToInt32(Session["usuarioLogadoPermissao"]));

                }
                repositoryAtendimento.Alerar(atendimento);
                return RedirectToAction("index");
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion
    }
}