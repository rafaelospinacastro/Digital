import { Component } from '@angular/core';
import { Service } from './compra.service';

@Component({
  selector: 'Compra',
  templateUrl: './compra.component.html',
  styleUrls: ['./compra.component.css'],
  providers: [Service]
})

export class CompraComponent {
  dataSource: any;

  constructor(service: Service) { 
    this.dataSource = service.getCompra();

  }
}
