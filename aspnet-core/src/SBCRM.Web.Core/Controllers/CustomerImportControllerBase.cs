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

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// Customers Controller to manage specific methods as endpoints
    /// </summary>
    public abstract class CustomerImportControllerBase : SBCRMControllerBase
    {
        private ICustomerAttachmentsAppService _customerAttachmentsAppService;
        private readonly IHostEnvironment _env;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerAttachmentAppService"></param>
        /// <param name="env"></param>
        public CustomerImportControllerBase(
            ICustomerAttachmentsAppService customerAttachmentAppService,
            IHostEnvironment env)
        {
            _customerAttachmentsAppService = customerAttachmentAppService;
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

                var dir = Path.Combine(_env.ContentRootPath, "Attachments");
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
                await attachment.CopyToAsync(new FileStream(filePath, FileMode.Create));
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
            var attachments = await _customerAttachmentsAppService.GetCustomerAttachmentForView(5);

            var dir = Path.Combine(_env.ContentRootPath, "Attachments");
            var path = Path.Combine(dir, filePath);
            if (System.IO.File.Exists(path))
            {
                var memory = new MemoryStream();
                using var stream = new FileStream(filePath, FileMode.Open);
                await stream.CopyToAsync(memory);
                memory.Position = 0;
                return File(memory, MimeTypes.GetMimeType(filePath), filePath);
            }
            throw new Exception();
        }
    }
}
