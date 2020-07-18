using SisATU.Base;
using SisATU.Base.ViewModel;
using SisATU.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisATU.Negocio
{
    public class EmpresaBLL
    {
        private EmpresaDAL EmpresaDAL;
        private Object bdConn;

        public EmpresaBLL()
        {
            EmpresaDAL = new EmpresaDAL(ref bdConn);
        }
        public EmpresaVM ConsultaRuc(string RUC)
        {
            EmpresaVM empresa = new EmpresaVM();
            try
            {
                EmpresaVM resultadoSUNAT = new EmpresaVM();

                resultadoSUNAT = EmpresaDAL.ConsultarEmpresa(RUC);
                if (resultadoSUNAT.ResultadoProcedimientoVM.CodResultado != 1)
                {
                    resultadoSUNAT = EmpresaDAL.ConsultaRuc(RUC);
                }

                empresa = EmpresaDAL.BuscaEmpresaSTD(RUC);

                if (empresa.ID_EMPRESA == 0)
                {
                    EmpresaDAL.CrearEmpresaSTD(resultadoSUNAT);
                    empresa = EmpresaDAL.BuscaEmpresaSTD(RUC);
                }
                empresa.RUC = resultadoSUNAT.RUC;
                empresa.RAZON_SOCIAL = resultadoSUNAT.RAZON_SOCIAL;
                if (resultadoSUNAT.FECHA_VENCIMIENTO_EXPEDIENTE != null)
                {
                    empresa.FECHA_VENCIMIENTO_EXPEDIENTE = resultadoSUNAT.FECHA_VENCIMIENTO_EXPEDIENTE;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return empresa;
        }

        public ResultadoProcedimientoVM CrearEmpresa(EmpresaModelo empresa)
        {
            return EmpresaDAL.CrearEmpresa(empresa);
        }
    }
}
