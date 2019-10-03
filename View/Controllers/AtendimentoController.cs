using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class AtendimentoController : BaseController
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

        //Escolher o tipo de atendimento
        #region
        public ActionResult Escolha()
        {
            if (VerificaLogado() == true)
            {

                return View();


            }
            else
            {
                return Redirect("/login");
            }

        }
        #endregion

        //Inserir
        #region Inserir
        public ActionResult Cadastro()
        {
            if (VerificaLogado() == true)
            {
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
                Atendimento atendimentoExistente = repositoryAtendimento.ObterPeloPaciente(atendimento.IdPaciente);
                if (atendimentoExistente != null)
                {
                    return JavaScript("<script>alert(\"some message\")</script>");
                }

                atendimento.IdFuncionario = funcionario.Id;
                atendimento.IdPosto = funcionario.IdPosto;
                atendimento.DataAtendimento = DateTime.Now;
                if(atendimento.Observacao == null)
                {
                    atendimento.Observacao = " ";
                }

                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    atendimento.Status = 1;
                }
                else
                {
                    atendimento.Status = Convert.ToInt32(Session["usuarioLogadoPermissao"]);
                }

                var inseriu = repositoryAtendimento.Inserir(atendimento);
                PacienteRepository pacienteRepository = new PacienteRepository();
                Paciente paciente = pacienteRepository.ObterPeloId(atendimento.IdPaciente);
                if (paciente.Lingua != 1)
                {
                    return Redirect("/atendimentoespecial/ParteCorpoEspecial?idAtendimento=" + atendimento.Id);
                }
                else
                {
                    return RedirectToAction("index");
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
                if (Session["usuarioLogadoPermissao"].ToString() != "1")
                {

                    Atendimento atendimento = repositoryAtendimento.ObterPeloId(id);
                    ViewBag.Atendimento = atendimento;
                    Paciente paciente = repositoryPaciente.ObterPeloId(atendimento.IdPaciente);
                    ViewBag.Paciente = paciente;
                    //Se o paciente for estrangeiro ele irá ter uma lista de sintomas que este selecionou
                    if (paciente.Lingua != 0)
                    {
                        AtendimentoParteCorpoSintomaRepository atendimentoParteCorpoSintoma = new AtendimentoParteCorpoSintomaRepository();
                        List<Sintoma> sintomas = new List<Sintoma>();
                        List<AtendimentoParteCorpoSintoma> AtendimentoSintoma = atendimentoParteCorpoSintoma.ObterPeloIdAtentimento(atendimento.Id);
                        for (int i = 0; i < AtendimentoSintoma.Count; i++)
                        {
                            sintomas.Add(new Sintoma { Nome = AtendimentoSintoma[i].Sintoma.Nome });
                        }
                        ViewBag.NivelDor = AtendimentoSintoma;
                        ViewBag.Sintomas = sintomas;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return Redirect("/login/sempermissao");

                }


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

                //Obtemos o atendimento original pois assim não é necessario preencher todos os campos, apenas o que 
                //desejamos alterar

                Atendimento atendimentoOriginal = repositoryAtendimento.ObterPeloId(atendimento.Id);
                atendimentoOriginal.IdFuncionario = funcionario.Id;
                atendimentoOriginal.IdPosto = funcionario.IdPosto;
                if (Session["usuarioLogadoPermissao"].ToString() == "3")
                {
                    atendimento.Status = (Convert.ToInt32(Session["usuarioLogadoPermissao"]));
                    atendimento.IdMedico = funcionario.Id;
                }
                else
                {
                    atendimento.Status = (Convert.ToInt32(Session["usuarioLogadoPermissao"]));

                }

                repositoryAtendimento.Alerar(atendimento);

                if ((Session["usuarioLogadoPermissao"].ToString() == "3") || (Session["usuarioLogadoPermissao"].ToString() == "4"))
                {
                    return Redirect("/encaminhamento/escolha?idAtendimento=" + atendimento.Id);
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion
    }
}