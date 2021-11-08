import { Injectable } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";

// Assign the URL of your actual data service to the variable below
const url:string = '/';
const dataSource:any = AspNetData.createStore({
      key: 'id', 
      loadUrl: url + 'api/Producto/Get',
      insertUrl: url + 'api/Producto/Post',
      updateUrl: url + 'api/Producto/Put',
      deleteUrl: url + 'api/Producto/Delete',
        onBeforeSend: function(method, ajaxOptions) {
          ajaxOptions.xhrFields = { withCredentials: true };
        }
      });



@Injectable()
export class Service { 
  getProducto() { return dataSource; }

}
