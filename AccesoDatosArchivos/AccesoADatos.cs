using System;

using System;

namespace DatosDesdeArchivos
{
    public abstract class AccesoADatos
    {
	    public abstract Cadeteria CargarCadeteria(string rutaCadeteria);
        public abstract List<Cadete> CargarCadetes(string rutaCadetes);
    }
}