import { Injectable } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";

// Assign the URL of your actual data service to the variable below
const url:string = '/';
const dataSource:any = AspNetData.createStore({
      key: 'id', 
      loadUrl: url + 'api/Compras/Get',
      insertUrl: url + 'api/Compras/Post',
      updateUrl: url + 'api/Compras/Put',
      deleteUrl: url + 'api/Compras/Delete',
        onBeforeSend: function(method, ajaxOptions) {
          ajaxOptions.xhrFields = { withCredentials: true };
        }
      });



@Injectable()
export class Service { 
  getCompra() { return dataSource; }

}
