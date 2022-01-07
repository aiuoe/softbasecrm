using SBCRM.Crm;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Microsoft.Extensions.Hosting;
using System.IO;
using SBCRM.Crm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MimeKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// Customers Controller to manage specific methods as endpoints
    /// </summary>
    public abstract class CustomerImportControllerBase : SBCRMControllerBase
    {
        private ICustomerAttachmentsAppService _customerAttachmentsAppService;
        private readonly IHostEnvironment _env;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerAttachmentAppService"></param>
        /// <param name="env"></param>
        public CustomerImportControllerBase(
            ICustomerAttachmentsAppService customerAttachmentAppService,
            IHostEnvironment env,
            IConfiguration configuration)
        {
            _customerAttachmentsAppService = customerAttachmentAppService;
            _configuration = configuration;
            _env = env;
        }

        /// <summary>
        /// This method recieves an input file as a customer attachment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int?> UploadAttachments(CustomerAttachmentDto input)
        {
            var attachment = Request.Form.Files.First();
            var extension = Path.GetExtension(attachment.FileName);

            try
            {
                if (!(string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".doc", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".pdf", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }

                var path = _configuration["Configuration:AttachmentsFolder"];
                var dir = Path.Combine(path, "Accounts");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var dto = new CreateOrEditCustomerAttachmentDto
                {
                    Id = input.Id,
                    Name = input.Name,
                    FilePath = attachment.FileName,
                    CustomerNumber = input.CustomerNumber
                };

                var filePath = Path.Combine(dir, attachment.FileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await attachment.CopyToAsync(stream);
                await _customerAttachmentsAppService.CreateOrEdit(dto);

                return dto.Id;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new UserFriendlyException(L("ErrorUploadingMessage"));
            }
        }

        /// <summary>
        /// Downloads an exiting attachement
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<FileResult> GetAttachment(string filePath)
        {
            var dir = Path.Combine(_configuration["Configuration:AttachmentsFolder"], "Accounts");
            var path = Path.Combine(dir, filePath);
            if (System.IO.File.Exists(path))
            {
                var memory = new MemoryStream();
                using var stream = new FileStream(path, FileMode.Open);
                await stream.CopyToAsync(memory);
                memory.Position = 0;
                return File(memory, MimeTypes.GetMimeType(filePath), filePath);
            }
            throw new Exception();
        }
    }
}
