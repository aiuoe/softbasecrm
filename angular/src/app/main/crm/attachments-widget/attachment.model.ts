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
