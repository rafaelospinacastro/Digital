import { Injectable } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";

// Assign the URL of your actual data service to the variable below
const url:string = '/';
const dataSource:any = AspNetData.createStore({
      key: 'id', 
      loadUrl: url + 'api/DetalleCompras/Get',
      insertUrl: url + 'api/DetalleCompras/Post',
      updateUrl: url + 'api/DetalleCompras/Put',
      deleteUrl: url + 'api/DetalleCompras/Delete',
        onBeforeSend: function(method, ajaxOptions) {
          ajaxOptions.xhrFields = { withCredentials: true };
        }
      });



@Injectable()
export class Service { 
  getDetalleCompra() { return dataSource; }

}
