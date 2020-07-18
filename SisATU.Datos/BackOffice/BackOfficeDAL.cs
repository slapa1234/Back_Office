//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using SisATU.Base.ViewModel;
using SisATU.Base.ViewModel.BackOffice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SisATU.Datos
{
    public class BackOfficeDAL
    {
        string cadenaConexion = string.Empty;

        #region Constructor
        public BackOfficeDAL()
        {
            cadenaConexion = Configuracion.GetConectionSting("sConexionSISREGISTRO");
        }
        #endregion

        #region Paginado
        public async Task<DTListaExpedienteVM> BuscarPag(string expediente, string NroDocumento, string persona, int id_modalidad_servicio, string fechaRegistro, string orden, int pagina = 1, int registros = 50)
        {
            try
            {
                DTListaExpedienteVM resultado = new DTListaExpedienteVM();

                using (var bdConn = new OracleConnection(this.cadenaConexion))
                {
                    using (var bdCmd = new OracleCommand("PKG_BACKOFFICE.SP_BUSCAR_PAG", bdConn))
                    {
                        bdCmd.CommandType = CommandType.StoredProcedure;
                        bdCmd.Parameters.AddRange(ParametroBackOffice(expediente, NroDocumento, persona, id_modalidad_servicio, fechaRegistro, orden, pagina, registros));
                        bdConn.Open();
                        using (var bdRd = await bdCmd.ExecuteReaderAsync(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                        {
                            if (bdRd.HasRows)
                            {
                                resultado.TotalPagina = Convert.ToInt32(bdCmd.Parameters["P_TOTPAG"].Value.ToString());
                                resultado.TotalRegistro = Convert.ToInt32(bdCmd.Parameters["P_TOTREG"].Value.ToString());

                                while (bdRd.Read())
                                {
                                    var item = new ListaExpediente();
                                    if (!DBNull.Value.Equals(bdRd["TRAMITE"])) { item.TRAMITE = Convert.ToString(bdRd["TRAMITE"]); }
                                    if (!DBNull.Value.Equals(bdRd["FECHA_REG"])) { item.FECHA_REG = Convert.ToString(bdRd["FECHA_REG"]); }
                                    if (!DBNull.Value.Equals(bdRd["NUMERO_DOCUMENTO"])) { item.NUMERO_DOCUMENTO = Convert.ToString(bdRd["NUMERO_DOCUMENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["PERSONA"])) { item.PERSONA = Convert.ToString(bdRd["PERSONA"]); }
                                    if (!DBNull.Value.Equals(bdRd["PARNOM"])) { item.PARNOM = Convert.ToString(bdRd["PARNOM"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBRE_MODALIDAD_SERVICIO"])) { item.MODALIDAD_SERVICIO = Convert.ToString(bdRd["NOMBRE_MODALIDAD_SERVICIO"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBRE_PROCEDIMIENTO"])) { item.NOMBRE_PROCEDIMIENTO = Convert.ToString(bdRd["NOMBRE_PROCEDIMIENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_EXPEDIENTE"])) { item.ID_EXPEDIENTE = Convert.ToInt32(bdRd["ID_EXPEDIENTE"]); }
                                    if (!DBNull.Value.Equals(bdRd["NROREG"])) { item.NROREG = Convert.ToInt32(bdRd["NROREG"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_PROCEDIMIENTO"])) { item.ID_PROCEDIMIENTO = Convert.ToInt32(bdRd["ID_PROCEDIMIENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_MODALIDAD_SERVICIO"])) { item.ID_MODALIDAD_SERVICIO = Convert.ToInt32(bdRd["ID_MODALIDAD_SERVICIO"]); }
                                    if (!DBNull.Value.Equals(bdRd["IDDOC"])) { item.IDDOC = Convert.ToInt32(bdRd["IDDOC"]); }
                                    if (!DBNull.Value.Equals(bdRd["ESTADO_SISTEMA"])) { item.ESTADO = Convert.ToString(bdRd["ESTADO_SISTEMA"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBREARCHIVOS"])) { item.NOMBREARCHIVOS = Convert.ToString(bdRd["NOMBREARCHIVOS"]); }
                                    if (!DBNull.Value.Equals(bdRd["CORREOELECTRONICO"])) { item.CORREOELECTRONICO = Convert.ToString(bdRd["CORREOELECTRONICO"]); }
                                    resultado.ListaExpediente.Add(item);
                                }
                            }
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Paginado
        public async Task<DTListaExpedienteVM> BuscarVentanilla(string expediente, string NroDocumento, string persona, int id_modalidad_servicio, string fechaRegistro, string orden, int pagina = 1, int registros = 50)
        {
            try
            {
                DTListaExpedienteVM resultado = new DTListaExpedienteVM();

                using (var bdConn = new OracleConnection(this.cadenaConexion))
                {
                    using (var bdCmd = new OracleCommand("PKG_BACKOFFICE.SP_BUSCAR_VENTANILLA_PAG", bdConn))
                    {
                        bdCmd.CommandType = CommandType.StoredProcedure;
                        bdCmd.Parameters.AddRange(ParametroBackOffice(expediente, NroDocumento, persona, id_modalidad_servicio, fechaRegistro, null, pagina, registros));
                        bdConn.Open();
                        using (var bdRd = await bdCmd.ExecuteReaderAsync(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                        {
                            if (bdRd.HasRows)
                            {
                                resultado.TotalPagina = Convert.ToInt32(bdCmd.Parameters["P_TOTPAG"].Value.ToString());
                                resultado.TotalRegistro = Convert.ToInt32(bdCmd.Parameters["P_TOTREG"].Value.ToString());

                                while (bdRd.Read())
                                {
                                    var item = new ListaExpediente();
                                    if (!DBNull.Value.Equals(bdRd["TRAMITE"])) { item.TRAMITE = Convert.ToString(bdRd["TRAMITE"]); }
                                    if (!DBNull.Value.Equals(bdRd["FECHA_REG"])) { item.FECHA_REG = Convert.ToString(bdRd["FECHA_REG"]); }
                                    if (!DBNull.Value.Equals(bdRd["NUMERO_DOCUMENTO"])) { item.NUMERO_DOCUMENTO = Convert.ToString(bdRd["NUMERO_DOCUMENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["PERSONA"])) { item.PERSONA = Convert.ToString(bdRd["PERSONA"]); }
                                    if (!DBNull.Value.Equals(bdRd["PARNOM"])) { item.PARNOM = Convert.ToString(bdRd["PARNOM"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBRE_MODALIDAD_SERVICIO"])) { item.MODALIDAD_SERVICIO = Convert.ToString(bdRd["NOMBRE_MODALIDAD_SERVICIO"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBRE_PROCEDIMIENTO"])) { item.NOMBRE_PROCEDIMIENTO = Convert.ToString(bdRd["NOMBRE_PROCEDIMIENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_EXPEDIENTE"])) { item.ID_EXPEDIENTE = Convert.ToInt32(bdRd["ID_EXPEDIENTE"]); }
                                    if (!DBNull.Value.Equals(bdRd["NROREG"])) { item.NROREG = Convert.ToInt32(bdRd["NROREG"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_PROCEDIMIENTO"])) { item.ID_PROCEDIMIENTO = Convert.ToInt32(bdRd["ID_PROCEDIMIENTO"]); }
                                    if (!DBNull.Value.Equals(bdRd["ID_MODALIDAD_SERVICIO"])) { item.ID_MODALIDAD_SERVICIO = Convert.ToInt32(bdRd["ID_MODALIDAD_SERVICIO"]); }
                                    if (!DBNull.Value.Equals(bdRd["IDDOC"])) { item.IDDOC = Convert.ToInt32(bdRd["IDDOC"]); }
                                    if (!DBNull.Value.Equals(bdRd["ESTADO_SISTEMA"])) { item.ESTADO = Convert.ToString(bdRd["ESTADO_SISTEMA"]); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBREARCHIVOS"])) { item.NOMBREARCHIVOS = Convert.ToString(bdRd["NOMBREARCHIVOS"]); }
                                    if (!DBNull.Value.Equals(bdRd["CORREOELECTRONICO"])) { item.CORREOELECTRONICO = Convert.ToString(bdRd["CORREOELECTRONICO"]); }
                                    resultado.ListaExpediente.Add(item);
                                }
                            }
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Parametros Back Office
        public OracleParameter[] ParametroBackOffice(string expediente, string NroDocumento, string persona, int id_modalidad_servicio, string fechaRegistro, string orden, int pagina, int registros)
        {
            OracleParameter[] bdParameters = new OracleParameter[12];

            bdParameters[0] = new OracleParameter("P_EXPEDIENTE", OracleDbType.Varchar2) { Value = expediente };
            bdParameters[1] = new OracleParameter("P_CONNUMDOC", OracleDbType.Varchar2) { Value = NroDocumento };
            bdParameters[2] = new OracleParameter("P_PERSONA", OracleDbType.Varchar2) { Value = persona };
            bdParameters[3] = new OracleParameter("P_SOLICITUD", OracleDbType.Int32) { Value = null };
            bdParameters[4] = new OracleParameter("P_MODALIDAD", OracleDbType.Int32) { Value = id_modalidad_servicio };
            bdParameters[5] = new OracleParameter("P_FECHA", OracleDbType.Varchar2) { Value = fechaRegistro };
            bdParameters[6] = new OracleParameter("P_ORDEN", OracleDbType.Varchar2) { Value = orden };
            bdParameters[7] = new OracleParameter("P_NUMPAG", OracleDbType.Int32) { Value = pagina };
            bdParameters[8] = new OracleParameter("P_NUMREG", OracleDbType.Int32) { Value = registros };
            bdParameters[9] = new OracleParameter("P_TOTPAG", OracleDbType.Int32, direction: ParameterDirection.Output);
            bdParameters[10] = new OracleParameter("P_TOTREG", OracleDbType.Int32, direction: ParameterDirection.Output);
            bdParameters[11] = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, direction: ParameterDirection.Output);
            return bdParameters;
        }
        #endregion
        #region Parametros Cabecera
        public OracleParameter[] ParametroCabecera(int id_expediente)
        {
            OracleParameter[] bdParameters = new OracleParameter[2];

            bdParameters[0] = new OracleParameter("P_IDEXPE", OracleDbType.Int32) { Value = id_expediente };
            bdParameters[1] = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, direction: ParameterDirection.Output);
            return bdParameters;
        }
        #endregion

        #region Cabecera


        public OracleParameter[] ParametrosLogin(string usuario, string password)
        {
            OracleParameter[] bdParameters = new OracleParameter[3];

            bdParameters[0] = new OracleParameter("P_NOMBRE_USUARIO", OracleDbType.Varchar2, 200) { Value = usuario };
            bdParameters[1] = new OracleParameter("P_CLAVE", OracleDbType.Varchar2, 200) { Value = password };
            bdParameters[2] = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, direction: ParameterDirection.Output);
            return bdParameters;
        }

        public OracleParameter[] ParametrosMenu(int usuarioCodigo)
        {
            OracleParameter[] bdParameters = new OracleParameter[2];

            bdParameters[0] = new OracleParameter("P_ID_USUARIO", OracleDbType.Int32) { Value = usuarioCodigo };
            bdParameters[1] = new OracleParameter("P_CURSOR", OracleDbType.RefCursor, direction: ParameterDirection.Output);
            return bdParameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioCodigo"></param>
        /// <returns></returns>

        public IEnumerable<BackOfficeMenuVM> MenuBackOffice(int usuarioCodigo) {
            IList<BackOfficeMenuVM> resultado = new List<BackOfficeMenuVM>();
            BackOfficeMenuVM item = null;
            try
            {
                using (var bdConn = new OracleConnection(cadenaConexion))
                {
                    using (var bdCmd = new OracleCommand("PKG_USUARIO.SP_LISTAR_MENU", bdConn))
                    {
                        bdCmd.CommandType = CommandType.StoredProcedure;
                        bdCmd.Parameters.AddRange(ParametrosMenu(usuarioCodigo));

                        bdConn.Open();
                        using (var bdRd = bdCmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                        {
                            if (bdRd.HasRows)
                            {
                                while (bdRd.Read())
                                {
                                    item = new BackOfficeMenuVM();
                                    if (!DBNull.Value.Equals(bdRd["SMENU"])) { item.MenuNombre = (bdRd["SMENU"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["SCONTROLADOR"])) { item.Controlador = (bdRd["SCONTROLADOR"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["SVISTA"])) { item.Vista = (bdRd["SVISTA"]).ValorCadena(); }
                                    resultado.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }

        public BackOfficeLoginVM LoginBackOffice(BackOfficeLoginVM usuarioModel)
        {
            BackOfficeLoginVM resultado = null;
            try
            {
                using (var bdConn = new OracleConnection(cadenaConexion))
                {
                    using (var bdCmd = new OracleCommand("PKG_USUARIO.SP_VALIDAR_USUARIO", bdConn))
                    {
                        bdCmd.CommandType = CommandType.StoredProcedure;
                        bdCmd.Parameters.AddRange(ParametrosLogin(usuarioModel.Usuario, usuarioModel.Password));

                        bdConn.Open();
                        using (var bdRd = bdCmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                        {
                            if (bdRd.HasRows)
                            {
                                resultado = new BackOfficeLoginVM();
                                while (bdRd.Read())
                                {
                                    if (!DBNull.Value.Equals(bdRd["ID_USARIO"])) { resultado.UsuarioCodigo = (bdRd["ID_USARIO"]).ValorEntero(); }
                                    if (!DBNull.Value.Equals(bdRd["NRO_DOCUMENTO"])) { resultado.NumeroDocumento = (bdRd["NRO_DOCUMENTO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["APELLIDO_MATERNO"])) { resultado.ApellidoMaterno = (bdRd["APELLIDO_MATERNO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["APELLIDO_PATERNO"])) { resultado.ApellidoPaterno = (bdRd["APELLIDO_PATERNO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["NOMBRES"])) { resultado.Nombres = (bdRd["NOMBRES"]).ValorCadena(); }


                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }


        public CabeceraBackOfficeVM ConsultaCabecera(int id_expediente)
        {
            CabeceraBackOfficeVM resultado = new CabeceraBackOfficeVM();
            try
            {
                using (var bdConn = new OracleConnection(cadenaConexion))
                {
                    using (var bdCmd = new OracleCommand("PKG_BACKOFFICE.SP_DETALLE_CABECERA", bdConn))
                    {
                        bdCmd.CommandType = CommandType.StoredProcedure;
                        bdCmd.Parameters.AddRange(ParametroCabecera(id_expediente));
                        bdConn.Open();
                        using (var bdRd = bdCmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                        {
                            if (bdRd.HasRows)
                            {
                                while (bdRd.Read())
                                {
                                    if (!DBNull.Value.Equals(bdRd["TRAMITE"])) { resultado.TRAMITE = (bdRd["TRAMITE"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["NUMERO_SOLICITANTE"])) { resultado.NUMERO_SOLICITANTE = (bdRd["NUMERO_SOLICITANTE"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["SOLICITANTE"])) { resultado.SOLICITANTE = (bdRd["SOLICITANTE"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["NUMERO_RECURRENTE"])) { resultado.NUMERO_RECURRENTE = (bdRd["NUMERO_RECURRENTE"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["RECURRENTE"])) { resultado.RECURRENTE = (bdRd["RECURRENTE"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["SOLICITUD"])) { resultado.SOLICITUD = (bdRd["SOLICITUD"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["PROCEDIMIENTO"])) { resultado.NOMBRE_PROCEDIMIENTO = (bdRd["PROCEDIMIENTO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["MODALIDAD_SERVICIO"])) { resultado.MODALIDAD_SERVICIO = (bdRd["MODALIDAD_SERVICIO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["DATOREGISTRO"])) { resultado.DATOREGISTRO = (bdRd["DATOREGISTRO"]).ValorCadena(); }
                                    if (!DBNull.Value.Equals(bdRd["FECHA_ATENCION"])) { resultado.FECHA_ATENCION = (bdRd["FECHA_ATENCION"]).ValorCadena(); }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }
        #endregion
    }
}
