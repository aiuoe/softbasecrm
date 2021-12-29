import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

/***
 * Service for global search component
 */
@Injectable()
export class GlobalSearchDataService {

    private globalSearchFilter = new BehaviorSubject<string>(null);
    globalSearch = this.globalSearchFilter.asObservable();

    updatedGlobalSearch(data: string) {
        this.globalSearchFilter.next(data);
    }
}
