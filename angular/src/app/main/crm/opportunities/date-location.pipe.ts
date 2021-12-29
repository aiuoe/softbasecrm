import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'dateLocation',
  pure: true
})
export class DateLocationPipe extends DatePipe implements PipeTransform {
  constructor(@Inject(LOCALE_ID) locale: string) {
    super(locale);
  }

  transform(value: any, format?: string, timezone?: string, locale?: string): any {
    return super.transform(value, format, timezone, locale)
  }
}