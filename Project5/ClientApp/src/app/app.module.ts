import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { ProductoComponent } from './producto/producto.component';
import { ClienteComponent } from './cliente/cliente.component';
import { CompraComponent } from './compra/compra.component';
import { DetalleCompraComponent } from './detalle-compra/detalle-compra.component';
import { CrearclienteComponent } from './crearcliente/crearcliente.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductoComponent,
    ClienteComponent,
    CompraComponent,
    DetalleCompraComponent,
    CrearclienteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'cliente', component: ClienteComponent },
      { path: 'producto', component: ProductoComponent },
      { path: 'compra', component: CompraComponent },
      { path: 'detalle-compra', component: DetalleCompraComponent },
      { path: 'crearcliente', component: CrearclienteComponent },
    ]),
    DxDataGridModule,
    DxFormModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
