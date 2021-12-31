import { Injectable } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { ActivityDuration } from '@shared/AppEnums';
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
}
