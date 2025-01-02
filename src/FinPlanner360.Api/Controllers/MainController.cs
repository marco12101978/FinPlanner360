﻿using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Notificacoes.Blog.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace FinPlanner360.Api.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected Guid UserId { get; set; }
        protected string UserName { get; set; }
        protected bool UserAdmin { get; set; }

        protected MainController(INotificador notificador, IAppIdentityUser user)
        {
            _notificador = notificador;

            if (user.IsAuthenticated())
            {
                UserId = user.GetUserId();
                UserName = user.GetUsername();
                UserAdmin = user.IsInRole("Admin");
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode, object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };
            }
            else
            {
                if ((int)statusCode >= 200 && (int)statusCode <= 299)
                {
                    return BadRequest(new
                    {
                        errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
                    });
                }

                return new ObjectResult(new
                {
                    errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
                })
                {
                    StatusCode = Convert.ToInt32(statusCode)
                };
            }

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse(HttpStatusCode.OK);
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
