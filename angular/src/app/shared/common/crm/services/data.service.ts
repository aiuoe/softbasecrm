import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class DataService {

    private globalSearchFilter = new BehaviorSubject<string>(null);
    globalSearch = this.globalSearchFilter.asObservable();

    updatedGlobalSearch(data: string) {
        this.globalSearchFilter.next(data);
    }
}
