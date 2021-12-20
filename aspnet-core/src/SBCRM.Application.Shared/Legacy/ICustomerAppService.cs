﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using SBCRM.Crm.Dtos;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle customer information
    /// </summary>
    public interface ICustomerAppService : IApplicationService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input);

        /// <summary>
        /// Get customer for view mode by number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber);

        /// <summary>
        /// Get customer for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);

        /// <summary>
        /// Create or edit customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditCustomerDto input);

        /// <summary>
        /// Get Customers for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input);

        /// <summary>
        /// Get Account type lookup
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown();

        /// <summary>
        /// Get Lead Source type lookup
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown();

        /// <summary>
        /// Get all Customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerInvoiceViewDto>> GetAllCustomerInvoices(GetAllCustomerInvoicesInput input);

        /// <summary>
        /// Get all Customer equipments
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerEquipmentViewDto>> GetAllCustomerEquipments(GetAllCustomerEquipmentInput input);

        /// <summary>
        /// Get all Customer WIP
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerWipViewDto>> GetAllCustomerWip(GetAllCustomerWipInput input);

        /// <summary>
        /// Check if exist customer by name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> CheckIfExistByName(string input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> ConvertFromLead(ConvertLeadToAccountDto input);
    }
}