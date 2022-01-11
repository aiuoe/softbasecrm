/**
 * A generic interface used to interact with the attachments widget
 */
export interface IAttachment {
    name: string;
    filePath: string;
    id: number | undefined;
}

/**
 * A customer attachment
 */
export class CustomerAttachment implements IAttachment {
    customerNumber: string;
    filePath: string;
    id: number | undefined;
    name: string;
}

/**
 * A customer attachment
 */
 export class LeadAttachment implements IAttachment {
    leadId: number;
    filePath: string;
    id: number | undefined;
    name: string;
}

/**
 * A opportunity attachment
 */
 export class OpportunityAttachment implements IAttachment {
    opportunityId: number;
    filePath: string;
    id: number | undefined;
    name: string;
}
