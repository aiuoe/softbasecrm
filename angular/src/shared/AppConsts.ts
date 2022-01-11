export class AppConsts {
    static readonly tenancyNamePlaceHolderInUrl = '{TENANCY_NAME}';

    static remoteServiceBaseUrl: string;
    static remoteServiceBaseUrlFormat: string;
    static appBaseUrl: string;
    static appBaseHref: string; // returns angular's base-href parameter value if used during the publish
    static appBaseUrlFormat: string;
    static recaptchaSiteKey: string;
    static subscriptionExpireNootifyDayCount: number;

    static localeMappings: any = [];

    static readonly userManagement = {
        defaultAdminUserName: 'admin',
    };

    static readonly localization = {
        defaultLocalizationSourceName: 'SBCRM',
    };

    static readonly authorization = {
        encrptedAuthTokenName: 'enc_auth_token',
    };

    static readonly grid = {
        defaultPageSize: 10,
    };

    static readonly MinimumUpgradePaymentAmount = 1;

    /// <summary>
    /// Gets current version of the application.
    /// It's also shown in the web page.
    /// </summary>
    static readonly WebAppGuiVersion = '10.5.0';

    static readonly SearchBarDelayMilliseconds = 500;
    static readonly All = 'All';
    static readonly None = 'None';
    static readonly Backspace = 'Backspace';
    static readonly UnitedStatesCountryCode = 'US';
    static readonly Account = 'Account';
    static readonly Lead = 'Lead';
    static readonly ViewMode = 'view';
    static readonly CreateOrEditMode = 'createoredit';

    static readonly activityModule = {
        noAssignedUserFilterId: -1,
    };

    /// <summary>
    /// Timer for the action result notify toast
    /// </summary>
    static readonly notifyToastTimer = 3000;
}
