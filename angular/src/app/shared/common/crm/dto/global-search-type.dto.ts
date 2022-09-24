import { GlobalSearchCategory } from '@shared/service-proxies/service-proxies';

/***
 * DTO to map global search types
 */
export class GlobalSearchTypeDto {
    id: GlobalSearchCategory;
    name: string;
}
