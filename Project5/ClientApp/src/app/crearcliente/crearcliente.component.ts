import { Component } from '@angular/core';
import { Service } from './crearcliente.service';

@Component({
  selector: 'crearcliente',
  templateUrl: './crearcliente.component.html',
  styleUrls: ['./crearcliente.component.css'],
  providers: [Service]
})

export class CrearclienteComponent {
  dataSource: any;

  constructor(service: Service) { 
    this.dataSource = service.getCliente();

  }
}
