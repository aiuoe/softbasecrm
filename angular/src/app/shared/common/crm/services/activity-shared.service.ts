import { Injectable } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { ActivityDuration, ActivityTaskType } from '@shared/AppEnums';
import { ActivityActivityTaskTypeLookupTableDto, ActivityDto } from '@shared/service-proxies/service-proxies';
import { LocalizationService } from 'abp-ng2-module';
import { ActivityDurationItemDto } from '../dto/activity-duration-item.dto';

/***
 * Service for the Activity module
 */
@Injectable()
export class ActivitySharedService {
    /**
     * Constructor method
     */
    constructor(private _localizationService: LocalizationService) {}

    /**
     * Localize text
     * @param value - The key from localization file
     * @returns - The localized text
     */
    private localize(value: string): string {
        return this._localizationService.localize(value, AppConsts.localization.defaultLocalizationSourceName);
    }

    /**
     * Gets all the list needed for the durations of activities
     */
    getActivityDurationItems(): Array<ActivityDurationItemDto> {
        return [
            new ActivityDurationItemDto(this.localize('FifteenMinutes'), 15, ActivityDuration.FifteenMinutes),
            new ActivityDurationItemDto(this.localize('ThirtyMinutes'), 30, ActivityDuration.ThirtyMinutes),
            new ActivityDurationItemDto(this.localize('OneHour'), 60, ActivityDuration.OneHour),
            new ActivityDurationItemDto(this.localize('OneHourAndThirtyMinutes'), 90, ActivityDuration.OneHourAndThirtyMinutes),
            new ActivityDurationItemDto(this.localize('TwoHours'), 120, ActivityDuration.TwoHours),
        ];
    }

    /**
     * Gets the default duration item
     * @param activityTypeCode
     * @returns
     */
    getDefaultDuration(activityTypeCode: string) {
        let durationItems = this.getActivityDurationItems();
        if (activityTypeCode != ActivityTaskType.TODO_REMINDER && activityTypeCode != ActivityTaskType.EMAIL_REMINDER) {
            return durationItems.find((x) => x.enumValue === ActivityDuration.OneHour).value;
        } else {
            return 0;
        }
    }

    /**
     * Check whether an activity is a Reminder-Type or not.
     * @param activityTypes The list of all Activity Task Types
     * @param activity The ActivityDto you want to verify
     * @returns True if the Activity is a Reminder-type, otherwise False.
     */
    isReminderTypeActivity(activityTypes: ActivityActivityTaskTypeLookupTableDto[], activity: ActivityDto): boolean {
        if (!activityTypes || activityTypes.length === 0) {
            return false;
        }

        const ACTIVITY_TYPE_CODE = activityTypes.find((x) => x.id == activity.activityTaskTypeId)?.code || '';

        return (
            ACTIVITY_TYPE_CODE == ActivityTaskType.EMAIL_REMINDER ||
            ACTIVITY_TYPE_CODE == ActivityTaskType.TODO_REMINDER
        );
    }
}
