import { Component } from '@angular/core';
import { Service } from './detalle-compra.service';

@Component({
  selector: 'DetalleCompra',
  templateUrl: './detalle-compra.component.html',
  styleUrls: ['./detalle-compra.component.css'],
  providers: [Service]
})

export class DetalleCompraComponent {
  dataSource: any;

  constructor(service: Service) { 
    this.dataSource = service.getDetalleCompra();

  }
}
