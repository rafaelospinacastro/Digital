import { Component } from '@angular/core';
import { Service } from './producto.service';

@Component({
  selector: 'Producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css'],
  providers: [Service]
})

export class ProductoComponent {
  dataSource: any;

  constructor(service: Service) { 
    this.dataSource = service.getProducto();

  }
}
