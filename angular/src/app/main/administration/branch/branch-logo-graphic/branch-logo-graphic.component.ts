import { AfterViewInit, Component, ElementRef, EventEmitter, Injector, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch logo tab
 */
@Component({
    selector: 'branchLogoGraphic',
    templateUrl: './branch-logo-graphic.component.html',
})

export class BranchLogoGraphicComponent extends AppComponentBase implements OnInit, AfterViewInit, OnChanges {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;
    @Output() fileAndFileTypeChanged = new EventEmitter<any>();
    @Output() fileChanged = new EventEmitter<File>();
    imageSrc: string = null;
    saving: boolean = false;
    logoGraphicFile: any;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    ngOnInit() {
        // this.imageSrc = this.upsertBranchDto.image;        
    }
    ngAfterViewInit() {
        // this.imageSrc = this.upsertBranchDto.image;        
    }
    ngOnChanges() {
        this.imageSrc = this.upsertBranchDto.image;
    }
    logoGraphicClear() {
        this.imageSrc = null;
        this.upsertBranchDto.image = null;
    }

    onFileSelected(event) {
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
}