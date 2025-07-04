namespace web_service_calculadora_despliegue.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string TipoOperacion { get; set; } = string.Empty;
        public double Resultado { get; set; }
    }
}
