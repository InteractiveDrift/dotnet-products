import { AsyncPipe, DecimalPipe, NgFor, NgIf } from '@angular/common';
import { Component, QueryList, ViewChildren } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductListService } from './product-list.service';
import { ProductDto } from '../core/api/v1/model/productDto'
import { NgbdSortableHeader, SortEvent } from '../directives/sortable.directive';
import { FormsModule } from '@angular/forms';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-products-list',
	standalone: true,
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
	imports: [
		NgFor,
    DecimalPipe,
		FormsModule,
		AsyncPipe,
		NgbTypeaheadModule,
		NgIf,
    NgbPaginationModule,
    NgbdSortableHeader
	],
	providers: [ProductListService, DecimalPipe],
})
export class ProductListComponent {
	product$: Observable<ProductDto[]>;
	total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader> | undefined;

	constructor(public service: ProductListService) {
	  this.product$ = service.products$;
		this.total$ = service.total$;
	}

	onSort({ column, direction }: SortEvent) {
		// resetting other headers
		this.headers!.forEach((header) => {
			if (header.sortable !== column) {
				header.direction = '';
			}
		});

		this.service.sortColumn = column;
		this.service.sortDirection = direction;
	}
}

