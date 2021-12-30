import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import * as moment from 'moment-timezone';
import { DateTime } from 'luxon';

/***
 * Pipe to manage timezone conversations on Dates
 */
@Pipe({
    name: 'momentFormat',
    pure: true
})
export class MomentFormatPipe extends DatePipe implements PipeTransform {
    constructor(@Inject(LOCALE_ID) locale: string) {
        super(locale);
    }

    /***
     * Transform the date to the given format
     * @param value
     * * @param format
     */
    transform(value: any, format?: string): any {
        const timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
        return moment.utc(<DateTime>(value).toUTC().toString()).tz(timeZone).format(format);
    }
}
