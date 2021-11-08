import { Component } from '@angular/core';
import { Service } from './cliente.service';

@Component({
  selector: 'Cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css'],
  providers: [Service]
})

export class ClienteComponent {
  dataSource: any;

  constructor(service: Service) { 
    this.dataSource = service.getCliente();

  }
}
