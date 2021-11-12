import { Injectable } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";

// Assign the URL of your actual data service to the variable below
const url:string = '/';
const dataSource:any = AspNetData.createStore({
      key: 'Id', 
      loadUrl: url + 'api/Clientes/Get',
      insertUrl: url + 'api/Clientes/Post',
      updateUrl: url + 'api/Clientes/Put',
      deleteUrl: url + 'api/Clientes/Delete',
        onBeforeSend: function(method, ajaxOptions) {
          ajaxOptions.xhrFields = { withCredentials: true };
        }
      });



@Injectable()
export class Service { 
  getCliente() { return dataSource; }

}
