namespace HogarGestor.App.Dominio
{
    public class AsignarMedico
    {
        public int Id { get; set; }

        public int JovenId { get; set; }

        public Joven Joven { get; set; }

        public int MedicoId { get; set; }

        public Medico Medico { get; set; }
    }
}
