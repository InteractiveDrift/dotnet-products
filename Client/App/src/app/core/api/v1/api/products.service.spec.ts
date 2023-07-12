import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ProductsService } from './products.service';
import { ProductDto } from '../model/productDto';

describe('ProductsService', () => {
  let service: ProductsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductsService]
    });

    service = TestBed.inject(ProductsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Make sure that there are no outstanding requests.
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve all products', () => {
    const dummyProducts: ProductDto[] = [
      {
        id: 1,
        name: 'Test Product 1',
        // Fill the rest properties for the product.
      },
      {
        id: 2,
        name: 'Test Product 2',
        // Fill the rest properties for the product.
      }
    ];

    service.apiProductsGet().subscribe(products => {
      expect(products.length).toBe(2);
      expect(products).toEqual(dummyProducts);
    });

    const req = httpMock.expectOne(`/api/Products`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyProducts);
  });

  it('should retrieve a single product', () => {
    const dummyProduct: ProductDto = {
      id: 1,
      name: 'Test Product',
      // Fill the rest properties for the product.
    };

    service.apiProductsIdGet(1).subscribe(product => {
      expect(product).toEqual(dummyProduct);
    });

    const req = httpMock.expectOne(`/api/Products/1`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyProduct);
  });

  // Similarly, you can create tests for postProduct, putProduct, and deleteProduct methods.
});
