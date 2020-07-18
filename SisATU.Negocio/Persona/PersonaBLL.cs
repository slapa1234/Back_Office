using SisATU.Base;
using SisATU.Base.Enumeradores;
using SisATU.Base.ViewModel;
using SisATU.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisATU.Negocio
{
    public class PersonaBLL
    {
        private PersonaDAL PersonaDAL;
        private Object bdConn;

        public PersonaBLL()
        {
            PersonaDAL = new PersonaDAL(ref bdConn);
        }
        public PersonaVM ConsultaDNI(string NRO_DOCUMENTO)
        {
            PersonaVM persona = new PersonaVM();
            PersonaVM personaReniec = new PersonaVM();
            PersonaVM buscaPersona = new PersonaVM();
            PersonaVM personaSTD = new PersonaVM();

            personaReniec = PersonaDAL.ConsultarPersona(EnumParametro.DNI.ValorEntero(), NRO_DOCUMENTO);

            if (personaReniec.ResultadoProcedimientoVM.CodResultado == 1 && persona.NOMBRES != null)
            {
                persona.NOMBRES = personaReniec.NOMBRES;
                persona.APELLIDO_PATERNO = personaReniec.APELLIDO_PATERNO;
                persona.APELLIDO_MATERNO = personaReniec.APELLIDO_MATERNO;
                persona.FOTO = personaReniec.FOTO;
                persona.DIRECCION = personaReniec.DIRECCION;
                persona.TELEFONO = personaReniec.TELEFONO;
                persona.CORREO = personaReniec.CORREO;
                persona.ID_DEPARTAMENTO = personaReniec.ID_DEPARTAMENTO;
                persona.ID_PROVINCIA = personaReniec.ID_PROVINCIA;
                persona.ID_DISTRITO = personaReniec.ID_DISTRITO;
                persona.DIRECCION_ACTUAL = personaReniec.DIRECCION_ACTUAL;
            }
            else
            {
                personaReniec = PersonaDAL.ConsultaDNI(NRO_DOCUMENTO);
                if (personaReniec.ResultadoProcedimientoVM.CodResultado == 1)
                {
                    persona.NOMBRES = personaReniec.NOMBRES;
                    persona.APELLIDO_PATERNO = personaReniec.APELLIDO_PATERNO;
                    persona.APELLIDO_MATERNO = personaReniec.APELLIDO_MATERNO;
                    persona.FOTO = personaReniec.FOTO;
                    persona.DIRECCION = personaReniec.DIRECCION;
                    persona.ULTIMO_DIGITO = personaReniec.ULTIMO_DIGITO;
                    persona.ResultadoProcedimientoVM.CodResultado = personaReniec.ResultadoProcedimientoVM.CodResultado;
                    persona.ResultadoProcedimientoVM.NomResultado = personaReniec.ResultadoProcedimientoVM.NomResultado;
                }
                else
                {
                    persona.ResultadoProcedimientoVM.CodResultado = personaReniec.ResultadoProcedimientoVM.CodResultado;
                    persona.ResultadoProcedimientoVM.NomResultado = personaReniec.ResultadoProcedimientoVM.NomResultado;
                    return persona;
                }

            }


            buscaPersona = new STDDAL().BuscarPersonaSTD(NRO_DOCUMENTO);
            persona.ID_PERSONA = buscaPersona.ID_PERSONA;
            persona.CODPAIS = buscaPersona.CODPAIS;
            persona.CODDPTO = buscaPersona.CODDPTO;
            persona.CODPROV = buscaPersona.CODPROV;
            persona.CODDIST = buscaPersona.CODDIST;

            if (buscaPersona.ID_PERSONA == 0)
            {
                if (personaReniec.NOMBRES != null)
                {
                    try
                    {
                        personaSTD = new STDDAL().CrearPersonaSTD(new PersonaModelo()
                        {
                            APELLIDO_PATERNO = personaReniec.APELLIDO_PATERNO,
                            APELLIDO_MATERNO = personaReniec.APELLIDO_MATERNO,
                            NOMBRES = personaReniec.NOMBRES,
                            NRO_DOCUMENTO = NRO_DOCUMENTO,
                            DIRECCION = personaReniec.DIRECCION,
                        });
                        buscaPersona = new STDDAL().BuscarPersonaSTD(NRO_DOCUMENTO);
                        persona.ID_PERSONA = buscaPersona.ID_PERSONA;
                        persona.CODPAIS = buscaPersona.CODPAIS;
                        persona.CODDPTO = buscaPersona.CODDPTO;
                        persona.CODPROV = buscaPersona.CODPROV;
                        persona.CODDIST = buscaPersona.CODDIST;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return persona;
        }

        public PersonaVM ConsultarCE(string NRO_DOCUMENTO)
        {
            PersonaVM personaReniec = new PersonaVM();

            personaReniec = PersonaDAL.ConsultarPersona(EnumParametro.CE.ValorEntero(), NRO_DOCUMENTO);

            if (personaReniec.ResultadoProcedimientoVM.CodResultado != 1)
            {
                personaReniec = PersonaDAL.ConsultarCE(NRO_DOCUMENTO);
            }

            return personaReniec;
        }

        public PersonaVM ConsultarPTP(string NRO_DOCUMENTO)
        {

            PersonaVM personaReniec = new PersonaVM();
            personaReniec = PersonaDAL.ConsultarPersona(EnumParametro.PTP.ValorEntero(), NRO_DOCUMENTO);

            if (personaReniec.ResultadoProcedimientoVM.CodResultado != 1)
            {
                personaReniec = PersonaDAL.ConsultarPTP(NRO_DOCUMENTO);
            }
            return personaReniec;
        }

        public PersonaVM ConsultarPersona(int ID_TIPO_DOCUMENTO, string NRO_DOCUMENTO)
        {
            return PersonaDAL.ConsultarPersona(ID_TIPO_DOCUMENTO, NRO_DOCUMENTO);
        }

        public ResultadoProcedimientoVM CrearPersona(PersonaModelo persona)
        {
            return PersonaDAL.CrearPersona(persona);
        }

        public ResultadoProcedimientoVM RecuperarContrasena(string nroDocumento, string correo, string contrasenia)
        {
            return PersonaDAL.RecuperarClave(nroDocumento, correo, contrasenia);
        }
    }
}
