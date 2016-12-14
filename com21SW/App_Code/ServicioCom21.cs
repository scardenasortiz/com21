using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Xml;
using com21DLL;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de ServicioWesternUnion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioCom21 : System.Web.Services.WebService {

    public ServicioCom21 () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    public string error;
    public string Error
    {
        get { return error; }
        set { error = value; }
    }

    
    //classServicios _servicios;
    classUsuario _usuario;
    
    classAgencias _agencias;
    classAlbum _album;
    classMp3Imagen _mp3imagen;
    classSuscriptores _suscriptores;
    classVideoYoutube _videoyoutube;
    classCancion _cancion;
    classInstrumentos _instrumentos;
    classDvdmusicales _dvdmusicales;
    classAccesorios _accesorios;
    classLongplay _longplay;
    classCancionero _cancionero;
    classAutocompletador _autocompletador;
    classAdministrador _administrador;

    #region "Variables de clases"
    classCom21Porvincias _provincias;
    classCom21Nosotros _nosotros;
    classCom21MisionVision _mv;
    classCom21Slide _slide;
    classCom21Categoria _categoria;
    classCom21SubCategoria _scategoria;
    classCom21Imagenes _imagenes;
    classCom21Ciudad _ciudad;
    classCom21Costo _costo;
    classCom21Marca _marca;
    classCom21Administrador _admin;
    classCom21Pais _pais;
    classCom21Empresa _empresa;
    classCom21Perfil _perfil;
    classCom21Producto _productos;
    classCom21PromoPubli _promopubli;
    classCom21Servicios _servicios;
    classCom21Reportes _reportes;
    classCom21Inventario _invent;
    classCom21Cliente _cliente;
    classCom21Tags _tags;
    Com21classPrefactura _prefactura;
    classCom21CategoriaServicios _catserv;
    classCom21Noticias _noticias;
    classCom21App _appC;
    #endregion
    List<string> items;


    /// METODOS WEB APP ANDROID COM21
    /// </summary>
    #region "METODOS WEB APP ANDROID COM21"
    [WebMethod]
    public DataSet Com21_consulta_portada()
    {
        _appC = new classCom21App();
        error = _appC.MsgError;
        return _appC.Com21_consulta_portada();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_app()
    {
        _appC = new classCom21App();
        error = _appC.MsgError;
        return _appC.Com21_consulta_productos_app();
    }
    [WebMethod]
    public DataSet Com21_consulta_ofertas_app()
    {
        _appC = new classCom21App();
        error = _appC.MsgError;
        return _appC.Com21_consulta_ofertas_app();
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_app()
    {
        _appC = new classCom21App();
        error = _appC.MsgError;
        return _appC.Com21_consulta_servicios_app();
    }
    #endregion
    /// <summary>
    /// METODOS WEB INBOX - OUTBOX
    /// </summary>
    #region "METODOS WEB INBOX - OUTBOX"
    [WebMethod]
    public DataSet Com21_consulta_inbox_outbox()
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_inbox_outbox();
    }
    [WebMethod]
    public DataSet Com21_consulta_inbox_outbox_id(int Id_InOut)
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_inbox_outbox_id(Id_InOut);
    }
    [WebMethod]
    public bool Com21_ingresa_inbox_outbox(string strXmlDatos)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_ingresa_inbox_outbox(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_inbox_outbox(int Id_InOut)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_edita_inbox_outbox(Id_InOut);
    }
    [WebMethod]
    public bool Com21_eliminar_inbox_outbox(int Id_InOut)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_eliminar_inbox_outbox(Id_InOut);
    }
    #endregion
    /// <summary>
    /// METODOS WEB NOTICIAS
    /// </summary>
    #region "METODOS WEB NOTICIAS"
    [WebMethod]
    public DataSet Com21_consulta_noticias()
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias();
    }
    [WebMethod]
    public DataSet Com21_consulta_noticias_mostrar()
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias_mostrar();
    }
    [WebMethod]
    public DataSet Com21_consulta_noticias_id(int Id_Servicio)
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias_id(Id_Servicio);
    }
    [WebMethod]
    public bool Com21_ingresa_noticias(string strXmlDatos)
    {
        com21DLL.classCom21Noticias _noticias = new com21DLL.classCom21Noticias();
        return _noticias.Com21_ingresa_noticias(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_noticias(string strXmlDatos, int Id_Servicio)
    {
        com21DLL.classCom21Noticias _noticias = new com21DLL.classCom21Noticias();
        return _noticias.Com21_edita_noticias(strXmlDatos, Id_Servicio);
    }
    [WebMethod]
    public bool Com21_elimina_noticias(int Id_Servicio)
    {
        com21DLL.classCom21Noticias _noticias = new com21DLL.classCom21Noticias();
        return _noticias.Com21_elimina_noticias(Id_Servicio);
    }
    [WebMethod]
    public DataSet Com21_consulta_noticias_letra(string Titulo)
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias_letra(Titulo);
    }
    [WebMethod]
    public bool Com21_edita_noticias_url(string Url, int Id_Servicio)
    {
        com21DLL.classCom21Noticias _noticias = new com21DLL.classCom21Noticias();
        return _noticias.Com21_edita_noticias_url(Url, Id_Servicio);
    }
    [WebMethod]
    public DataSet Com21_consulta_noticias_ultimo()
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias_ultimo();
    }
    [WebMethod]
    public DataSet Com21_consulta_noticias_numero(int Numero, int Des)
    {
        _noticias = new classCom21Noticias();
        error = _noticias.MsgError;
        return _noticias.Com21_consulta_noticias_numero(Numero, Des);
    }
    #endregion
    /// <summary>
    /// METODOS WEB CATEGORIAS SERVICIOS
    /// </summary>
    #region "METODOS WEB CATEGORIAS SERVICIOS"
    [WebMethod]
    public DataSet Com21_consulta_catserv()
    {
        _catserv = new classCom21CategoriaServicios();
        error = _catserv.MsgError;
        return _catserv.Com21_consulta_catserv();
    }
    [WebMethod]
    public DataSet Com21_consulta_catserv_id(int Id_catserv)
    {
        _catserv = new classCom21CategoriaServicios();
        error = _catserv.MsgError;
        return _catserv.Com21_consulta_catserv_id(Id_catserv);
    }
    [WebMethod]
    public bool Com21_ingresa_catserv(string strXmlDatos)
    {
        com21DLL.classCom21CategoriaServicios _catserv = new com21DLL.classCom21CategoriaServicios();
        return _catserv.Com21_ingresa_catserv(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_catserv(string strXmlDatos, int Id_catserv)
    {
        com21DLL.classCom21CategoriaServicios _catserv = new com21DLL.classCom21CategoriaServicios();
        return _catserv.Com21_edita_catserv(strXmlDatos, Id_catserv);
    }
    [WebMethod]
    public bool Com21_elimina_catserv(int Id_catserv)
    {
        com21DLL.classCom21CategoriaServicios _catserv = new com21DLL.classCom21CategoriaServicios();
        return _catserv.Com21_elimina_catserv(Id_catserv);
    }
    [WebMethod]
    public DataSet Com21_consulta_catserv_letra(string Letra, int Ident)
    {
        _catserv = new classCom21CategoriaServicios();
        error = _catserv.MsgError;
        return _catserv.Com21_consulta_catserv_letra(Letra, Ident);
    }
    [WebMethod]
    public DataSet Com21_consulta_catserv_numero_web(int Numero, int Id_catserv)
    {
        _catserv = new classCom21CategoriaServicios();
        error = _catserv.MsgError;
        return _catserv.Com21_consulta_catserv_numero_web(Numero, Id_catserv);
    }
    #endregion
    /// <summary>
    /// METODOS WEB PREFACTURAS
    /// </summary>
    #region "METODOS PREFACTURAS"
    [WebMethod]
    public bool proc_ingresa_prefactura(string strXmlDatos)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_ingresa_prefactura(strXmlDatos);
    }
    [WebMethod]
    public DataSet consulta_producto_prefacturado_id_user_cant_tot()
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_producto_prefacturado_id_user_cant_tot();
    }
    [WebMethod]
    public DataSet consulta_producto_repetido(int IdUsuario, int IdProducto)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_producto_repetido(IdUsuario, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_producto_repetido(string strXmlDatos, int IdUsuario, int IdProducto, string Producto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_producto_repetido(strXmlDatos, IdUsuario, IdProducto, Producto);
    }
    [WebMethod]
    public DataSet consulta_producto_prefacturado(int IdUsuario)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_producto_prefacturado(IdUsuario);
    }
    [WebMethod]
    public bool proc_edita_producto_prefacturado_carrito(string strXmlDatos, int IdPrefactura)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_producto_prefacturado_carrito(strXmlDatos, IdPrefactura);
    }
    [WebMethod]
    public bool proc_elimina_producto_prefactura(int IdUsuario, int IdPrefactura)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_elimina_producto_prefactura(IdUsuario, IdPrefactura);
    }
    [WebMethod]
    public bool proc_edita_prefacturaDatosUsuario(string strXmlDatos, int IdUsuario)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_prefacturaDatosUsuario(strXmlDatos, IdUsuario);
    }
    [WebMethod]
    public bool proc_edita_codupdate_prefactura(int IdProducto, int IdUsuario, string CodUpdate)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_codupdate_prefactura(IdProducto, IdUsuario, CodUpdate);
    }
    [WebMethod]
    public bool proc_edita_prefacturado_producto_DatosUsuario_CodUpdate(string strXmlDatos, string CodUpdate)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_prefacturado_producto_DatosUsuario_CodUpdate(strXmlDatos, CodUpdate);
    }
    [WebMethod]
    public bool proc_edita_prefacturado_producto_Estado_CodUpdate(string strXmlDatos, string CodUpdate)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_prefacturado_producto_Estado_CodUpdate(strXmlDatos, CodUpdate);
    }
    [WebMethod]
    public bool proc_Ingresa_Transaccion(string strXmlDatos)
    {
        _prefactura = new Com21classPrefactura();
        return _prefactura.proc_Ingresa_Transaccion(strXmlDatos);
    }
    [WebMethod]
    public bool proc_Ingresa_DetalleTransaccion(string strXmlDatos)
    {
        _prefactura = new Com21classPrefactura();
        return _prefactura.proc_Ingresa_DetalleTransaccion(strXmlDatos);
    }
    [WebMethod]
    public bool proc_Actualiza_Transaccion(string strXmlDatos, string IdTransaccion)
    {
        _prefactura = new Com21classPrefactura();
        return _prefactura.proc_Actualiza_Transaccion(strXmlDatos, IdTransaccion);
    }
    [WebMethod]
    public bool proc_actualiza_cantidad_producto_id(int Cant, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_cantidad_producto_id(Cant, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_cantidad_producto_id_Menos(int Cant, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_cantidad_producto_id_Menos(Cant, IdProducto);
    }
    [WebMethod]
    public DataSet consulta_producto_prefacturado_IdCod(int IdUsuario, string CodUpdate)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_producto_prefacturado_IdCod(IdUsuario, CodUpdate);
    }
    [WebMethod]
    public DataSet consulta_prefactura_trans_direccion(int Pais, int Provincia, int Ciudad)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_prefactura_trans_direccion(Pais, Provincia, Ciudad);
    }
    [WebMethod]
    public DataSet consulta_transaccion_facturada_IdT(string IdTransaccion)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_transaccion_facturada_IdT(IdTransaccion);
    }
    [WebMethod]
    public bool proc_edita_producto_prefacturado_Fact(string strXmlDatos, string IdTransaccion)
    {
        _prefactura = new Com21classPrefactura();
        return _prefactura.proc_edita_producto_prefacturado_Fact(strXmlDatos, IdTransaccion);
    }
    [WebMethod]
    public bool proc_ingresa_ordenes(string Cod, int IdUsuario, string Trans)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.proc_ingresa_ordenes(Cod, IdUsuario, Trans);
    }
    [WebMethod]
    public DataSet consulta_ordenes(int IdUsuario)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_ordenes(IdUsuario);
    }
    [WebMethod]
    public DataSet consulta_detalle_orden(int IdUsuario, string IdTransaccion, string cod)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_detalle_orden(IdUsuario, IdTransaccion, cod);
    }
    //[WebMethod]
    //public DataSet consulta_producto_prefacturado_IdCod(int IdUsuario, string CodUpdate)
    //{
    //    _prefactura = new Com21classPrefactura();
    //    error = _prefactura.Error;
    //    return _prefactura.consulta_producto_prefacturado_IdCod(IdUsuario, CodUpdate);
    //}
    //fin actuales




    //antiguos
    [WebMethod]
    public DataSet consulta_producto_prefacturado_accesorio(int IdUsuario)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.MsgError;
        return _prefactura.consulta_producto_prefacturado_accesorio(IdUsuario);
    }
    [WebMethod]
    public bool proc_edita_producto_prefacturado(string strXmlDatos, int IdUsuario)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_producto_prefacturado(strXmlDatos, IdUsuario);
    }
    [WebMethod]
    public bool proc_edita_total_prefactura(int IdProducto, int IdUsuario, string Producto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_edita_total_prefactura(IdProducto, IdUsuario, Producto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_accesorio(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_accesorio(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_cancionero(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_cancionero(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_album(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_album(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_longplay(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_longplay(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_instrumento(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_instrumento(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_producto_dvdmusicales(string strXmlDatos, int IdProducto)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_producto_dvdmusicales(strXmlDatos, IdProducto);
    }
    [WebMethod]
    public bool proc_actualiza_stock_productos_general(string Tipo, int IdProducto, int Cantidad, int Id_Usuario)
    {
        com21DLL.Com21classPrefactura _prefactura = new com21DLL.Com21classPrefactura();
        return _prefactura.proc_actualiza_stock_productos_general(Tipo, IdProducto, Cantidad, Id_Usuario);
    }
    [WebMethod]
    public DataSet consulta_producto_prefacturado_tarifa(int IdUsuario)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_producto_prefacturado_tarifa(IdUsuario);
    }
    //[WebMethod]
    //public DataSet consulta_Pais_EditaUsu(int IdPais)
    //{
    //    _nosotros = new classCom21Nosotros();
    //    error = _nosotros.MsgError;
    //    return _nosotros.consulta_Pais_EditaUsu(IdPais);
    //}

    ///costo envio IdCiudad
    ///
    [WebMethod]
    public DataSet consulta_costoenvio_IdCiudad(string Ciudad)
    {
        _prefactura = new Com21classPrefactura();
        error = _prefactura.Error;
        return _prefactura.consulta_costoenvio_IdCiudad(Ciudad);
    }
    #endregion
    /// METODOS WEB TAGS
    /// </summary>
    #region "METODOS WEB TAGS"
    [WebMethod]
    public DataSet Com21_consulta_tags_marca_categorias_sub()
    {
        _tags = new classCom21Tags();
        error = _tags.MsgError;
        return _tags.Com21_consulta_tags_marca_categorias_sub();
    }
    #endregion
    /// </summary>
    /// METODOS WEB CLIENTES
    /// </summary>
    #region "METODOS WEB CLIENTES"
    [WebMethod]
    public DataSet Com21_consulta_valida_cliente(String usuario, String clave)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_valida_cliente(usuario, clave);
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente()
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente();
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente_id(int Id_Clientes)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente_id(Id_Clientes);
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente_letra(String Letra)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente_letra(Letra);
    }
    [WebMethod]
    public DataSet Com21_consulta_recuperar_clave_cliente(String Dato, String Ident)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_recuperar_clave_cliente(Dato, Ident);
    }
    [WebMethod]
    public bool Com21_ingresa_cliente(string strXmlDatos)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_ingresa_cliente(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_cliente(string strXmlDatos, int Id_Clientes)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_edita_cliente(strXmlDatos, Id_Clientes);
    }
    [WebMethod]
    public bool Com21_edita_clave_cliente(string strXmlDatos, int Id_Clientes)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_edita_clave_cliente(strXmlDatos, Id_Clientes);
    }
    [WebMethod]
    public DataSet Com21_consulta_valida_user(String Usuario)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_valida_user(Usuario);
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente_direccio_envio(int Id_Clientes)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente_direccio_envio(Id_Clientes);
    }
    [WebMethod]
    public bool Com21_ingresa_cliente_direccion(string strXmlDatos)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_ingresa_cliente_direccion(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_cliente_direccion(string strXmlDatos, int Id_Clientes)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_edita_cliente_direccion(strXmlDatos, Id_Clientes);
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente_correo_clave(String Correo)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente_correo_clave(Correo);
    }
    [WebMethod]
    public XmlDocument Com21_consulta_clientesolo_prueba()
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_clientesolo_prueba();
    }
    [WebMethod]
    public DataSet com21_clienteCom21_consulta_cliente_historial_compras(int IdUsuario)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.com21_clienteCom21_consulta_cliente_historial_compras(IdUsuario);
    }
    [WebMethod]
    public DataSet Com21_consulta_cliente_DatosCompra(int Id_Clientes, int Inicio)
    {
        _cliente = new classCom21Cliente();
        error = _cliente.MsgError;
        return _cliente.Com21_consulta_cliente_DatosCompra(Id_Clientes, Inicio);
    }
    [WebMethod]
    public bool Com21_edita_cliente_DatosCompra(string strXmlDatos, int Id_Clientes)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_edita_cliente_DatosCompra(strXmlDatos, Id_Clientes);
    }
    [WebMethod]
    public bool Com21_ingresa_cliente_DatosCompra(string strXmlDatos)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_ingresa_cliente_DatosCompra(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_elimina_cliente_DatosCompra(int Id_Clientes)
    {
        com21DLL.classCom21Cliente _cliente = new com21DLL.classCom21Cliente();
        return _cliente.Com21_elimina_cliente_DatosCompra(Id_Clientes);
    }
    #endregion
    /// </summary>
    /// METODOS WEB INVENTARIO
    /// </summary>
    #region "METODOS WEB INVENTARIO"
    [WebMethod]
    public DataSet Com21_consulta_inventario_productos()
    {
        _invent = new classCom21Inventario();
        error = _invent.MsgError;
        return _invent.Com21_consulta_inventario_productos();
    }
    [WebMethod]
    public DataSet Com21_consulta_inventario_productos_nombre(string Nombre)
    {
        _invent = new classCom21Inventario();
        error = _invent.MsgError;
        return _invent.Com21_consulta_inventario_productos_nombre(Nombre);
    }
    [WebMethod]
    public DataSet Com21_consulta_inventario_productos_id(int Ivent, int Prod)
    {
        _invent = new classCom21Inventario();
        error = _invent.MsgError;
        return _invent.Com21_consulta_inventario_productos_id(Ivent, Prod);
    }
    [WebMethod]
    public DataSet Com21_consulta_inventario_productos_CV(int Filtrar, int Pro)
    {
        _invent = new classCom21Inventario();
        error = _invent.MsgError;
        return _invent.Com21_consulta_inventario_productos_CV(Filtrar, Pro);
    }
    [WebMethod]
    public bool Com21_ingresa_inventario_productos(string strXmlDatos)
    {
        com21DLL.classCom21Inventario _invent = new com21DLL.classCom21Inventario();
        return _invent.Com21_ingresa_inventario_productos(strXmlDatos);
    }    
    #endregion
    /// METODOS WEB REPORTES
    /// </summary>
    #region "METODOS WEB REPORTES"
    [WebMethod]
    public DataSet Com21_consulta_ResportesTransaccion()
    {
        _reportes = new classCom21Reportes();
        error = _reportes.MsgError;
        return _reportes.Com21_consulta_ResportesTransaccion();
    }
    [WebMethod]
    public DataSet Com21_consulta_ResportesInicial()
    {
        _reportes = new classCom21Reportes();
        error = _reportes.MsgError;
        return _reportes.Com21_consulta_ResportesInicial();
    }
    [WebMethod]
    public DataSet Com21_consulta_Resportes(int Ident, int Ddl, string Inicio, string Fin)
    {
        _reportes = new classCom21Reportes();
        error = _reportes.MsgError;
        return _reportes.Com21_consulta_Resportes(Ident, Ddl, Inicio, Fin);
    }
    [WebMethod]
    public DataSet Com21_consulta_ResportesInicialTrans()
    {
        _reportes = new classCom21Reportes();
        error = _reportes.MsgError;
        return _reportes.Com21_consulta_ResportesInicialTrans();
    }
    [WebMethod]
    public DataSet Com21_consulta_ResportesFechaTrans(string FecInicio, string FecFin, int Ident)
    {
        _reportes = new classCom21Reportes();
        error = _reportes.MsgError;
        return _reportes.Com21_consulta_ResportesFechaTrans(FecInicio, FecFin, Ident);
    }
    #endregion
    /// METODOS WEB SERVICIOS
    /// </summary>
    #region "METODOS WEB SERVICIOS"
    [WebMethod]
    public DataSet Com21_consulta_servicios()
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios();
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_mostrar()
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_mostrar();
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_id(int Id_Servicio)
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_id(Id_Servicio);
    }
    [WebMethod]
    public bool Com21_ingresa_servicios(string strXmlDatos)
    {
        com21DLL.classCom21Servicios _servicios = new com21DLL.classCom21Servicios();
        return _servicios.Com21_ingresa_servicios(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_servicios(string strXmlDatos, int Id_Servicio)
    {
        com21DLL.classCom21Servicios _servicios = new com21DLL.classCom21Servicios();
        return _servicios.Com21_edita_servicios(strXmlDatos, Id_Servicio);
    }
    [WebMethod]
    public bool Com21_elimina_servicios(int Id_Servicio)
    {
        com21DLL.classCom21Servicios _servicios = new com21DLL.classCom21Servicios();
        return _servicios.Com21_elimina_servicios(Id_Servicio);
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_letra(string Titulo)
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_letra(Titulo);
    }
    [WebMethod]
    public bool Com21_edita_servicios_url(string Url, int Id_Servicio)
    {
        com21DLL.classCom21Servicios _servicios = new com21DLL.classCom21Servicios();
        return _servicios.Com21_edita_servicios_url(Url, Id_Servicio);
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_ultimo()
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_ultimo();
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_numero(int Numero, int Des)
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_numero(Numero, Des);
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_cat()
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_cat();
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_web_numero_categoria_id(int Numero, int Sub, int Des, int Id_Categoria)
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_web_numero_categoria_id(Numero, Sub, Des, Id_Categoria);
    }
    [WebMethod]
    public DataSet Com21_consulta_servicios_web_Top5()
    {
        _servicios = new classCom21Servicios();
        error = _servicios.MsgError;
        return _servicios.Com21_consulta_servicios_web_Top5();
    }
    #endregion
    /// <summary>
    /// METODOS WEB PROMOCIONES PUBLICIDAD
    /// </summary>
    #region "METODOS WEB PROMOCIONES PUBLICIDAD"
    [WebMethod]
    public DataSet Com21_consulta_promo_publi()
    {
        _promopubli = new classCom21PromoPubli();
        error = _promopubli.MsgError;
        return _promopubli.Com21_consulta_promo_publi();
    }
    [WebMethod]
    public DataSet Com21_consulta_promo_publi_id(int Id_ProPu)
    {
        _promopubli = new classCom21PromoPubli();
        error = _promopubli.MsgError;
        return _promopubli.Com21_consulta_promo_publi_id(Id_ProPu);
    }
    [WebMethod]
    public bool Com21_ingresa_promo_publi(string strXmlDatos)
    {
        com21DLL.classCom21PromoPubli _promopubli = new com21DLL.classCom21PromoPubli();
        return _promopubli.Com21_ingresa_promo_publi(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_promo_publi(string strXmlDatos, int Id_ProPu)
    {
        com21DLL.classCom21PromoPubli _promopubli = new com21DLL.classCom21PromoPubli();
        return _promopubli.Com21_edita_promo_publi(strXmlDatos, Id_ProPu);
    }
    [WebMethod]
    public bool Com21_elimina_promo_publi(int Id_ProPu)
    {
        com21DLL.classCom21PromoPubli _promopubli = new com21DLL.classCom21PromoPubli();
        return _promopubli.Com21_elimina_promo_publi(Id_ProPu);
    }
    [WebMethod]
    public bool Com21_edita_promo_publi_prioridad(int Id_ProPu)
    {
        com21DLL.classCom21PromoPubli _promopubli = new com21DLL.classCom21PromoPubli();
        return _promopubli.Com21_edita_promo_publi_prioridad(Id_ProPu);
    }
    [WebMethod]
    public DataSet Com21_consulta_promo_publi_mostrar()
    {
        _promopubli = new classCom21PromoPubli();
        error = _promopubli.MsgError;
        return _promopubli.Com21_consulta_promo_publi_mostrar();
    }
    [WebMethod]
    public DataSet Com21_consulta_promo_publi_letra(int Seleccionar, int Prioridad)
    {
        _promopubli = new classCom21PromoPubli();
        error = _promopubli.MsgError;
        return _promopubli.Com21_consulta_promo_publi_letra(Seleccionar, Prioridad);
    }
    [WebMethod]
    public DataSet Com21_consulta_promo_publi_prioridad(int Prioridad)
    {
        _promopubli = new classCom21PromoPubli();
        error = _promopubli.MsgError;
        return _promopubli.Com21_consulta_promo_publi_prioridad(Prioridad);
    }
    #endregion
    /// <summary>
    /// METODOS WEB PRODUCTOS
    /// </summary>
    #region "METODOS WEB PRODUCTOS"
    [WebMethod]
    public DataSet Com21_consulta_productos()
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_id(int Id_productos)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_id(Id_productos);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_id_Web(int Id_productos)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_id_Web(Id_productos);
    }
    [WebMethod]
    public bool Com21_ingresa_productos(string strXmlDatos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_ingresa_productos(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_productos(string strXmlDatos, int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_edita_productos(strXmlDatos, Id_productos);
    }
    [WebMethod]
    public bool Com21_elimina_productos(int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_elimina_productos(Id_productos);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_letra(string Letra)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_letra(Letra);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_tituloid(int Id_Producto)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_tituloid(Id_Producto);
    }
    [WebMethod]
    public bool Com21_edita_productos_Url(string Url, int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_edita_productos_Url(Url, Id_productos);
    }
    [WebMethod]
    public bool Com21_edita_productos_marca(string strXmlDatos, int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_edita_productos_marca(strXmlDatos, Id_productos);
    }
    [WebMethod]
    public bool Com21_edita_productos_sub_categoria(string strXmlDatos, int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_edita_productos_sub_categoria(strXmlDatos, Id_productos);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_marca()
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_marca();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_sub_categoria()
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_sub_categoria();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_numero(int Numero, int Sub, int Des)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_numero(Numero, Sub, Des);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_precio(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_precio(Inicio, Fin, Numero, Sub, Des, Ident);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_ultimo()
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_ultimo();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_marca_sub(int Id_SubCategoria)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_marca_sub(Id_SubCategoria);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_numero_marca_id(int Numero, int Sub, int Des, int Id_Marca)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_numero_marca_id(Numero, Sub, Des, Id_Marca);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_marcar(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident, int Id_Marca)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_marcar(Inicio, Fin, Numero, Sub, Des, Ident, Id_Marca);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_categoria_nosub(int Cat, int Sub)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_categoria_nosub(Cat, Sub);
    }
    [WebMethod]
    public DataSet Com21_consulta_catalgo_productos_web()
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_catalgo_productos_web();
    }
    #region "Catalogos Productos"
    [WebMethod]
    public DataSet Com21_consulta_productos_Catalogo_web_numero(int Numero, int Des)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_Catalogo_web_numero(Numero, Des);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_Catalogo_web_numero_Sub(int Numero, int Sub, int Des)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_Catalogo_web_numero_Sub(Numero, Sub, Des);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_Catalogo_web_precio(string Inicio, string Fin, int Numero, int Des, int Ident)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_Catalogo_web_precio(Inicio, Fin, Numero, Des, Ident);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_Catalogo_web_precio_Sub(string Inicio, string Fin, int Numero, int Sub, int Des, int Ident)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_Catalogo_web_precio_Sub(Inicio, Fin, Numero, Sub, Des, Ident);
    }
    #endregion
    [WebMethod]
    public DataSet Com21_consulta_productos_cantidad_id(int Id_productos)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_cantidad_id(Id_productos);
    }
    [WebMethod]
    public bool Com21_edita_productos_cantidad_restar(string strXmlDatos, int Id_productos)
    {
        com21DLL.classCom21Producto _productos = new com21DLL.classCom21Producto();
        return _productos.Com21_edita_productos_cantidad_restar(strXmlDatos, Id_productos);
    }

    #region "BUSQUEDA"
    [WebMethod]
    public DataSet Com21_consulta_productos_web_numero_busqueda(int Numero, string Texto, int Des)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_numero_busqueda(Numero, Texto, Des);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_web_precio_busqueda(string Inicio, string Fin, int Numero, string Texto, int Des, int Ident)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_web_precio_busqueda(Inicio, Fin, Numero, Texto, Des, Ident);
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_relacionados(int Id_Producto, int Id_Categoria, int Id_SubCategoria)
    {
        _productos = new classCom21Producto();
        error = _productos.MsgError;
        return _productos.Com21_consulta_productos_relacionados(Id_Producto, Id_Categoria, Id_SubCategoria);
    }
    #endregion
    #endregion
    /// </summary>
    /// METODOS WEB PERFIL
    /// </summary>
    #region "METODOS WEB PERFIL"
    [WebMethod]
    public DataSet Com21_consulta_perfil_opc(int Id_Administrador)
    {
        _perfil = new classCom21Perfil();
        error = _perfil.MsgError;
        return _perfil.Com21_consulta_perfil_opc(Id_Administrador);
    }
    //[WebMethod]
    //public DataSet Com21_consulta_perfil_id(int Id_perfil)
    //{
    //    _perfil = new classCom21Perfil();
    //    error = _perfil.MsgError;
    //    return _perfil.Com21_consulta_perfil_id(Id_perfil);
    //}
    [WebMethod]
    public bool Com21_ingresa_perfil(string strXmlDatos)
    {
        com21DLL.classCom21Perfil _perfil = new com21DLL.classCom21Perfil();
        return _perfil.Com21_ingresa_perfil(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_perfil(string strXmlDatos, int Id_Perfil)
    {
        com21DLL.classCom21Perfil _perfil = new com21DLL.classCom21Perfil();
        return _perfil.Com21_edita_perfil(strXmlDatos, Id_Perfil);
    }
    [WebMethod]
    public bool Com21_elimina_perfil(int Id_perfil)
    {
        com21DLL.classCom21Perfil _perfil = new com21DLL.classCom21Perfil();
        return _perfil.Com21_elimina_perfil(Id_perfil);
    }

    [WebMethod]
    public bool Com21_activa_administrador(int Id_Administrador)
    {
        com21DLL.classCom21Perfil _perfil = new com21DLL.classCom21Perfil();
        return _perfil.Com21_activa_administrador(Id_Administrador);
    }
    #endregion
    /// <summary>
    /// METODOS WEB PROVINCIA
    /// </summary>
    #region "METODOS WEB PROVINCIAS"
    [WebMethod]
    public DataSet Com21_consulta_provincias()
    {
        _provincias = new classCom21Porvincias();
        error = _provincias.MsgError;
        return _provincias.Com21_consulta_provincias();
    }
    [WebMethod]
    public DataSet Com21_consulta_provincias_id(int Id_Provincia)
    {
        _provincias = new classCom21Porvincias();
        error = _provincias.MsgError;
        return _provincias.Com21_consulta_provincias_id(Id_Provincia);
    }
    [WebMethod]
    public bool Com21_ingresa_provincias(string strXmlDatos)
    {
        com21DLL.classCom21Porvincias _provincias = new com21DLL.classCom21Porvincias();
        return _provincias.Com21_ingresa_provincias(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_provincias(string strXmlDatos, int Id_Provincia)
    {
        com21DLL.classCom21Porvincias _provincias = new com21DLL.classCom21Porvincias();
        return _provincias.Com21_edita_provincias(strXmlDatos, Id_Provincia);
    }
    [WebMethod]
    public bool Com21_elimina_provincias(int Id_Provincia)
    {
        com21DLL.classCom21Porvincias _provincias = new com21DLL.classCom21Porvincias();
        return _provincias.Com21_elimina_provincias(Id_Provincia);
    }
    [WebMethod]
    public bool Com21_activar_provincias(int Id_Provincia)
    {
        com21DLL.classCom21Porvincias _provincias = new com21DLL.classCom21Porvincias();
        return _provincias.Com21_activar_provincias(Id_Provincia);
    }
    [WebMethod]
    public bool Com21_elimina_provincias_Ciudades(int Id_Provincia)
    {
        com21DLL.classCom21Porvincias _provincias = new com21DLL.classCom21Porvincias();
        return _provincias.Com21_elimina_provincias_Ciudades(Id_Provincia);
    }
    [WebMethod]
    public DataSet Com21_consulta_provincias_letra(string Letra, int Id_Pais, int Ident)
    {
        _provincias = new classCom21Porvincias();
        error = _provincias.MsgError;
        return _provincias.Com21_consulta_provincias_letra(Letra, Id_Pais, Ident);
    }
    #endregion
    /// <summary>
    /// METODOS WEB EMPRESA
    /// </summary>
    #region "METODOS WEB EMPRESA"
    [WebMethod]
    public DataSet Com21_consulta_empresa()
    {
        _empresa = new classCom21Empresa();
        error = _empresa.MsgError;
        return _empresa.Com21_consulta_empresa();
    }
    [WebMethod]
    public DataSet Com21_consulta_empresa_id(int Id_Empresa)
    {
        _empresa = new classCom21Empresa();
        error = _empresa.MsgError;
        return _empresa.Com21_consulta_empresa_id(Id_Empresa);
    }
    [WebMethod]
    public bool Com21_ingresa_empresa(string strXmlDatos)
    {
        com21DLL.classCom21Empresa _empresa = new com21DLL.classCom21Empresa();
        return _empresa.Com21_ingresa_empresa(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_empresa(string strXmlDatos, int Id_Empresa)
    {
        com21DLL.classCom21Empresa _empresa = new com21DLL.classCom21Empresa();
        return _empresa.Com21_edita_empresa(strXmlDatos, Id_Empresa);
    }
    [WebMethod]
    public bool Com21_elimina_empresa(int Id_Empresa)
    {
        com21DLL.classCom21Empresa _empresa = new com21DLL.classCom21Empresa();
        return _empresa.Com21_elimina_empresa(Id_Empresa);
    }
    [WebMethod]
    public DataSet Com21_consulta_empresa_letra(string Letra)
    {
        _empresa = new classCom21Empresa();
        error = _empresa.MsgError;
        return _empresa.Com21_consulta_empresa_letra(Letra);
    }
    [WebMethod]
    public bool Com21_elimina_costo_idempresa(int Id_Empresa)
    {
        com21DLL.classCom21Empresa _empresa = new com21DLL.classCom21Empresa();
        return _empresa.Com21_elimina_costo_idempresa(Id_Empresa);
    }
    [WebMethod]
    public DataSet Com21_consulta_empresa_idciudad(int Id_Ciudad, int Despacho)
    {
        _empresa = new classCom21Empresa();
        error = _empresa.MsgError;
        return _empresa.Com21_consulta_empresa_idciudad(Id_Ciudad, Despacho);
    }
    [WebMethod]
    public bool Com21_edita_empresa_despacho(int Id_Ciudad)
    {
        com21DLL.classCom21Empresa _empresa = new com21DLL.classCom21Empresa();
        return _empresa.Com21_edita_empresa_despacho(Id_Ciudad);
    }
    #endregion
    /// <summary>
    /// METODOS WEB PAIS
    /// </summary>
    #region "METODOS WEB PAIS"
    [WebMethod]
    public DataSet Com21_consulta_pais()
    {
        _pais = new classCom21Pais();
        error = _pais.MsgError;
        return _pais.Com21_consulta_pais();
    }
    [WebMethod]
    public DataSet Com21_consulta_pais_id(int Id_Pais)
    {
        _pais = new classCom21Pais();
        error = _pais.MsgError;
        return _pais.Com21_consulta_pais_id(Id_Pais);
    }
    [WebMethod]
    public bool Com21_ingresa_pais(string strXmlDatos)
    {
        com21DLL.classCom21Pais _pais = new com21DLL.classCom21Pais();
        return _pais.Com21_ingresa_pais(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_pais(string strXmlDatos, int Id_Pais)
    {
        com21DLL.classCom21Pais _pais = new com21DLL.classCom21Pais();
        return _pais.Com21_edita_pais(strXmlDatos, Id_Pais);
    }
    [WebMethod]
    public bool Com21_elimina_pais(int Id_Pais)
    {
        com21DLL.classCom21Pais _pais = new com21DLL.classCom21Pais();
        return _pais.Com21_elimina_pais(Id_Pais);
    }
    [WebMethod]
    public DataSet Com21_consulta_pais_letra(string Letra, int Ident)
    {
        _pais = new classCom21Pais();
        error = _pais.MsgError;
        return _pais.Com21_consulta_pais_letra(Letra, Ident);
    }
    [WebMethod]
    public bool Com21_elimina_provincia_pais(int Id_Pais)
    {
        com21DLL.classCom21Pais _pais = new com21DLL.classCom21Pais();
        return _pais.Com21_elimina_provincia_pais(Id_Pais);
    }
    #endregion
    /// <summary>
    /// METODOS WEB CIUDAD
    /// </summary>
    #region "METODOS WEB CIUDADES"
    [WebMethod]
    public DataSet Com21_consulta_ciudades()
    {
        _ciudad = new classCom21Ciudad();
        error = _ciudad.MsgError;
        return _ciudad.Com21_consulta_ciudades();
    }
    [WebMethod]
    public DataSet Com21_consulta_ciudades_id(int Id_Ciudad)
    {
        _ciudad = new classCom21Ciudad();
        error = _ciudad.MsgError;
        return _ciudad.Com21_consulta_ciudades_id(Id_Ciudad);
    }
    [WebMethod]
    public bool Com21_ingresa_ciudades(string strXmlDatos)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_ingresa_ciudades(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_ciudades(string strXmlDatos, int Id_Ciudad)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_edita_ciudades(strXmlDatos, Id_Ciudad);
    }
    [WebMethod]
    public bool Com21_elimina_ciudades(int Id_Ciudad)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_elimina_ciudades(Id_Ciudad);
    }
    [WebMethod]
    public bool Com21_activar_ciudades(int Id_Ciudad)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_activar_ciudades(Id_Ciudad);
    }
    [WebMethod]
    public bool Com21_consultar_ciudades_provincia(int Id_Provincia)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_consultar_ciudades_provincia(Id_Provincia);
    }
    [WebMethod]
    public DataSet Com21_consulta_provincias_idpais(int Id_Pais)
    {
        _ciudad = new classCom21Ciudad();
        error = _ciudad.MsgError;
        return _ciudad.Com21_consulta_provincias_idpais(Id_Pais);
    }
    [WebMethod]
    public bool Com21_elimina_ciudad_costo(int Id_Ciudad)
    {
        com21DLL.classCom21Ciudad _ciudad = new com21DLL.classCom21Ciudad();
        return _ciudad.Com21_elimina_ciudad_costo(Id_Ciudad);
    }
    [WebMethod]
    public DataSet Com21_consulta_ciudades_letra(string Letra, int Id_Pais, int Id_Provincia, int Ident)
    {
        _ciudad = new classCom21Ciudad();
        error = _ciudad.MsgError;
        return _ciudad.Com21_consulta_ciudades_letra(Letra, Id_Pais, Id_Provincia, Ident);
    }
    #endregion
    /// <summary>
    /// METODOS WEB NOSOTROS
    /// </summary>
    #region "METODOS WEB NOSOTROS"
    [WebMethod]
    public DataSet Com21_consulta_nosotros()
    {
        _nosotros = new classCom21Nosotros();
        error = _nosotros.MsgError;
        return _nosotros.Com21_consulta_nosotros();
    }
    [WebMethod]
    public DataSet Com21_consulta_nosotros_id(int IdNosotros)
    {
        _nosotros = new classCom21Nosotros();
        error = _nosotros.MsgError;
        return _nosotros.Com21_consulta_nosotros_id(IdNosotros);
    }
    [WebMethod]
    public bool Com21_ingresa_nosotros(string strXmlDatos)
    {
        com21DLL.classCom21Nosotros _nosotros = new com21DLL.classCom21Nosotros();
        return _nosotros.Com21_ingresa_nosotros(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_nosotros(string strXmlDatos, int IdNosotros)
    {
        com21DLL.classCom21Nosotros _nosotros = new com21DLL.classCom21Nosotros();
        return _nosotros.Com21_edita_nosotros(strXmlDatos, IdNosotros);
    }
    [WebMethod]
    public bool Com21_elimina_nosotros(int IdNosotros)
    {
        com21DLL.classCom21Nosotros _nosotros = new com21DLL.classCom21Nosotros();
        return _nosotros.Com21_elimina_nosotros(IdNosotros);
    }
    #endregion
    /// <summary>
    /// METODOS WEB MISION-VISION
    /// </summary>
    #region "METODOS WEB MISION-VISION"
    [WebMethod]
    public DataSet Com21_consulta_misionvision()
    {
        _mv = new classCom21MisionVision();
        error = _mv.MsgError;
        return _mv.Com21_consulta_misionvision();
    }
    [WebMethod]
    public DataSet Com21_consulta_misionvision_id(int Id_Empresa)
    {
        _mv = new classCom21MisionVision();
        error = _mv.MsgError;
        return _mv.Com21_consulta_misionvision_id(Id_Empresa);
    }
    [WebMethod]
    public bool Com21_ingresa_misionvision(string strXmlDatos)
    {
        com21DLL.classCom21MisionVision _mv = new com21DLL.classCom21MisionVision();
        return _mv.Com21_ingresa_misionvision(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_misionvision(string strXmlDatos, int Id_Empresa)
    {
        com21DLL.classCom21MisionVision _mv = new com21DLL.classCom21MisionVision();
        return _mv.Com21_edita_misionvision(strXmlDatos, Id_Empresa);
    }
    [WebMethod]
    public bool Com21_elimina_misionvision(int Id_Empresa)
    {
        com21DLL.classCom21MisionVision _mv = new com21DLL.classCom21MisionVision();
        return _mv.Com21_elimina_misionvision(Id_Empresa);
    }
    #endregion
    /// <summary>
    /// METODOS WEB SLIDE
    /// </summary>
    #region "METODOS WEB SLIDE"

    [WebMethod]
    public DataSet Com21_consulta_slide()
    {
        _slide = new classCom21Slide();
        error = _slide.MsgError;
        return _slide.Com21_consulta_slide();
    }
    [WebMethod]
    public DataSet Com21_consulta_slide_mostrar()
    {
        _slide = new classCom21Slide();
        error = _slide.MsgError;
        return _slide.Com21_consulta_slide_mostrar();
    }
    [WebMethod]
    public DataSet Com21_consulta_slide_id(int IdSlide)
    {
        _slide = new classCom21Slide();
        error = _slide.MsgError;
        return _slide.Com21_consulta_slide_id(IdSlide);
    }

    [WebMethod]
    public bool Com21_ingresa_slide(string strXmlDatos)
    {
        com21DLL.classCom21Slide _slide = new com21DLL.classCom21Slide();
        return _slide.Com21_ingresa_slide(strXmlDatos);
    }

    [WebMethod]
    public bool Com21_edita_slide(string strXmlDatos, int IdSlide)
    {
        com21DLL.classCom21Slide _slide = new com21DLL.classCom21Slide();
        return _slide.Com21_edita_slide(strXmlDatos, IdSlide);
    }

    [WebMethod]
    public bool Com21_elimina_slide(int IdSlide)
    {
        com21DLL.classCom21Slide _slide = new com21DLL.classCom21Slide();
        return _slide.Com21_elimina_slide(IdSlide);
    }

    [WebMethod]
    public bool Com21_activar_slide(int IdSlide)
    {
        com21DLL.classCom21Slide _slide = new com21DLL.classCom21Slide();
        return _slide.Com21_activar_slide(IdSlide);
    }
    #endregion
    /// <summary>
    /// METODOS WEB MARCAS
    /// </summary>
    #region "METODOS WEB MARCAS"
    [WebMethod]
    public DataSet Com21_consulta_marca()
    {
        _marca = new classCom21Marca();
        error = _marca.MsgError;
        return _marca.Com21_consulta_marca();
    }
    [WebMethod]
    public DataSet Com21_consulta_marca_id(int Id_Marca)
    {
        _marca = new classCom21Marca();
        error = _marca.MsgError;
        return _marca.Com21_consulta_marca_id(Id_Marca);
    }
    [WebMethod]
    public bool Com21_ingresa_marca(string strXmlDatos)
    {
        com21DLL.classCom21Marca _marca = new com21DLL.classCom21Marca();
        return _marca.Com21_ingresa_marca(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_marca(string strXmlDatos, int Id_Marca)
    {
        com21DLL.classCom21Marca _marca = new com21DLL.classCom21Marca();
        return _marca.Com21_edita_marca(strXmlDatos, Id_Marca);
    }
    [WebMethod]
    public bool Com21_elimina_marca(int Id_Marca)
    {
        com21DLL.classCom21Marca _marca = new com21DLL.classCom21Marca();
        return _marca.Com21_elimina_marca(Id_Marca);
    }
    [WebMethod]
    public DataSet Com21_consulta_marca_letra(string Letra, int Ident)
    {
        _marca = new classCom21Marca();
        error = _marca.MsgError;
        return _marca.Com21_consulta_marca_letra(Letra, Ident);
    }
    [WebMethod]
    public bool Com21_inactivar_productos_marca(int Id_Marca)
    {
        com21DLL.classCom21Marca _marca = new com21DLL.classCom21Marca();
        return _marca.Com21_inactivar_productos_marca(Id_Marca);
    }
    #endregion
    /// </summary>
    /// METODOS WEB CATEGORIAS
    /// </summary>
    #region "METODOS WEB CATEGORIAS"
    [WebMethod]
    public DataSet Com21_consulta_categoria()
    {
        _categoria = new classCom21Categoria();
        error = _categoria.MsgError;
        return _categoria.Com21_consulta_categoria();
    }
    [WebMethod]
    public DataSet Com21_consulta_categoria_id(int Id_Categoria)
    {
        _categoria = new classCom21Categoria();
        error = _categoria.MsgError;
        return _categoria.Com21_consulta_categoria_id(Id_Categoria);
    }
    [WebMethod]
    public bool Com21_ingresa_categoria(string strXmlDatos)
    {
        com21DLL.classCom21Categoria _categoria = new com21DLL.classCom21Categoria();
        return _categoria.Com21_ingresa_categoria(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_categoria(string strXmlDatos, int Id_Categoria)
    {
        com21DLL.classCom21Categoria _categoria = new com21DLL.classCom21Categoria();
        return _categoria.Com21_edita_categoria(strXmlDatos, Id_Categoria);
    }
    [WebMethod]
    public bool Com21_elimina_categoria(int Id_Categoria)
    {
        com21DLL.classCom21Categoria _categoria = new com21DLL.classCom21Categoria();
        return _categoria.Com21_elimina_categoria(Id_Categoria);
    }
    [WebMethod]
    public DataSet Com21_consulta_categoria_letra(string Letra, int Ident)
    {
        _categoria = new classCom21Categoria();
        error = _categoria.MsgError;
        return _categoria.Com21_consulta_categoria_letra(Letra, Ident);
    }
    [WebMethod]
    public DataSet Com21_consulta_categoria_numero_web(int Numero, int Id_Categoria)
    {
        _categoria = new classCom21Categoria();
        error = _categoria.MsgError;
        return _categoria.Com21_consulta_categoria_numero_web(Numero, Id_Categoria);
    }
    #endregion
    /// <summary>
    /// METODOS WEB SUB-CATEGORIAS
    /// </summary>
    #region "METODOS WEB SUB-CATEGORIAS"
    [WebMethod]
    public DataSet Com21_consulta_scategoria()
    {
        _scategoria = new classCom21SubCategoria();
        error = _scategoria.MsgError;
        return _scategoria.Com21_consulta_scategoria();
    }
    [WebMethod]
    public DataSet Com21_consulta_scategoria_id(int Id_SubCategoria)
    {
        _scategoria = new classCom21SubCategoria();
        error = _scategoria.MsgError;
        return _scategoria.Com21_consulta_scategoria_id(Id_SubCategoria);
    }
    [WebMethod]
    public bool Com21_ingresa_scategoria(string strXmlDatos)
    {
        com21DLL.classCom21SubCategoria _scategoria = new com21DLL.classCom21SubCategoria();
        return _scategoria.Com21_ingresa_scategoria(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_scategoria(string strXmlDatos, int Id_SubCategoria)
    {
        com21DLL.classCom21SubCategoria _scategoria = new com21DLL.classCom21SubCategoria();
        return _scategoria.Com21_edita_scategoria(strXmlDatos, Id_SubCategoria);
    }
    [WebMethod]
    public bool Com21_elimina_scategoria(int Id_SubCategoria)
    {
        com21DLL.classCom21SubCategoria _scategoria = new com21DLL.classCom21SubCategoria();
        return _scategoria.Com21_elimina_scategoria(Id_SubCategoria);
    }
    [WebMethod]
    public DataSet Com21_consulta_scategoria_letra(string Letra, int Ident, int Id_Categoria)
    {
        _scategoria = new classCom21SubCategoria();
        error = _scategoria.MsgError;
        return _scategoria.Com21_consulta_scategoria_letra(Letra, Ident, Id_Categoria);
    }
    [WebMethod]
    public bool Com21_inactivar_productos_scategoria(int Id_SubCategoria)
    {
        com21DLL.classCom21SubCategoria _scategoria = new com21DLL.classCom21SubCategoria();
        return _scategoria.Com21_inactivar_productos_scategoria(Id_SubCategoria);
    }
    #endregion
    /// <summary>
    /// METODOS WEB IMAGENES PRODUCTOS
    /// </summary>
    #region "METODOS WEB IMAGENES"
    [WebMethod]
    public DataSet Com21_consulta_imagenes()
    {
        _imagenes = new classCom21Imagenes();
        error = _imagenes.MsgError;
        return _imagenes.Com21_consulta_imagenes();
    }
    [WebMethod]
    public DataSet Com21_consulta_imagenes_id(int Id_Imagenes)
    {
        _imagenes = new classCom21Imagenes();
        error = _imagenes.MsgError;
        return _imagenes.Com21_consulta_imagenes_id(Id_Imagenes);
    }
    [WebMethod]
    public bool Com21_ingresa_imagenes(string strXmlDatos)
    {
        com21DLL.classCom21Imagenes _imagenes = new com21DLL.classCom21Imagenes();
        return _imagenes.Com21_ingresa_imagenes(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_imagenes(string strXmlDatos, int Id_Imagenes)
    {
        com21DLL.classCom21Imagenes _imagenes = new com21DLL.classCom21Imagenes();
        return _imagenes.Com21_edita_imagenes(strXmlDatos, Id_Imagenes);
    }
    [WebMethod]
    public bool Com21_elimina_imagenes(int Id_Imagenes)
    {
        com21DLL.classCom21Imagenes _imagenes = new com21DLL.classCom21Imagenes();
        return _imagenes.Com21_elimina_imagenes(Id_Imagenes);
    }
    [WebMethod]
    public DataSet Com21_consulta_imagenes_mostrar()
    {
        _imagenes = new classCom21Imagenes();
        error = _imagenes.MsgError;
        return _imagenes.Com21_consulta_imagenes_mostrar();
    }
    [WebMethod]
    public DataSet Com21_consulta_productos_titulo(string Titulo)
    {
        _imagenes = new classCom21Imagenes();
        error = _imagenes.MsgError;
        return _imagenes.Com21_consulta_productos_titulo(Titulo);
    }
    [WebMethod]
    public DataSet Com21_consulta_imagenes_id_producto(int Id_Producto)
    {
        _imagenes = new classCom21Imagenes();
        error = _imagenes.MsgError;
        return _imagenes.Com21_consulta_imagenes_id_producto(Id_Producto);
    }
    #endregion
    /// <summary>
    /// METODOS WEB COSTO
    /// </summary>
    #region "METODOS WEB COSTOS"
    [WebMethod]
    public DataSet Com21_consulta_costo()
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_costo();
    }
    [WebMethod]
    public DataSet Com21_consulta_costo_id(int Id_Costo)
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_costo_id(Id_Costo);
    }
    [WebMethod]
    public bool Com21_ingresa_costo(string strXmlDatos)
    {
        com21DLL.classCom21Costo _costo = new com21DLL.classCom21Costo();
        return _costo.Com21_ingresa_costo(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_costo(string strXmlDatos, int Id_Costo)
    {
        com21DLL.classCom21Costo _costo = new com21DLL.classCom21Costo();
        return _costo.Com21_edita_costo(strXmlDatos, Id_Costo);
    }
    [WebMethod]
    public bool Com21_elimina_costo(int Id_Costo)
    {
        com21DLL.classCom21Costo _costo = new com21DLL.classCom21Costo();
        return _costo.Com21_elimina_costo(Id_Costo);
    }
    [WebMethod]
    public bool Com21_activar_costo(int Id_Costo)
    {
        com21DLL.classCom21Costo _costo = new com21DLL.classCom21Costo();
        return _costo.Com21_activar_costo(Id_Costo);
    }
    [WebMethod]
    public DataSet Com21_consulta_ciudad_activa()
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_ciudad_activa();
    }
    [WebMethod]
    public DataSet Com21_consulta_valida_costo_existente(int Id_Costo)
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_valida_costo_existente(Id_Costo);
    }
    [WebMethod]
    public DataSet Com21_consulta_ciudad_idprovincia(int Id_Provincia)
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_ciudad_idprovincia(Id_Provincia);
    }
    [WebMethod]
    public DataSet Com21_consulta_valida_costo_existente_ciudadId(int Id_Ciudad, int Id_Empresa)
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_valida_costo_existente_ciudadId(Id_Ciudad, Id_Empresa);
    }
    [WebMethod]
    public DataSet Com21_consulta_costo_IdUsuario_IdCiudad(int Id_Clientes, int Id_Ciudad)
    {
        _costo = new classCom21Costo();
        error = _costo.MsgError;
        return _costo.Com21_consulta_costo_IdUsuario_IdCiudad(Id_Clientes, Id_Ciudad);
    }
    #endregion
    /// </summary>
    /// METODOS WEB ADMINISTRADOR
    /// </summary>
    #region "METODOS WEB ADMINISTRADOR"
    [WebMethod]
    public DataSet Com21_consulta_administrador()
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_administrador();
    }
    [WebMethod]
    public DataSet Com21_consulta_administrador_id(int Id_Categoria)
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_administrador_id(Id_Categoria);
    }
    [WebMethod]
    public bool Com21_ingresa_administrador(string strXmlDatos)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_ingresa_administrador(strXmlDatos);
    }
    [WebMethod]
    public bool Com21_edita_administrador(string strXmlDatos, int Id_Categoria)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_edita_administrador(strXmlDatos, Id_Categoria);
    }
    [WebMethod]
    public bool Com21_elimina_administrador(int Id_Categoria)
    {
        com21DLL.classCom21Administrador _admin = new com21DLL.classCom21Administrador();
        return _admin.Com21_elimina_administrador(Id_Categoria);
    }
    [WebMethod]
    public DataSet Com21_consulta_administrador_letra(string Letra)
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_administrador_letra(Letra);
    }
    [WebMethod]
    public DataSet Com21_consulta_general_contador_admin()
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_general_contador_admin();
    }
    [WebMethod]
    public bool valida_administrador(string Usuario, string Clave)
    {
        _admin = new classCom21Administrador();
        error = _admin.Error;
        return _admin.valida_administrador(Usuario, Clave);
    }
    [WebMethod]
    public DataSet consulta_id_admin(string Usuario, string Clave)
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.consulta_id_admin(Usuario, Clave);
    }
    [WebMethod]
    public DataSet Com21_consulta_administrador_user(string Usuario)
    {
        _admin = new classCom21Administrador();
        error = _admin.MsgError;
        return _admin.Com21_consulta_administrador_user(Usuario);
    }
    #endregion
    /// <summary>





   
    ///// <summary>
    ///// METODOS WEB LOCAL
    ///// </summary>
    //#region "METODOS WEB LOCAL"

    //[WebMethod]
    //public DataSet consulta_agencias()
    //{
    //    _agencias = new classAgencias();
    //    error = _agencias.MsgError;
    //    return _agencias.consulta_agencias();
    //}

    //[WebMethod]
    //public DataSet consulta_agencias_id(int IdAgencias)
    //{
    //    _agencias = new classAgencias();
    //    error = _agencias.MsgError;
    //    return _agencias.consulta_agencias_id(IdAgencias);
    //}

    //[WebMethod]
    //public DataSet consulta_agencias_idpyc(int IdProvincia, int IdCiudad)
    //{
    //    _agencias = new classAgencias();
    //    error = _agencias.MsgError;
    //    return _agencias.consulta_agencias_idpyc(IdProvincia, IdCiudad);
    //}
    

    //[WebMethod]
    //public bool proc_ingresa_agencias(string strXmlDatos)
    //{
    //    com21DLL.classAgencias _agencias = new com21DLL.classAgencias();
    //    return _agencias.proc_ingresa_agencias(strXmlDatos);
    //}

    //[WebMethod]
    //public bool proc_edita_agencias(string strXmlDatos, int IdAgencias)
    //{
    //    com21DLL.classAgencias _agencias = new com21DLL.classAgencias();
    //    return _agencias.proc_edita_agencias(strXmlDatos, IdAgencias);
    //}

    //[WebMethod]
    //public bool proc_elimina_agencias(int IdAgencias)
    //{
    //    com21DLL.classAgencias _agencias = new com21DLL.classAgencias();
    //    return _agencias.proc_elimina_agencias(IdAgencias);
    //}

    //[WebMethod]
    //public DataSet consulta_suscriptores()
    //{
    //    _suscriptores = new classSuscriptores();
    //    error = _suscriptores.MsgError;
    //    return _suscriptores.consulta_suscriptores();
    //}
    //[WebMethod]
    //public bool proc_ingresa_suscriptores(string strXmlDatos)
    //{
    //    com21DLL.classSuscriptores _suscriptores = new com21DLL.classSuscriptores();
    //    return _suscriptores.proc_ingresa_suscriptores(strXmlDatos);
    //}
    //[WebMethod]
    //public bool proc_edita_suscriptores(string strXmlDatos, int IdSuscriptores)
    //{
    //    com21DLL.classSuscriptores _suscriptores = new com21DLL.classSuscriptores();
    //    return _suscriptores.proc_edita_suscriptores(strXmlDatos, IdSuscriptores);
    //}
    //[WebMethod]
    //public DataSet consulta_suscriptores_id(int IdSuscriptores)
    //{
    //    _suscriptores = new classSuscriptores();
    //    error = _suscriptores.MsgError;
    //    return _suscriptores.consulta_suscriptores_id(IdSuscriptores);
    //}
    //[WebMethod]
    //public bool proc_elimina_suscriptores(int IdSuscriptores)
    //{
    //    com21DLL.classSuscriptores _suscriptores = new com21DLL.classSuscriptores();
    //    return _suscriptores.proc_elimina_suscriptores(IdSuscriptores);
    //}
    
    //[WebMethod]
    //public DataSet consulta_album()
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_album();
    //}
    //[WebMethod]
    //public DataSet consulta_album_id(int IdAlbum)
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_album_id(IdAlbum);
    //}
    //[WebMethod]
    //public bool proc_ingresa_album(string strXmlDatos)
    //{
    //    com21DLL.classAlbum _album = new com21DLL.classAlbum();
    //    return _album.proc_ingresa_album(strXmlDatos);
    //}
    //[WebMethod]
    //public bool proc_edita_album(string strXmlDatos, int IdAlbum)
    //{
    //    com21DLL.classAlbum _album = new com21DLL.classAlbum();
    //    return _album.proc_edita_album(strXmlDatos, IdAlbum);
    //}
    //[WebMethod]
    //public bool proc_elimina_album(int IdAlbum)
    //{
    //    com21DLL.classAlbum _album = new com21DLL.classAlbum();
    //    return _album.proc_elimina_album(IdAlbum);
    //}
    //[WebMethod]
    //public DataSet consulta_album_prioridad(int Prioridad)
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_album_prioridad(Prioridad);
    //}
    //[WebMethod]
    //public bool proc_edita_album_prioridad(string strXmlDatos, int IdAlbum)
    //{
    //    com21DLL.classAlbum _album = new com21DLL.classAlbum();
    //    return _album.proc_edita_album_prioridad(strXmlDatos, IdAlbum);
    //}
    //#endregion

    ///// <summary>
    ///// METODOS WEB USUARIO
    ///// </summary>
    //#region "METODOS WEB USUARIO"
    //[WebMethod]
    //public bool editar_clave_usuario(string strXmlDatos, int Usuario, string Clave)
    //{
    //    com21DLL.classUsuario obj_usuario = new com21DLL.classUsuario();
    //    return obj_usuario.editar_clave_usuario(strXmlDatos, Usuario, Clave);
    //}

    //[WebMethod]
    //public bool editar_clave_administrador(string strXmlDatos, int Usuario, string Clave)
    //{
    //    com21DLL.classUsuario _usuario = new com21DLL.classUsuario();
    //    return _usuario.editar_clave_administrador(strXmlDatos, Usuario, Clave);
    //}

    

    //[WebMethod]
    //public bool valida_usuario(string Usuario, string Clave)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.Error;
    //    return _usuario.valida_usuario(Usuario, Clave);
    //}

    //[WebMethod]
    //public int obtener_id_usuario(string Usuario, string Clave)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.Error;
    //    return _usuario.obtener_id_usuario(Usuario, Clave);
    //}

    //[WebMethod]
    //public DataSet consulta_id_user(string Usuario, string Clave)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.consulta_id_user(Usuario, Clave);
    //}

    

    //[WebMethod]
    //public DataSet consulta_usuario()
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.consulta_usuario();
    //}

    //[WebMethod]
    //public DataSet consulta_usuario_id(int IdUsuario)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.consulta_usuario_id(IdUsuario);
    //}

    //[WebMethod]
    //public DataSet consulta_usuario_especifico(string Usuario)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.consulta_usuario_especifico(Usuario);
    //}

    //[WebMethod]
    //public DataSet consulta_email_especifico(string Email)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.consulta_email_especifico(Email);
    //}

    //[WebMethod]
    //public bool proc_ingresa_usuario(string strXmlDatos)
    //{
    //    com21DLL.classUsuario _usuario = new com21DLL.classUsuario();
    //    return _usuario.proc_ingresa_usuario(strXmlDatos);
    //}

    //[WebMethod]
    //public bool proc_edita_usuario(string strXmlDatos, int IdUsuario)
    //{
    //    com21DLL.classUsuario _usuario = new com21DLL.classUsuario();
    //    return _usuario.proc_edita_usuario(strXmlDatos, IdUsuario);
    //}

    //[WebMethod]
    //public bool proc_elimina_usuario(int IdUsuario)
    //{
    //    com21DLL.classUsuario _usuario = new com21DLL.classUsuario();
    //    return _usuario.proc_elimina_usuario(IdUsuario);
    //}
    //#endregion 

    
    //[WebMethod]
    //public DataSet ConsultaProvincia(int Pais)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.ConsultaProvincia(Pais);
    //}


    //[WebMethod]
    //public DataSet ConsultaCiudadesProv(int Provincia)
    //{
    //    _usuario = new classUsuario();
    //    error = _usuario.MsgError;
    //    return _usuario.ConsultaCiudadesProv(Provincia);
    //}

    
    //[WebMethod]
    //public DataSet consulta_mp3imagen()
    //{
    //    _mp3imagen = new classMp3Imagen();
    //    error = _mp3imagen.MsgError;
    //    return _mp3imagen.consulta_mp3imagen();
    //}
    //[WebMethod]
    //public DataSet Consulta_mp3()
    //{
    //    com21DLL.classMp3Imagen _mp3imagen = new com21DLL.classMp3Imagen();
    //    error = _mp3imagen.MsgError;
    //    return _mp3imagen.Consulta_mp3();
    //}
    //[WebMethod]
    //public DataSet ConsultaAlbumImagen()
    //{
    //    _mp3imagen = new classMp3Imagen();
    //    error = _mp3imagen.MsgError;
    //    return _mp3imagen.ConsultaAlbumImagen();
    //}

    //#region "METODOS WEB VIDEOSYOUTUBE"
    //[WebMethod]
    //public DataSet consulta_VideoYoutube_id(int IdVideoYoutube)
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta_VideoYoutube_id(IdVideoYoutube);
    //}
    //[WebMethod]
    //public DataSet consulta_VideoYoutube()
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta_VideoYoutube();
    //}
    //[WebMethod]
    //public bool proc_ingresa_VideoYoutube(string strXmlDatos)
    //{
    //    com21DLL.classVideoYoutube _videoyoutube = new com21DLL.classVideoYoutube();
    //    return _videoyoutube.proc_ingresa_VideoYoutube(strXmlDatos);
    //}
    //[WebMethod]
    //public bool proc_edita_VideoYoutube(string strXmlDatos, int IdVideoYoutube)
    //{
    //    com21DLL.classVideoYoutube _videoyoutube = new com21DLL.classVideoYoutube();
    //    return _videoyoutube.proc_edita_VideoYoutube(strXmlDatos, IdVideoYoutube);
    //}
    //[WebMethod]
    //public bool proc_elimina_VideoYoutube(int IdVideoYoutube)
    //{
    //    com21DLL.classVideoYoutube _videoyoutube = new com21DLL.classVideoYoutube();
    //    return _videoyoutube.proc_elimina_VideoYoutube(IdVideoYoutube);
    //}
    //[WebMethod]
    //public DataSet consulta__mostrar_VideoYoutube(int IdVideoYoutube)
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta__mostrar_VideoYoutube(IdVideoYoutube);
    //}
    //[WebMethod]
    //public DataSet consulta__mostrarVideoYoutube()
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta__mostrarVideoYoutube();
    //}
    //#endregion 
    
    //#region "METODOS WEB USUARIO CANCIONES"
    //[WebMethod]
    //public DataSet consulta_cancion()
    //{
    //    _cancion = new classCancion();
    //    error = _cancion.MsgError;
    //    return _cancion.consulta_cancion();
    //}
    //[WebMethod]
    //public DataSet consulta_cancion_id(int IdCancion)
    //{
    //    _cancion = new classCancion();
    //    error = _cancion.MsgError;
    //    return _cancion.consulta_cancion_id(IdCancion);
    //}
    //[WebMethod]
    //public bool proc_ingresa_cancion(string strXmlDatos)
    //{
    //    com21DLL.classCancion _cancion = new com21DLL.classCancion();
    //    return _cancion.proc_ingresa_cancion(strXmlDatos);
    //}
    //[WebMethod]
    //public bool proc_edita_cancion(string strXmlDatos, int IdCancion)
    //{
    //    com21DLL.classCancion _cancion = new com21DLL.classCancion();
    //    return _cancion.proc_edita_cancion(strXmlDatos, IdCancion);
    //}
    //[WebMethod]
    //public bool proc_elimina_cancion(int IdCancion)
    //{
    //    com21DLL.classCancion _cancion = new com21DLL.classCancion();
    //    return _cancion.proc_elimina_cancion(IdCancion);
    //}
    //[WebMethod]
    //public DataSet consulta_cancion_prioridad(int Prioridad)
    //{
    //    _cancion = new classCancion();
    //    error = _cancion.MsgError;
    //    return _cancion.consulta_cancion_prioridad(Prioridad);
    //}
    //[WebMethod]
    //public bool proc_edita_cancion_prioridad(string strXmlDatos, int IdCancion)
    //{
    //    com21DLL.classCancion _cancion = new com21DLL.classCancion();
    //    return _cancion.proc_edita_cancion_prioridad(strXmlDatos, IdCancion);
    //}
    //#endregion


    //#region "METODO AUTOCOMPLETADOR"
    //[WebMethod]
    //public string[] GetCompletionList(string prefixText)
    //{
    //    _autocompletador = new classAutocompletador();
    //    error = _autocompletador.MsgError;
    //    DataSet complatado = _autocompletador.autocompletador(prefixText);
         
    //    if (complatado.Tables[0].Rows.Count > 0)
    //    {
    //       int contador = int.Parse(complatado.Tables[0].Rows.Count.ToString());
    //        items = new List<string>(contador);
    //        for (int i = 0; i < contador; i++)
    //        {
    //            //char c1 = (char)random.Next(65, 90);
    //            //char c2 = (char)random.Next(97, 122);
    //            //char c3 = (char)random.Next(97, 122);
    //            items.Add(complatado.Tables[0].Rows[i].ToString());
    //            //items.Add(prefixText + c1 + c2 + c3);
    //        }
    //    }
    //    return items.ToArray();
        
    //}
    //#endregion

    //#region "METODO LISTAALBUM"
    
    //[WebMethod]
    //public DataSet consulta_lista()
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_lista();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos(string Genero, int Crud, int IdGenero)
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_lista_dos(Genero, Crud, IdGenero);
    //}

    //[WebMethod]
    //public DataSet contar_informacion()
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.contar_informacion();
    //}
    //#endregion

    //#region "METODO LISTAVIDEOS"
    //[WebMethod]
    //public DataSet consulta_lista_video()
    //{
    //    _dvdmusicales = new classDvdmusicales();
    //    error = _dvdmusicales.MsgError;
    //    return _dvdmusicales.consulta_lista_video();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_video(string Genero, int Crud, int IdGenero)
    //{
    //    _dvdmusicales = new classDvdmusicales();
    //    error = _dvdmusicales.MsgError;
    //    return _dvdmusicales.consulta_lista_dos_video(Genero, Crud, IdGenero);
    //}
    //#endregion

    //#region "METODO LISTALONGPLAY"

    //[WebMethod]
    //public DataSet consulta_lista_LP()
    //{
    //    _longplay = new classLongplay();
    //    error = _longplay.MsgError;
    //    return _longplay.consulta_lista_LP();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_LP(string Genero, int Crud)
    //{
    //    _longplay = new classLongplay();
    //    error = _longplay.MsgError;
    //    return _longplay.consulta_lista_dos_LP(Genero, Crud);
    //}

    //[WebMethod]
    //public DataSet contar_informacion_LP()
    //{
    //    _longplay = new classLongplay();
    //    error = _longplay.MsgError;
    //    return _longplay.contar_informacion_LP();
    //}
    //#endregion
    //#region "METODO LISTAACCESORIOS"

    //[WebMethod]
    //public DataSet consulta_lista_ACC()
    //{
    //    _accesorios = new classAccesorios();
    //    error = _accesorios.MsgError;
    //    return _accesorios.consulta_lista_ACC();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_ACC(string Genero, int Crud)
    //{
    //    _accesorios = new classAccesorios();
    //    error = _accesorios.MsgError;
    //    return _accesorios.consulta_lista_dos_ACC(Genero, Crud);
    //}

    //[WebMethod]
    //public DataSet contar_informacion_ACC()
    //{
    //    _accesorios = new classAccesorios();
    //    error = _accesorios.MsgError;
    //    return _accesorios.contar_informacion_ACC();
    //}
    //#endregion
    //#region "METODO LISTAINSTRUMENTOS"

    //[WebMethod]
    //public DataSet consulta_lista_INST()
    //{
    //    _instrumentos = new classInstrumentos();
    //    error = _instrumentos.MsgError;
    //    return _instrumentos.consulta_lista_INST();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_INST(string Genero, int Crud)
    //{
    //    _instrumentos = new classInstrumentos();
    //    error = _instrumentos.MsgError;
    //    return _instrumentos.consulta_lista_dos_INST(Genero, Crud);
    //}

    //[WebMethod]
    //public DataSet contar_informacion_INST()
    //{
    //    _instrumentos = new classInstrumentos();
    //    error = _instrumentos.MsgError;
    //    return _instrumentos.contar_informacion_INST();
    //}
    //#endregion
    //#region "METODO LISTACANCIONEROS"
    //[WebMethod]
    //public DataSet consulta_lista_CAN()
    //{
    //    _cancionero = new classCancionero();
    //    error = _cancionero.MsgError;
    //    return _cancionero.consulta_lista_CAN();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_CAN(string Genero, int Crud)
    //{
    //    _cancionero = new classCancionero();
    //    error = _cancionero.MsgError;
    //    return _cancionero.consulta_lista_dos_CAN(Genero, Crud);
    //}

    //[WebMethod]
    //public DataSet contar_informacion_CAN()
    //{
    //    _cancionero = new classCancionero();
    //    error = _cancionero.MsgError;
    //    return _cancionero.contar_informacion_CAN();
    //}
    //#endregion
    //#region "METODO LISTAYOUTUBE"

    //[WebMethod]
    //public DataSet consulta_lista_YT()
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta_lista_YT();
    //}

    //[WebMethod]
    //public DataSet consulta_lista_dos_YT(string Genero, int Crud)
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.consulta_lista_dos_YT(Genero, Crud);
    //}

    //[WebMethod]
    //public DataSet contar_informacion_YT()
    //{
    //    _videoyoutube = new classVideoYoutube();
    //    error = _videoyoutube.MsgError;
    //    return _videoyoutube.contar_informacion_YT();
    //}
    //#endregion
    //#region "FLITRO GRIDVIEW"
    // [WebMethod]
    //public DataSet consulta_filtro(string argumento)
    //{
    //    _album = new classAlbum();
    //    error = _album.MsgError;
    //    return _album.consulta_filtro(argumento);
    //}
    // [WebMethod]
    // public DataSet consulta_filtro_dvd(string argumento)
    // {
    //     _dvdmusicales = new classDvdmusicales();
    //     error = _dvdmusicales.MsgError;
    //     return _dvdmusicales.consulta_filtro_dvd(argumento);
    // }
    //#endregion

    // [WebMethod]
    // public int obtener_usuario_id(string usuario, string clave)
    // {
    //     _suscriptores = new classSuscriptores();
    //     error = _suscriptores.MsgError;
    //     return _suscriptores.obtener_usuario_id(usuario, clave);
    // }

     //[WebMethod]
     //public DataSet consulta_emailclave(string Email)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.Error;
     //    return _nosotros.consulta_emailclave(Email);
     //}
    //#region "METODOS DE CONSULTA DE LOS PRODUCTOS"
    // [WebMethod]
    // public DataSet consulta_galeria_accesorio(int IdProducto)
    // {
    //     _accesorios = new classAccesorios();
    //     error = _accesorios.MsgError;
    //     return _accesorios.consulta_galeria_accesorio(IdProducto);
    // }
    // [WebMethod]
    // public DataSet consulta_galeria_longplay(int IdProducto)
    // {
    //     _longplay = new classLongplay();
    //     error = _longplay.MsgError;
    //     return _longplay.consulta_galeria_longplay(IdProducto);
    // }
    // [WebMethod]
    // public DataSet consulta_galeria_cancionero(int IdProducto)
    // {
    //     _cancionero = new classCancionero();
    //     error = _cancionero.MsgError;
    //     return _cancionero.consulta_galeria_cancionero(IdProducto);
    // }
    // [WebMethod]
    // public DataSet consulta_galeria_dvdmusicales(int IdProducto)
    // {
    //     _dvdmusicales = new classDvdmusicales();
    //     error = _dvdmusicales.MsgError;
    //     return _dvdmusicales.consulta_galeria_dvdmusicales(IdProducto);
    // }
    // [WebMethod]
    // public DataSet consulta_galeria_instrumento(int IdProducto)
    // {
    //     _instrumentos = new classInstrumentos();
    //     error = _instrumentos.MsgError;
    //     return _instrumentos.consulta_galeria_instrumento(IdProducto);
    // }
    // [WebMethod]
    // public DataSet consulta_galeria_album(int IdProducto)
    // {
    //     _album = new classAlbum();
    //     error = _album.MsgError;
    //     return _album.consulta_galeria_album(IdProducto);
    // }
    //#endregion


     //[WebMethod]
     //public DataSet consulta_PaisPrivEstCiu()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.Error;
     //    return _nosotros.consulta_PaisPrivEstCiu();
     //}
     //[WebMethod]
     //public bool proc_ingresa_PaisPrivEstCiu(string strXmlDatos)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_ingresa_PaisPrivEstCiu(strXmlDatos);
     //}
     //[WebMethod]
     //public bool proc_ingresa_Pais(string strXmlDatos)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_ingresa_Pais(strXmlDatos);
     //}
     //[WebMethod]
     //public bool proc_ingresa_Provincia(string strXmlDatos)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_ingresa_Provincia(strXmlDatos);
     //}
     //[WebMethod]
     //public bool proc_actualiza_PaisPrivEstCiu(string strXmlDatos, int IdCiudad)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_actualiza_PaisPrivEstCiu(strXmlDatos, IdCiudad);
     //}
     //[WebMethod]
     //public DataSet consulta_Pais()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Pais();
     //}
     //[WebMethod]
     //public bool proc_elimina_CostoEnvio_x_Ciudad(int IdCiudad)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_CostoEnvio_x_Ciudad(IdCiudad);
     //}
     //[WebMethod]
     //public DataSet consulta_ProvinciaID_Prin(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_ProvinciaID_Prin(IdPais);
     //}
     //[WebMethod]
     //public DataSet consulta_PaisPrivEstCiu_ID(int IdCiudad)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_PaisPrivEstCiu_ID(IdCiudad);
     //}
     //[WebMethod]
     //public bool proc_elimina_PaisPrivEstCiu(int IdCiudad)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_PaisPrivEstCiu(IdCiudad);
     //}
     //[WebMethod]
     //public DataSet consulta_Provincia_ID(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Provincia_ID(IdPais);
     //}
     //[WebMethod]
     //public DataSet consulta_ProCiu_datos_ID(int Id)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_ProCiu_datos_ID(Id);
     //}

     //[WebMethod]
     //public bool proc_elimina_Pais(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_Pais(IdPais);
     //}
     //[WebMethod]
     //public DataSet consulta_Ciudad_ID(int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Ciudad_ID(IdProvincia);
     //}
     //[WebMethod]
     //public DataSet consulta_producto_prefacturado(int IdUsuario)
     //{
     //    _prefactura = new Com21classPrefactura();
     //    error = _prefactura.MsgError;
     //    return _prefactura.consulta_producto_prefacturado(IdUsuario);
     //}
     //[WebMethod]
     //public bool proc_edita_prefacturaDatosUsuario(string strXmlDatos, int IdPrefactura)
     //{
     //    com21DLL.Com21classPrefactura _oferta = new com21DLL.Com21classPrefactura();
     //    return _oferta.proc_edita_prefacturaDatosUsuario(strXmlDatos, IdPrefactura);
     //}
     //[WebMethod]
     //public bool proc_actualiza_Pais(string strXmlDatos, int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_actualiza_Pais(strXmlDatos, IdPais);
     //}
     //[WebMethod]
     //public bool proc_actualiza_Provincia(string strXmlDatos, int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_actualiza_Provincia(strXmlDatos, IdProvincia);
     //}
     //[WebMethod]
     //public bool proc_elimina_Provincia_x_pais(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_Provincia_x_pais(IdPais);
     //}
     //[WebMethod]
     //public DataSet consulta_Ciudad_x_Pro_Pa(int IdPais, int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Ciudad_x_Pro_Pa(IdPais, IdProvincia);
     //}
     //[WebMethod]
     //public bool proc_elimina_PaisPrivEstCiu_x_pais(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_PaisPrivEstCiu_x_pais(IdPais);
     //}
     //[WebMethod]
     //public DataSet consulta_Pais_ID(int IdPais)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Pais_ID(IdPais);
     //}
     //[WebMethod]
     //public bool proc_elimina_Provincia(int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_Provincia(IdProvincia);
     //}
     //[WebMethod]
     //public bool proc_elimina_Ciudad_x_Provincia(int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_Ciudad_x_Provincia(IdProvincia);
     //}
     //[WebMethod]
     //public DataSet consulta_ProvinciaID(int IdProvincia)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_ProvinciaID(IdProvincia);
     //}
     //[WebMethod]
     //public DataSet consulta_Ciudad()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_Ciudad();
     //}
     //[WebMethod]
     //public DataSet consulta_CostoEnvio()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.Error;
     //    return _nosotros.consulta_CostoEnvio();
     //}
     //[WebMethod]
     //public DataSet consulta_CostoEnvio_ID(int IdCosto)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_CostoEnvio_ID(IdCosto);
     //}
     //[WebMethod]
     //public DataSet consulta_CostoEnvio_x_Ciudad(int IdCiudad)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.Error;
     //    return _nosotros.consulta_CostoEnvio_x_Ciudad(IdCiudad);
     //}
     
     //[WebMethod]
     //public bool proc_ingresa_CostoEnvio(string strXmlDatos)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_ingresa_CostoEnvio(strXmlDatos);
     //}
     //[WebMethod]
     //public bool proc_actualiza_CostoEnvio(string strXmlDatos, int IdCosto)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_actualiza_CostoEnvio(strXmlDatos, IdCosto);
     //}
     //[WebMethod]
     //public bool proc_elimina_CostoEnvio(int IdCosto)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    return _nosotros.proc_elimina_CostoEnvio(IdCosto);
     //}
     //[WebMethod]
     //public DataSet consulta_transaccion()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_transaccion();
     //}
     //[WebMethod]
     //public DataSet consulta_transaccion_id(string IdTransaccion)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_transaccion_id(IdTransaccion);
     //}

     //[WebMethod]
     //public DataSet consulta_transaccion_id_dos(string IdTransaccion)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_transaccion_id_dos(IdTransaccion);
     //}
     //[WebMethod]
     //public DataSet consulta_detalle_transaccion_id(string IdTransaccion)
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.MsgError;
     //    return _nosotros.consulta_detalle_transaccion_id(IdTransaccion);
     //}
     //[WebMethod]
     //public bool modificar_transaccion_id(string strXmlDatos, string IdTransaccion)
     //{
     //    com21DLL.classCom21Nosotros _producto = new com21DLL.classCom21Nosotros();
     //    return _producto.modificar_transaccion_id(strXmlDatos, IdTransaccion);
     //}
     //[WebMethod]
     //public DataSet consulta_stock()
     //{
     //    _nosotros = new classCom21Nosotros();
     //    error = _nosotros.Error;
     //    return _nosotros.consulta_stock();
     //}
     //[WebMethod]
     //public bool proc_actualiza_Stock(string strXmlDatos, int Crud, int Codigo)
     //{
     //    com21DLL.classCom21Nosotros _producto = new com21DLL.classCom21Nosotros();
     //    return _producto.proc_actualiza_Stock(strXmlDatos, Crud, Codigo);
     //}

    //#region "Web Métodos Administrador"
    // [WebMethod]
    // public bool valida_administrador(string Usuario, string Clave)
    // {
    //     _administrador = new classAdministrador();
    //     error = _administrador.Error;
    //     return _administrador.valida_administrador(Usuario, Clave);
    // }
    // [WebMethod]
    // public DataSet consulta_id_admin(string Usuario, string Clave)
    // {
    //     _administrador = new classAdministrador();
    //     error = _administrador.MsgError;
    //     return _administrador.consulta_id_admin(Usuario, Clave);
    // }
    // [WebMethod]
    // public DataSet Consulta_CostoEnvio_Pais()
    // {
    //     _administrador = new classAdministrador();
    //     error = _administrador.Error;
    //     return _administrador.Consulta_CostoEnvio_Pais();
    // }
    // [WebMethod]
    // public DataSet Consulta_CostoEnvio_Pais_id(int Id_Pais)
    // {
    //     _administrador = new classAdministrador();
    //     error = _administrador.Error;
    //     return _administrador.Consulta_CostoEnvio_Pais_id(Id_Pais);
    // }
    // [WebMethod]
    // public bool Proc_ingresa_CostoEnvio_Pais(string strXmlDatos)
    // {
    //     _administrador = new classAdministrador();
    //     return _administrador.Proc_ingresa_CostoEnvio_Pais(strXmlDatos);
    // }
    // [WebMethod]
    // public bool Proc_edita_CostoEnvio_Pais(string strXmlDatos, int Id_Pais)
    // {
    //     _administrador = new classAdministrador();
    //     return _administrador.Proc_edita_CostoEnvio_Pais(strXmlDatos, Id_Pais);
    // }
    // [WebMethod]
    // public bool Proc_elimina_CostoEnvio_Pais(int Id_Pais)
    // {
    //     _administrador = new classAdministrador();
    //     return _administrador.Proc_elimina_CostoEnvio_Pais(Id_Pais);
    // }
    //#endregion
}
