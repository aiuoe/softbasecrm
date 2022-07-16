using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SBCRM.Web.Common
{
    /// <summary>
    /// Methods extensions for IFormFile concerns
    /// </summary>
    public static class FormFileExtensions
    {
        /// <summary>
        /// This type of content is associated with NSWAG's limitation to make files optional/nullable in the frontend.
        /// </summary>
        public const string EmptyFieldContentType = "emptyfile";

        /// <summary>
        /// Get bytes from IFormFile using memory stream
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            if (formFile == null || EmptyFieldContentType.Equals(formFile.ContentType, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
