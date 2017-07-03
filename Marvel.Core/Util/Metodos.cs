using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Marvel.Core.Util
{
    public class Metodos
    {
        public static Metodos Instance => new Metodos();

        /// <summary>
        /// Crea la query para la llamada la api y la guarda en <see cref="Cadenas.Query"/> 
        /// </summary>
        /// <param name="query"></param>

        public void SetQueryString(string query)
        {
            Cadenas.Credenciales = GetCadenaAutenticacionApi();
            Cadenas.Query = query + Cadenas.Credenciales;
        }


        /// <summary>
        /// Devuelve el QueryString para la autenticacion en la Api de Marvel.
        /// </summary>
        /// <returns></returns>
        private string GetCadenaAutenticacionApi()
        {
            var timeStamp = GetTimestamp();
            var hash = GetHash(timeStamp);

            return "?ts=" + timeStamp + "&apikey=" + Cadenas.PublicKey + "&hash=" + hash;
        }

        /// <summary>
        /// Obtiene el HASH(MD5) del TimeStamp , PrivateKey y la PublicKey.
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private string GetHash(string timestamp)
        {
            var combined = timestamp + Cadenas.PrivateKey + Cadenas.PublicKey;
            var bytes = Encoding.UTF8.GetBytes(combined);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes);
            var converted = BitConverter.ToString(hash);

            return converted.Replace("-", string.Empty).ToLower();
        }

        /// <summary>
        /// Obtiene el TimeStamp de el dia de hoy.
        /// </summary>
        /// <returns></returns>
        private static string GetTimestamp()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = DateTime.UtcNow - origin;

            return Math.Floor(diff.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }
    }
}
