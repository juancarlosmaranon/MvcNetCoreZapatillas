using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Models;

#region SQL SERVER
//VUESTRO PROCEDIMIENTO DE PAGINACION DE IMAGENES DE ZAPATILLAS
//CREATE OR ALTER PROCEDURE SP_ZAPATILLAS
//(@IDPRODUCTO INT, @POSICION INT)
//AS
//    BEGIN 
//	SELECT * FROM (SELECT CAST(
//	ROW_NUMBER() OVER(ORDER BY IDIMAGEN) AS INT) AS POSICION,
//    ISNULL(IDIMAGEN, 0) AS IDIMAGEN, IDPRODUCTO, IMAGEN
//	FROM IMAGENZAPAS
//	WHERE IDPRODUCTO = @IDPRODUCTO) AS QUERY
//	WHERE POSICION >= @POSICION AND POSICION < (@POSICION +1)
//END

#endregion

namespace MvcNetCoreZapatillas.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        public List<Zapatilla> GetZapatillas()
        {
            return this.context.Zapatillas.ToList();
        }

        public Zapatilla DetallesZapatillas(int idproducto)
        {
            return this.context.Zapatillas.Where(x => x.IdProducto == idproducto).FirstOrDefault();
        }

        public List<ImagenZapatilla> GetImagenes(int idproducto)
        {
            return this.context.ImagenesZapatillas.Where(x => x.IdProducto == idproducto).ToList();
        }

        public int TotalImagenes(int idproducto)
        {
            return this.context.ImagenesZapatillas.Where(x => x.IdProducto == idproducto).Count();
        }

        public ImagenZapatilla GetImagen(int idproducto, int posicion)
        {
            string sql = "SP_ZAPATILLAS @IDPRODUCTO, @POSICION";

            SqlParameter pamid = new SqlParameter("IDPRODUCTO", idproducto);
            SqlParameter pampos = new SqlParameter("POSICION", posicion);

            var consulta = this.context.ImagenesZapatillas.FromSqlRaw(sql, pamid, pampos);
            return consulta.AsEnumerable().FirstOrDefault();
        }
    }
}
