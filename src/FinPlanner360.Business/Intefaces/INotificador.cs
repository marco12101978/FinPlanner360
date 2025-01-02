using FinPlanner360.Business.Notificacoes.Blog.Business.Notificacoes;

namespace FinPlanner360.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
