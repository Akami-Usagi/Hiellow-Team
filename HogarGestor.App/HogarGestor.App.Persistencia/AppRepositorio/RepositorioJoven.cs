using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Persistencia{

    
    public class RepositorioJoven : IRepositorioJoven
    {

        private readonly AppContext _appContext;
        public RepositorioJoven(AppContext appContext){
            _appContext = appContext;
        }

        
        public Joven AddJoven(Joven joven)
        {
            var jovenAdicionado = _appContext.Jovenes.Add(joven);
            _appContext.SaveChanges();
            return jovenAdicionado.Entity;
        }

        public void DeleteJoven(int IdJoven)
        {
            var jovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if (jovenEncontrado == null){
                return;
            }
            _appContext.Jovenes.Remove(jovenEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Joven> GetAllJovenes()
        {
            return _appContext.Jovenes;
        }

        public Joven GetJoven(int IdJoven)
        {
            return _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
        }

        public Joven UpdateJoven(Joven joven)
        {
            var jovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Documento == joven.Documento);
            if (jovenEncontrado != null){
                jovenEncontrado.Nombre = joven.Nombre;
                jovenEncontrado.Apellidos = joven.Apellidos;
                jovenEncontrado.NumeroTelefono = joven.NumeroTelefono;
                jovenEncontrado.Genero = joven.Genero;
                jovenEncontrado.DocumentoTipo = joven.DocumentoTipo;
                jovenEncontrado.Direccion = joven.Direccion;
                jovenEncontrado.Latitud = joven.Latitud;
                jovenEncontrado.Longitud = joven.Longitud;
                jovenEncontrado.Ciudad = joven.Ciudad;
                jovenEncontrado.FechaNacimiento = joven.FechaNacimiento;
                jovenEncontrado.FamiliarDesignado = joven.FamiliarDesignado;
                jovenEncontrado.Nutricionista = joven.Nutricionista;
                jovenEncontrado.Pediatra = joven.Pediatra;
                jovenEncontrado.HistoriaJoven = joven.HistoriaJoven;
                _appContext.SaveChanges();
                
            }
            return jovenEncontrado;
        }

        

        public Medico ToAssignNutricionista(int IdJoven, Medico nutricionista)
        {
            var JovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.Nutricionista = nutricionista;
                _appContext.SaveChanges();
                return nutricionista;
            }
            return null;
        }

        public Medico ToAssignPediatra(int IdJoven, Medico pediatra){
            var JovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.Pediatra = pediatra;
                _appContext.SaveChanges();
                return pediatra;
            }
            return null;
        }

        public IEnumerable<Joven> GetFiltro(string filtro=null)
        {
            var jovenes = this.GetAllJovenes();
            if (jovenes != null){
                if (!String.IsNullOrEmpty(filtro)){
                    jovenes = jovenes.Where(j => j.Nombre.Contains(filtro));
                }
            }
            return jovenes;
        }

        public Familiar ToAssignFamiliar(int IdJoven, Familiar familiar)
        {
            var JovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.FamiliarDesignado = familiar;
                _appContext.SaveChanges();
                return familiar;
            }
            return null;
        }

        public Medico ConsultarPediatra(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j=> j.Pediatra).FirstOrDefault();
            return joven.Pediatra;
        }

        public Medico ConsultarNutricionista(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j=> j.Nutricionista).FirstOrDefault();
            return joven.Nutricionista;
        }

        public Medico ConsultarMedico(int IdJoven){
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j=> j.Pediatra).FirstOrDefault();
            if(joven.Pediatra != null){
                return joven.Pediatra;
            }
            else{
                return joven.Nutricionista;
            }
        }

        public Familiar ConsultarFamiliar(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j=> j.FamiliarDesignado).FirstOrDefault();
            return joven.FamiliarDesignado;
        }

        public Historia GetHistoriaJoven(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j=> j.HistoriaJoven).FirstOrDefault();
            return joven.HistoriaJoven;
        }

        public Historia ToAssignHistoria(int IdJoven, Historia historia)
        {
            var JovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Id == IdJoven);
            if(JovenEncontrado!=null){
                JovenEncontrado.HistoriaJoven = historia;
                _appContext.SaveChanges();
                return historia;
            }
            return null;
        }
        public IEnumerable<PatronesCrecimiento> GetPatronesJoven(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j => j.HistoriaJoven).FirstOrDefault();
            var historia = GetHistoriaJoven(joven.Id);
            var historiaFound = _appContext.Historias.Where(h => h.Id == historia.Id).Include(h => h.PatronCrecimiento).FirstOrDefault();
            return historiaFound.PatronCrecimiento;
        }

        public IEnumerable<SugerenciaCuidado> GetSugerenciasJoven(int IdJoven)
        {
            var joven = _appContext.Jovenes.Where(j => j.Id == IdJoven).Include(j => j.HistoriaJoven).FirstOrDefault();
            var historia = GetHistoriaJoven(joven.Id);
            var historiaFound = _appContext.Historias.Where(h => h.Id == historia.Id).Include(h => h.SugerenciasCuidado).FirstOrDefault();
            return historiaFound.SugerenciasCuidado;
        }
    }
}