﻿using Models.ACME;
using DataAccess.ACME;

namespace Services.ACME
{
    public class EmpresaService
    {
        public bool Crear(EmpresaEntiedad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();
            try
            {
                empresaDA.Insertar(empresaEntidad);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Actualizar(EmpresaEntiedad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();
            try
            {
                empresaDA.Modificar(empresaEntidad);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public EmpresaEntiedad BuscarxID(int IDEmpresa)
        {
            EmpresaDA? empresaDA = new EmpresaDA();
            try
            {
                return empresaDA.BuscarID(IDEmpresa);
            }
            catch
            {
                return null;
            }
        }
        public List< EmpresaEntiedad>?Listar()
        {
            EmpresaDA? empresaDA = new EmpresaDA();
            try
            {
                return empresaDA.Listar();
            }
            catch
            {
                return null;
            }
        }
        public bool Eliminar(EmpresaEntiedad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();
            try
            {
                empresaDA.Anular(empresaEntidad);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
