import { Component, EventEmitter, Injector, Input, OnChanges, Output } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch logo tab
 */
@Component({
    selector: 'branchLogoGraphic',
    styleUrls: ['./branch-logo-graphic.component.scss'],
    templateUrl: './branch-logo-graphic.component.html',
})

export class BranchLogoGraphicComponent extends AppComponentBase implements OnChanges {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;
    @Output() fileChanged = new EventEmitter<File>();
    imageSrc: string = null;
    saving: boolean = false;

    /**
     * constructor
     */
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    /**
     * OnChanges
     */
    ngOnChanges() {
        this.imageSrc = this.upsertBranchDto.image;
    }

    /**
     * clear button on click action
     */
    clearOnClick(): void {
        this.clearLogoGraphic();
    }

    /**
     * file input on change action
     */
    fileOnChange(event: any): void {
        if (event.target.files && event.target.files[0]) {
            let file = event.target.files[0];
            this.fileChanged.emit(file);
            this.upsertBranchDto.logoFile = file.name;
            let fileReader = new FileReader();
            fileReader.onload = (event: any) => {
                this.imageSrc = fileReader.result as string;
            }
            fileReader.readAsDataURL(file);
        }
    }

    /**
     * clear logo graphic
     */
    private clearLogoGraphic(): void {
        this.imageSrc = null;
        this.upsertBranchDto.image = null;
        this.upsertBranchDto.logoFile = null;
        this.fileChanged.emit(null);
    }
}