using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Persistencia.AppRepositorio
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {

        private readonly AppContext _appContext;
        public RepositorioFamiliar(AppContext appContext){
            _appContext = appContext;
        }

        public Familiar AddFamiliar(Familiar familiar)
        {
            var FamiliarAdicionado = _appContext.Familiares.Add(familiar);
            _appContext.SaveChanges();
            return FamiliarAdicionado.Entity;
        }

        public void DeleteFamiliar(string DocumentoFamiliar)
        {
            var FamiliarEncontrado = _appContext.Familiares.FirstOrDefault(f => f.Documento == DocumentoFamiliar);
            if(FamiliarEncontrado == null){
                return;
            }
            _appContext.Familiares.Remove(FamiliarEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Familiar> GetAllFamiliares()
        {
            return _appContext.Familiares;
        }

        public Familiar GetFamiliar(string DocumentoFamiliar)
        {
            var FamiliarEncontrado = _appContext.Familiares.FirstOrDefault(f => f.Documento == DocumentoFamiliar);
            return FamiliarEncontrado;
        }

        public Familiar UpdateFamiliar(Familiar familiar)
        {
            var FamiliarEncontrado = _appContext.Familiares.FirstOrDefault(f => f.Documento == familiar.Documento);
            if (FamiliarEncontrado != null){
                FamiliarEncontrado.Nombre = familiar.Nombre;
                FamiliarEncontrado.Apellidos = familiar.Apellidos;
                FamiliarEncontrado.NumeroTelefono = familiar.NumeroTelefono;
                FamiliarEncontrado.Genero = familiar.Genero;
                FamiliarEncontrado.DocumentoTipo = familiar.DocumentoTipo;
                FamiliarEncontrado.Parentesco = familiar.Parentesco;
                FamiliarEncontrado.CorreoElectronico = familiar.CorreoElectronico;
                _appContext.SaveChanges();
            }
            return FamiliarEncontrado;
        }
    }
}