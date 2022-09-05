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

        public void DeleteJoven(string DocumentoJoven)
        {
            var jovenEncontrado = _appContext.Jovenes.FirstOrDefault(j => j.Documento == DocumentoJoven);
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

        public Joven GetJoven(string DocumentoJoven)
        {
            return _appContext.Jovenes.FirstOrDefault(j => j.Documento == DocumentoJoven);
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
    }
}