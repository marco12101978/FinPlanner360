namespace FinPlanner360.Business.Notificacoes
{
    namespace Blog.Business.Notificacoes
    {
        public class Notificacao
        {
            public Notificacao(string mensagem)
            {
                Mensagem = mensagem;
            }

            public string Mensagem { get; }
        }
    }
}
