namespace FinPlanner360.Business.Models.Validations.Documentos
{
    public static class ValidacaoDatetime
    {
        public static bool EhUmaDataValida(DateTime? data)
        {
            return data.HasValue && data.Value != DateTime.MinValue;
        }

        public static bool EhUmaDataValida(DateTime data)
        {
            return data > DateTime.MinValue;
        }
    }
}
