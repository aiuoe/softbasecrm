import { ActivityDuration } from '@shared/AppEnums';

/**
 * Used for listing the Activity duration items
 */
export class ActivityDurationItemDto {
    text: string;
    value: number;
    enumValue: ActivityDuration;

    /**
     * Constructor method
     * @param text - The text to display in the UI
     * @param value - The value of this duration
     * @param enumValue - The equivalent ActivityDuration enum value of this object
     */
    constructor(text: string, value: number, enumValue: ActivityDuration) {
        this.text = text;
        this.value = value;
        this.enumValue = enumValue;
    }
}
