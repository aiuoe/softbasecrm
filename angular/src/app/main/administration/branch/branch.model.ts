export enum BrowseMode {
    Add = 1,
    View,
    Edit
}

export interface IActionButton {
    name: string;
    cssClass: string;
    iconClass?: string;
    isActive: (argument?: () => any) => boolean;
    action: (argument?: () => any) => void;
}