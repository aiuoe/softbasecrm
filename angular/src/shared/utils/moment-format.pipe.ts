import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import * as moment from 'moment-timezone';

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
        return moment.utc(value).tz(timeZone).format(format);
    }
}
