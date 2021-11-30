﻿using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.MultiTenancy.Payments.PayPal.Dto;

namespace SBCRM.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
