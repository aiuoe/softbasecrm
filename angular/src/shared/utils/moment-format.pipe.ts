import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import * as moment from 'moment-timezone';
import { DateTime } from 'luxon';

@Pipe({
    name: 'momentFormat',
    pure: true
})
export class MomentFormatPipe extends DatePipe implements PipeTransform {
    constructor(@Inject(LOCALE_ID) locale: string) {
        super(locale);
    }

    transform(value: any, format?: string): any {
        const timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
        return moment.utc(<DateTime>(value).toUTC().toString()).tz(timeZone).format(format);
    }
}
